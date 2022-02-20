using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHocDTO
    {
        private int _maLopHoc;
        private string _tenLopHoc;
        private int _maGiaoVien;
        private string _hocPhiLopHoc;
        private string _nienKhoa;
        private GiaoVienDTO _giaovien;
        private List<LopHocDangKyDTO> _cacLopHocDangKy;
        private List<GioHocDTO> _cacGioHoc;
        private List<GioHocKhacDTO> _cacGioHocKhac;

        public LopHocDTO(int maLopHoc, string tenLopHoc, int maGiaoVien, string hocPhiLopHoc, string nienKhoa, GiaoVienDTO giaovien, List<LopHocDangKyDTO> cacLopHocDangKy, List<GioHocDTO> cacGioHoc, List<GioHocKhacDTO> cacGioHocKhac)
        {
            _maLopHoc = maLopHoc;
            _tenLopHoc = tenLopHoc;
            _maGiaoVien = maGiaoVien;
            _hocPhiLopHoc = hocPhiLopHoc;
            _nienKhoa = nienKhoa;
            _giaovien = giaovien;
            _cacLopHocDangKy = cacLopHocDangKy;
            _cacGioHoc = cacGioHoc;
            _cacGioHocKhac = cacGioHocKhac;
        }

        public int MaLopHoc { get => _maLopHoc; set => _maLopHoc = value; }
        public string TenLopHoc { get => _tenLopHoc; set => _tenLopHoc = value; }
        public int MaGiaoVien { get => _maGiaoVien; set => _maGiaoVien = value; }
        public string NienKhoa { get => _nienKhoa; set => _nienKhoa = value; }
        public GiaoVienDTO Giaovien { get => _giaovien; set => _giaovien = value; }
        public List<LopHocDangKyDTO> CacLopHocDangKy { get => _cacLopHocDangKy; set => _cacLopHocDangKy = value; }
        public List<GioHocDTO> CacGioHoc { get => _cacGioHoc; set => _cacGioHoc = value; }
        public List<GioHocKhacDTO> CacGioHocKhac { get => _cacGioHocKhac; set => _cacGioHocKhac = value; }
        public string HocPhiLopHoc { get => _hocPhiLopHoc; set => _hocPhiLopHoc = value; }
    }
}
