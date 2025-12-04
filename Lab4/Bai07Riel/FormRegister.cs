using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bai7Riel
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Kiểm tra sơ bộ
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!");
                return;
            }

            // Tạo Object dữ liệu chuẩn theo API
            var regData = new
            {
                username = txtUser.Text,
                password = txtPass.Text,
                email = txtEmail.Text,
                first_name = txtFirstName.Text,
                last_name = txtLastName.Text,
                phone = txtPhone.Text,
                sex = 1, // Mặc định Nam (1) cho nhanh
                birthday = dtpDob.Value.ToString("yyyy-MM-dd"), // Format chuẩn
                language = "vi"
            };

            try
            {
                using (var client = new HttpClient())
                {
                    var jsonBody = JsonConvert.SerializeObject(regData);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // Gọi API Đăng ký
                    var res = await client.PostAsync("https://nt106.uitiot.vn/api/v1/user/signup", content);
                    var responseString = await res.Content.ReadAsStringAsync();

                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("✅ Đăng ký thành công!\nHãy quay lại đăng nhập.", "Thông báo");
                        this.Close(); // Đóng form đăng ký
                    }
                    else
                    {
                        // Hiển thị lỗi chi tiết từ Server để m biết sai chỗ nào
                        MessageBox.Show($"❌ Đăng ký thất bại:\n{responseString}", "Lỗi Server");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

    }
}