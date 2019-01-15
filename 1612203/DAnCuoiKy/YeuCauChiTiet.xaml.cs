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
	/// Interaction logic for YeuCauChiTiet.xaml
	/// </summary>
	public partial class YeuCauChiTiet : Window
	{
		public YeuCauChiTiet()
		{
			InitializeComponent();
		}

		private void btnCT_Click(object sender, RoutedEventArgs e)
		{
			var flag = 0;
			var windows = new ChiTietSanPham();
			var db = new STOREEntities();
			//windows.Sender(txtTen.Text.ToString());
			//windows.Show();
			foreach (var index in db.SanPhams)
			{
				if (index.TenSP.ToString().ToLower() == txtTen.Text.ToString())
				{
					
					flag = 1;
					break;

				}
			}
			if (flag == 0)
			{
				MessageBox.Show("Không tìm thấy xin vui lòng thử lại");
			}
			else
			{
				//windows.Sender(txtTen.Text.ToString());
				windows.Show();
			}

		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
