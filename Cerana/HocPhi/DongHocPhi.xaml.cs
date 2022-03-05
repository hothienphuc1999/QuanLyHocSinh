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

namespace Cerana.HocPhi
{
    /// <summary>
    /// Interaction logic for DongHocPhi.xaml
    /// </summary>
    public partial class DongHocPhi : Window
    {
        int mahocsinh = -1;
        List<HocPhiDTO> dshocphi = new List<HocPhiDTO>();
        public DongHocPhi(int mahs)
        {
            InitializeComponent();
            mahocsinh = mahs;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NoComboBox.ItemsSource = HocPhiNoBUS.FindHocPhiNoByIDHocSinh(mahocsinh);
        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int rowAffected = 0;
            foreach (HocPhiDTO hocphi in dshocphi)
            {
                rowAffected += HocPhiBUS.CreateHocPhi(hocphi);
            }
            MessageBox.Show($"{rowAffected} học phí đã được lưu");
        }

        private void LoaiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoaiComboBox.SelectedIndex == 0)
            {
                ThangMoiStackPanel.IsEnabled = true;
                NoComboBox.IsEnabled = false;
            }
            else
            {
                ThangMoiStackPanel.IsEnabled = false;
                NoComboBox.IsEnabled = true;
            }
        }

        private void LoaiComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            LoaiComboBox.SelectedIndex = 1;
        }

        private void ThangDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            ThangDatePicker.SelectedDate = DateTime.Now;
        }
        private void LoadLopHoc()
        {
            DateTime month = ThangDatePicker.SelectedDate.Value;
            LopHocCBB.ItemsSource = LopHocDangKyBUS.GetLopHocDangKyByIDHocSinhAndMonth(mahocsinh, month);
        }

        private void ThangDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadLopHoc();
        }
        private string NumberConvert(string num)
        {
            int val = int.Parse(num);
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return val.ToString("#,###", cul.NumberFormat);
        }
        private void LopHocCBB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LopHocCBB.SelectedItem != null)
            {
                LopHocDangKyDTO dangky = LopHocCBB.SelectedItem as LopHocDangKyDTO;
                HocPhiLopHocTxt.Text = $"Học phí của lớp học: {NumberConvert(dangky.Lophoc.HocPhiLopHoc)}";
                MienGiamTxt.Text = $"Học phí miễn giảm: {dangky.Miengiam}";
                NgayVaoHocTxt.Text = $"Ngày vào học: {dangky.NgayBatDau.Value:dd/MM/yyyy}";
                if (dangky.NgayKetThuc != null)
                    NgayKetThucTxt.Text = $"Ngày nghỉ học: {dangky.NgayKetThuc.Value:dd/MM/yyyy}";
                else
                    NgayKetThucTxt.Text = $"Ngày nghỉ học:";
            }
            else
            {
                HocPhiLopHocTxt.Text = $"Học phí của lớp học:";
                MienGiamTxt.Text = $"Học phí miễn giảm:";
                NgayVaoHocTxt.Text = $"Ngày vào học:";
                NgayKetThucTxt.Text = $"Ngày nghỉ học:";
            }
        }

        private void NoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HocPhiLopHocTxt.Text = $"Học phí của lớp học:";
            MienGiamTxt.Text = $"Học phí miễn giảm:";
            NgayVaoHocTxt.Text = $"Ngày vào học:";
            NgayKetThucTxt.Text = $"Ngày nghỉ học:";
            if (NoComboBox.SelectedItem != null)
                PriceTextBox.Text = (NoComboBox.SelectedItem as HocPhiNoDTO).TienNo.ToString();
            else
                PriceTextBox.Text = "";
        }

        private void AddHocPhiBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoaiComboBox.SelectedIndex == 0)
            {
                if (LopHocCBB.SelectedItem != null)
                {
                    LopHocDangKyDTO dangky = LopHocCBB.SelectedItem as LopHocDangKyDTO;
                    HocPhiDTO hocphi = new HocPhiDTO(-1, new DateTime(ThangDatePicker.SelectedDate.Value.Year, ThangDatePicker.SelectedDate.Value.Month, 1), int.Parse(PriceTextBox.Text), DatePicker.SelectedDate.Value, NguoiDongCBB.Text, NguoiThuCBB.Text, DongTaiCBB.Text, MaBienLaiTextBox.Text, null, dangky.MaDangKy, dangky);
                    dshocphi.Add(hocphi);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học của tháng mới!");
                }
            }
            else
            {
                if (NoComboBox.SelectedItem != null)
                {
                    HocPhiNoDTO hocphino = NoComboBox.SelectedItem as HocPhiNoDTO;
                    HocPhiDTO hocphi = new HocPhiDTO(-1, hocphino.ThangNo, hocphino.TienNo, DatePicker.SelectedDate.Value, ((ComboBoxItem)NguoiDongCBB.SelectedItem).Content.ToString(), ((ComboBoxItem)NguoiThuCBB.SelectedItem).Content.ToString(), ((ComboBoxItem)DongTaiCBB.SelectedItem).Content.ToString(), MaBienLaiTextBox.Text, null, hocphino.LopHocDangKy.MaDangKy, hocphino.LopHocDangKy);
                    dshocphi.Add(hocphi);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học nợ!");
                }
            }
            HocPhiListBox.ItemsSource = null;
            HocPhiListBox.ItemsSource = dshocphi;
            TinhTongHocPhi();
        }

        private void DeleteHocPhi_Click(object sender, RoutedEventArgs e)
        {
            if (HocPhiListBox.SelectedItem != null)
            {
                dshocphi.Remove(HocPhiListBox.SelectedItem as HocPhiDTO);
                HocPhiListBox.ItemsSource = null;
                HocPhiListBox.ItemsSource = dshocphi;
                TinhTongHocPhi();
            }
        }

        private void TinhTongHocPhi()
        {
            int tongtien = dshocphi.Sum(p => p.GiaTien);
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            TotalPriceTxt.Text = $"Tổng học phí: {tongtien.ToString("#,###", cul.NumberFormat)} đ";
        }
    }
}
