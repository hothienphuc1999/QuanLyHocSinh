using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class GiaoVienBUS
    {
        static public List<GiaoVienDTO> LoadAllGiaoVien()
        {
            return GiaoVienDAO.LoadAllGiaoVien();
        }
    }
}
