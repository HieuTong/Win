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
	/// Interaction logic for BieuDoThongKeDoanhThuTheoNam.xaml
	/// </summary>
	public partial class BieuDoThongKeDoanhThuTheoNam : Window
	{
		public delegate void SendNam(string n);
		public SendNam Sender;
		System.Collections.ArrayList dataNamDT;
		public BieuDoThongKeDoanhThuTheoNam()
		{
			InitializeComponent();
			Sender = new SendNam(GetNam);
		}
		public static string NamTK;
		private void GetNam(string n)
		{
			NamTK = n;
		}
		class DoanhThuNam
		{
			public float TienThuDuoc { get; set; }
			public float TienNhap { get; set; }
		}
		class SanPhamNamDoanhThu
		{
			//public string MaSP { get; set; }
			public int GiaNhapLieu { get; set; }
			public int SL { get; set; }
		}

		private List<DoanhThuNam> getItemDTN()
		{
			var itemsDTNDTN = new List<DoanhThuNam>();
			var itemsSPNDTN = new List<SanPhamNamDoanhThu>();
			var db = new STOREEntities();
			var thuDuoc = (float)0;
			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(NamTK))
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
							var itngayDoanhThu = new SanPhamNamDoanhThu()
							{
								//MaSP = msp,
								GiaNhapLieu = (int)sp_.GiaNhap,
								SL = soluong

							};
							itemsSPNDTN.Add(itngayDoanhThu);

						}

					}

				}

			}
			var tienNhapTam = 0;
			for (int i = 0; i < itemsSPNDTN.Count(); i++)
			{
				tienNhapTam += itemsSPNDTN[i].GiaNhapLieu * itemsSPNDTN[i].SL;
			}
			//var tienNhap = tienNhapTam;

			itemsDTNDTN.Add(new DoanhThuNam()
			{
				TienNhap = (float)tienNhapTam,
				TienThuDuoc = thuDuoc
			});
			return itemsDTNDTN;
		}
		System.Collections.ArrayList dataNDTDTN;
		class NamDoanhThu
		{
			public string name { get; set; }
			public float amount { get; set; }
			public NamDoanhThu(string name, float amount)
			{
				this.name = name;
				this.amount = amount;
			}

		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dataNDTDTN = new System.Collections.ArrayList();
			var itemNDT = getItemDTN();
			for (var i = 0; i < itemNDT.Count(); i++)
			{
				dataNDTDTN.Add(new NamDoanhThu("Tiền chi", itemNDT[i].TienNhap));
				dataNDTDTN.Add(new NamDoanhThu("Tiền thu", itemNDT[i].TienThuDuoc));
			}
			chartNamDoanhThu.ItemsSource = dataNDTDTN;
		}
	}
}
