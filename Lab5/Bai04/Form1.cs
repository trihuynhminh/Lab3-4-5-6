// Trong file Form1.cs

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Cần cho FirstOrDefault
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
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
            await webViewDetails.EnsureCoreWebView2Async(null);
            await LoadAndDisplayMovies();
        }

        // --- Hàm Trích xuất Dữ liệu (ScrapeMovies) ---
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

                    var movieContainers = doc.DocumentNode.SelectNodes("//div[@id='tab-1']//div[contains(@class, 'col-lg-4') and contains(@class, 'padding-bottom-30')]");

                    // Tải dữ liệu JSON đã lưu (nếu có) để giữ lại SoldTickets
                    var savedMovies = LoadJsonFile("movies.json");

                    if (movieContainers != null)
                    {
                        int totalItems = movieContainers.Count;
                        int progressIncrement = (totalItems > 0) ? (40 / totalItems) : 1;

                        foreach (var container in movieContainers)
                        {
                            var linkNode = container.SelectSingleNode(".//h3/a");
                            string detailUrl = linkNode?.GetAttributeValue("href", string.Empty);
                            string title = linkNode?.InnerText?.Trim() ?? "Không có tiêu đề";
                            var imgNode = container.SelectSingleNode(".//img");
                            string imageUrl = imgNode?.GetAttributeValue("src", string.Empty);

                            // Chuẩn hóa URL tuyệt đối
                            if (!string.IsNullOrEmpty(detailUrl) && detailUrl.StartsWith("/chi-tiet-phim.htm"))
                            {
                                detailUrl = new Uri(new Uri(url), detailUrl).AbsoluteUri;
                            }
                            if (!string.IsNullOrEmpty(imageUrl) && imageUrl.StartsWith("/"))
                            {
                                imageUrl = new Uri(new Uri(url), imageUrl).AbsoluteUri;
                            }

                            // TẠO OBJECT PHIM MỚI VÀ GÁN SUẤT CHIẾU MẪU
                            Movie newMovie = new Movie
                            {
                                Title = title,
                                ImageUrl = imageUrl,
                                DetailUrl = detailUrl,

                                // GÁN DỮ LIỆU SUẤT CHIẾU MẪU (Cho mục đích kiểm thử BookingForm)
                                AvailableShowtimes = GetSampleShowtimes(title)
                            };

                            // KIỂM TRA & CẬP NHẬT: Nếu phim đã tồn tại, dùng ID và SoldTickets/TotalTickets cũ
                            var existingMovie = savedMovies.FirstOrDefault(m => m.Title == newMovie.Title);
                            if (existingMovie != null)
                            {
                                newMovie.Id = existingMovie.Id;
                                newMovie.SoldTickets = existingMovie.SoldTickets;
                                newMovie.TotalTickets = existingMovie.TotalTickets;
                            }

                            movieList.Add(newMovie);
                            progressBar1.Value += progressIncrement;
                            if (progressBar1.Value > 95) progressBar1.Value = 95;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phim nào đang chiếu trên trang web.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi trích xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Value = 100;
            return movieList;
        }

        // --- HÀM HỖ TRỢ: TẠO SUẤT CHIẾU MẪU ---
        private List<ShowtimeOption> GetSampleShowtimes(string title)
        {
            // Tối ưu hóa giá/phòng chiếu dựa trên tên phim (ví dụ)
            decimal basePrice = 80000;
            if (title.ToLower().Contains("vip") || title.ToLower().Contains("đặc biệt"))
                basePrice = 100000;

            return new List<ShowtimeOption>
            {
                new ShowtimeOption { Time = "10:00", ScreenName = "Standard 1", AdjustedPrice = basePrice },
                new ShowtimeOption { Time = "14:30", ScreenName = "VIP 2", AdjustedPrice = basePrice + 20000 },
                new ShowtimeOption { Time = "19:00", ScreenName = "Standard 3", AdjustedPrice = basePrice + 10000 }
            };
        }

        private async Task LoadAndDisplayMovies()
        {
            _movieList = await ScrapeMovies(BaseUrl);
            SaveToJson(_movieList, "movies.json");
            DisplayMovies(_movieList);
        }

        private void SaveToJson(List<Movie> movies, string fileName)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(movies, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi file {fileName}: {ex.Message}", "Lỗi");
            }
        }

        private List<Movie> LoadJsonFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    return JsonSerializer.Deserialize<List<Movie>>(jsonString);
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi nếu file không đọc được, trả về danh sách trống
            }
            return new List<Movie>();
        }

        private void DisplayMovies(List<Movie> movies)
        {
            flpMovieList.Controls.Clear();

            foreach (var movie in movies)
            {
                var movieControl = new MovieItemControl(movie);

                movieControl.MovieClicked += MovieControl_MovieClicked;
                movieControl.BookingRequested += MovieControl_BookingRequested;

                flpMovieList.Controls.Add(movieControl);
            }
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

        // --- HÀM XỬ LÝ ĐẶT VÉ (GỌI BOOKING FORM) ---
        private void MovieControl_BookingRequested(object sender, Movie selectedMovie)
        {
            // Mở Form Đặt Vé và truyền đối tượng Movie vào
            BookingForm bookingForm = new BookingForm(selectedMovie);
            bookingForm.ShowDialog();

            // SAU KHI BOOKINGFORM ĐÓNG LẠI:
            // Gọi lại LoadAndDisplayMovies để tải lại dữ liệu từ movies.json (đã được BookingForm cập nhật)
            LoadAndDisplayMovies();
        }
    }
}