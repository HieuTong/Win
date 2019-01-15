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
    /// Interaction logic for ThongKeTheoKhoangThoiGian.xaml
    /// </summary>
    public partial class ThongKeTheoKhoangThoiGian : Window
    {
        public ThongKeTheoKhoangThoiGian()
        {
            InitializeComponent();
        }

		private void btnTKKTG_Click(object sender, RoutedEventArgs e)
		{
			DateTime tu = pickFromTime.SelectedDate.Value;
			DateTime den = pickToTime.SelectedDate.Value;
			if (tu > den)
			{
				MessageBox.Show("Thời gian đầu vượt quá thời gian sau!");
			}
			else
			{
				var dauco = 0;
				var db = new STOREEntities();
				foreach (var item in db.HoaDons)
				{
					if (tu <= item.NgayLapHoaDon && item.NgayLapHoaDon <= den)
					{
						dauco = 1;
						break;
					}
				}
				if (dauco == 0)
				{
					MessageBox.Show("Không tìm thấy các hóa đơn trong khoảng thời gian này");

				}
				else
				{
					var windows = new BieuDoSanPhamKhoangThoiGian();
					var transfer = pickFromTime.Text + " " + pickToTime;
					windows.Sender(transfer);
					windows.Show();
				}
			}
			

		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
