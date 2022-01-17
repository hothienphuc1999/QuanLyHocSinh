using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LuongGiaoVienDTO
    {
        private int _maLuong;
        private int _thang;
        private DateTime _ngayGuiLuong;
        private int _tongLuong;
        private int _tienGuiLai;
        private int _tienNhanThem;
        private int _maGiaoVien;
        private float _heSo;
        private GiaoVienDTO _giaoVien;
        private List<ChiTietLuongDTO> _cacChiTietLuong;

        public LuongGiaoVienDTO(int maLuong, int thang, DateTime ngayGuiLuong, int tongLuong, int tienGuiLai, int tienNhanThem, int maGiaoVien, float heSo, GiaoVienDTO giaoVien, List<ChiTietLuongDTO> cacChiTietLuong)
        {
            _maLuong = maLuong;
            _thang = thang;
            _ngayGuiLuong = ngayGuiLuong;
            _tongLuong = tongLuong;
            _tienGuiLai = tienGuiLai;
            _tienNhanThem = tienNhanThem;
            _maGiaoVien = maGiaoVien;
            _heSo = heSo;
            _giaoVien = giaoVien;
            _cacChiTietLuong = cacChiTietLuong;
        }

        public int MaLuong { get => _maLuong; set => _maLuong = value; }
        public int Thang { get => _thang; set => _thang = value; }
        public DateTime NgayGuiLuong { get => _ngayGuiLuong; set => _ngayGuiLuong = value; }
        public int TongLuong { get => _tongLuong; set => _tongLuong = value; }
        public int TienGuiLai { get => _tienGuiLai; set => _tienGuiLai = value; }
        public int TienNhanThem { get => _tienNhanThem; set => _tienNhanThem = value; }
        public int MaGiaoVien { get => _maGiaoVien; set => _maGiaoVien = value; }
        public float HeSo { get => _heSo; set => _heSo = value; }
        public GiaoVienDTO GiaoVien { get => _giaoVien; set => _giaoVien = value; }
        public List<ChiTietLuongDTO> CacChiTietLuong { get => _cacChiTietLuong; set => _cacChiTietLuong = value; }
    }
}
