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
	/// Interaction logic for LocTheoGia.xaml
	/// </summary>
	public partial class LocTheoGia : Window
	{
		public LocTheoGia()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private List<SanPham> getLocItem()
		{
			var items = new List<SanPham>();
			var db = new STOREEntities();
			foreach(var index in db.SanPhams)
			{
				if(index.GiaBan>=int.Parse(txt1.Text) &&
					index.GiaBan <= int.Parse(txt2.Text))
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
		private void btnLocGia_Click(object sender, RoutedEventArgs e)
		{
			
			var items = getLocItem();
			if (items.Count == 0)
			{
				MessageBox.Show("Xin lỗi!Không có giá trong khoảng này!");
			}
			else
			{
				LocSP.ItemsSource = items;
			}
			
		}
	}
}
