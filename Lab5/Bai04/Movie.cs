// Trong file Movie.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai04
{
    // Lớp mô tả một suất chiếu/phòng chiếu cụ thể (dùng trong BookingForm)
    public class ShowtimeOption
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public string Time { get; set; }      // Giờ chiếu (Ví dụ: 10:00)
        public string ScreenName { get; set; } // Tên phòng chiếu (Ví dụ: Standard 1, VIP 2)
        public decimal AdjustedPrice { get; set; } // Giá vé thực tế của suất chiếu này

        // Cần thiết cho ComboBox trong BookingForm
        public override string ToString()
        {
            return $"{Time} - {ScreenName} ({AdjustedPrice:N0} VNĐ)";
        }
    }


    public class Movie
    {
        // Sử dụng trường ẩn để đảm bảo ID không bị reset khi deserializing từ JSON
        private string _id = Guid.NewGuid().ToString();

        // --- Dữ liệu Trích xuất ---
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string DetailUrl { get; set; }

        // Danh sách các suất chiếu khả dụng cho phim này
        public List<ShowtimeOption> AvailableShowtimes { get; set; } = new List<ShowtimeOption>();


        // --- Dữ liệu Nghiệp vụ/Quản lý vé ---
        public int TotalTickets { get; set; } = 100; // Tổng số vé mặc định
        public int SoldTickets { get; set; } = 0;    // Số vé đã bán

        // THUỘC TÍNH MỚI: DANH SÁCH CÁC GHẾ ĐÃ BÁN (Tên ghế, ví dụ: "A1", "B5")
        public List<string> SoldSeats { get; set; } = new List<string>();

        // Price được thay bằng giá trung bình hoặc giá cơ sở (Giá thực tế nằm trong ShowtimeOption)
        public decimal BasePrice { get; set; } = 80000;

        // Đảm bảo Id chỉ tạo ngẫu nhiên nếu chưa được gán (quan trọng cho JSON)
        public string Id
        {
            get
            {
                // Đảm bảo ID luôn có giá trị, kể cả sau deserialization
                if (string.IsNullOrEmpty(_id))
                {
                    _id = Guid.NewGuid().ToString();
                }
                return _id;
            }
            set => _id = value;
        }

        // Thuộc tính tính toán (Giá/Doanh thu cơ sở)
        // Lưu ý: Tính Revenue cơ sở nếu không dùng giá suất chiếu
        public decimal Revenue => SoldTickets * BasePrice;
        public double SalesRatio => (double)SoldTickets / TotalTickets;

    }
}