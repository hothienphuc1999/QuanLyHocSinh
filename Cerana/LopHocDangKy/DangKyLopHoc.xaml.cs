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
    /// Interaction logic for LopHocDangKy.xaml
    /// </summary>
    public partial class DangKyLopHoc : Window
    {
        int malophoc = -1;
        List<HocSinhDTO> list = new List<HocSinhDTO>();
        public DangKyLopHoc(int malh)
        {
            InitializeComponent();
            malophoc = malh;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int createdNum = 0;
            foreach (HocSinhDTO hs in list)
            {
                LopHocDangKyDTO dk = new LopHocDangKyDTO(
                    -1,
                    DateStartedPicker.SelectedDate.Value,
                    null,
                    true,
                    hs.MaHS,
                    malophoc,
                    "",
                    null,
                    null,
                    0,
                    0);
                createdNum += LopHocDangKyBUS.CreateLopHocDangKy(dk);
            }
            MessageBox.Show($"{createdNum} học sinh đã thêm");
        }
        private void SearchHocSinhByName(string holot, string ten)
        {
            List<HocSinhDTO> list = HocSinhBUS.SearchHocSinh(holot, ten);
            ResultDataGrid.ItemsSource = list;
        }
        private void SearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string[] hoten = SearchTextbox.Text.Split(' ');
                string ten = hoten.Last();
                string holot = "";
                for (int i = 0; i < hoten.Length - 1; i++)
                {
                    holot += hoten[i];
                }
                SearchHocSinhByName(holot, ten);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (HocSinhDTO hs in ResultDataGrid.SelectedItems)
            {
                list.Add(hs);
            }
            DangKyDataGrid.ItemsSource = null;
            DangKyDataGrid.ItemsSource = list;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (HocSinhDTO hs in DangKyDataGrid.SelectedItems)
            {
                list.Remove(hs);
            }
            DangKyDataGrid.ItemsSource = null;
            DangKyDataGrid.ItemsSource = list;
        }

        private void DateStartedPicker_Loaded(object sender, RoutedEventArgs e)
        {
            DateStartedPicker.SelectedDate = DateTime.Now;
        }
    }
}
