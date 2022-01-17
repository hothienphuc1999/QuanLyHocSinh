using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocPhiNoDTO
    {
        private int _maNo;
        private int _thangNo;
        private int _tienNo;
        private int _maDangKy;
        private LopHocDangKyDTO _lopHocDangKy;

        public HocPhiNoDTO(int maNo, int thangNo, int tienNo, int maDangKy, LopHocDangKyDTO lopHocDangKy)
        {
            _maNo = maNo;
            _thangNo = thangNo;
            _tienNo = tienNo;
            _maDangKy = maDangKy;
            _lopHocDangKy = lopHocDangKy;
        }

        public int MaNo { get => _maNo; set => _maNo = value; }
        public int ThangNo { get => _thangNo; set => _thangNo = value; }
        public int TienNo { get => _tienNo; set => _tienNo = value; }
        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public LopHocDangKyDTO LopHocDangKy { get => _lopHocDangKy; set => _lopHocDangKy = value; }
    }
}
