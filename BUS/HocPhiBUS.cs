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
