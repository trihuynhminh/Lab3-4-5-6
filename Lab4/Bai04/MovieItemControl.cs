using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    // Trong MovieItemControl.cs
    public partial class MovieItemControl : UserControl
    {
        public event EventHandler<string> MovieClicked; // Sự kiện khi click vào phim

        public MovieItemControl(Movie movie)
        {
            InitializeComponent();
            DisplayData(movie);

            // Đăng ký sự kiện Click cho toàn bộ Control hoặc Poster/Title
            this.Click += MovieItemControl_Click;
            // Phải đăng ký cho cả các control con để sự kiện được kích hoạt
            pbPoster.Click += MovieItemControl_Click;
        }

        private void DisplayData(Movie movie)
        {
            lblTitle.Text = movie.Title;
            lblUrl.Text = movie.DetailUrl;

            // Tải ảnh Poster (cần sử dụng thư viện tải ảnh như WebClient hoặc HttpClient)
            // Ví dụ đơn giản:
            try
            {
                pbPoster.Load(movie.ImageUrl);
            }
            catch
            {
                // Xử lý lỗi tải ảnh nếu có
            }
        }

        private void MovieItemControl_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện và truyền DetailUrl
            MovieClicked?.Invoke(this, lblUrl.Text);
        }
    }
}
