using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocPhiDTO
    {
        private int _maHocPhi;
        private int _thangDong;
        private int _giaTien;
        private DateTime _thoiGianDong;
        private string _nguoiDong;
        private string _nguoiThu;
        private string _dongTai;
        private string _soBienLaiGiay;
        private DateTime _thoiGianChinhSua;
        private int _maDangKy;
        private LopHocDangKyDTO _lopHocDangKy;

        public HocPhiDTO(int maHocPhi, int thangDong, int giaTien, DateTime thoiGianDong, string nguoiDong, string nguoiThu, string dongTai, string soBienLaiGiay, DateTime thoiGianChinhSua, int maDangKy, LopHocDangKyDTO lopHocDangKy)
        {
            _maHocPhi = maHocPhi;
            _thangDong = thangDong;
            _giaTien = giaTien;
            _thoiGianDong = thoiGianDong;
            _nguoiDong = nguoiDong;
            _nguoiThu = nguoiThu;
            _dongTai = dongTai;
            _soBienLaiGiay = soBienLaiGiay;
            _thoiGianChinhSua = thoiGianChinhSua;
            _maDangKy = maDangKy;
            _lopHocDangKy = lopHocDangKy;
        }

        public int MaHocPhi { get => _maHocPhi; set => _maHocPhi = value; }
        public int ThangDong { get => _thangDong; set => _thangDong = value; }
        public int GiaTien { get => _giaTien; set => _giaTien = value; }
        public DateTime ThoiGianDong { get => _thoiGianDong; set => _thoiGianDong = value; }
        public string NguoiDong { get => _nguoiDong; set => _nguoiDong = value; }
        public string NguoiThu { get => _nguoiThu; set => _nguoiThu = value; }
        public string DongTai { get => _dongTai; set => _dongTai = value; }
        public string SoBienLaiGiay { get => _soBienLaiGiay; set => _soBienLaiGiay = value; }
        public DateTime ThoiGianChinhSua { get => _thoiGianChinhSua; set => _thoiGianChinhSua = value; }
        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public LopHocDangKyDTO LopHocDangKy { get => _lopHocDangKy; set => _lopHocDangKy = value; }
    }
}
