using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhDTO
    {
        private int _maHS;
        private string _hoLot;
        private string _ten;
        private string _sdtHocSinh;
        private string _sdtPhuHuynh;
        private string _lop;
        private string _nienKhoa;
        private bool _xacNhanSDT;
        private List<LopHocDangKyDTO> _cacLopHocDangKy;

        public HocSinhDTO(int maHS, string hoLot, string ten, string sdtHocSinh, string sdtPhuHuynh, string lop, string nienKhoa, bool xacNhanSDT, List<LopHocDangKyDTO> cacLopHocDangKy)
        {
            _maHS = maHS;
            _hoLot = hoLot;
            _ten = ten;
            _sdtHocSinh = sdtHocSinh;
            _sdtPhuHuynh = sdtPhuHuynh;
            _lop = lop;
            _nienKhoa = nienKhoa;
            _xacNhanSDT = xacNhanSDT;
            _cacLopHocDangKy = cacLopHocDangKy;
        }

        public int MaHS { get => _maHS; set => _maHS = value; }
        public string HoLot { get => _hoLot; set => _hoLot = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string SdtHocSinh { get => _sdtHocSinh; set => _sdtHocSinh = value; }
        public string SdtPhuHuynh { get => _sdtPhuHuynh; set => _sdtPhuHuynh = value; }
        public string Lop { get => _lop; set => _lop = value; }
        public string NienKhoa { get => _nienKhoa; set => _nienKhoa = value; }
        public bool XacNhanSDT { get => _xacNhanSDT; set => _xacNhanSDT = value; }
        public List<LopHocDangKyDTO> CacLopHocDangKy { get => _cacLopHocDangKy; set => _cacLopHocDangKy = value; }
    }
}
