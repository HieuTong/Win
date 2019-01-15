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
	/// Interaction logic for CapNhatSanPham.xaml
	/// </summary>
	public partial class CapNhatSanPham : Window
	{
		public delegate void SendMaSP(string n);
		public SendMaSP Sender;
		public CapNhatSanPham()
		{
			InitializeComponent();
			Sender = new SendMaSP(GetMaSP);
		}
		public static string TenMaSP;
		public void GetMaSP(string n)
		{
			TenMaSP = n;
		}
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			foreach (var index in db.SanPhams)
			{
				if (index.MaSanPham.ToString() ==TenMaSP)
				{
					index.MaLoaiSP = txt1.Text;
					index.TenSP = txt2.Text;
					index.GiaNhap = int.Parse(txt3.Text);
					index.GiaBan = int.Parse(txt4.Text);
					index.SoLuong = int.Parse(txt5.Text);
					index.TrangThai = int.Parse(txt6.Text);
					index.ImagePath = txt7.Text;

				}

			}
			db.SaveChanges();
			MessageBox.Show("Đã cập nhật");
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
