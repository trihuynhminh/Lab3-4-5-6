using System.Net;
using System.Net.Mail;


namespace Bai01
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();        // tài khoản Gmail
            string password = txtPassword.Text.Trim();  // App password
            string to = txtTo.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string body = rtbBody.Text.Trim();

            MailMessage mail = new MailMessage(email, to, subject, body);
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential(email, password);
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
