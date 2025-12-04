using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; // Cần thiết để xử lý JSON

namespace Lab4.Bai5 // Đảm bảo đúng Namespace của m
{
    public partial class Form5 : Form
    {
        // Hằng số chứa địa chỉ API đăng nhập
        private const string LOGIN_URL = "https://nt106.uitiot.vn/auth/token";

        public Form5()
        {
            // Hàm khởi tạo các Control trên giao diện (nằm trong Form5.Designer.cs)
            InitializeComponent();

            // Gắn sự kiện cho nút POST (sử dụng async/await)
            btnPOST.Click += async (s, e) => await HandleLogin();
        }

        /// <summary>
        /// Hàm xử lý logic đăng nhập bằng HTTP POST
        /// </summary>
        private async Task HandleLogin()
        {
            // Lấy thông tin từ giao diện
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                rtbResult.Text = "Username và Password không được để trống.";
                return;
            }

            rtbResult.Text = "Đang gửi yêu cầu đăng nhập...\n";

            try
            {
                // Tốt nhất là dùng using cho HttpClient
                using (var client = new HttpClient())
                {
                    // 1. Chuẩn bị nội dung POST dưới dạng form-data
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    // 2. Gửi yêu cầu POST không đồng bộ
                    HttpResponseMessage response = await client.PostAsync(LOGIN_URL, content);

                    // 3. Đọc nội dung phản hồi
                    string responseString = await response.Content.ReadAsStringAsync();

                    // 4. Phân tích chuỗi JSON
                    JObject responseObject = JObject.Parse(responseString);

                    // 5. Xử lý kết quả
                    if (response.IsSuccessStatusCode) // Đăng nhập thành công (200 OK)
                    {
                        string tokenType = responseObject["token_type"]?.ToString();
                        string accessToken = responseObject["access_token"]?.ToString();

                        rtbResult.Text = "✅ Đăng nhập thành công!\n\n";
                        rtbResult.Text += $"token_type: **{tokenType}**\n";
                        rtbResult.Text += $"access_token: **{accessToken}**";

                        // Lưu ý: M nên lưu token này (accessToken và tokenType) để dùng cho Bài 7.
                    }
                    else // Đăng nhập thất bại (Ví dụ: 401 Unauthorized)
                    {
                        string detail = responseObject["detail"]?.ToString() ?? "Lỗi không xác định.";

                        rtbResult.Text = $"❌ Đăng nhập thất bại (HTTP {response.StatusCode})\n";
                        rtbResult.Text += $"Thông báo lỗi: **{detail}**";
                    }
                }
            }
            catch (Exception ex)
            {
                rtbResult.Text = $"⚠️ Đã xảy ra lỗi: {ex.Message}";
            }
        }
    }
}