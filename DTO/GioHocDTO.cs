using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHocDTO
    {
        private int _maGioHoc;
        private int _maLopHoc;
        private int _thu;
        private TimeSpan _gio;
        private LopHocDTO _lophoc;

        public GioHocDTO(int maGioHoc, int maLopHoc, int thu, TimeSpan gio, LopHocDTO lophoc)
        {
            _maGioHoc = maGioHoc;
            _maLopHoc = maLopHoc;
            _thu = thu;
            _gio = gio;
            _lophoc = lophoc;
        }

        public int MaGioHoc { get => _maGioHoc; set => _maGioHoc = value; }
        public int MaLopHoc { get => _maLopHoc; set => _maLopHoc = value; }
        public int Thu { get => _thu; set => _thu = value; }
        public TimeSpan Gio { get => _gio; set => _gio = value; }
        public LopHocDTO Lophoc { get => _lophoc; set => _lophoc = value; }
    }
}
