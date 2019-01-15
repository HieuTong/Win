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
	/// Interaction logic for ChonNgayThongKeDoanhThu1.xaml
	/// </summary>
	public partial class ChonNgayThongKeDoanhThu1 : Window
	{
		public ChonNgayThongKeDoanhThu1()
		{
			InitializeComponent();
		}

		private void btnTKDT_Click(object sender, RoutedEventArgs e)
		{
			var ngaydoanhThu = dateDoanhThu.Text;
			var db = new STOREEntities();
			var flag = 0;//de xem co thu ngay do hay khong
			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(ngaydoanhThu))
				{
					flag = 1;
					break;
				}
			}
			if (flag == 0)
			{
				MessageBox.Show("Không tìm thấy ngày này trong các hóa đơn!");
			}
			else
			{
				var windows = new BieuDoThongKeDoanhThuTheoNgay();
				windows.Sender(ngaydoanhThu);
				windows.Show();
			}
			
		}

		private void btnEx_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
