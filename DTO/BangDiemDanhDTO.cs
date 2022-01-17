using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangDiemDanhDTO
    {
        private int _maDangKy;
        private int _maDiemDanh;
        private DateTime _thoiGianDiemDanh;
        private int _trangThai;
        private LopHocDangKyDTO _lopHocDangKy;

        public BangDiemDanhDTO(int maDangKy, int maDiemDanh, DateTime thoiGianDiemDanh, int trangThai, LopHocDangKyDTO lopHocDangKy)
        {
            _maDangKy = maDangKy;
            _maDiemDanh = maDiemDanh;
            _thoiGianDiemDanh = thoiGianDiemDanh;
            _trangThai = trangThai;
            _lopHocDangKy = lopHocDangKy;
        }

        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public int MaDiemDanh { get => _maDiemDanh; set => _maDiemDanh = value; }
        public DateTime ThoiGianDiemDanh { get => _thoiGianDiemDanh; set => _thoiGianDiemDanh = value; }
        public int TrangThai { get => _trangThai; set => _trangThai = value; }
        public LopHocDangKyDTO LopHocDangKy { get => _lopHocDangKy; set => _lopHocDangKy = value; }
    }
}
