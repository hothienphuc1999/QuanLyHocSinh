using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocSinhBUS
    {
        static public List<HocSinhDTO> SearchHocSinh(string holot, string ten)
        {
            return HocSinhDAO.SearchHocSinh(holot, ten);
        }
        static public List<HocSinhDTO> SearchHocSinhByPhone(string sdthocsinh)
        {
            return HocSinhDAO.SearchHocSinhByPhone(sdthocsinh);
        }
        static public List<HocSinhDTO> SearchHocSinhByParentPhone(string sdtphuhuynh)
        {
            return HocSinhDAO.SearchHocSinhByParentPhone(sdtphuhuynh);
        }
        static public List<HocSinhDTO> SearchHocSinhExact(string holot, string ten)
        {
            return HocSinhDAO.SearchHocSinhExact(holot, ten);
        }
        static public int CreateHocSinh(HocSinhDTO hocsinh)
        {
            return HocSinhDAO.CreateHocSinh(hocsinh);
        }
        static public int UpdateHocSinh(HocSinhDTO hocsinh)
        {
            return HocSinhDAO.UpdateHocSinh(hocsinh);
        }
        static public int DeleteHocSinh(int mahs)
        {
            return HocSinhDAO.DeleteHocSinh(mahs);
        }
    }
}
