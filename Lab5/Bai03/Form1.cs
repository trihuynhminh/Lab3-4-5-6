using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Security;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Authentication;
using System.Windows.Forms;

// Lưu ý: Đảm bảo bạn đã cài đặt MailKit qua NuGet Package Manager

namespace Bai03 // Thay thế bằng Namespace của bạn
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
            string appPassword = txtPassword.Text; // Đây là Mật khẩu Ứng dụng

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(appPassword))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu Ứng dụng.", "Thiếu thông tin");
                return;
            }

            // Xử lý chọn giao thức
            if (rdoIMAP.Checked)
            {
                LoadEmails_IMAP(email, appPassword);
            }
            else if (rdoPOP3.Checked)
            {
                LoadEmails_POP3(email, appPassword);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giao thức (IMAP hoặc POP3).");
            }
        }

        // =========================================================
        //                 HÀM ĐỌC MAIL BẰNG IMAP (Bài 2)
        // =========================================================
        private void LoadEmails_IMAP(string email, string appPassword)
        {
            string imapHost = "imap.gmail.com";
            int imapPort = 993;
            lvEmails.Items.Clear();

            using (var client = new ImapClient())
            {
                try
                {
                    client.Connect(imapHost, imapPort, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(email, appPassword);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // CẬP NHẬT LABEL TOTAL VÀ RECENT
                    lblTotal.Text = $"Total: {inbox.Count}";
                    lblRecent.Text = $"Recent: {inbox.Recent}"; // Sử dụng thuộc tính Recent của MailKit
                                                                // KẾT THÚC CẬP NHẬT

                    int limit = Math.Min(inbox.Count, 20); // Chỉ hiển thị tối đa 20 mail gần nhất

                    // Duyệt ngược từ cuối danh sách (mail mới nhất)
                    for (int i = inbox.Count - 1; i >= inbox.Count - limit; i--)
                    {
                        // Lấy toàn bộ message (chứa đầy đủ Subject, From, Date)
                        var message = inbox.GetMessage(i);

                        var item = new ListViewItem(message.Subject);
                        item.SubItems.Add(message.From.ToString());
                        // Định dạng ngày giờ hiển thị
                        item.SubItems.Add(message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"));
                        lvEmails.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
                catch (MailKit.Security.AuthenticationException) // Đã được sửa để tránh lỗi Ambiguous
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra Email và App Password.", "Lỗi Xác Thực");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi kết nối IMAP: {ex.Message}", "Lỗi Kết Nối");
                }
            }
        }

        // =========================================================
        //                 HÀM ĐỌC MAIL BẰNG POP3 (Bài 3)
        // =========================================================
        private void LoadEmails_POP3(string email, string appPassword)
        {
            string popHost = "pop.gmail.com";
            int popPort = 995;
            lvEmails.Items.Clear();

            using (var client = new Pop3Client())
            {
                try
                {
                    client.Connect(popHost, popPort, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(email, appPassword);

                    int count = client.Count;

                    // CẬP NHẬT LABEL TOTAL VÀ RECENT
                    lblTotal.Text = $"Total: {count}";
                    lblRecent.Text = $"Recent: N/A"; // POP3 thường không cung cấp thông tin "Recent"
                    // KẾT THÚC CẬP NHẬT

                    int limit = Math.Min(count, 20); // Chỉ hiển thị tối đa 20 mail gần nhất

                    // Duyệt từ cuối danh sách (mail mới nhất)
                    for (int i = count - 1; i >= count - limit; i--)
                    {
                        // Lấy toàn bộ message 
                        var message = client.GetMessage(i);

                        var item = new ListViewItem(message.Subject);
                        item.SubItems.Add(message.From.ToString());
                        // Định dạng ngày giờ hiển thị
                        item.SubItems.Add(message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"));
                        lvEmails.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi kết nối POP3: {ex.Message}", "Lỗi Kết Nối");
                }
            }
        }
    }
}