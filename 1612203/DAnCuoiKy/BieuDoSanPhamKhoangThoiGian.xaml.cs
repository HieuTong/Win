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
	/// Interaction logic for BieuDoSanPhamKhoangThoiGian.xaml
	/// </summary>
	public partial class BieuDoSanPhamKhoangThoiGian : Window
	{
		public delegate void SendKhoangTG(string n);
		public SendKhoangTG Sender;
		System.Collections.ArrayList dataKTG;
		public BieuDoSanPhamKhoangThoiGian()
		{
			InitializeComponent();
			Sender = new SendKhoangTG(GetKTG);
		}
		public string getKTg;
		public string ToTime;
		public string FromTime;
		DateTime FROM;
		DateTime TO;
		private void GetKTG(string n)
		{
			getKTg = n;
			const string Space = " ";
			var tokensKTG = getKTg.Split(new String[] {Space },
					StringSplitOptions.None)
					.Select(token => token.Trim().ToLower());
			List<string> tachThangKTG = new List<string>();
			foreach (var token in tokensKTG)
			{
				tachThangKTG.Add(token);
				//MessageBox.Show(token);

			}
			//var k = 0;
			//while (k < getKTg.Length)
			//{
			//	if (getKTg[k] == ' ')
			//		break;
			//	k++;
			//}
			FromTime = tachThangKTG[0];
			ToTime = tachThangKTG[1];
			FROM = DateTime.Parse(FromTime);
			TO = DateTime.Parse(ToTime);
			//
			MessageBox.Show(FROM.ToString()+TO.ToString());
		
		}
		class SanPhamKT
		{
			public string MaSP { get; set; }
			public string TenSP { get; set; }
			public int SL { get; set; }
		};
		class SanPhamKTBD
		{
			public string name { get; set; }
			public int amount { get; set; }
			public SanPhamKTBD(string name, int amount)
			{
				this.name = name;
				this.amount = amount;
			}
		};

		private List<SanPhamKT> getItemKT()
		{
			var itemsKt = new List<SanPhamKT>();
			var db = new STOREEntities();
			foreach (var item in db.HoaDons)
			{
				if(FROM<item.NgayLapHoaDon && item.NgayLapHoaDon < TO)
				{
					var mahoadon = item.MaHoaDon;
					foreach (var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							var msp = para.MaSanPham;
							var sp_ = db.SanPhams.Find(msp);
							var soluong = (int)para.SoLuong;
							var it = new SanPhamKT() { MaSP = msp, TenSP = sp_.TenSP, SL = soluong };
							itemsKt.Add(it);
						}
					}
				}
				
				
			}
			for (var i = 0; i < itemsKt.Count(); i++)
			{
				for (var j = i + 1; j < itemsKt.Count(); j++)
				{
					if (itemsKt[i].MaSP == itemsKt[j].MaSP)
					{
						itemsKt[i].SL += itemsKt[j].SL;
						itemsKt.Remove(itemsKt[j]);
						j--;
					}
				}
			}
			return itemsKt;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dataKTG = new System.Collections.ArrayList();
			var items = getItemKT();
			for (var i = 0; i < items.Count(); i++)
			{
				dataKTG.Add(new SanPhamKTBD(items[i].TenSP, items[i].SL));
			}
			chartKTG.ItemsSource = dataKTG;
		}
	}
}
