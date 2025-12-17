using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MimeKit;

namespace Bai06
{
    public partial class FrmViewEmail : Form
    {
        private MailDetail _mail;
        string _password;

        public FrmViewEmail(MailDetail mail, string password)
        {
            InitializeComponent();
            _password = password;
            _mail = mail;

        }

        // ==============================
        // 1. Load nội dung email khi form mở
        // ==============================
        private async void FrmViewEmail_Load(object sender, EventArgs e)
        {
            await wvEmailContent.EnsureCoreWebView2Async(null);

            // Ép WebView2 sang Light Mode
            wvEmailContent.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
            wvEmailContent.CoreWebView2.Settings.IsStatusBarEnabled = true;
            wvEmailContent.CoreWebView2.Profile.PreferredColorScheme =
                Microsoft.Web.WebView2.Core.CoreWebView2PreferredColorScheme.Light;

            LoadMail();
        }

        // ==============================
        // 2. Hiển thị thông tin email lên giao diện
        // ==============================
        private void LoadMail()
        {
            this.Text = _mail.Subject;

            lblFrom.ForeColor = Color.Black;

            lblFrom.Text = $"From: {_mail.FromName} <{_mail.FromAddress}>";


            lblTo.Text = "To:  me";

            lblSubject.Text = _mail.Subject;
            lblDate.Text = "Date: " + _mail.Date;

            DisplayMailBody(_mail);
            ShowAttachmentsUI();
        }


        // ==============================
        // 3. Hiển thị nội dung email (HTML hoặc Text)
        // ==============================
        private void DisplayMailBody(MailDetail mail)
        {
            string html;

            if (!string.IsNullOrEmpty(mail.BodyHtml))
            {
                html = mail.BodyHtml;
            }
            else
            {
                html = System.Net.WebUtility.HtmlEncode(mail.BodyText ?? "");
            }

            wvEmailContent.NavigateToString(html);
        }

        // ==============================
        // 4. Hiển thị danh sách file đính kèm
        // ==============================
        private void ShowAttachmentsUI()
        {
            flowAttachments.Controls.Clear();

            foreach (var att in _mail.Attachments)
            {
                var chip = new Guna.UI2.WinForms.Guna2Button
                {
                    BorderRadius = 12,
                    AutoSize = false,
                    Height = 32,
                    FillColor = Color.White,
                    BorderColor = Color.Silver,
                    BorderThickness = 1,
                    ForeColor = Color.Black,
                    TextAlign = HorizontalAlignment.Left
                };

                string label = "📎 " + att.FileName;
                chip.Text = label;

                int textWidth = TextRenderer.MeasureText(label, chip.Font).Width;
                chip.Width = textWidth + 20;

                chip.Click += async (s, e) => await OpenAttachment(att);

                flowAttachments.Controls.Add(chip);
            }

            // Thêm nút "Save All Attachments"
            var btnSaveAll = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "💾 Save All Attachments",
                BorderRadius = 12,
                Height = 36,
                FillColor = Color.LightSteelBlue,
                ForeColor = Color.Black
            };
            btnSaveAll.Click += async (s, e) => await SaveAllAttachments();

            flowAttachments.Controls.Add(btnSaveAll);
        }

        // ==============================
        // 5. Mở file đính kèm bằng ứng dụng mặc định
        // ==============================
        private async Task OpenAttachment(MailAttachment att)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "EmailAttachments");
                Directory.CreateDirectory(tempPath);

                string filePath = Path.Combine(tempPath, att.FileName);
                await File.WriteAllBytesAsync(filePath, att.Data);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file đính kèm\n" + ex.Message);
            }
        }

        // ==============================
        // 6. Lưu tất cả file đính kèm vào thư mục người dùng chọn
        // ==============================
        private async Task SaveAllAttachments()
        {
            try
            {
                using var fbd = new FolderBrowserDialog
                {
                    Description = "Chọn thư mục để lưu tất cả file đính kèm"
                };

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = fbd.SelectedPath;

                    foreach (var att in _mail.Attachments)
                    {
                        string safeFileName = $"{Guid.NewGuid()}_{att.FileName}";
                        string filePath = Path.Combine(folderPath, safeFileName);

                        await File.WriteAllBytesAsync(filePath, att.Data);
                    }

                    MessageBox.Show("Đã lưu tất cả file đính kèm thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRely_Click(object sender, EventArgs e)
        {
            // Người gửi: chính bạn (tài khoản đang đăng nhập)
            string fromAddress = _mail.ToAddress;      // địa chỉ email của bạn
            string fromName = _mail.ToName;            // tên hiển thị thật của bạn
            string password = _password;               // mật khẩu đăng nhập
            // Người nhận: người gửi của mail gốc
            string toAddress = _mail.FromAddress;      // địa chỉ email của người gửi
            string toName = _mail.FromName;            // tên hiển thị của người gửi

            FrmSendEmail frmSend = new FrmSendEmail(
                "smtp.gmail.com", 465, true,
                fromAddress, fromName, password,
                toAddress, toName, true
            );
            frmSend.Show();
        }
    }
}
