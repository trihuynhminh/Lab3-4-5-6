// Trong file Form1.cs

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    // Đảm bảo Form1 được khai báo trong namespace của project
    public partial class Form1 : Form
    {
        private const string BaseUrl = "https://betacinemas.vn/phim.htm";
        private List<Movie> _movieList = new List<Movie>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Đảm bảo WebView2 đã được khởi tạo
            await webViewDetails.EnsureCoreWebView2Async(null);
            await LoadAndDisplayMovies();
        }

        // --- Hàm Trích xuất Dữ liệu (Đã sửa lỗi Selector) ---
        private async Task<List<Movie>> ScrapeMovies(string url)
        {
            var movieList = new List<Movie>();
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            try
            {
                using (var client = new HttpClient())
                {
                    progressBar1.Value = 10;
                    string html = await client.GetStringAsync(url);
                    progressBar1.Value = 30;

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    progressBar1.Value = 50;

                    // SỬA LỖI TẠI ĐÂY: Sử dụng selector dựa trên cấu trúc HTML bạn cung cấp
                    // Container của các bộ phim nằm trong thẻ DIV có class col-lg-4, và nó nằm trong #tab-1
                    var movieContainers = doc.DocumentNode.SelectNodes("//div[@id='tab-1']//div[contains(@class, 'col-lg-4') and contains(@class, 'padding-bottom-30')]");

                    if (movieContainers != null)
                    {
                        int totalItems = movieContainers.Count;
                        int progressIncrement = (totalItems > 0) ? (40 / totalItems) : 1; // 40% cho vòng lặp

                        foreach (var container in movieContainers)
                        {
                            // 1. Trích xuất Detail URL và Title
                            // Link và Title nằm trong thẻ <a> bên trong <h3>
                            var linkNode = container.SelectSingleNode(".//h3/a");
                            string detailUrl = linkNode?.GetAttributeValue("href", string.Empty);
                            // Lấy Title từ InnerText của thẻ <a>
                            string title = linkNode?.InnerText?.Trim() ?? "Không có tiêu đề";

                            // 2. Trích xuất Image URL (Nằm trong thẻ <img>)
                            var imgNode = container.SelectSingleNode(".//img");
                            string imageUrl = imgNode?.GetAttributeValue("src", string.Empty);

                            // 3. Chuẩn hóa URL tuyệt đối
                            if (!string.IsNullOrEmpty(detailUrl) && detailUrl.StartsWith("/chi-tiet-phim.htm"))
                            {
                                detailUrl = new Uri(new Uri(url), detailUrl).AbsoluteUri;
                            }
                            // Áp dụng cho Image URL nếu nó là tương đối
                            if (!string.IsNullOrEmpty(imageUrl) && imageUrl.StartsWith("/"))
                            {
                                imageUrl = new Uri(new Uri(url), imageUrl).AbsoluteUri;
                            }

                            // Ghi đè Title nếu alt của ảnh có giá trị (tùy chọn)
                            if (string.IsNullOrEmpty(title) && imgNode != null)
                            {
                                title = imgNode.GetAttributeValue("alt", string.Empty) ?? "Không có tiêu đề";
                            }


                            movieList.Add(new Movie
                            {
                                Title = title,
                                ImageUrl = imageUrl,
                                DetailUrl = detailUrl
                            });

                            progressBar1.Value += progressIncrement;
                            if (progressBar1.Value > 95) progressBar1.Value = 95;
                        }
                    }
                    else
                    {
                        // Nếu không tìm thấy phim nào, giữ nguyên progress
                        // Thường xảy ra khi trang web không có phim nào đang chiếu
                        MessageBox.Show("Không tìm thấy phim nào đang chiếu trên trang web.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có lỗi mạng hoặc lỗi nghiêm trọng
                MessageBox.Show("Lỗi khi trích xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Value = 100;
            return movieList;
        }

        private async Task LoadAndDisplayMovies()
        {
            _movieList = await ScrapeMovies(BaseUrl);
            SaveToJson(_movieList, "movies.json");
            DisplayMovies(_movieList);
        }

        private void SaveToJson(List<Movie> movies, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(movies, options);
            File.WriteAllText(fileName, jsonString);
        }

        private void DisplayMovies(List<Movie> movies)
        {
            flpMovieList.Controls.Clear();

            foreach (var movie in movies)
            {
                var movieControl = new MovieItemControl(movie);
                movieControl.MovieClicked += MovieControl_MovieClicked;
                flpMovieList.Controls.Add(movieControl);
            }
            // Ẩn ProgressBar sau khi hiển thị xong (tùy chọn, nếu bạn muốn nó biến mất)
            // progressBar1.Visible = false;
        }

        private void MovieControl_MovieClicked(object sender, string detailUrl)
        {
            if (!string.IsNullOrEmpty(detailUrl))
            {
                try
                {
                    webViewDetails.Source = new Uri(detailUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy cập chi tiết phim: " + ex.Message, "Lỗi");
                }
            }
        }
    }
}