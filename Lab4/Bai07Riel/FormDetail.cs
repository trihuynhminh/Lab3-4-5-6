using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bai7Riel
{
    public partial class FormDetail : Form
    {
        private DishModel _dish;
        public FormDetail(DishModel dish)
        {
            InitializeComponent();
            _dish = dish;
            if (_dish == null)
            {
                this.Text = "Thêm Món Mới";
                btnDelete.Visible = false;
                txtImage.Text = "https://via.placeholder.com/150";
            }
            else
            {
                this.Text = "Xem / Xóa Món";
                btnSave.Visible = false; // Xem thì ẩn nút Lưu, chỉ cho Xóa
                txtName.Text = _dish.TenMonAn;
                txtPrice.Text = _dish.Gia.ToString();
                txtAddress.Text = _dish.DiaChi;
                txtDesc.Text = _dish.MoTa;
                txtImage.Text = _dish.HinhAnh;
                if (!string.IsNullOrEmpty(_dish.HinhAnh)) try { pbImage.LoadAsync(_dish.HinhAnh); } catch { }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var newDish = new
            {
                ten_mon_an = txtName.Text,
                gia = double.Parse(txtPrice.Text),
                dia_chi = txtAddress.Text,
                mo_ta = txtDesc.Text,
                hinh_anh = txtImage.Text
            };
            try
            {
                using (var client = AppState.GetClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(newDish), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/add", content);
                    if (res.IsSuccessStatusCode) { MessageBox.Show("Thêm thành công!"); this.Close(); }
                    else MessageBox.Show("Lỗi: " + await res.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắn xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                using (var client = AppState.GetClient())
                {
                    var res = await client.DeleteAsync($"https://nt106.uitiot.vn/api/v1/monan/{_dish.Id}");
                    if (res.IsSuccessStatusCode) { MessageBox.Show("Đã xóa!"); this.Close(); }
                    else MessageBox.Show("Lỗi (Có thể không phải món của bạn): " + await res.Content.ReadAsStringAsync());
                }
            }
            catch { }
        }
    }
}