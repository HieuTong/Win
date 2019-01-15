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
	/// Interaction logic for ThongKeDoanhThuTheoThoiGian.xaml
	/// </summary>
	public partial class ThongKeDoanhThuTheoThoiGian : Window
	{
		public ThongKeDoanhThuTheoThoiGian()
		{
			InitializeComponent();
		}

		private void btnNgay_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonNgayThongKeDoanhThu1();
			windows.Show();
		}

		private void btnThang_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonThangThongKeDoanhThu();
			windows.Show();
		}

		private void btnNam_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonNamThongKeDoanhThu();
			windows.Show();
		}
	}
}
