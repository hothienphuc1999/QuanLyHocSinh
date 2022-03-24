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

namespace Cerana.HocPhiNo
{
    /// <summary>
    /// Interaction logic for HocPhiDangNo.xaml
    /// </summary>
    public partial class HocPhiDangNo : Window
    {
        public HocPhiDangNo(int mahs)
        {
            InitializeComponent();
            LoadHocPhiNo(mahs);
        }
        private void LoadHocPhiNo(int mahs)
        {
            DeptDataGrid.ItemsSource = HocPhiNoBUS.FindHocPhiNoByIDHocSinh(mahs);
        }
    }
}
