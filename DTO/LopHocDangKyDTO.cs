using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHocDangKyDTO
    {
        private int _maDangKy;
        private DateTime _ngayBatDau;
        private DateTime _ngayKetThuc;
        private bool _tinhTrang;
        private int _maHocSinh;
        private int _maLopHoc;
        private HocSinhDTO _hocsinh;
        private LopHocDTO _lophoc;
        private List<BangDiemDanhDTO> _cacBangDiemDanh;
        private List<HocPhiNoDTO> _cacHocPhiNo;
        private List<HocPhiMienGiamDTO> _cacHocPhiMienGiam;
        private List<HocPhiDTO> _cacHocPhi;

        public LopHocDangKyDTO(int maDangKy, DateTime ngayBatDau, DateTime ngayKetThuc, bool tinhTrang, int maHocSinh, int maLopHoc, HocSinhDTO hocsinh, LopHocDTO lophoc, List<BangDiemDanhDTO> cacBangDiemDanh, List<HocPhiNoDTO> cacHocPhiNo, List<HocPhiMienGiamDTO> cacHocPhiMienGiam, List<HocPhiDTO> cacHocPhi)
        {
            _maDangKy = maDangKy;
            _ngayBatDau = ngayBatDau;
            _ngayKetThuc = ngayKetThuc;
            _tinhTrang = tinhTrang;
            _maHocSinh = maHocSinh;
            _maLopHoc = maLopHoc;
            _hocsinh = hocsinh;
            _lophoc = lophoc;
            _cacBangDiemDanh = cacBangDiemDanh;
            _cacHocPhiNo = cacHocPhiNo;
            _cacHocPhiMienGiam = cacHocPhiMienGiam;
            _cacHocPhi = cacHocPhi;
        }

        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public DateTime NgayBatDau { get => _ngayBatDau; set => _ngayBatDau = value; }
        public DateTime NgayKetThuc { get => _ngayKetThuc; set => _ngayKetThuc = value; }
        public bool TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public int MaHocSinh { get => _maHocSinh; set => _maHocSinh = value; }
        public int MaLopHoc { get => _maLopHoc; set => _maLopHoc = value; }
        public HocSinhDTO Hocsinh { get => _hocsinh; set => _hocsinh = value; }
        public LopHocDTO Lophoc { get => _lophoc; set => _lophoc = value; }
        public List<BangDiemDanhDTO> CacBangDiemDanh { get => _cacBangDiemDanh; set => _cacBangDiemDanh = value; }
        public List<HocPhiNoDTO> CacHocPhiNo { get => _cacHocPhiNo; set => _cacHocPhiNo = value; }
        public List<HocPhiMienGiamDTO> CacHocPhiMienGiam { get => _cacHocPhiMienGiam; set => _cacHocPhiMienGiam = value; }
        public List<HocPhiDTO> CacHocPhi { get => _cacHocPhi; set => _cacHocPhi = value; }
    }
}
