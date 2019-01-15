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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAnCuoiKy
{
	/// <summary>
	/// Interaction logic for BieuDoNgaySanPham.xaml
	/// </summary>
	public partial class BieuDoNgaySanPham : Window
	{
		public delegate void SendNgay(string n);
		public SendNgay Sender;
		System.Collections.ArrayList data;
		public BieuDoNgaySanPham()
		{
			InitializeComponent();
			
			Sender = new SendNgay(GetNgay);
		}
		public static string NgayTK;
		private void GetNgay(string n)
		{
			NgayTK = n;
		}
		class SanPhamNgay
		{
			public string MaSP { get; set; }
			public string TenSP { get; set; }
			public int SL { get; set; }
		}

		private List<SanPhamNgay> getItemSPTK()
		{
			var itemsSPTK = new List<SanPhamNgay>();
			var db = new STOREEntities();

			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(NgayTK))
				{
					var mahoadon = item.MaHoaDon;
					foreach (var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							var msp = para.MaSanPham;
							var sp_ = db.SanPhams.Find(msp);
							var soluong = (int)para.SoLuong;
							var it = new SanPhamNgay() { MaSP = msp, TenSP = sp_.TenSP, SL = soluong };
							itemsSPTK.Add(it);
						}
					}
				}
			}
			for (var i = 0; i < itemsSPTK.Count(); i++)
			{
				for (var j = i + 1; j < itemsSPTK.Count(); j++)
				{
					if (itemsSPTK[i].MaSP == itemsSPTK[j].MaSP)
					{
						itemsSPTK[i].SL += itemsSPTK[j].SL;
						itemsSPTK.Remove(itemsSPTK[j]);
						j--;
					}
				}
			}
			return itemsSPTK;
		}
		class SPNgayBD
		{
			public string name { get; set; }
			public int amount { get; set; }
			public SPNgayBD(string name, int amount)
			{
				this.name = name;
				this.amount = amount;
			}


		};
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			data = new System.Collections.ArrayList();
			var items = getItemSPTK();
			for(var i = 0; i < items.Count(); i++)
			{
				data.Add(new SPNgayBD(items[i].TenSP, items[i].SL));
			}
			chart.ItemsSource = data;
		}
	}
}


