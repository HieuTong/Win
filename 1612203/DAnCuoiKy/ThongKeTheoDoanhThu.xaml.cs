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
	/// Interaction logic for ThongKeTheoDoanhThu.xaml
	/// </summary>
	public partial class ThongKeTheoDoanhThu : Window
	{
		public ThongKeTheoDoanhThu()
		{
			InitializeComponent();
		}

		private void btnTG_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThongKeDoanhThuTheoThoiGian();
			windows.Show();
		}

		private void btnKTG_Click(object sender, RoutedEventArgs e)
		{
		
		}
	}
}
