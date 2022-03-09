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

namespace Cerana.LopHocDangKy
{
    /// <summary>
    /// Interaction logic for ChuyenLop.xaml
    /// </summary>
    public partial class ChuyenLop : Window
    {
        List<LopHocDangKyDTO> list;
        public ChuyenLop(List<LopHocDangKyDTO> dangkys)
        {
            InitializeComponent();
            list = dangkys;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int rowAffected = 0;
            LopHocDTO lophoc = ClassComboBox.SelectedItem as LopHocDTO;
            foreach (LopHocDangKyDTO dk in list)
            {
                dk.TinhTrang = false;
                dk.NgayKetThuc = NgayCLDatePicker.SelectedDate;
                LopHocDangKyDTO dangkymoi = new LopHocDangKyDTO(
                    -1,
                    NgayCLDatePicker.SelectedDate,
                    null,
                    true,
                    dk.MaHocSinh,
                    lophoc.MaLopHoc,
                    "",
                    null,
                    null,
                    0,
                    0);
                LopHocDangKyBUS.UpdateLopHocDangKy(dk);
                LopHocDangKyBUS.CreateLopHocDangKy(dangkymoi);
                rowAffected++;
            }
            MessageBox.Show($"{rowAffected} học sinh đã được chuyển lớp");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadGiaoVien()
        {
            List<GiaoVienDTO> giaoVien = GiaoVienBUS.LoadAllGiaoVien();
            TeacherComboBox.ItemsSource = giaoVien;
        }
        private void NgayCLDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            NgayCLDatePicker.SelectedDate = DateTime.Now;
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

        private void ClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
