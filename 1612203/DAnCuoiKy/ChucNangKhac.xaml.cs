using Aspose.Cells;
using Aspose.Words;
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
	/// Interaction logic for ChucNangKhac.xaml
	/// </summary>
	public partial class ChucNangKhac : Window
	{
		public ChucNangKhac()
		{
			InitializeComponent();
		}

		private void btnLoc_Click(object sender, RoutedEventArgs e)
		{
			var windows = new LocTheoGia();
			windows.Show();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnTK_Click(object sender, RoutedEventArgs e)
		{
			var windows = new TimKiemTheoTen();
			windows.Show();
		}

		private void btnExcel_Click(object sender, RoutedEventArgs e)
		{
			var db = new STOREEntities();
			var s = "";
			foreach (var index in db.SanPhams)
			{
				s = index.MaSanPham;
			}
			int n = int.Parse(s.Substring(2, 3));
			n = n + 1;
			if (n < 10)
			{
				s = "SP00" + n.ToString();
			}
			else if (n < 100)
			{
				s = "SP0" + n.ToString();
			}
			else
			{
				s = "SP" + n.ToString();
			}

			List<string> dataExcel = new List<string>();
			dataExcel.Add(s);
			Workbook wb = new Workbook("Data.xlsx");
			Worksheet sheet = wb.Worksheets[0];

			char column = 'B';
			int row = 2;
			Cell cell = sheet.Cells[$"{column}{row}"];
			while (cell.Value != null)
			{
				dataExcel.Add(cell.Value.ToString());
				column++;
				cell = sheet.Cells[$"{column}{row}"];
			}
			//MessageBox.Show(dataExcel.Count.ToString());
			var i = 0;
			var spAddExcel = new SanPham()
			{
				MaSanPham = dataExcel[i].ToString(),
				MaLoaiSP = dataExcel[++i].ToString(),
				TenSP = dataExcel[++i].ToString(),
				GiaNhap = int.Parse(dataExcel[++i]),
				GiaBan = int.Parse(dataExcel[++i]),
				SoLuong = int.Parse(dataExcel[++i]),
				TrangThai = int.Parse(dataExcel[++i]),
				ImagePath = dataExcel[++i].ToString()
			};
			MessageBox.Show(spAddExcel.MaSanPham+spAddExcel.MaLoaiSP);
			db.SanPhams.Add(spAddExcel);
			db.SaveChanges();
			MessageBox.Show("Dữ liệu Excel được thêm vào dữ liệu");
		}
	}
}
