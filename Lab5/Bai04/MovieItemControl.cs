using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai04
{
    // Trong MovieItemControl.cs
    public partial class MovieItemControl : UserControl
    {
        // Sự kiện cũ: Dùng để xem chi tiết trên WebView2
        public event EventHandler<string> MovieClicked;

        // SỰ KIỆN MỚI: Dùng để gọi Form Đặt Vé, truyền toàn bộ đối tượng Movie
        public event EventHandler<Movie> BookingRequested;

        // LƯU TRỮ đối tượng Movie (RẤT QUAN TRỌNG)
        private Movie _movieData;

        public MovieItemControl(Movie movie)
        {
            InitializeComponent();

            // 1. Lưu lại đối tượng Movie
            _movieData = movie;

            DisplayData(movie);

            // 2. Đăng ký sự kiện Click cho chức năng xem chi tiết
            this.Click += MovieItemControl_Click;
            pbPoster.Click += MovieItemControl_Click;
            lblTitle.Click += MovieItemControl_Click; // Đăng ký thêm label title

            // 3. Đăng ký sự kiện Click cho nút Đặt Vé (btnBookTicket sẽ được thêm ở Designer)
            btnBookTicket.Click += BtnBookTicket_Click;
        }

        private void DisplayData(Movie movie)
        {
            lblTitle.Text = movie.Title;
            lblUrl.Text = movie.DetailUrl;

            // Hiển thị thông tin vé bán
            lblTicketInfo.Text = $"Đã bán: {movie.SoldTickets} / {movie.TotalTickets} vé";

            // Tải ảnh Poster
            try
            {
                // Sử dụng LoadAsync để không chặn UI Thread
                pbPoster.LoadAsync(movie.ImageUrl);
            }
            catch
            {
                // Xử lý lỗi tải ảnh
            }
        }

        // Xử lý sự kiện click để xem chi tiết (URL)
        private void MovieItemControl_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện và truyền DetailUrl
            MovieClicked?.Invoke(this, _movieData.DetailUrl);
        }

        // Xử lý sự kiện click nút Đặt Vé (Movie Object)
        private void BtnBookTicket_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện mới, truyền toàn bộ đối tượng Movie
            BookingRequested?.Invoke(this, _movieData);
        }
    }
}