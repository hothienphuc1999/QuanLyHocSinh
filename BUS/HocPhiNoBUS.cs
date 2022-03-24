using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocPhiNoBUS
    {
        static public List<HocPhiNoDTO> FindHocPhiNoByIDHocSinh(int mahs)
        {
            return HocPhiNoDAO.GetHocPhiNoByIDHocSinh(mahs);
        }
        static public List<HocPhiNoDTO> GetHocPhiNoByIDLopHocAndMonth(int malh, DateTime thang)
        {
            return HocPhiNoDAO.GetHocPhiNoByIDLopHocAndMonth(malh, thang);
        }
        static public List<HocPhiNoDTO> GetLopHocDangKyByIDLopHocAndMonth(int malh, DateTime thang)
        {
            return HocPhiNoDAO.GetLopHocDangKyByIDLopHocAndMonth(malh, thang);
        }
        static public int CreateHocPhiNo(HocPhiNoDTO hocphino)
        {
            return HocPhiNoDAO.CreateHocPhiNo(hocphino);
        }
        static public int UpdateHocPhiNo(HocPhiNoDTO hocphino)
        {
            return HocPhiNoDAO.UpdateHocPhiNo(hocphino);
        }
        static public int DeleteHocPhiNo(int madk, int mano)
        {
            return HocPhiNoDAO.DeleteHocPhiNo(madk, mano);
        }
    }
}
