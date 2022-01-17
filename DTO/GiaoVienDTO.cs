using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiaoVienDTO
    {
        private int _maGiaoVien;
        private string _danhXung;
        private string _tenGiaoVien;
        private string _sdtGiaoVien;
        private List<LopHocDTO> _cacLopHoc;
        private List<LuongGiaoVienDTO> _cacLuongGiaoVien;

        public GiaoVienDTO(int maGiaoVien, string danhXung, string tenGiaoVien, string sdtGiaoVien, List<LopHocDTO> cacLopHoc, List<LuongGiaoVienDTO> cacLuongGiaoVien)
        {
            _maGiaoVien = maGiaoVien;
            _danhXung = danhXung;
            _tenGiaoVien = tenGiaoVien;
            _sdtGiaoVien = sdtGiaoVien;
            _cacLopHoc = cacLopHoc;
            _cacLuongGiaoVien = cacLuongGiaoVien;
        }

        public int MaGiaoVien { get => _maGiaoVien; set => _maGiaoVien = value; }
        public string DanhXung { get => _danhXung; set => _danhXung = value; }
        public string TenGiaoVien { get => _tenGiaoVien; set => _tenGiaoVien = value; }
        public string SdtGiaoVien { get => _sdtGiaoVien; set => _sdtGiaoVien = value; }
        public List<LopHocDTO> CacLopHoc { get => _cacLopHoc; set => _cacLopHoc = value; }
        public List<LuongGiaoVienDTO> CacLuongGiaoVien { get => _cacLuongGiaoVien; set => _cacLuongGiaoVien = value; }
    }
}
