using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class FrmBai06 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public FrmBai06()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Token lấy từ bài 5
                string tokenType = "Bearer";
                string accessToken = txtToken.Text;

                // Thêm Authorization header
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);

                // Gửi GET request
                var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
                var getUserResponse = await client.GetAsync(getUserUrl);

                getUserResponse.EnsureSuccessStatusCode();

                // Đọc dữ liệu JSON trả về
                var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

                // Parse JSON từ API
                JObject userJson = JObject.Parse(getUserResponseString);

                // Tạo chuỗi thông tin
                string userInfo = "";
                userInfo += "Tên: " + userJson["name"]?.ToString() + Environment.NewLine;
                userInfo += "Email: " + userJson["email"]?.ToString() + Environment.NewLine;
                userInfo += "ID: " + userJson["id"]?.ToString() + Environment.NewLine;

                // Nếu có thêm các trường khác thì nối tiếp
                userInfo += "Username: " + userJson["username"]?.ToString() + Environment.NewLine;
                userInfo += "Phone: " + userJson["phone"]?.ToString() + Environment.NewLine;
                userInfo += "Role: " + userJson["role"]?.ToString() + Environment.NewLine;

                // Hiển thị trong RichTextBox
                rtbUserInfo.Text = userInfo;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
