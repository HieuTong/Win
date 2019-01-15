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
	/// Interaction logic for HoaDonChiTiet.xaml
	/// </summary>
	public partial class HoaDonChiTiet : Window
	{
		//khai bao delegate
		public delegate void SendMessage(string Message);
		public SendMessage Sender;
		public HoaDonChiTiet()
		{
			InitializeComponent();
			Sender = new SendMessage(GetMessage);
		}
		public static string mahd;

		private void GetMessage(string Message)
		{
			mahd = Message;
		}
		class SP
		{
			public string MaSP { get; set; }
			public string TenSP { get; set; }
			public int SL { get; set; }
			public int DonGia { get; set; }
			public int ThanhTien { get; set; }
		}
		public int tongtien = 0;

		private List<SP> getItemSP()
		{
			var items = new List<SP>();
			//cap nhat
			var db = new STOREEntities();
			var hoadon_ = db.HoaDons.Find(mahd);
			lblMaHD.Content = hoadon_.MaHoaDon;
			lblMaKH.Content = hoadon_.MaKhachHang;
			var khachhang_ = db.KhachHangs.Find(hoadon_.MaKhachHang);
			lblName.Content = khachhang_.TenKhach;
			lblDate.Content = hoadon_.NgayLapHoaDon.ToString();

			foreach(var index in db.ChiTietHoaDons)
			{
				if (index.MaHoaDon == mahd)
				{
					var msp = index.MaSanPham;
					var sp_ = db.SanPhams.Find(msp);
					var soluong = (int)index.SoLuong;
					var dongia = (int)sp_.GiaBan;
					var thanhtien = soluong * dongia;
					tongtien = tongtien + thanhtien;
					var item = new SP
					{
						MaSP = msp,
						TenSP = sp_.TenSP,
						SL = soluong,
						DonGia = dongia,
						ThanhTien = thanhtien
					};
					items.Add(item);
				}
			}
			



			return items;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var items = getItemSP();
			itemListView.ItemsSource = items;
		}

		private void btntt_Click(object sender, RoutedEventArgs e)
		{
			if (txtGiamGia.Text == "")
			{
				lblTongTien.Content = tongtien.ToString();
				int diem = tongtien / 100000;
				lblDiem.Content = diem.ToString();

			}
			else 
			{

				var giamgia = float.Parse(txtGiamGia.Text.ToString());
				//MessageBox.Show(giamgia.ToString());
				var tongtientam = tongtien * giamgia;
				tongtien -= (int)tongtientam;
				var db = new STOREEntities();
				var update_ = db.HoaDons.Find(mahd);
				update_.TongTien = tongtien;
				update_.GiamGia = float.Parse(txtGiamGia.Text.ToString());
				update_.Diem = tongtien / 100000;
				var update1_ = db.KhachHangs.Find(lblMaKH.Content);
				update1_.DiemThanhVien += tongtien / 100000;
				db.SaveChanges();
				lblTongTien.Content = tongtien.ToString();
				int diem = tongtien / 100000;
				lblDiem.Content = diem.ToString();


			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
