using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			InitializeComponent();
		}
		/*
		class SanPhama
		{
			public string MaSanPham { get; set; }
			public string MaLoaiSP { get; set; }
			public string TenSP { get; set; }
			public int GiaNhap { get; set; }
			public int GiaBan { get; set; }
			public int SoLuong { get; set; }
			public int TrangThai { get; set; }
			public string ImagePath { get; set; }

		}*/
		private List<SanPham> getItem()
		{
			//var items = new List<SanPham>();
			var db = new STOREEntities();
			/*
			foreach(var index in db.SanPhams)
			{
				var item = new SanPham()
				{
					MaSanPham = index.MaSanPham,
					MaLoaiSP = index.MaLoaiSP,
					TenSP = index.TenSP,
					GiaNhap = (int)index.GiaNhap,
					GiaBan = (int)index.GiaBan,
					SoLuong = (int)index.SoLuong,
					TrangThai = (int)index.TrangThai,
					ImagePath = index.ImagePath
				};
				items.Add(item);
			}
			*/
			return db.SanPhams.ToList();
		}

		public int rowPerPage = 6;
		public int currentPage = 0;
		List<SanPham> items = new List<SanPham>();

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			currentPage = 1;
			items = getItem();
			
			lvSP.ItemsSource = items.Take(6);
			

		}

		
		private void btnPre_Click(object sender, RoutedEventArgs e)
		{
			if (currentPage == 1)
			{

			}
			else
			{
				currentPage--;
				lvSP.ItemsSource = items.Skip((currentPage - 1) * rowPerPage).Take(6);
			}
			
		}



		private void btnAf_Click(object sender, RoutedEventArgs e)
		{
			if (currentPage * 6 >= items.Count)
			{

			}
			else
			{
				currentPage++;
				lvSP.ItemsSource= items.Skip((currentPage - 1) * rowPerPage).Take(6);
			}

		}
		private void btnReload_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			List<SanPham> itemsReload = new List<SanPham>();
			foreach(var index in db.SanPhams)
			{
				if (index.TrangThai == 1)
				{
					
					itemsReload.Add(index);
				}
			}
			lvSP.ItemsSource = itemsReload;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThemSanPham();
			windows.Show();
		}

		private void btnChucNangKhac_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ChucNangKhac();
			windows.Show();
		}
		
		private void lvSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(lvSP.SelectedItem==null) return;
			var windows = new ChiTietSanPham(lvSP.SelectedItem as SanPham);
			windows.Show();
		}

		

		

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			var mahd = txtHD.Text;
			if (mahd == "")
			{
				MessageBox.Show("Vui lòng điền mã hóa đơn");
			}
			else
			{
				var db = new STOREEntities();
				var hoadon = db.HoaDons.Find(mahd);
				if (hoadon == null)
				{
					MessageBox.Show("Không tìm thấy mã hóa đơn");
				}
				else
				{
					var windows = new HoaDonChiTiet();
					windows.Sender(txtHD.Text);
					windows.Show();
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThongKeTheoSanPham();
			windows.Show();
		}

		private void btnThongTinBan_Click(object sender, RoutedEventArgs e)
		{
			var windows = new CuaSoBanHang();
			windows.Show();
		}

		private void btnDoanhThu_Click(object sender, RoutedEventArgs e)
		{
			var windows = new ThongKeTheoDoanhThu();
			windows.Show();
		}

		
	}
}
