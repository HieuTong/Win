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
    /// Interaction logic for ChonThangThongKe.xaml
    /// </summary>
    public partial class ChonThangThongKe : Window
    {
		
		public ChonThangThongKe()
        {
            InitializeComponent();
        }
		//public DateTime m;
		private void btnTk_Click(object sender, RoutedEventArgs e)
		{
			var m = monthPicker.Text;
			const string Sa = "/";
			
			var tokens = m.Split(new String[] { Sa },
				StringSplitOptions.None)
				.Select(token => token.Trim().ToLower());
			List<string> tachThang = new List<string>();
			foreach(var token in tokens)
			{
				tachThang.Add(token);
			}
			var thang = tachThang[0];
			var ngay = tachThang[1];
			var nam = tachThang[2];
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
				var m1 = item.NgayLapHoaDon.ToString();
				const string Space = " ";
				var tokens1 = m1.Split(new String[] { Sa, Space },
					StringSplitOptions.None)
					.Select(token => token.Trim().ToLower());
				List<string> tachThang1 = new List<string>();
				foreach (var token in tokens1)
				{
					tachThang1.Add(token);
					//MessageBox.Show(token);

				}
				//MessageBox.Show(tachThang1[0] +" "+ tachThang1[2]);
				if (tachThang1[0] == thang && tachThang1[2] == nam)
				{
					flag = 1;
					break;
				}
				for(var r = 0; r < tachThang1.Count(); r++)
				{
					tachThang1.RemoveAt(r);
				}
				
			}
			if (flag == 0)
			{
				MessageBox.Show("Không tìm thấy tháng này trong các hóa đơn!");
			}
			else
			{
				var windows = new BieuDoThangSanPham();
				var sen = thang + " " + nam;
				windows.Sender(sen);
				windows.Show();
			}


		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
