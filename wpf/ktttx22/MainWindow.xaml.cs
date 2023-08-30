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
using ktttx22.Models;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace ktttx22
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

        QLBanHangContext db = new QLBanHangContext();

        public void HienThiDL()
        {
            var sp = from x in db.SanPhams
                     select new { x.MaLoai, x.MaSp, x.TenSp, x.DonGia, x.SoLuong, ThanhTien = x.DonGia * x.SoLuong };

            dgSanPham.ItemsSource = sp.ToList();
        }

        public void HienThiCB()
        {
            var loai = from x in db.LoaiSanPhams
                       select x;

            cbLoaiSP.ItemsSource = loai.ToList();
            cbLoaiSP.DisplayMemberPath = "TenLoai";
            cbLoaiSP.SelectedValuePath = "MaLoai";
            cbLoaiSP.SelectedIndex = -1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDL();
            HienThiCB();
        }

        public bool checkDL()
        {
            string notice = "";

            if (txtDonGia.Text == "" || txtSoLuong.Text == "" || txtMaSp.Text == "" || txtTenSp.Text== "" || cbLoaiSP.SelectedIndex < 0)
            {
                notice += "Nhap day du thong tin";
            }
            else
            {
                if (!Regex.IsMatch(txtSoLuong.Text, @"\d+"))
                {
                    notice += "\nSo luong phai la so!";
                }
                else
                {
                    int sl = int.Parse(txtSoLuong.Text);
                    if (sl <= 0)
                    {
                        notice += "\nSo luong phai lon hon 0";
                    }
                }

                if (!Regex.IsMatch(txtDonGia.Text, @"\d+"))
                {
                    notice += "\nDon gia phai la so!";
                }
                else
                {
                    float sl = float.Parse(txtDonGia.Text);
                    if (sl <= 0)
                    {
                        notice += "\nDon gia phai lon hon 0";
                    }
                }
            }

            if (notice != "")
            {
                MessageBox.Show(notice, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            var query = db.SanPhams.SingleOrDefault(x => x.MaSp.Equals(txtMaSp.Text));

            if (query != null)
            {
                MessageBox.Show("Ma SP da ton tai!", "THONG BAO!!");
                HienThiDL();
            }
            else
            {
                try
                {
                    if (checkDL())
                    {
                        SanPham sp = new SanPham();
                        sp.MaSp = txtMaSp.Text;
                        sp.TenSp = txtTenSp.Text;
                        sp.DonGia = float.Parse(txtDonGia.Text);
                        sp.SoLuong = int.Parse(txtSoLuong.Text);

                        LoaiSanPham loaisp = (LoaiSanPham)cbLoaiSP.SelectedItem;
                        sp.MaLoai = loaisp.MaLoai;

                        db.SanPhams.Add(sp);

                        db.SaveChanges();

                        MessageBox.Show("Them SP thanh cong!", "THONG BAO!!");

                        HienThiDL();
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "THONG BAO!!");
                }
            }
        }

        private void dgSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic itemSelected = dgSanPham.SelectedItem;

            if (itemSelected != null)
            {
                txtMaSp.Text = itemSelected.MaSp;
                txtTenSp.Text = itemSelected.TenSp;
                cbLoaiSP.SelectedValue = itemSelected.MaLoai;
                txtDonGia.Text = itemSelected.DonGia.ToString();   
                txtSoLuong.Text = itemSelected.SoLuong.ToString();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sp = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMaSp.Text));

                if (sp == null)
                {
                    MessageBox.Show("Khong tim thay SP can sua!", "THONG BAO!!");
                    HienThiDL();
                }
                else
                {
                    if (checkDL())
                    {
                        sp.TenSp = txtTenSp.Text;
                        sp.DonGia = float.Parse(txtDonGia.Text);
                        sp.SoLuong = int.Parse(txtSoLuong.Text);

                        LoaiSanPham loaisp = (LoaiSanPham)cbLoaiSP.SelectedItem;
                        sp.MaLoai = loaisp.MaLoai;

                        db.SaveChanges();

                        MessageBox.Show("Sua SP thanh cong!", "THONG BAO!!");

                        HienThiDL();
                    }
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "THONG BAO!!");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.SanPhams.SingleOrDefault(x => x.MaSp.Equals(txtMaSp.Text));

            if (sp == null)
            {
                MessageBox.Show("Khong tim thay SP can xoa!", "THONG BAO!!");
                HienThiDL() ;
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Ban co muon xoa SP nay khong?", "THONG BAO!!", MessageBoxButton.YesNo);

                if (rs == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(sp);

                    db.SaveChanges();

                    MessageBox.Show("Xoa SP thanh cong!", "THONG BAO!!");

                    HienThiDL();
                }
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var sp = from x in db.SanPhams
                     join y in db.LoaiSanPhams
                     on x.MaLoai equals y.MaLoai
                     where y.TenLoai == cbLoaiSP.Text
                     select new { x.MaLoai, x.MaSp, x.TenSp, x.DonGia, x.SoLuong, ThanhTien = x.DonGia * x.SoLuong };

            dgSanPham.ItemsSource = sp.ToList();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Window1 wd = new Window1();
            wd.Show();
        }
    }
}
