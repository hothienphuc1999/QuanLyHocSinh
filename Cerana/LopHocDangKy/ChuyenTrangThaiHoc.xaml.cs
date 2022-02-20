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
    /// Interaction logic for ChuyenTrangThaiHoc.xaml
    /// </summary>
    public partial class ChuyenTrangThaiHoc : Window
    {
        List<LopHocDangKyDTO> list = new List<LopHocDangKyDTO>();
        public ChuyenTrangThaiHoc(List<LopHocDangKyDTO> dsdk)
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
            foreach (LopHocDangKyDTO dk in list)
            {
                dk.TinhTrang = false;
                dk.NgayKetThuc = NgayKTDatePicker.SelectedDate.Value;
                rowAffected += LopHocDangKyBUS.UpdateLopHocDangKy(dk);
            }
            MessageBox.Show($"{rowAffected} học sinh đã được cập nhật");
        }

        private void NgayKTDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            NgayKTDatePicker.SelectedDate = DateTime.Now;
        }
    }
}
