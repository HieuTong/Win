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
	/// Interaction logic for BieuDoThongKeDoanhThuTheoNgay.xaml
	/// </summary>
	public partial class BieuDoThongKeDoanhThuTheoNgay : Window
	{
		public delegate void SendNgay(string n);
		public SendNgay Sender;
		public BieuDoThongKeDoanhThuTheoNgay()
		{
			InitializeComponent();
			Sender = new SendNgay(GetNgay);
		}
		public static string NgayTK;
		private void GetNgay(string n)
		{
			NgayTK = n;
		}
		class DoanhThuNgay
		{
			public float TienThuDuoc { get; set; }
			public float TienNhap { get; set; }
		}
		class SanPhamNgayDoanhThu
		{
			//public string MaSP { get; set; }
			public int GiaNhapLieu { get; set; }
			public int SL { get; set; }
		}

		private List<DoanhThuNgay> getItemDTN()
		{
			var itemsDTN = new List<DoanhThuNgay>();
			var itemsSPN = new List<SanPhamNgayDoanhThu>();
			var db = new STOREEntities();
			var thuDuoc = (float)0;
			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(NgayTK))
				{
					//var thuDuoc = 0;
					thuDuoc += (float)item.TongTien;
					var mahoadon = item.MaHoaDon;
					foreach(var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							var msp = para.MaSanPham;
							var sp_ = db.SanPhams.Find(msp);
							var soluong = (int)para.SoLuong;
							var itngayDoanhThu = new SanPhamNgayDoanhThu()
							{
								//MaSP = msp,
								GiaNhapLieu = (int)sp_.GiaNhap,
								SL = soluong

							};
							itemsSPN.Add(itngayDoanhThu);
					
						}

					}
					
				}
				
			}
			var tienNhapTam = 0;
			for (int i = 0; i < itemsSPN.Count(); i++)
			{
				tienNhapTam += itemsSPN[i].GiaNhapLieu * itemsSPN[i].SL;
			}
			//var tienNhap = tienNhapTam;
			
			itemsDTN.Add(new DoanhThuNgay()
			{
				TienNhap = (float)tienNhapTam,
				TienThuDuoc = thuDuoc
			});
			return itemsDTN;
		}
		System.Collections.ArrayList dataNDT;
		class NgayDoanhthu
		{
			public string name { get; set; }
			public float amount { get; set; }
			public NgayDoanhthu(string name,float amount)
			{
				this.name = name;
				this.amount = amount;
			}
			
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dataNDT = new System.Collections.ArrayList();
			var itemNDT = getItemDTN();
			for(var i = 0; i < itemNDT.Count(); i++)
			{
				dataNDT.Add(new NgayDoanhthu("Tiền chi",itemNDT[i].TienNhap));
				dataNDT.Add(new NgayDoanhthu("Tiền thu", itemNDT[i].TienThuDuoc));
			}
			chartNgayDoanhThu.ItemsSource = dataNDT;
			
		}
	}
}

