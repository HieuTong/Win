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
	/// Interaction logic for ChiTietSanPham.xaml
	/// </summary>
	public partial class ChiTietSanPham : Window
	{
		//List<string> stringTen = new List<string>();
		//public delegate void SendTenSP(string n);
		//public SendTenSP Sender;
		SanPham sp;

		public ChiTietSanPham(SanPham sp)
		{
			InitializeComponent();
			this.sp = sp;
		}

		public ChiTietSanPham()
		{
			InitializeComponent();
			//Sender = new SendTenSP(GetTenSP);
		}
		//public static string TenSPChiTiet;
		//private void GetTenSP(string n)
		//{
		//	TenSPChiTiet = n;
		//	//stringTen.Add(n);
			
		//}
		private void btnCapNhat_Click(object sender, RoutedEventArgs e)
		{
			//var db = new STOREEntities();
			//foreach(var index in db.SanPhams)
			//{
			//	if (index.MaSanPham == sp.MaSanPham)
			//	{
			//		index.MaLoaiSP = txt1.Text;
			//		index.TenSP = txt2.Text;
			//		index.GiaNhap = int.Parse(txt3.Text);
			//		index.GiaBan = int.Parse(txt4.Text);
			//		index.SoLuong = int.Parse(txt5.Text);
			//		index.TrangThai = int.Parse(txt6.Text);
			//		index.ImagePath = txt7.Text;

			//	}

			//}
			//db.SaveChanges();
			//MessageBox.Show("Đã cập nhật");
			//this.Close();
			var windows = new CapNhatSanPham();
			windows.Sender(sp.MaSanPham);
			windows.Show();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			txt1.Content = sp.MaLoaiSP.ToString();
			txt2.Content = sp.TenSP.ToString();
			txt3.Content = sp.GiaNhap.ToString();
			txt4.Content = sp.GiaBan.ToString();
			txt5.Content = sp.SoLuong.ToString();
			txt6.Content = sp.TrangThai.ToString();
			txt7.Content = sp.ImagePath.ToString();
		}

		private void btnXoa_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			var a = db.SanPhams.Find(sp.MaSanPham);
			a.TrangThai = 0;
			db.SaveChanges();
			MessageBox.Show("Dữ liệu xóa đã được ghi lại");
		}
	}
}
