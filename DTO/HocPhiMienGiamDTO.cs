using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocPhiMienGiamDTO
    {
        private int _maMienGiam;
        private int _maDangKy;
        private DateTime _thangBatDau;
        private DateTime _thangKetThuc;
        private string _noiDungGiam;
        private LopHocDangKyDTO _lopHocDangKy;

        public HocPhiMienGiamDTO(int maMienGiam, int maDangKy, DateTime thangBatDau, DateTime thangKetThuc, string noiDungGiam, LopHocDangKyDTO lopHocDangKy)
        {
            _maMienGiam = maMienGiam;
            _maDangKy = maDangKy;
            _thangBatDau = thangBatDau;
            _thangKetThuc = thangKetThuc;
            _noiDungGiam = noiDungGiam;
            _lopHocDangKy = lopHocDangKy;
        }

        public int MaMienGiam { get => _maMienGiam; set => _maMienGiam = value; }
        public int MaDangKy { get => _maDangKy; set => _maDangKy = value; }
        public DateTime ThangBatDau { get => _thangBatDau; set => _thangBatDau = value; }
        public DateTime ThangKetThuc { get => _thangKetThuc; set => _thangKetThuc = value; }
        public string NoiDungGiam { get => _noiDungGiam; set => _noiDungGiam = value; }
        public LopHocDangKyDTO LopHocDangKy { get => _lopHocDangKy; set => _lopHocDangKy = value; }
    }
}
