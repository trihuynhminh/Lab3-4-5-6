using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Bai7Riel
{
    // Class lưu Token và User dùng chung toàn app
    public static class AppState
    {
        public static string Token { get; set; } = "";

        // Hàm lấy HttpClient đã gắn sẵn Token
        public static HttpClient GetClient()
        {
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return client;
        }
    }

    // Cấu trúc món ăn (Mapping đúng với API)
    public class DishModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("ten_mon_an")] public string TenMonAn { get; set; }
        [JsonProperty("gia")] public double Gia { get; set; }
        [JsonProperty("mo_ta")] public string MoTa { get; set; }
        [JsonProperty("dia_chi")] public string DiaChi { get; set; }
        [JsonProperty("hinh_anh")] public string HinhAnh { get; set; }
        [JsonProperty("nguoi_dong_gop")] public string NguoiDongGop { get; set; }
    }
}