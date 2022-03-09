using BUS;
using Cerana.LopHocDangKy;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cerana
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            AppTabControl.SelectedIndex = 0;
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            AppTabControl.SelectedIndex = 1;

        }

        private void ClassButton_Click(object sender, RoutedEventArgs e)
        {
            AppTabControl.SelectedIndex = 2;
        }

        private void TuitionButton_Click(object sender, RoutedEventArgs e)
        {
            AppTabControl.SelectedIndex = 3;
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StudentFirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string ten = StudentFirstNameTextBox.Text;
            string holot = StudentLastNameTextBox.Text;
            try
            {
                List<HocSinhDTO> list = HocSinhBUS.SearchHocSinhExact(holot, ten);
                string thongtinhhocsinh = "";
                if (list != null)
                {
                    foreach (HocSinhDTO hs in list)
                    {
                        thongtinhhocsinh += $"Họ tên: {hs.HoLot} {hs.Ten} - SĐT Phụ Huynh: {hs.SdtPhuHuynh} - Lớp: {hs.Lop}\n";
                    }
                    MessageBox.Show
                        (
                        $"Đã tồn tại các học sinh có cùng tên trong cơ sở dữ liệu: \n{thongtinhhocsinh}",
                        "Lưu ý",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchHocSinhByName(string holot, string ten)
        {
            List<HocSinhDTO> list = HocSinhBUS.SearchHocSinh(holot, ten);
            HocSinhDataGrid.ItemsSource = list;
        }
        private void SearchHocSinhByPhone(string sdthocsinh)
        {
            List<HocSinhDTO> list = HocSinhBUS.SearchHocSinhByPhone(sdthocsinh);
            HocSinhDataGrid.ItemsSource = list;
        }
        private void SearchHocSinhByParentPhone(string sdtphuhuynh)
        {
            List<HocSinhDTO> list = HocSinhBUS.SearchHocSinhByParentPhone(sdtphuhuynh);
            HocSinhDataGrid.ItemsSource = list;
        }
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)FindByComboBox.SelectedItem;
                string value = selectedItem.Content.ToString();
                switch (value)
                {
                    case "Tìm theo tên":
                        string[] hoten = SearchTextBox.Text.Split(' ');
                        string ten = hoten.Last();
                        string holot = "";
                        for (int i = 0; i < hoten.Length - 1; i++)
                        {
                            holot += hoten[i];
                        }
                        SearchHocSinhByName(holot, ten);
                        break;
                    case "Tìm theo sđt học sinh":
                        SearchHocSinhByPhone(SearchTextBox.Text);
                        break;
                    case "Tìm theo sđt phụ huynh":
                        SearchHocSinhByParentPhone(SearchTextBox.Text);
                        break;
                }
            }
        }


        private void DangKyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<int> list = new List<int>();
            foreach (HocSinhDTO hocsinh in HocSinhDataGrid.SelectedItems)
            {
                list.Add(hocsinh.MaHS);
            }
        }

        private void HocSinhDataGrid_Unselected(object sender, RoutedEventArgs e)
        {
            (sender as DataGrid).SelectedItem = null;
        }


        private void SelectStudentCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SelectStudentCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void QuanLyLopMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HocSinhDTO selected = HocSinhDataGrid.SelectedItem as HocSinhDTO;
            if (selected != null)
            {
                LopHocDangKy.LopHocDaDangKy dangkys = new LopHocDaDangKy(selected.MaHS);
                dangkys.Show();
            }
        }

        private void XoaHocSinhMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa các học sinh đang đánh dấu chọn? \n" +
                "Toàn bộ dữ liệu liên quan đến học sinh sẽ bị mất!",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                int rowAffected = 0;
                foreach (HocSinhDTO hocsinh in HocSinhDataGrid.SelectedItems)
                {
                    rowAffected += HocSinhBUS.DeleteHocSinh(hocsinh.MaHS);
                }
                MessageBox.Show($"{rowAffected} học sinh đã được xóa");
            }

        }
        private void SaveHocSinhButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentLastNameTextBox.Text != "" && StudentFirstNameTextBox.Text != "")
            {
                string holot = StudentLastNameTextBox.Text;
                string ten = StudentFirstNameTextBox.Text;
                string sdthocsinh = StudentPhoneNumberTxtBox.Text;
                string sdtphuhuynh = ParentPhoneNumberTxtBox.Text;
                string lop = ClassTextBox.Text;
                string nienkhoa = YearTextBox.Text;
                bool xacnhan = (bool)VerifiedPhoneCheckbox.IsChecked;


                if (StudentCodeTextBox.Text == "")
                {
                    HocSinhDTO hocSinh = new HocSinhDTO(-1, holot, ten, sdthocsinh, sdtphuhuynh, lop, nienkhoa, xacnhan, null);
                    int result = HocSinhBUS.CreateHocSinh(hocSinh);
                    MessageBox.Show($"{result} học sinh đã được thêm");
                }
                else
                {
                    int mahs = int.Parse(StudentCodeTextBox.Text);
                    HocSinhDTO hocSinh = new HocSinhDTO(mahs, holot, ten, sdthocsinh, sdtphuhuynh, lop, nienkhoa, xacnhan, null);
                    int result = HocSinhBUS.UpdateHocSinh(hocSinh);
                    MessageBox.Show($"{result} học sinh đã được cập nhật");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ họ và tên của học sinh", "Lưu ý", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StudentPhoneNumberTxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string sdthocsinh = StudentPhoneNumberTxtBox.Text;
            if (sdthocsinh != "" && sdthocsinh.Length != 10)
            {
                MessageBox.Show($"Số điện thoại này chỉ {sdthocsinh.Length} số", "Lưu ý");
            }
        }

        private void ParentPhoneNumberTxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string sdtphuhuynh = ParentPhoneNumberTxtBox.Text;
            if (sdtphuhuynh != "" && sdtphuhuynh.Length != 10)
            {
                MessageBox.Show($"Số điện thoại này chỉ {sdtphuhuynh.Length} số", "Lưu ý");
            }
        }

        private void DongHocPhiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (HocSinhDataGrid.SelectedItem != null)
            {
                HocSinhDTO hocsinh = HocSinhDataGrid.SelectedItem as HocSinhDTO;
                HocPhi.DongHocPhi dongHocPhi = new HocPhi.DongHocPhi(hocsinh.MaHS);
                dongHocPhi.Show();
            }
        }

        private void SaveLopButton_Click(object sender, RoutedEventArgs e)
        {
            string tenlh = ClassNameTextBox.Text;
            string nienkhoa = ClassYearTextBox.Text;
            string hocphilophoc = PriceTextBox.Text;
            int magv = (TeacherOfClassCBB.SelectedItem as GiaoVienDTO).MaGiaoVien;
            if (ClassCodeTextBox.Text == "")
            {
                LopHocDTO lophoc = new LopHocDTO(-1, tenlh, magv, hocphilophoc, nienkhoa, null, null, null, null);
                int result = LopHocBUS.CreateLopHoc(lophoc);
                MessageBox.Show($"{result} lớp học đã được thêm");
            }
            else
            {
                int malh = int.Parse(ClassCodeTextBox.Text);
                LopHocDTO lophoc = new LopHocDTO(malh, tenlh, magv, hocphilophoc, nienkhoa, null, null, null, null);
                int result = LopHocBUS.UpdateLopHoc(lophoc);
                MessageBox.Show($"{result} lớp học đã được cập nhật");
            }
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
        private void LoadHocSinhOfLopHoc()
        {
            LopHocDTO lophoc = ClassComboBox.SelectedItem as LopHocDTO;
            DateTime month = new DateTime(MonthPicker.SelectedDate.Value.Year, MonthPicker.SelectedDate.Value.Month, 1);
            if (lophoc != null)
            {
                List<LopHocDangKyDTO> result = LopHocDangKyBUS.FindLopHocDangKyByIDLopHoc(lophoc.MaLopHoc, month);
                StudyAssignDataGrid.ItemsSource = result;
            }
        }
        private void ClassComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadHocSinhOfLopHoc();
        }

        private void MonthPicker_Loaded(object sender, RoutedEventArgs e)
        {
            MonthPicker.SelectedDate = DateTime.Now;
        }

        private void AddClassButton_Click(object sender, RoutedEventArgs e)
        {
            ClassComboBox.SelectedIndex = -1;
        }

        private void DeleteClassButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClassCodeTextBox.Text != "")
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này?", "Xóa lớp học", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int result = LopHocBUS.DeleteLopHoc(int.Parse(ClassCodeTextBox.Text));
                    MessageBox.Show($"{result} lớp học đã xóa");
                }
            }
        }

        private void ThemLopHocMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedIndex != -1)
            {
                int malophoc = (ClassComboBox.SelectedItem as LopHocDTO).MaLopHoc;
                DangKyLopHoc lopHocDangKy = new DangKyLopHoc(malophoc);
                lopHocDangKy.Show();
            }
        }

        private void XoaDangKy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa các học sinh đang đánh dấu chọn? \n" +
                "Toàn bộ dữ liệu liên quan đến học sinh sẽ bị mất!",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                int rowAffected = 0;
                foreach (LopHocDangKyDTO dangky in StudyAssignDataGrid.SelectedItems)
                {
                    rowAffected += LopHocDangKyBUS.DeleteLopHocDangKy(dangky.MaDangKy);
                }
                MessageBox.Show($"{rowAffected} học sinh đã được xóa");
            }
        }

        private void RefreshAssignButton_Click(object sender, RoutedEventArgs e)
        {
            LoadHocSinhOfLopHoc();
        }

        private void SetIsNghiLuon_Click(object sender, RoutedEventArgs e)
        {
            List<LopHocDangKyDTO> list = new List<LopHocDangKyDTO>();
            foreach (LopHocDangKyDTO dangky in StudyAssignDataGrid.SelectedItems)
            {
                list.Add(dangky);
            }
            ChuyenTrangThaiHoc window = new ChuyenTrangThaiHoc(list);
            window.Show();
        }

        private void SetIsDangHoc_Click(object sender, RoutedEventArgs e)
        {
            int rowAffected = 0;
            foreach (LopHocDangKyDTO dangky in StudyAssignDataGrid.SelectedItems)
            {
                dangky.TinhTrang = true;
                dangky.NgayKetThuc = null;
                rowAffected += LopHocDangKyBUS.UpdateLopHocDangKy(dangky);
            }
            MessageBox.Show($"{rowAffected} học sinh đã được cập nhật");
        }

        private void MienGiam_Click(object sender, RoutedEventArgs e)
        {
            List<LopHocDangKyDTO> list = new List<LopHocDangKyDTO>();
            foreach (LopHocDangKyDTO dangky in StudyAssignDataGrid.SelectedItems)
            {
                list.Add(dangky);
            }
            MienGiam window = new MienGiam(list);
            window.Show();
        }

        private void ChuyenLop_Click(object sender, RoutedEventArgs e)
        {
            List<LopHocDangKyDTO> list = new List<LopHocDangKyDTO>();
            foreach (LopHocDangKyDTO dangky in StudyAssignDataGrid.SelectedItems)
            {
                list.Add(dangky);
            }
            ChuyenLop window = new ChuyenLop(list);
            window.Show();
        }

        private void HocPhiDaDongMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HocPhiNoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveHocPhiButton_Click(object sender, RoutedEventArgs e)
        {
            if (AssignCodeTextBox.Text != "" && TuitionCodeTextBox.Text != "")
            {
                int madk = int.Parse(AssignCodeTextBox.Text);
                int mahp = int.Parse(TuitionCodeTextBox.Text);
                DateTime thangdong = new DateTime(MonthTuition.SelectedDate.Value.Year, MonthTuition.SelectedDate.Value.Month, 1);
                int giatien = int.Parse(PriceTuitionTextBox.Text);
                DateTime thoigiandong = TimeOfTuition.SelectedDate.Value;
                string nguoidong = Customer.Text;
                string nguoithu = Cashier.Text;
                string dongtai = TuitionAt.Text;
                string sobienlaigiay = BillNumberTextBox.Text;
                DateTime thoigianchinhsua = DateTime.Now;
                HocPhiDTO hocphi = new HocPhiDTO(mahp, thangdong, giatien, thoigiandong, nguoidong, nguoithu, dongtai, sobienlaigiay, thoigianchinhsua, madk, null);
                int rowAffected = HocPhiBUS.UpdateHocPhi(hocphi);
                MessageBox.Show($"{rowAffected} học phí đã được cập nhật");
            }
        }

        private void MonthTuitionPicker_Loaded(object sender, RoutedEventArgs e)
        {
            MonthTuitionPicker.SelectedDate = DateTime.Now;
        }
        private void LoadHocPhi()
        {
            if (MonthTuitionPicker.SelectedDate != null)
            {
                DateTime ngay = MonthTuitionPicker.SelectedDate.Value;
                TuitionDataGrid.ItemsSource = HocPhiBUS.GetHocPhi(ngay);
            }
        }
        private void RefreshTuitionButton_Click(object sender, RoutedEventArgs e)
        {
            LoadHocPhi();
        }

        private void MonthTuitionPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadHocPhi();
        }

        private void XoaHocPhi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
               "Bạn có chắc chắn muốn xóa các học sinh đang đánh dấu chọn? \n" +
               "Toàn bộ dữ liệu liên quan đến học sinh sẽ bị mất!",
               "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                int rowAffected = 0;
                foreach (HocPhiDTO hocphi in TuitionDataGrid.SelectedItems)
                {
                    rowAffected += HocPhiBUS.DeleteHocPhi(hocphi.MaDangKy, hocphi.MaHocPhi);
                }
                MessageBox.Show($"{rowAffected} học sinh đã được xóa");
            }
        }
    }
}
