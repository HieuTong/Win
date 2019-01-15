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
    /// Interaction logic for ThongKeTheoSanPham.xaml
    /// </summary>
    public partial class ThongKeTheoSanPham : Window
    {
        public ThongKeTheoSanPham()
        {
            InitializeComponent();
        }

		private void btnTgXacDinh_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThongKeTheoThoiGianXacDinh();
			windows.Show();
		}

		private void btnKtg_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThongKeTheoKhoangThoiGian();
			windows.Show();
		}
	}
}
