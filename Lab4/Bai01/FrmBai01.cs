using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Bai01
{
    public partial class FrmBai01 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FrmBai01()
        {
            InitializeComponent();
        }


        private async Task<string> getHTMLAsync(string szURL)
        {
            try
            {
                // Nếu thiếu http:// hoặc https:// thì tự động thêm
                if (!szURL.StartsWith("http://") && !szURL.StartsWith("https://"))
                {
                    szURL = "http://" + szURL;
                }

                // Gửi request và nhận nội dung
                string responseFromServer = await _httpClient.GetStringAsync(szURL);
                return responseFromServer;
            }
            catch (Exception ex)
            {
                return "Lỗi khi tải trang: " + ex.Message;
            }
        }


        private async void btnGet_Click(object sender, EventArgs e)
        {
            string url = txtLink.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Gọi hàm getHTML và hiển thị kết quả
            string htmlContent = await getHTMLAsync(url);
            rtbHTLMCode.Text = htmlContent.Length > 10000
            ? htmlContent.Substring(0, 10000) + "...(truncated)"
            : htmlContent;
        }
    }
}
