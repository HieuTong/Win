using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAnCuoiKy
{
    /// <summary>
    /// Interaction logic for CuaSoBanHang.xaml
    /// </summary>
    public partial class CuaSoBanHang : Window
    {
        public CuaSoBanHang()
        {
            InitializeComponent();
        }
		private void btnLHD_Click(object sender, RoutedEventArgs e)
		{
			if (txt2.Text == "")
			{
				MessageBox.Show("Vui lòng điền thông tin khách hàng");
			}
			else
			{
				var db = new STOREEntities();
				var check_KH = db.KhachHangs.Find(txt2.Text.ToUpper());
				if (check_KH == null)
				{
					MessageBox.Show("Không tồn tại mã khách hàng này");
				}
				else
				{
					var hdToAdd = new HoaDon() { MaHoaDon = mahd, MaKhachHang = txt2.Text, NgayLapHoaDon = NgayLap, TrangThaiThanhToan = cmbChoice.SelectedItem.ToString(), GiamGia = 0, TongTien = 0, Diem = 0 };
					db.HoaDons.Add(hdToAdd);
					db.SaveChanges();

					var windows = new BanChiTietSanPham();
					var send = mahd + "+" + txt2.Text;
					windows.Sender(send);
					windows.Show();

				}
			}
		}

		private void txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			txt2.Text = "";
		}
		List<string> listcmb = new List<string>();
		//khai bao bien mahd va Nhay lap hoa don
		public string mahd;
		public DateTime NgayLap;
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//combobox
			listcmb.Add("Giao hàng thu tiền");
			listcmb.Add("Chuyển khoản");
			cmbChoice.ItemsSource = listcmb;

			var db = new STOREEntities();
			//tìm mã hóa đơn tiếp theo để thêm
			var s = "";
			foreach (var index in db.HoaDons)
			{
				s = index.MaHoaDon;
			}
			int n = int.Parse(s.Substring(2, 3));
			n = n + 1;
			if (n < 10)
			{
				s = "HD00" + n.ToString();

			}
			else if (n < 100)
			{
				s = "HD0" + n.ToString();
			}
			else
			{
				s = "HD" + n.ToString();
			}
			mahd = s;
			NgayLap = DateTime.Now;
			lbl11.Content = s;
			lbl31.Content = NgayLap;
		}
		private void btnexit_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			foreach (var index in db.HoaDons)
			{
				if (index.MaHoaDon == mahd)
				{
					db.HoaDons.Remove(index);
					db.SaveChanges();
				}
			}
		}
	}
}
