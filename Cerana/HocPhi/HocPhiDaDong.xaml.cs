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

namespace Cerana.HocPhi
{
    /// <summary>
    /// Interaction logic for HocPhiDaDong.xaml
    /// </summary>
    public partial class HocPhiDaDong : Window
    {
        public HocPhiDaDong(int mahs)
        {
            InitializeComponent();
            LoadHocPhi(mahs);
        }

        private void LoadHocPhi(int mahs)
        {
            TuitionDataGrid.ItemsSource = HocPhiBUS.GetHocPhiByIDHocSinh(mahs);
        }

        private void XoaHocPhi_Click(object sender, RoutedEventArgs e)
        {
            int rowAffected = 0;
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa các học phí đang đánh dấu chọn? \n" +
                "Toàn bộ dữ liệu liên quan đến học phí sẽ bị mất!",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (TuitionDataGrid.SelectedItems != null)
                {
                    foreach (HocPhiDTO hocphi in TuitionDataGrid.SelectedItems)
                    {
                        rowAffected += HocPhiBUS.DeleteHocPhi(hocphi.MaDangKy, hocphi.MaHocPhi);
                    }
                }
                MessageBox.Show($"{rowAffected} học phí đã được xóa!");
            }
        }
    }
}
