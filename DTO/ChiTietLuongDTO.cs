using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietLuongDTO
    {
        private int _maChiTietLuong;
        private int _maLuong;
        private DateTime _thang;
        private int _soTien;
        private enum _loai { Thực, Ứng };
        private LuongGiaoVienDTO _luong;

        public int MaChiTietLuong { get => _maChiTietLuong; set => _maChiTietLuong = value; }
        public int MaLuong { get => _maLuong; set => _maLuong = value; }
        public DateTime Thang { get => _thang; set => _thang = value; }
        public int SoTien { get => _soTien; set => _soTien = value; }
        public LuongGiaoVienDTO Luong { get => _luong; set => _luong = value; }

        public ChiTietLuongDTO(int maChiTietLuong, int maLuong, DateTime thang, int soTien, LuongGiaoVienDTO luong)
        {
            _maChiTietLuong = maChiTietLuong;
            _maLuong = maLuong;
            _thang = thang;
            _soTien = soTien;
            _luong = luong;
        }
    }
}
