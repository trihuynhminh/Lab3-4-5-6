using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class FrmBai02 : Form
    {
        public FrmBai02()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng nhập URL và đường dẫn file!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu thiếu http/https thì thêm http://
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Tải nội dung HTML về string
                    string htmlContent = await client.GetStringAsync(url);

                    // Lấy thư mục từ đường dẫn file
                    string? folderPath = Path.GetDirectoryName(filePath);

                    // Nếu không có thư mục (chỉ nhập tên file), mặc định lưu ở thư mục hiện tại
                    if (string.IsNullOrEmpty(folderPath))
                    {
                        folderPath = Environment.CurrentDirectory;
                        filePath = Path.Combine(folderPath, filePath);
                    }

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Ghi ra file
                    await File.WriteAllTextAsync(filePath, htmlContent);
                }

                MessageBox.Show("Download thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hiển thị bằng WebView2
                await webViewMain.EnsureCoreWebView2Async();

                // Chuyển đường dẫn file sang URI hợp lệ
                string fileUri = new Uri(Path.GetFullPath(filePath)).AbsoluteUri;
                webViewMain.CoreWebView2.Navigate(fileUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
