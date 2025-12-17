using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Security;
using MimeKit;
using MailKit;

namespace Bai06
{
    public partial class FrmSendEmail : Form
    {
        private List<string> _attachments = new List<string>();

        private string _smtpServer;
        private int _smtpPort;
        private bool _useSsl;
        private string _fromAddress;
        private string _password;
        private string _toAddress;
        private string _toName;
        private string _fromName;
        private bool _isRely;

        public FrmSendEmail(string smtpServer, int smtpPort, bool useSsl,
                            string fromAddress, string fromName, string password,
                            string toAddress , string toName, bool isRely)
        {
            InitializeComponent();

            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _useSsl = useSsl;
            _fromAddress = fromAddress;
            _password = password;
            _toAddress = toAddress;
            _toName = toName;
            _fromName = fromName;
            _isRely = isRely;

            // Điền sẵn vào textbox
            txtFrom.Text = _fromAddress;

            if (!string.IsNullOrEmpty(_toAddress))
                txtTo.Text = _toAddress;
        }
        // ==============================
        // 1. Chọn file đính kèm
        // ==============================
        private void btnAttach_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Chọn file đính kèm"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    _attachments.Add(file);

                    var chip = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = "📎 " + Path.GetFileName(file),
                        BorderRadius = 12,
                        Height = 32,
                        AutoSize = true
                    };
                    flowAttachments.Controls.Add(chip);
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_fromName, _fromAddress));
                message.To.Add(new MailboxAddress(_toName, txtTo.Text.Trim()));
                
                if(_isRely)
                    message.Subject = "Re: " + txtSubject.Text.Trim();
                else
                    message.Subject = txtSubject.Text;

                var builder = new BodyBuilder { TextBody = txtBody.Text };

                // Debug: kiểm tra danh sách file
                MessageBox.Show(string.Join("\n", _attachments), "Danh sách file đính kèm");

                foreach (var file in _attachments)
                {
                    if (File.Exists(file))
                    {
                        builder.Attachments.Add(file);
                    }
                }

                message.Body = builder.ToMessageBody();

                using var client = new MailKit.Net.Smtp.SmtpClient();
                // 1) Kết nối theo cờ _useSsl
                if (_useSsl)
                {
                    // Thường dành cho port 465
                    await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.SslOnConnect);
                }
                else
                {
                    // Dùng STARTTLS nếu server hỗ trợ (port 587)
                    await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTlsWhenAvailable);
                }


                await client.AuthenticateAsync(_fromAddress, _password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                MessageBox.Show("Gửi email thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }

    }
}
    
