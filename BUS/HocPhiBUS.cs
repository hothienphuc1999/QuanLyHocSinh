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
    }
}
