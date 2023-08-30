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
using ktttx22.Models;

namespace ktttx22
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        QLBanHangContext db = new QLBanHangContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var sp = from x in db.SanPhams
                     join y in db.LoaiSanPhams
                     on x.MaLoai equals y.MaLoai
                     where y.MaLoai == "L01"
                     select new { y.TenLoai, x.MaSp, x.TenSp, x.DonGia, x.SoLuong, ThanhTien = x.DonGia * x.SoLuong };

            dgSanPham.ItemsSource = sp.ToList();
        }
    }
}
