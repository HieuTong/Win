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
	/// Interaction logic for ChonNamThongKeDoanhThu.xaml
	/// </summary>
	public partial class ChonNamThongKeDoanhThu : Window
	{
		public ChonNamThongKeDoanhThu()
		{
			InitializeComponent();
		}

		private void btnTkNam_Click(object sender, RoutedEventArgs e)
		{
			var nam = txtNamTKDT.Text;
			var db = new STOREEntities();
			var flag = 0;//de xem co thu ngay do hay khong
			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(nam))
				{
					flag = 1;
					break;
				}
			}
			if (flag == 0)
			{
				MessageBox.Show("Không tìm thấy năm này trong các hóa đơn!");
			}
			else
			{
				var windows = new BieuDoThongKeDoanhThuTheoNam();
				windows.Sender(nam);
				windows.Show();
			}
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
