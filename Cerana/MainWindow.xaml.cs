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
            for (int i = 0; i < HocSinhDataGrid.Items.Count; i++)
            {
                var item = HocSinhDataGrid.Items[i];
                var mycheckbox = HocSinhDataGrid.Columns[0].GetCellContent(item) as CheckBox;
                if ((bool)mycheckbox.IsChecked)
                {
                    list.Add(((HocSinhDTO)item).MaHS);
                }
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
                for (int i = 0; i < HocSinhDataGrid.Items.Count; i++)
                {
                    var item = HocSinhDataGrid.Items[i];
                    var mycheckbox = HocSinhDataGrid.Columns[0].GetCellContent(item) as CheckBox;
                    if ((bool)mycheckbox.IsChecked)
                    {
                        rowAffected += HocSinhBUS.DeleteHocSinh(((HocSinhDTO)item).MaHS);
                    }
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
                string lop = ClassNameTextBox.Text;
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

        }

        private void SaveLopButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
