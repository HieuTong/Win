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
	/// Interaction logic for BieuDoThangSanPhamDoanhThu.xaml
	/// </summary>
	public partial class BieuDoThangSanPhamDoanhThu : Window
	{
		public delegate void SendThang(string n);
		public SendThang Sender;
		public BieuDoThangSanPhamDoanhThu()
		{
			InitializeComponent();
			Sender = new SendThang(GetThang);
		}
		
		public string meDTT;
		public string ThangTTKDTT;
		public string NamTTKDTT;
		private void GetThang(string n)
		{
			meDTT = n;
			var i = 0;
			while (i < n.Length)
			{
				if (meDTT[i] == ' ')
					break;
				i++;
			}
			ThangTTKDTT = meDTT.Substring(0, i);
			NamTTKDTT = meDTT.Substring(i + 1, 4);
		}

		class DoanhThuThang
		{
			public float TienThuDuoc { get; set; }
			public float TienNhap { get; set; }
		}
		class SanPhamThangDoanhThu
		{
			//public string MaSP { get; set; }
			public int GiaNhapLieu { get; set; }
			public int SL { get; set; }
		}

		private List<DoanhThuThang> getItemDTNDTT()
		{
			var itemsDTNDTT = new List<DoanhThuThang>();
			var itemsSPNDTT = new List<SanPhamThangDoanhThu>();
			var db = new STOREEntities();
			var thuDuoc = (float)0;
			foreach (var item in db.HoaDons)
			{
				var m2DTT = item.NgayLapHoaDon.ToString();
				const string Space = " ";
				const string Sa = "/";
				var tokens2DTT = m2DTT.Split(new String[] { Sa, Space },
					StringSplitOptions.None)
					.Select(token => token.Trim().ToLower());
				List<string> tachThang2DTT = new List<string>();
				foreach (var token in tokens2DTT)
				{
					tachThang2DTT.Add(token);
					//MessageBox.Show(token);

				}
				if (tachThang2DTT[0] == ThangTTKDTT && tachThang2DTT[2] == NamTTKDTT)
				{
					//var thuDuoc = 0;
					thuDuoc += (float)item.TongTien;
					var mahoadon = item.MaHoaDon;
					foreach (var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							var msp = para.MaSanPham;
							var sp_ = db.SanPhams.Find(msp);
							var soluong = (int)para.SoLuong;
							var itngayDoanhThu = new SanPhamThangDoanhThu()
							{
								//MaSP = msp,
								GiaNhapLieu = (int)sp_.GiaNhap,
								SL = soluong

							};
							itemsSPNDTT.Add(itngayDoanhThu);

						}

					}

				}

			}
			var tienNhapTam = 0;
			for (int i = 0; i < itemsSPNDTT.Count(); i++)
			{
				tienNhapTam += itemsSPNDTT[i].GiaNhapLieu * itemsSPNDTT[i].SL;
			}
			//var tienNhap = tienNhapTam;

			itemsDTNDTT.Add(new DoanhThuThang()
			{
				TienNhap = (float)tienNhapTam,
				TienThuDuoc = thuDuoc
			});
			return itemsDTNDTT;
		}
		System.Collections.ArrayList dataNDT;
		class NgayDoanhthu
		{
			public string name { get; set; }
			public float amount { get; set; }
			public NgayDoanhthu(string name, float amount)
			{
				this.name = name;
				this.amount = amount;
			}

		}
		System.Collections.ArrayList dataThangDT;
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dataThangDT = new System.Collections.ArrayList();
			var itemNDTDTT = getItemDTNDTT();
			for (var i = 0; i < itemNDTDTT.Count(); i++)
			{
				dataThangDT.Add(new NgayDoanhthu("Tiền chi", itemNDTDTT[i].TienNhap));
				dataThangDT.Add(new NgayDoanhthu("Tiền thu", itemNDTDTT[i].TienThuDuoc));
			}
			chartThangDoanhThu.ItemsSource = dataThangDT;
		}
	}
}
