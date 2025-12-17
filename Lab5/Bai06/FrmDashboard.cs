using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using MailKit;
using System.Drawing;
using Guna.UI2.WinForms;

namespace Bai06
{
    public partial class FrmDashboard : Form
    {
        // ==============================
        // 1. Khai báo biến toàn cục
        // ==============================
        private ImapClient _client;                 // Đối tượng kết nối IMAP
        private readonly object _imapLock = new();  // Khóa đồng bộ khi thao tác IMAP
        private string displayName;
        public FrmDashboard()
        {
            InitializeComponent();

        }

        // ==============================
        // 2. Xử lý sự kiện Đăng nhập
        // ==============================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap.Enabled = false;

            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string imapServer = txtIMAP.Text.Trim();

            int imapPort, smtpPort;

            // Kiểm tra Port IMAP
            if (!int.TryParse(cboPortIMAP.Text.Trim(), out imapPort))
            {
                MessageBox.Show("Vui lòng nhập Port IMAP hợp lệ.");
                btnDangNhap.Enabled = true;
                return;
            }

            // Kiểm tra Port SMTP
            if (!int.TryParse(cboPortSMTP.Text.Trim(), out smtpPort))
            {
                MessageBox.Show("Vui lòng nhập Port SMTP hợp lệ.");
                btnDangNhap.Enabled = true;
                return;
            }

            // Kiểm tra tài khoản/mật khẩu
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnDangNhap.Enabled = true;
                return;
            }

            // Thực hiện đăng nhập trên luồng nền
            Task.Run(() => PerformLogin(username, password, imapServer, imapPort));
        }

        // ==============================
        // 3. Hàm đăng nhập IMAP (có lấy displayName)
        // ==============================
        private async void PerformLogin(string user, string pass, string server, int port)
        {
            _client = new ImapClient();

            try
            {
                await _client.ConnectAsync(server, port, SecureSocketOptions.SslOnConnect);
                _client.AuthenticationMechanisms.Remove("XOAUTH2");
                await _client.AuthenticateAsync(user, pass);

                // Sau khi đăng nhập, lấy displayName thật
                var sent = _client.GetFolder(SpecialFolder.Sent);
                await sent.OpenAsync(FolderAccess.ReadOnly);

                var uids = await sent.SearchAsync(MailKit.Search.SearchQuery.All);
                if (uids.Count > 0)
                {
                    var lastUid = uids.Last();
                    var message = await sent.GetMessageAsync(lastUid);

                    var fromMailbox = message.From.Mailboxes.FirstOrDefault();
                    if (fromMailbox != null && !string.IsNullOrWhiteSpace(fromMailbox.Name))
                    {
                        displayName = fromMailbox.Name; // tên hiển thị thật
                    }
                }



                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Đăng nhập IMAP thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnDangNhap.Visible = false;
                    btnDangXuat.Visible = true;
                    btnRefresh.Visible = true;
                    btnGuiMail.Visible = true;

                    txtTaiKhoan.ReadOnly = true;
                    txtMatKhau.ReadOnly = true;
                    txtIMAP.Enabled = false;
                    txtSMTP.Enabled = false;
                    cboPortIMAP.Enabled = false;
                    cboPortSMTP.Enabled = false;

                    ShowLoading(true);
                    LoadEmails();
                    ShowLoading(false);
                });
            }
            catch (Exception ex)
            {
                if (_client.IsConnected)
                    _client.Disconnect(true);
                _client = null;

                ShowErrorMessage($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                this.Invoke((MethodInvoker)(() => btnDangNhap.Enabled = true));
            }
        }

        // ==============================
        // 4. Hàm hiển thị lỗi
        // ==============================
        private void ShowErrorMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(message, "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        // ==============================
        // 5. Tải danh sách email
        // ==============================
        private async void LoadEmails()
        {
            if (_client == null || !_client.IsConnected)
            {
                ShowErrorMessage("Lỗi: Không có kết nối IMAP.");
                return;
            }

            this.Invoke((MethodInvoker)delegate
            {
                dgvEmails.Rows.Clear();
                dgvEmails.Columns.Clear();

                dgvEmails.Columns.Add("#", "#");
                dgvEmails.Columns.Add("From", "From");
                dgvEmails.Columns.Add("Subject", "Subject");
                dgvEmails.Columns.Add("Date", "Datetime");
                dgvEmails.Columns.Add("UID", "UID");
                dgvEmails.Columns["UID"].Visible = false;
                dgvEmails.Columns.Add("IsSeen", "IsSeen");
                dgvEmails.Columns["IsSeen"].Visible = false;

                dgvEmails.Columns[0].Width = 30;
                dgvEmails.Columns[1].Width = 200;
                dgvEmails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEmails.Columns[3].Width = 120;
            });

            try
            {
                var inbox = _client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var uids = await inbox.SearchAsync(MailKit.Search.SearchQuery.All);
                var latestUids = uids.Skip(Math.Max(0, uids.Count() - 20)).ToList();

                var items = await inbox.FetchAsync(latestUids,
                    MessageSummaryItems.UniqueId |
                    MessageSummaryItems.Envelope |
                    MessageSummaryItems.InternalDate |
                    MessageSummaryItems.Flags);

                int rowIndex = 1;
                foreach (var item in items.Reverse())
                {
                    var mailbox = item.Envelope.From.Mailboxes.FirstOrDefault();
                    string from = mailbox != null
                        ? $"{mailbox.Name} <{mailbox.Address}>"
                        : "Unknown";

                    string subject = item.Envelope.Subject;
                    string date = item.InternalDate?.ToLocalTime().ToString("dd/MM/yyyy HH:mm") ?? "N/A";
                    bool isSeen = item.Flags.HasValue && item.Flags.Value.HasFlag(MessageFlags.Seen);

                    this.Invoke((MethodInvoker)delegate
                    {
                        dgvEmails.Rows.Add(rowIndex, from, subject, date, item.UniqueId.ToString(), isSeen);
                    });
                    rowIndex++;
                }

                await inbox.CloseAsync(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi tải email: {ex.Message}");
            }
        }

        // ==============================
        // 6. Định dạng font cho email đã đọc/chưa đọc
        // ==============================
        private void dgvEmails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEmails.Rows.Count) return;
            if (dgvEmails.Font == null) return;

            try
            {
                object isSeenValue = dgvEmails.Rows[e.RowIndex].Cells["IsSeen"].Value;
                if (isSeenValue != null && isSeenValue is bool isSeen)
                {
                    Font baseFont = dgvEmails.Font;
                    e.CellStyle.Font = new Font(baseFont, isSeen ? FontStyle.Regular : FontStyle.Bold);
                }
            }
            catch { }
        }

        // ==============================
        // 7. Đọc chi tiết email
        // ==============================
        private async Task<MailDetail> ReadMail(UniqueId uid)
        {
            try
            {
                var inbox = _client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var message = await inbox.GetMessageAsync(uid);

                var fromMailbox = message.From.Mailboxes.FirstOrDefault();
                var toMailbox = message.To.Mailboxes.FirstOrDefault();

                var detail = new MailDetail
                {
                    FromName = fromMailbox?.Name,
                    FromAddress = fromMailbox?.Address,
                    ToName = toMailbox?.Name,
                    ToAddress = toMailbox?.Address,
                    Subject = message.Subject,
                    Date = message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    BodyText = message.TextBody ?? "",
                    BodyHtml = message.HtmlBody ?? ""
                };

                // File đính kèm
                foreach (var part in message.Attachments)
                {
                    if (part is MimePart mimePart)
                    {
                        using var ms = new MemoryStream();
                        mimePart.Content.DecodeTo(ms);

                        detail.Attachments.Add(new MailAttachment
                        {
                            FileName = mimePart.FileName,
                            Data = ms.ToArray()
                        });
                    }
                }

                return detail;
            }
            catch
            {
                return null;
            }
        }



        // ==============================
        // 8. Double click để mở email
        // ==============================
        private async void dgvEmails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string uidText = dgvEmails.Rows[e.RowIndex].Cells["UID"].Value?.ToString();
            if (!UniqueId.TryParse(uidText, out UniqueId uid)) return;

            ShowLoading(true);
            var mail = await Task.Run(() => ReadMail(uid));
            ShowLoading(false);

            if (mail == null) return;

            FrmViewEmail frm = new FrmViewEmail(mail, txtMatKhau.Text.Trim());
            frm.Show();

            _ = Task.Run(() => MarkAsSeenAsync(uid));

            dgvEmails.Rows[e.RowIndex].Cells["IsSeen"].Value = true;
            dgvEmails.InvalidateRow(e.RowIndex);
        }

        // ==============================
        // 9. Đánh dấu email là đã đọc
        // ==============================
        private async Task MarkAsSeenAsync(UniqueId uid)
        {
            try
            {
                lock (_imapLock)
                {
                    if (_client == null || !_client.IsConnected)
                        return;
                }

                var inbox = _client.Inbox;

                lock (_imapLock)
                {
                    inbox.Open(FolderAccess.ReadWrite);
                    inbox.AddFlags(uid, MessageFlags.Seen, true);
                    inbox.Close();
                }
            }
            catch
            {
                // Bỏ qua lỗi nhỏ
            }
        }

        // ==============================
        // 10. Đăng xuất khỏi IMAP
        // ==============================
        private async Task LogoutAsync()
        {
            try
            {
                lock (_imapLock)
                {
                    if (_client == null) return;
                }

                if (_client.IsConnected)
                {
                    await _client.DisconnectAsync(true);
                }

                _client.Dispose();
                _client = null;

                // Cập nhật lại UI
                this.Invoke((MethodInvoker)delegate
                {
                    dgvEmails.Rows.Clear();

                    btnDangNhap.Visible = true;
                    btnDangXuat.Visible = false;
                    btnRefresh.Visible = false;
                    btnGuiMail.Visible = false;

                    txtTaiKhoan.ReadOnly = false;
                    txtMatKhau.ReadOnly = false;
                    txtIMAP.Enabled = true;
                    txtSMTP.Enabled = true;
                    cboPortIMAP.Enabled = true;
                    cboPortSMTP.Enabled = true;

                    MessageBox.Show("Đã đăng xuất thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng xuất: " + ex.Message);
            }
        }

        // ==============================
        // 11. Sự kiện click nút Đăng xuất
        // ==============================
        private async void btnDangXuat_Click(object sender, EventArgs e)
        {
            await LogoutAsync();
        }

        // ==============================
        // 12. Sự kiện click nút Gửi mail
        // ==============================
        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            string fromAddress = txtTaiKhoan.Text.Trim();   // địa chỉ email đăng nhập
            string fromName = displayName;                  // tên hiển thị (bạn gán khi đăng nhập)
            string password = txtMatKhau.Text.Trim();       // mật khẩu
            string server = txtSMTP.Text.Trim();            // SMTP server
            int port = int.Parse(cboPortSMTP.Text.Trim());  // SMTP port
            bool _useSsl = true;
            if (port == 587) _useSsl = false;

            // Mở form gửi mail, truyền đầy đủ thông tin người gửi
            FrmSendEmail frmSend = new FrmSendEmail(server, port, _useSsl,
                                        fromAddress, fromName, password,
                                        null, null, false);

            frmSend.Show();
        }

        // ==============================
        // 13. Hiển thị/ẩn loading indicator
        // ==============================
        private void ShowLoading(bool show)
        {
            loadingIndicator.Visible = show;
            if (show)
                loadingIndicator.Start();
            else
                loadingIndicator.Stop();
        }

        // ==============================
        // 14. Sự kiện click nút Refresh
        // ==============================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmails();
        }

        private void cboPortSMTP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
