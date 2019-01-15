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
	/// Interaction logic for TimKiemTheoTen.xaml
	/// </summary>
	public partial class TimKiemTheoTen : Window
	{
		public TimKiemTheoTen()
		{
			InitializeComponent();
		}
		private List<SanPham> getTimKiemItem()
		{
			var items = new List<SanPham>();
			var db = new STOREEntities();
			foreach (var index in db.SanPhams)
			{
				if (index.TenSP.ToString().ToLower().Contains(txt1.Text.ToString().ToLower()))
					
				{
					var item = new SanPham()
					{
						MaSanPham = index.MaSanPham,
						MaLoaiSP = index.MaLoaiSP,
						TenSP = index.TenSP,
						GiaNhap = (int)index.GiaNhap,
						GiaBan = (int)index.GiaBan,
						SoLuong = (int)index.SoLuong,
						TrangThai = (int)index.TrangThai,
						ImagePath = index.ImagePath
					};
					items.Add(item);
				}

			}
			return items;
		}
		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnTK_Click(object sender, RoutedEventArgs e)
		{
			var items = getTimKiemItem();
			if (items.Count == 0)
			{
				MessageBox.Show("Xin lỗi!Không tìm thấy sản phẩm!");
			}
			else
			{
				lvTimKiemSP.ItemsSource = items;
			}
		}
	}
}
