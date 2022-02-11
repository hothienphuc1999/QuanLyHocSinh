using System;

namespace DTO
{
    public class LopHocDangKyDTO
    {
        private int _maDangKy;
        private DateTime? _ngayBatDau;
        private DateTime? _ngayKetThuc;
        private bool _tinhTrang;
        private int _maHocSinh;
        private int _maLopHoc;
        private string _miengiam;
        private HocSinhDTO _hocsinh;
        private LopHocDTO _lophoc;
        //private List<BangDiemDanhDTO> _cacBangDiemDanh;
        //private List<HocPhiNoDTO> _cacHocPhiNo;
        //private List<HocPhiDTO> _cacHocPhi;
        private int _soTienDong;
        private int _soTienNo;

        public LopHocDangKyDTO(int maDangKy, DateTime? ngayBatDau, DateTime? ngayKetThuc, bool tinhTrang, int maHocSinh, int maLopHoc, string miengiam, HocSinhDTO hocsinh, LopHocDTO lophoc, int soTienDong, int soTienNo)
        {
            _maDangKy = maDangKy;
            _ngayBatDau = ngayBatDau;
            _ngayKetThuc = ngayKetThuc;
            _tinhTrang = tinhTrang;
            _maHocSinh = maHocSinh;
            _maLopHoc = maLopHoc;
            _miengiam = miengiam;
            _hocsinh = hocsinh;
            _lophoc = lophoc;
            _soTienDong = soTienDong;
            _soTienNo = soTienNo;
        }

        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public DateTime? NgayBatDau { get => _ngayBatDau; set => _ngayBatDau = value; }
        public DateTime? NgayKetThuc { get => _ngayKetThuc; set => _ngayKetThuc = value; }
        public int MaHocSinh { get => _maHocSinh; set => _maHocSinh = value; }
        public int MaLopHoc { get => _maLopHoc; set => _maLopHoc = value; }
        public HocSinhDTO Hocsinh { get => _hocsinh; set => _hocsinh = value; }
        public LopHocDTO Lophoc { get => _lophoc; set => _lophoc = value; }
        public string Miengiam { get => _miengiam; set => _miengiam = value; }
        public bool TinhTrang { get => _tinhTrang; set => _tinhTrang = value; }
        public int SoTienDong { get => _soTienDong; set => _soTienDong = value; }
        public int SoTienNo { get => _soTienNo; set => _soTienNo = value; }
    }
}
