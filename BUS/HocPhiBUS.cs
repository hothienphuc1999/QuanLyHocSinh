using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocPhiBUS
    {
        static public int CreateHocPhi(HocPhiDTO hocphi)
        {
            return HocPhiDAO.CreateHocPhi(hocphi);
        }
        static public List<HocPhiDTO> GetHocPhi(DateTime ngay)
        {
            return HocPhiDAO.GetHocPhi(ngay);
        }
        static public List<HocPhiDTO> GetHocPhiByIDGiaoVien(DateTime ngay, int magv)
        {
            return HocPhiDAO.GetHocPhiByIDGiaoVien(ngay, magv);
        }
        static public List<HocPhiDTO> GetHocPhiByIDHocSinh(int mahs)
        {
            return HocPhiDAO.GetHocPhiByIDHocSinh(mahs);
        }
        static public List<HocPhiDTO> GetHocPhiByIDDangKyAndMonth(int madk, DateTime thang)
        {
            return HocPhiDAO.GetHocPhiByIDDangKyAndMonth(madk, thang);
        }
        static public int UpdateHocPhi(HocPhiDTO hocphi)
        {
            return HocPhiDAO.UpdateHocPhi(hocphi);
        }
        static public int DeleteHocPhi(int madk, int mahp)
        {
            return HocPhiDAO.DeleteHocPhi(madk, mahp);
        }
    }
}
