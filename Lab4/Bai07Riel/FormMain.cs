using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bai7Riel
{
    public partial class FormMain : Form
    {
        private List<DishModel> _list = new List<DishModel>();

        public FormMain()
        {
            InitializeComponent();
            cbMode.SelectedIndex = 0;
            this.Load += async (s, e) => await LoadData();
            numPage.ValueChanged += async (s, e) => await LoadData();
            cbMode.SelectedIndexChanged += async (s, e) => await LoadData();
            dgvDishes.CellDoubleClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    var dish = (DishModel)dgvDishes.Rows[e.RowIndex].DataBoundItem;
                    new FormDetail(dish).ShowDialog();
                    _ = LoadData();
                }
            };
        }

        private async Task LoadData()
        {
            string url = "https://nt106.uitiot.vn/api/v1/monan/" + ((cbMode.SelectedIndex == 0) ? "all" : "my-dishes");
            var body = new { current = (int)numPage.Value, pageSize = 10 };
            try
            {
                using (var client = AppState.GetClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                    var res = await client.PostAsync(url, content);
                    var json = await res.Content.ReadAsStringAsync();
                    if (res.IsSuccessStatusCode)
                    {
                        var jObj = JObject.Parse(json);
                        _list = jObj["data"].ToObject<List<DishModel>>();
                        dgvDishes.DataSource = _list;
                    }
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormDetail(null).ShowDialog();
            _ = LoadData();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (_list.Count > 0)
            {
                var dish = _list[new Random().Next(_list.Count)];
                MessageBox.Show($"Ăn món này đi: {dish.TenMonAn}");
                new FormDetail(dish).ShowDialog();
            }
            else MessageBox.Show("Danh sách trống!");
        }
    }
}