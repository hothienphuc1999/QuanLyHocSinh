using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LopHocBUS
    {
        static public List<LopHocDTO> FindLopHocByIDGiaoVien(int magv)
        {
            return LopHocDAO.FindLopHocByIDGiaoVien(magv);
        }
        static public List<string> GetAllNienKhoaInLopHoc(int magv)
        {
            return LopHocDAO.GetAllNienKhoaInLopHoc(magv);
        }
        static public List<LopHocDTO> FindLopHocByIDGiaoVienWithNienKhoa(int magv, string nienkhoa)
        {
            return LopHocDAO.FindLopHocByIDGiaoVienWithNienKhoa(magv, nienkhoa);
        }
        static public int CreateLopHoc(LopHocDTO lophoc)
        {
            return LopHocDAO.CreateLopHoc(lophoc);
        }
        static public int UpdateLopHoc(LopHocDTO lophoc)
        {
            return LopHocDAO.UpdateLopHoc(lophoc);
        }
        static public int DeleteLopHoc(int malophoc)
        {
            return LopHocDAO.DeleteLopHoc(malophoc);
        }
    }
}
