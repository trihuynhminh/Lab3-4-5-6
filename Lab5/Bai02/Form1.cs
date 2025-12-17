using System;
using System.Collections.Generic;
using System.ComponentModel;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Bai02 // Bạn có thể đổi tên namespace thành Bai02 nếu muốn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string appPassword = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(appPassword))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu Ứng dụng.", "Thiếu thông tin");
                return;
            }

            // Gọi trực tiếp hàm xử lý IMAP theo yêu cầu Bài 2
            LoadEmails_IMAP(email, appPassword);
        }

        // =========================================================
        //                 HÀM ĐỌC MAIL BẰNG IMAP (Bài 2)
        // =========================================================
        private void LoadEmails_IMAP(string email, string appPassword)
        {
            // Các thông số cấu hình IMAP cho Gmail
            string imapHost = "imap.gmail.com";
            int imapPort = 993;
            lvEmails.Items.Clear();

            // Khởi tạo client IMAP từ thư viện MailKit
            using (var client = new ImapClient())
            {
                try
                {
                    // Kết nối và xác thực với máy chủ
                    client.Connect(imapHost, imapPort, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(email, appPassword);

                    // Truy cập vào Inbox
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // Cập nhật thông tin tổng số thư và thư mới
                    lblTotal.Text = $"Total: {inbox.Count}";
                    lblRecent.Text = $"Recent: {inbox.Recent}";

                    // Giới hạn hiển thị 20 mail gần nhất để tối ưu tốc độ
                    int limit = Math.Min(inbox.Count, 20);

                    // Duyệt ngược từ mail mới nhất về cũ
                    for (int i = inbox.Count - 1; i >= inbox.Count - limit; i--)
                    {
                        var message = inbox.GetMessage(i);

                        // Hiển thị dữ liệu lên ListView
                        var item = new ListViewItem(message.Subject); // Chủ đề
                        item.SubItems.Add(message.From.ToString());   // Người gửi
                        item.SubItems.Add(message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")); // Thời gian
                        lvEmails.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
                catch (MailKit.Security.AuthenticationException)
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra Email và App Password.", "Lỗi Xác Thực");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi kết nối IMAP: {ex.Message}", "Lỗi Kết Nối");
                }
            }
        }
    }
}
