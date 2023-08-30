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

namespace Test1
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

        Models.QLBHContext db = new Models.QLBHContext();

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var data = from x in db.Sanphams
                       select x;
            dg.ItemsSource = data.ToList();
        }
    }
}
// Scaffold-DbContext "Data Source=HUYNHHOAI\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer –OutputDir Models