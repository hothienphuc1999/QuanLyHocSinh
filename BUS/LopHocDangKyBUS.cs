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
        static public List<LopHocDangKyDTO> GetLopHocDangKyByIDHocSinh(int mahs)
        {
            return LopHocDangKyDAO.GetLopHocDangKyByIDHocSinh(mahs);
        }
        static public int CreateLopHocDangKy(LopHocDangKyDTO dangky)
        {
            return LopHocDangKyDAO.CreateLopHocDangKy(dangky);
        }
        static public int UpdateLopHocDangKy(LopHocDangKyDTO dangky)
        {
            return LopHocDangKyDAO.UpdateLopHocDangKy(dangky);
        }
        static public int DeleteLopHocDangKy(int madk)
        {
            return LopHocDangKyDAO.DeleteLopHocDangKy(madk);
        }
        static public List<LopHocDangKyDTO> GetLopHocDangKyByIDHocSinhAndMonth(int mahocsinh, DateTime month)
        {
            return LopHocDangKyDAO.GetLopHocDangKyByIDHocSinhAndMonth(mahocsinh, month);
        }
    }
}
