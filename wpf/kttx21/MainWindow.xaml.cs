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
using kttx21.Models;
using System.Text.RegularExpressions;
using System.Reflection;


namespace kttx21
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
            var dl = from x in db.SanPhams
                     select new {x.MaLoai, x.MaSp, x.TenSp, x.DonGia, x.SoLuong, ThanhTien = x.SoLuong * x.DonGia};

            dgSanPham.ItemsSource = dl.ToList();
        }

        public void HienThiCB()
        {
            var dl = from x in db.LoaiSanPhams
                     select x;

            cbLoai.ItemsSource = dl.ToList();

            cbLoai.DisplayMemberPath = "TenLoai";
            cbLoai.SelectedValuePath = "MaLoai";
            cbLoai.SelectedIndex = -1;
        }

        public bool CheckDL()
        {
            string notice = "";

            if (txtDonGia.Text == "" || txtMaSp.Text == "" || txtTenSp.Text == "" || txtSoLuong.Text == "" || cbLoai.SelectedIndex < 0)
            {
                notice += "hay nhap day du du lieu!";
            }
            else
            {
                if (!Regex.IsMatch(txtSoLuong.Text, @"\d+"))
                {
                    notice += "so luong phai la so";
                }
                else
                {
                    int soluong = int.Parse(txtSoLuong.Text);
                    if (soluong <= 0)
                    {
                        notice += "So luong phai lon hon 0";
                    }
                }

                if (!Regex.IsMatch(txtDonGia.Text, @"\d+"))
                {
                    notice += "don gia phai la so";
                }
                else
                {
                    float dongia = float.Parse(txtDonGia.Text);
                    if (dongia <= 0)
                    {
                        notice += "don gia phai lon hon 0";
                    }
                }
            }

            if (notice != "")
            {
                MessageBox.Show(notice, "THONG BAO!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            txtDonGia.Text = "";
            txtMaSp.Text = "";
            txtTenSp.Text = "";
            txtSoLuong.Text = "";
            cbLoai.SelectedIndex = -1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDL();
            HienThiCB();
        }

        private void dgSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic rowSelected = dgSanPham.SelectedItem;

            if (rowSelected != null)
            {
                txtMaSp.Text = rowSelected.MaSp;

                txtTenSp.Text = rowSelected.TenSp;

                cbLoai.SelectedValue = rowSelected.MaLoai;

                txtSoLuong.Text = rowSelected.SoLuong.ToString();

                txtDonGia.Text = rowSelected.DonGia.ToString();
            }
        }

        private void ButtonThem_Click(object sender, RoutedEventArgs e)
        {
            var query = db.SanPhams.SingleOrDefault(x => x.MaSp.Equals(txtMaSp.Text));

            if (query != null)
            {
                MessageBox.Show("da ton tai ma san pham!", "THONG BAO!!");
                HienThiDL();
            }
            else
            {
                try
                {
                    if (CheckDL())
                    {
                        SanPham newProduct = new SanPham();

                        newProduct.MaSp = txtMaSp.Text;

                        newProduct.TenSp = txtTenSp.Text;

                        newProduct.SoLuong = int.Parse(txtSoLuong.Text); 

                        newProduct.DonGia = float.Parse(txtDonGia.Text);

                        LoaiSanPham loaiSp = (LoaiSanPham)cbLoai.SelectedItem;
                        newProduct.MaLoai = loaiSp.MaLoai;

                        db.SanPhams.Add(newProduct);

                        db.SaveChanges();

                        HienThiDL();

                        Clear();

                        MessageBox.Show("them san pham thanh cong !", "THONG BAO!!");
                    }
                }
                catch (Exception e1)
                { 
                    MessageBox.Show("Co loi khi them: " +  e1.Message, "THONG BAO!!");
                }
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sp = db.SanPhams.SingleOrDefault( t => t.MaSp.Equals(txtMaSp.Text) );

                if (sp == null)
                {
                    MessageBox.Show("Khong tim thay san pham can sua!", "THONG BAO!!");
                    HienThiDL();
                }
                else
                {
                    if (CheckDL())
                    {
                        sp.TenSp = txtTenSp.Text;
                        sp.SoLuong = int.Parse(txtSoLuong.Text);
                        sp.DonGia = float.Parse(txtDonGia.Text);
                        LoaiSanPham loaiSP = (LoaiSanPham)cbLoai.SelectedItem;
                        sp.MaLoai = loaiSP.MaLoai;

                        db.SaveChanges();

                        HienThiDL();

                        Clear();

                        MessageBox.Show("sua san pham thanh cong !", "THONG BAO!!");
                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Co loi khi them: " + e1.Message, "THONG BAO!!");
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            var productDeleted = db.SanPhams.SingleOrDefault(t => t.MaSp.Equals(txtMaSp.Text));

            if (productDeleted == null)
            {
                MessageBox.Show("Khong tim thay san pham can xoa!", "THONG BAO!!");
                HienThiDL();
            } 
            else
            {
                MessageBoxResult rs = MessageBox.Show("Ban co muon xoa san pham nay khong?", "THONG BAO!!", MessageBoxButton.YesNo);

                if (rs == MessageBoxResult.Yes)
                {
                    db.SanPhams.Remove(productDeleted);
                    db.SaveChanges();

                    HienThiDL();

                    Clear();

                    MessageBox.Show("San pham da duoc xoa.", "THONG BAO");
                }    
            }
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            var sp = from x in db.SanPhams
                     join y in db.LoaiSanPhams
                     on x.MaLoai equals y.MaLoai
                     where y.TenLoai == cbLoai.Text
                     select new { x.MaLoai, x.MaSp, x.TenSp, x.DonGia, x.SoLuong, ThanhTien = x.SoLuong * x.DonGia };

            dgSanPham.ItemsSource = sp.ToList();
        }

        private void BtnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWd = new Window1();
            
            newWd.Show();
        }
    }
}
