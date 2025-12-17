// Trong file BookingForm.cs

using System;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Drawing; // Cần cho màu sắc Button
using System.Threading.Tasks; // Cần cho SendEmailAsync
using MimeKit; // Cần cho MimeMessage
using MailKit.Net.Smtp; // Cần cho SmtpClient
using AuthenticationException = MailKit.Security.AuthenticationException; // Giải quyết lỗi ambiguous

namespace Bai04
{
    public partial class BookingForm : Form
    {
        private Movie _selectedMovie;
        private ShowtimeOption _currentShowtime;
        private List<string> _selectedSeats = new List<string>(); // Danh sách ghế đang chọn

        // CẬP NHẬT: SỬA LỖI XÁC THỰC BẰNG CÁCH DÙNG THÔNG TIN THẬT (TỪ HÌNH ẢNH CŨ)
        // LƯU Ý: Nếu App Password này không còn hoạt động, bạn phải tạo cái mới.
        private const string SenderEmail = "babytran780@gmail.com";
        private const string SenderPassword = "oqkd ejkg oiyp tkfd"; // Giả định đây là App Password hợp lệ
        // ----------------------------------------------------------------------


        public BookingForm(Movie movie)
        {
            InitializeComponent();
            _selectedMovie = movie;

            // 1. Cấu hình ban đầu
            lblMovieTitle.Text = "ĐẶT VÉ: " + _selectedMovie.Title;
            this.Text = "Đặt vé: " + _selectedMovie.Title;

            // 2. Nạp dữ liệu Suất chiếu vào ComboBox
            cbShowtime.DataSource = _selectedMovie.AvailableShowtimes;
            cbShowtime.DisplayMember = "ToString";

            // 3. Thiết lập sự kiện
            cbShowtime.SelectedIndexChanged += CbShowtime_SelectedIndexChanged;
            btnBook.Click += BtnBook_Click;

            // Thiết lập trạng thái ban đầu
            if (_selectedMovie.AvailableShowtimes.Any())
            {
                _currentShowtime = cbShowtime.SelectedItem as ShowtimeOption;
            }
            SetupSeatLayout(); // Khởi tạo Layout ghế
            UpdateTotalAmount();
        }

        // Sự kiện khi suất chiếu thay đổi
        private void CbShowtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentShowtime = cbShowtime.SelectedItem as ShowtimeOption;
            _selectedSeats.Clear(); // Xóa chọn ghế khi đổi suất chiếu
            lblSelectedSeats.Text = "Ghế đã chọn: 0";
            SetupSeatLayout(); // Tải lại layout ghế (mô phỏng ghế đã bán cho suất chiếu đó)
            UpdateTotalAmount();
        }

        // --- HÀM 1: TẠO LAYOUT GHẾ VÀ XỬ LÝ CHỌN/HỦY CHỌN ---
        private void SetupSeatLayout()
        {
            flpSeats.Controls.Clear();
            int rows = 5; // A, B, C, D, E
            int cols = 10; // 1 - 10

            for (int i = 0; i < rows * cols; i++)
            {
                string seatName = $"{(char)('A' + (i / cols))}{((i % cols) + 1).ToString("D2")}"; // D01, D02...

                Button seatButton = new Button
                {
                    Text = seatName,
                    Name = $"Seat_{seatName}",
                    Size = new Size(45, 40),
                    Tag = seatName,
                    Margin = new Padding(3),
                    BackColor = Color.LightGray
                };

                // KIỂM TRA GHẾ ĐÃ BÁN (Dựa trên SoldSeats trong Movie.cs)
                if (_selectedMovie.SoldSeats.Contains(seatName))
                {
                    seatButton.BackColor = Color.Red; // Đã bán
                    seatButton.Enabled = false;
                }
                else
                {
                    seatButton.Click += SeatButton_Click;
                }

                flpSeats.Controls.Add(seatButton);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seat = btn.Tag.ToString();

            if (_selectedSeats.Contains(seat))
            {
                // Hủy chọn
                _selectedSeats.Remove(seat);
                btn.BackColor = Color.LightGray;
            }
            else
            {
                // Chọn
                _selectedSeats.Add(seat);
                btn.BackColor = Color.Yellow;
            }

            // Cập nhật hiển thị và Tổng tiền
            lblSelectedSeats.Text = $"Ghế đã chọn ({_selectedSeats.Count}): " + string.Join(", ", _selectedSeats.OrderBy(s => s));
            UpdateTotalAmount();
        }

        // --- HÀM 2: CẬP NHẬT TỔNG TIỀN ---
        private void UpdateTotalAmount()
        {
            if (_currentShowtime == null)
            {
                lblTotalAmount.Text = "TỔNG THANH TOÁN: 0 VNĐ";
                return;
            }

            int quantity = _selectedSeats.Count;
            decimal total = quantity * _currentShowtime.AdjustedPrice;

            lblTotalAmount.Text = string.Format("TỔNG THANH TOÁN: {0:N0} VNĐ", total);
            btnBook.Enabled = (quantity > 0);
        }

        // --- HÀM 3: XỬ LÝ ĐẶT VÉ VÀ GỬI EMAIL ---
        private async void BtnBook_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            string customerEmail = txtCustomerEmail.Text.Trim();
            int quantity = _selectedSeats.Count;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerEmail) || quantity == 0)
            {
                MessageBox.Show("Vui lòng nhập Tên, Email và chọn ít nhất một ghế.", "Cảnh báo");
                return;
            }

            // 1. Cập nhật dữ liệu phim (mô phỏng đặt chỗ thành công)
            _selectedMovie.SoldTickets += quantity;
            _selectedMovie.SoldSeats.AddRange(_selectedSeats);

            // 2. Lưu lại vào file JSON
            UpdateJsonFile(_selectedMovie);

            string seatsList = string.Join(", ", _selectedSeats.OrderBy(s => s));

            // 3. Gửi Email xác nhận (Xử lý bất đồng bộ)
            string subject = $"Xác nhận đặt vé thành công: {_selectedMovie.Title}";
            string bodyHtml = GenerateConfirmationBody(customerName, _selectedMovie.Title, seatsList, _currentShowtime);

            try
            {
                await SendEmailAsync(customerEmail, subject, bodyHtml);

                string successMessage = $@"ĐẶT VÉ THÀNH CÔNG!
Phim: {_selectedMovie.Title}
Ghế: {seatsList}
Email xác nhận đã được gửi tới {customerEmail}.";

                MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Thay vì thoát ngay, ta thông báo và cho phép người dùng đóng form
                MessageBox.Show($"Đặt vé thành công, nhưng lỗi gửi email: {ex.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.OK; // Đặt vé đã thành công, nên đóng form
            }
        }

        // --- HÀM 4: GỬI EMAIL XÁC NHẬN (SMTP) ---
        private async Task SendEmailAsync(string recipientEmail, string subject, string bodyHtml)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(SenderEmail, SenderPassword); // Dùng App Password

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Rạp Chiếu Phim UIT", SenderEmail));
                    message.To.Add(new MailboxAddress(recipientEmail, recipientEmail));
                    message.Subject = subject;

                    message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = bodyHtml
                    };

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (AuthenticationException ex)
                {
                    // Ném lại lỗi xác thực để hàm BtnBook_Click bắt được
                    throw new Exception("Lỗi xác thực SMTP. Vui lòng kiểm tra App Password và Email gửi.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi kết nối hoặc gửi email: " + ex.Message, ex);
                }
            }
        }

        // --- HÀM 5: TẠO NỘI DUNG EMAIL HTML ---
        private string GenerateConfirmationBody(string name, string movieTitle, string seats, ShowtimeOption showtime)
        {
            string posterUrl = _selectedMovie.ImageUrl;
            string slogan = "Chúc quý khách xem phim vui vẻ tại Rạp UIT!";

            // Tạo CSS nội tuyến cho poster làm nền
            return $@"
                <html>
                <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; text-align: center;'>
                    <div style='max-width: 600px; margin: auto; background: url({posterUrl}) no-repeat center center; background-size: cover; padding: 40px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); color: #fff;'>
                        
                        <div style='background-color: rgba(0, 0, 0, 0.7); padding: 20px; border-radius: 5px; text-align: left; text-shadow: 1px 1px 2px #000;'>
                            <h1 style='color: #ffcc00; text-align: center;'>XÁC NHẬN VÉ ĐIỆN TỬ</h1>
                            <p>Xin chào, <strong>{name}</strong>!</p>
                            <p>Vé của quý khách đã được đặt thành công. Dưới đây là thông tin chi tiết:</p>
                            
                            <hr style='border-color: #fff; opacity: 0.5;'>
                            
                            <p><strong>Tên phim:</strong> {movieTitle}</p>
                            <p><strong>Phòng chiếu:</strong> {showtime.ScreenName}</p>
                            <p><strong>Thời gian:</strong> {showtime.Time}</p>
                            <p><strong>Số ghế:</strong> <strong>{seats}</strong> (Tổng cộng: {_selectedSeats.Count} vé)</p>
                            <p><strong>Tổng tiền:</strong> {(_selectedSeats.Count * showtime.AdjustedPrice):N0} VNĐ</p>
                        </div>
                        
                        <h3 style='margin-top: 30px; color: #ff0077; background-color: rgba(0, 0, 0, 0.7); padding: 5px; border-radius: 5px;'>{slogan}</h3>
                    </div>
                </body>
                </html>";
        }

        // --- HÀM HỖ TRỢ CẬP NHẬT JSON (Tái sử dụng từ code cũ) ---
        private void UpdateJsonFile(Movie updatedMovie)
        {
            try
            {
                string fileName = "movies.json";
                if (!File.Exists(fileName)) return;

                string jsonString = File.ReadAllText(fileName);
                var allMovies = JsonSerializer.Deserialize<List<Movie>>(jsonString);

                for (int i = 0; i < allMovies.Count; i++)
                {
                    if (allMovies[i].Id == updatedMovie.Id)
                    {
                        // Cập nhật SoldTickets và SoldSeats
                        allMovies[i].SoldTickets = updatedMovie.SoldTickets;
                        allMovies[i].SoldSeats = updatedMovie.SoldSeats; // Thêm SoldSeats
                        break;
                    }
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                jsonString = JsonSerializer.Serialize(allMovies, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật file dữ liệu movies.json: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}