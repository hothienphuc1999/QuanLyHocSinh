using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for HPNo.xaml
    /// </summary>
    public partial class HPNo : Window
    {
        public HPNo()
        {
            InitializeComponent();
        }

        private void SaveHocPhiNoButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssignCodeTextBox.Text != "" && DeptCodeTextBox.Text != "")
            {
                int madk = int.Parse(AssignCodeTextBox.Text);
                int mano = int.Parse(DeptCodeTextBox.Text);
                DateTime thangno = new DateTime(MonthDeptPicker.SelectedDate.Value.Year, MonthDeptPicker.SelectedDate.Value.Month, 1);
                int tienno = int.Parse(DeptTextBox.Text);
                HocPhiNoDTO hpno = new HocPhiNoDTO(mano, thangno, tienno, madk, null);
                int rowAffected = HocPhiNoBUS.UpdateHocPhiNo(hpno);
                MessageBox.Show($"{rowAffected} học phí nợ đã được cập nhật");
            }
        }

        private void RefresDeptButton_Click(object sender, RoutedEventArgs e)
        {
            LoadHocPhiNoOfLopHoc();
        }

        private void LoadGiaoVien()
        {
            List<GiaoVienDTO> giaoVien = GiaoVienBUS.LoadAllGiaoVien();
            TeacherComboBox.ItemsSource = giaoVien;
        }

        private void LoadLopHocOfGiaoVienWithNienKhoa(int magv, string nienkhoa)
        {
            List<LopHocDTO> lophoc = LopHocBUS.FindLopHocByIDGiaoVienWithNienKhoa(magv, nienkhoa);
            ClassComboBox.ItemsSource = lophoc;
        }

        private void LoadNienKhoa(int magv)
        {
            List<string> nienkhoa = LopHocBUS.GetAllNienKhoaInLopHoc(magv);
            YearComboBox.ItemsSource = nienkhoa;
        }

        private void MonthDeptPicker_Loaded(object sender, RoutedEventArgs e)
        {
            MonthDeptPicker.SelectedDate = DateTime.Now;
        }

        private void MonthDeptPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TeacherComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGiaoVien();
        }

        private void TeacherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GiaoVienDTO giaovien = TeacherComboBox.SelectedItem as GiaoVienDTO;
            YearComboBox.SelectedIndex = -1;
            if (giaovien != null)
            {
                LoadNienKhoa(giaovien.MaGiaoVien);
            }
            else
            {
                YearComboBox.ItemsSource = null;
            }
        }

        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GiaoVienDTO giaovien = TeacherComboBox.SelectedItem as GiaoVienDTO;
            string nienkhoa = YearComboBox.SelectedItem as string;
            if (nienkhoa != null && giaovien != null)
            {
                LoadLopHocOfGiaoVienWithNienKhoa(giaovien.MaGiaoVien, nienkhoa);
            }
            else
            {
                ClassComboBox.ItemsSource = null;
            }
        }

        private void LoadHocPhiNoOfLopHoc()
        {
            LopHocDTO lophoc = ClassComboBox.SelectedItem as LopHocDTO;
            DateTime month = new DateTime(MonthDeptPicker.SelectedDate.Value.Year, MonthDeptPicker.SelectedDate.Value.Month, 1);
            if (lophoc != null)
            {
                List<HocPhiNoDTO> result = HocPhiNoBUS.GetHocPhiNoByIDLopHocAndMonth(lophoc.MaLopHoc, month);
                DeptDataGrid.ItemsSource = result;
                int total = result.Sum(p => p.TienNo);
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                TotalOfDayTextbox.Text = $"Tổng nợ: {total.ToString("#,###", cul.NumberFormat)} đ";
            }
        }

        private void ClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadHocPhiNoOfLopHoc();
        }

        private void ExportDeptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThemHocPhi_Click(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null && MonthDeptPicker.SelectedDate != null)
            {
                int malh = (ClassComboBox.SelectedItem as LopHocDTO).MaLopHoc;
                DateTime thang = new DateTime(MonthDeptPicker.SelectedDate.Value.Year, MonthDeptPicker.SelectedDate.Value.Month, 1);
                ThemHocPhiNo window = new ThemHocPhiNo(malh, thang);
                window.Show();
            }
        }

        private void XoaHocPhi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
               "Bạn có chắc chắn muốn xóa các học phí nợ đang đánh dấu chọn? \n" +
               "Toàn bộ dữ liệu liên quan đến học phí nợ sẽ bị mất!",
               "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                int rowAffected = 0;
                foreach (HocPhiNoDTO hpno in DeptDataGrid.SelectedItems)
                {
                    rowAffected += HocPhiNoBUS.DeleteHocPhiNo(hpno.MaDangKy, hpno.MaNo);
                }
                MessageBox.Show($"{rowAffected} học sinh đã được xóa");
            }
        }
    }
}
