using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    // Trong file Movie.cs
    public class Movie
    {
        // Thông tin cơ bản trích xuất từ trang https://betacinemas.vn/phim.htm
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string DetailUrl { get; set; }

        // Thêm các thuộc tính phục vụ việc quản lý phòng vé (kế thừa bài 5)
        public int TotalTickets { get; set; } = 100; // Tổng số vé, ví dụ
        public int SoldTickets { get; set; } = 0;    // Số vé đã bán
        public decimal Price { get; set; } = 80000;  // Giá vé, ví dụ

        // Thuộc tính tính toán
        public decimal Revenue => SoldTickets * Price;
        public double SalesRatio => (double)SoldTickets / TotalTickets;

        // Để dễ dàng kiểm tra, có thể thêm một ID duy nhất
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
