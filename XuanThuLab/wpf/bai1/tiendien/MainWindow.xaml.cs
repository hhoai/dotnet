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

namespace tiendien
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

        private void btnTinh_clicked(object sender, RoutedEventArgs e)
        {
            float csc, csm, soTT, trDM, vDM, tongTien;
            csc = float.Parse(ipCSC.Text);
            csm = float.Parse(ipCSM.Text);

            soTT = csm - csc;

            if (soTT <= 50)
            {
                trDM = soTT;
                vDM = 0;
            }
            else
            {
                trDM = 50;
                vDM = soTT - 50;
            }

            tongTien = trDM * 500 + vDM * 1000;

            soTieuThu.Text = soTT + "";
            kwTDM.Text = trDM + "";
            kwVDM.Text = vDM + "";
            iptongTien.Text = tongTien + "";
        }

        private void btnIn_clicked(object sender, RoutedEventArgs e)
        {
            showText.Text = cbTen.Text + "\nSố kw tiêu thụ: " + soTieuThu.Text + "\nTổng tiền: " + iptongTien.Text;
        }

        private void btnThoat_clicked(object sender, RoutedEventArgs e)
        {
            soTieuThu.Text = "";
            kwVDM.Text = "";
            kwTDM.Text = "";
            showText.Text = "";
            ipCSC.Text = "";
            ipCSM.Text = "";
            iptongTien.Text = "";
            cbTen.Text = "";
        }
    }
}
