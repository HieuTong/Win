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
	/// Interaction logic for ThemSanPham.xaml
	/// </summary>
	public partial class ThemSanPham : Window
	{
		public ThemSanPham()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			if(txt1.Text == ""|| txt2.Text == ""|| txt3.Text == ""|| txt4.Text == ""||
				txt5.Text == ""|| txt6.Text == ""|| txt7.Text == "")
			{
				var btn = MessageBoxButton.OK;
				var img = MessageBoxImage.Error;
				var msg = "Bạn chưa nhập đầy đủ thông tin";
				MessageBox.Show(msg, "Thông báo", btn, img);
			}
			else
			{
				var db = new STOREEntities();
				var s = "";
				foreach (var index in db.SanPhams)
				{
					s = index.MaSanPham;
				}
				int n = int.Parse(s.Substring(2, 3));
				n = n + 1;
				if (n < 10)
				{
					s = "SP00" + n.ToString();
				}else if (n < 100)
				{
					s = "SP0" + n.ToString();
				}
				else
				{
					s = "SP" + n.ToString();
				}
				var spAdd = new SanPham()
				{
					MaSanPham = s,
					MaLoaiSP = txt1.Text,
					TenSP = txt2.Text,
					GiaNhap = int.Parse(txt3.Text),
					GiaBan = int.Parse(txt4.Text),
					SoLuong = int.Parse(txt5.Text),
					TrangThai = int.Parse(txt6.Text),
					ImagePath = txt7.Text
				};
				db.SanPhams.Add(spAdd);
				db.SaveChanges();
				MessageBox.Show("Thêm thành công");
				
			}
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
