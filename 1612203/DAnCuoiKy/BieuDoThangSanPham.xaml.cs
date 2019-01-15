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
    /// Interaction logic for BieuDoThangSanPham.xaml
    /// </summary>
    public partial class BieuDoThangSanPham : Window
    {
		public delegate void SendThang(string n);
		public SendThang Sender;
		System.Collections.ArrayList dataThang;
        public BieuDoThangSanPham()
        {
            InitializeComponent();
			Sender = new SendThang(GetThang);
        }
		public string me;
		public string ThangTTK;
		public string NamTTK;
		private void GetThang(string n)
		{
			me = n;
			var i = 0;
			while (i < n.Length)
			{
				if (me[i] ==' ')
					break;
				i++;
			}
			ThangTTK = me.Substring(0, i);
			NamTTK = me.Substring(i + 1, 4);
		}
		class SanPhamThang
		{
			public string MaSP { get; set; }
			public string TenSP { get; set; }
			public int SL { get; set; }
		}
		private List<SanPhamThang> getItemSPTK()
		{

			var itemsSPTK = new List<SanPhamThang>();
			var db = new STOREEntities();
			const string Sa = "/";
			foreach (var item in db.HoaDons)
			{
				var m2 = item.NgayLapHoaDon.ToString();
				const string Space = " ";
				var tokens2 = m2.Split(new String[] { Sa, Space },
					StringSplitOptions.None)
					.Select(token => token.Trim().ToLower());
				List<string> tachThang2 = new List<string>();
				foreach (var token in tokens2)
				{
					tachThang2.Add(token);
					//MessageBox.Show(token);

				}
				if (tachThang2[0] == ThangTTK && tachThang2[2] == NamTTK)
				{
					var mahoadon = item.MaHoaDon;
					foreach (var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							var msp = para.MaSanPham;
							var sp_ = db.SanPhams.Find(msp);
							var soluong = (int)para.SoLuong;
							var it = new SanPhamThang() { MaSP = msp, TenSP = sp_.TenSP, SL = soluong };
							itemsSPTK.Add(it);
						}
					}
				}
				for (var r = 0; r < tachThang2.Count(); r++)
				{
					tachThang2.RemoveAt(r);
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
		class SPThangBD
		{
			public string name { get; set; }
			public int amount { get; set; }
			public SPThangBD(string name, int amount)
			{
				this.name = name;
				this.amount = amount;
			}


		};
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dataThang = new System.Collections.ArrayList();
			var items = getItemSPTK();
			for (var i = 0; i < items.Count(); i++)
			{
				dataThang.Add(new SPThangBD(items[i].TenSP, items[i].SL));
			}
			chartMonth.ItemsSource = dataThang;

		}
	}
}
