using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LopHocDangKyBUS
    {
        static public List<LopHocDangKyDTO> FindLopHocDangKyByIDLopHoc(int malophoc, DateTime month)
        {
            return LopHocDangKyDAO.FindLopHocDangKyByIDLopHoc(malophoc, month);
        }
    }
}
