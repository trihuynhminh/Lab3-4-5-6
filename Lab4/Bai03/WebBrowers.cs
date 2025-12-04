using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using HtmlAgilityPack;
using System.IO;

namespace Bai03
{
    public partial class WebBrowers : Form
    {
        public WebBrowers()
        {
            InitializeComponent();
        }

        // Trong file Form1.cs

        // 1. Load Website
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            if (!string.IsNullOrEmpty(url))
            {
                // Đảm bảo URL có tiền tố http/https
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                try
                {
                    // Tải nội dung website vào WebView2
                    webView.Source = new Uri(url);
                }
                catch (UriFormatException ex)
                {
                    MessageBox.Show("URL không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Reload Website
        private void btnReload_Click(object sender, EventArgs e)
        {
            // Tải lại trang hiện tại
            webView.Reload();
        }

        // Trong file Form1.cs
        private async void btnDownHTML_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Tải mã nguồn HTML thô
                using (HttpClient client = new HttpClient())
                {
                    // Thiết lập user agent để tránh bị từ chối truy cập từ một số server
                    client.DefaultRequestHeaders.Add("User-Agent", "BasicWebBrowser/1.0");
                    string htmlContent = await client.GetStringAsync(url);

                    // 2. Hiển thị mã nguồn trong Form mới
                    SourceCodeForm sourceForm = new SourceCodeForm(htmlContent);
                    sourceForm.Show();

                    // Tùy chọn: Lưu file HTML vào ổ đĩa
                    // System.IO.File.WriteAllText("index.html", htmlContent);
                    // MessageBox.Show("Đã tải file index.html thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hoặc hiển thị mã nguồn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDownResources_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Tải mã nguồn HTML
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "BasicWebBrowser/1.0");
                    string htmlContent = await client.GetStringAsync(url);

                    // 2. Phân tích HTML bằng HtmlAgilityPack
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    // 3. Trích xuất tất cả các thẻ <img>
                    var imageNodes = doc.DocumentNode.SelectNodes("//img");

                    if (imageNodes == null || imageNodes.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hình ảnh nào.", "Thông báo");
                        return;
                    }

                    // Tạo thư mục để lưu ảnh
                    string downloadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloaded_Images");
                    Directory.CreateDirectory(downloadFolder);

                    int downloadCount = 0;
                    Uri baseUri = new Uri(url);

                    foreach (var img in imageNodes)
                    {
                        string src = img.GetAttributeValue("src", string.Empty);

                        if (!string.IsNullOrEmpty(src))
                        {
                            // Chuyển đổi URL tương đối thành tuyệt đối (ví dụ: /images/logo.png -> https://uit.edu.vn/images/logo.png)
                            Uri imageUri = new Uri(baseUri, src);

                            // Lấy tên file
                            string fileName = Path.GetFileName(imageUri.LocalPath);
                            if (string.IsNullOrEmpty(fileName) || fileName.Length > 50)
                            {
                                // Đảm bảo tên file hợp lệ (đối với những URL phức tạp)
                                fileName = $"image_{Guid.NewGuid().ToString().Substring(0, 8)}{Path.GetExtension(imageUri.LocalPath)}";
                            }

                            string fullPath = Path.Combine(downloadFolder, fileName);

                            // 4. Tải file ảnh
                            byte[] imageBytes = await client.GetByteArrayAsync(imageUri);
                            File.WriteAllBytes(fullPath, imageBytes);
                            downloadCount++;
                        }
                    }

                    MessageBox.Show($"Hoàn tất! Đã tải xuống {downloadCount} hình ảnh vào thư mục:\n{downloadFolder}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Resources: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
