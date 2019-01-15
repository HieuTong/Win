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
	/// Interaction logic for BanChiTietSanPham.xaml
	/// </summary>
	public partial class BanChiTietSanPham : Window
	{
		//khai bao delegate
		public delegate void SendMessage(string Message);
		public SendMessage Sender;
		public BanChiTietSanPham()
		{
			InitializeComponent();
			//tao con tro
			Sender = new SendMessage(GetMessage);
		}
		public string mess;
		public string mahd;
		public string makh;

		//nhan du lieu 
		
		private void GetMessage(string Message)
		{
			mess = Message;
			mahd = mess.Substring(0, 5);
			makh = mess.Substring(6, 5);
		}
		public int T = 0;
		private void btnNhap_Click(object sender, RoutedEventArgs e)
		{
			if (txt1.Text == "" || txt2.Text == "")
			{
				MessageBox.Show("Vui lòng nhập thông tin");
			}
			else
			{
				var db = new STOREEntities();
				var masp = txt1.Text;
				var timmasp = db.SanPhams.Find(masp);
				if (timmasp == null)
				{
					MessageBox.Show("Mã sản phẩm không hợp lệ");
				}
				else
				{
					// Tìm mã chi tiết hóa đơn tiếp theo để thêm
					var s = "";
					foreach(var index in db.ChiTietHoaDons)
					{
						s = index.MaChiTietHoaDon;
					}
					int n = int.Parse(s.Substring(2, 3));
					n = n + 1;
					if (n < 10)
					{
						s = "CT00" + n.ToString();
					}else if (n < 100)
					{
						s = "CT0" + n.ToString();
					}
					else
					{
						s = "CT" + n.ToString();
					}
					var soluong = int.Parse(txt2.Text);
					var update_SoluongSP = db.SanPhams.Find(txt1.Text);
					update_SoluongSP.SoLuong -= soluong;
					//var giaban = update_SoluongSP.GiaBan;
					int giaban = int.Parse(hienGia.Text);
					var tongtien = soluong * giaban;
					var update_tongTien = db.HoaDons.Find(mahd);
					update_tongTien.TongTien += tongtien;
					
					T += tongtien;


					var spToAdd = new ChiTietHoaDon
					{
						MaChiTietHoaDon = s,
						MaHoaDon = mahd,
						MaSanPham = txt1.Text,
						SoLuong = int.Parse(txt2.Text)
					};
					db.ChiTietHoaDons.Add(spToAdd);
					db.SaveChanges();
					MessageBox.Show("Thêm thành công");
				}
			}
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			var update_diem = db.KhachHangs.Find(makh);
			update_diem.DiemThanhVien += T / 100000;
			var update_diemHoaDon = db.HoaDons.Find(mahd);
			update_diemHoaDon.Diem += T / 100000;
			db.SaveChanges();
			this.Close();
		}

		private void txt1_GotFocus(object sender, RoutedEventArgs e)
		{
			txt1.Text = "";
		}

		private void txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			txt2.Text = "";
		}

		private void btnXemGia_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			var giaSanPham = db.SanPhams.Find(txt1.Text);
			if (giaSanPham == null)
			{
				MessageBox.Show("Không tìm thấy sản phẩm!");
			}
			else
			{
				hienGia.Text = giaSanPham.GiaBan.ToString();
			}
			
		}
	}
}
