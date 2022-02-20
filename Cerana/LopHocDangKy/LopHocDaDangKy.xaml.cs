using BUS;
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

namespace Cerana.LopHocDangKy
{
    /// <summary>
    /// Interaction logic for LopHocDaDangKy.xaml
    /// </summary>
    public partial class LopHocDaDangKy : Window
    {
        public LopHocDaDangKy(int mahs)
        {
            InitializeComponent();
            ListDangKyDataGrid.ItemsSource = LopHocDangKyBUS.GetLopHocDangKyByIDHocSinh(mahs);
        }
    }
}
