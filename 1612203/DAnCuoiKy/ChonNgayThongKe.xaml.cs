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
    /// Interaction logic for ChonNgayThongKe.xaml
    /// </summary>
    public partial class ChonNgayThongKe : Window
    {
        public ChonNgayThongKe()
        {
            InitializeComponent();
        }

		private void tksp_Click(object sender, RoutedEventArgs e)
		{
			var ngay = dateThongKe.Text;
			var db = new STOREEntities();
			var flag = 0;//de xem co thu ngay do hay khong
			foreach(var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(ngay))
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
				var windows = new BieuDoNgaySanPham();
				windows.Sender(ngay);
				windows.Show();
			}
			
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
