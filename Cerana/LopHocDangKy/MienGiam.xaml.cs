using BUS;
using DTO;
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

namespace Cerana
{
    /// <summary>
    /// Interaction logic for MienGiam.xaml
    /// </summary>
    public partial class MienGiam : Window
    {
        List<LopHocDangKyDTO> list = new List<LopHocDangKyDTO>();
        public MienGiam(List<LopHocDangKyDTO> dsdk)
        {
            InitializeComponent();
            list = dsdk;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int rowAffected = 0;
            string miengiam = MienGiamTextBox.Text;
            foreach (LopHocDangKyDTO dk in list)
            {
                dk.Miengiam = miengiam;
                rowAffected += LopHocDangKyBUS.UpdateLopHocDangKy(dk);
            }
            MessageBox.Show($"{rowAffected} học sinh đã được cập nhật");
        }
    }
}
