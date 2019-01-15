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
	/// Interaction logic for ChonThangThongKeDoanhThu.xaml
	/// </summary>
	public partial class ChonThangThongKeDoanhThu : Window
	{
		public ChonThangThongKeDoanhThu()
		{
			InitializeComponent();
		}

		private void btnTK_Click(object sender, RoutedEventArgs e)
		{
			var mDTT = monthPickerDt.Text;
			const string Sa = "/";

			var tokensDTT = mDTT.Split(new String[] { Sa },
				StringSplitOptions.None)
				.Select(token => token.Trim().ToLower());
			List<string> tachThangDTT = new List<string>();
			foreach (var token in tokensDTT)
			{
				tachThangDTT.Add(token);
			}
			var thang = tachThangDTT[0];
			var ngay = tachThangDTT[1];
			var nam = tachThangDTT[2];
			//var i = 0;
			//while (i < m.Length)
			//{
			//	if (m[i] == '/')
			//		break;
			//	i++;
			//}
			//var monthTK=m.Substring(0, i);
			var db = new STOREEntities();
			var flag = 0;//de xem co thu ngay do hay khong
			foreach (var item in db.HoaDons)
			{
				//var j = 0;
				//while (j < item.NgayLapHoaDon.ToString().Length)
				//{
				//	if (m[j] == '/')
				//		break;
				//	j++;
				//}
				var m1DTT = item.NgayLapHoaDon.ToString();
				const string Space = " ";
				var tokens1DTT = m1DTT.Split(new String[] { Sa, Space },
					StringSplitOptions.None)
					.Select(token => token.Trim().ToLower());
				List<string> tachThang1DTT = new List<string>();
				foreach (var token in tokens1DTT)
				{
					tachThang1DTT.Add(token);
					//MessageBox.Show(token);

				}
				//MessageBox.Show(tachThang1[0] +" "+ tachThang1[2]);
				if (tachThang1DTT[0] == thang && tachThang1DTT[2] == nam)
				{
					flag = 1;
					break;
				}
				for (var r = 0; r < tachThang1DTT.Count(); r++)
				{
					tachThang1DTT.RemoveAt(r);
				}

			}
			if (flag == 0)
			{
				MessageBox.Show("Không tìm thấy tháng này trong các hóa đơn!");
			}
			else
			{
				var windows = new BieuDoThangSanPhamDoanhThu();
				var sen = thang + " " + nam;
				windows.Sender(sen);
				windows.Show();
			}
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
