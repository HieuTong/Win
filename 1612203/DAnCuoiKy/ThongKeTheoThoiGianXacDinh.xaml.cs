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
    /// Interaction logic for ThongKeTheoThoiGianXacDinh.xaml
    /// </summary>
    public partial class ThongKeTheoThoiGianXacDinh : Window
    {
        public ThongKeTheoThoiGianXacDinh()
        {
            InitializeComponent();
        }

		private void btnNgaySanPham_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonNgayThongKe();
			windows.Show();

		}

		private void btnThangSP_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonThangThongKe();
			windows.Show();
		}

		private void btnNamSanPham_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChonNamThongKe();
			windows.Show();
		}
	}
}
