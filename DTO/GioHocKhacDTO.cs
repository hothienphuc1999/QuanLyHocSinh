using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHocKhacDTO
    {
        private int _maGioHocKhac;
        private DateTime _ngayNghi;
        private DateTime _thoiGianBu;
        private int _maLopHoc;
        private LopHocDTO _lopHoc;

        public GioHocKhacDTO(int maGioHocKhac, DateTime ngayNghi, DateTime thoiGianBu, int maLopHoc, LopHocDTO lopHoc)
        {
            _maGioHocKhac = maGioHocKhac;
            _ngayNghi = ngayNghi;
            _thoiGianBu = thoiGianBu;
            _maLopHoc = maLopHoc;
            _lopHoc = lopHoc;
        }

        public int MaGioHocKhac { get => _maGioHocKhac; set => _maGioHocKhac = value; }
        public DateTime NgayNghi { get => _ngayNghi; set => _ngayNghi = value; }
        public DateTime ThoiGianBu { get => _thoiGianBu; set => _thoiGianBu = value; }
        public int MaLopHoc { get => _maLopHoc; set => _maLopHoc = value; }
        public LopHocDTO LopHoc { get => _lopHoc; set => _lopHoc = value; }
    }
}
