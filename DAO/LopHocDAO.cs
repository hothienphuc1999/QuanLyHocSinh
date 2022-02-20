using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAO
{
    public class LopHocDAO
    {
        static public List<LopHocDTO> FindLopHocByIDGiaoVien(int magiaovien)
        {
            DataConnection dataConnection = new DataConnection();
            List<LopHocDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_find_lophoc_by_giaovien",
                    new SqlParameter { ParameterName = "@magv", Value = magiaovien });
                if (dt != null)
                {
                    result = new List<LopHocDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        LopHocDTO lophoc = new LopHocDTO(
                            (int)r["MaLopHoc"],
                            r["TenLopHoc"].ToString(),
                            (int)r["MaGiaoVien"],
                            r["HocPhiLopHoc"].ToString(),
                            r["NienKhoa"].ToString(),
                            GiaoVienDAO.FindGiaoVienByID(magiaovien),
                            null,
                            null,
                            null);
                        result.Add(lophoc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public List<string> GetAllNienKhoaInLopHoc(int magv)
        {
            DataConnection dataConnection = new DataConnection();
            List<string> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_nienkhoa",
                    new SqlParameter { ParameterName = "@magv", Value = magv });
                if (dt != null)
                {
                    result = new List<string>();
                    foreach (DataRow r in dt.Rows)
                    {
                        result.Add(r["NienKhoa"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public List<LopHocDTO> FindLopHocByIDGiaoVienWithNienKhoa(int magiaovien, string nienkhoa)
        {
            DataConnection dataConnection = new DataConnection();
            List<LopHocDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_find_lophoc_by_giaovien_with_nienkhoa",
                    new SqlParameter { ParameterName = "@magv", Value = magiaovien },
                    new SqlParameter { ParameterName = "@nienkhoa", Value = nienkhoa});
                if (dt != null)
                {
                    result = new List<LopHocDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        LopHocDTO lophoc = new LopHocDTO(
                            (int)r["MaLopHoc"],
                            r["TenLopHoc"].ToString(),
                            (int)r["MaGiaoVien"],
                            r["HocPhiLopHoc"].ToString(),
                            r["NienKhoa"].ToString(),
                            GiaoVienDAO.FindGiaoVienByID(magiaovien),
                            null,
                            null,
                            null);
                        result.Add(lophoc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public int CreateLopHoc(LopHocDTO lophoc)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_create_lophoc",
                    new SqlParameter { ParameterName = "@tenlh", Value = lophoc.TenLopHoc },
                    new SqlParameter { ParameterName = "@nienkhoa", Value = lophoc.NienKhoa },
                    new SqlParameter { ParameterName = "@hplh", Value = lophoc.HocPhiLopHoc },
                    new SqlParameter { ParameterName = "@magv", Value = lophoc.MaGiaoVien }
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public int UpdateLopHoc(LopHocDTO lophoc)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_lophoc",
                    new SqlParameter { ParameterName = "@malh", Value = lophoc.MaLopHoc },
                    new SqlParameter { ParameterName = "@tenlh", Value = lophoc.TenLopHoc },
                    new SqlParameter { ParameterName = "@nienkhoa", Value = lophoc.NienKhoa },
                    new SqlParameter { ParameterName = "@hplh", Value = lophoc.HocPhiLopHoc },
                    new SqlParameter { ParameterName = "@magv", Value = lophoc.MaGiaoVien }
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public int DeleteLopHoc(int malophoc)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_delete_lophoc",
                    new SqlParameter { ParameterName = "@malh", Value = malophoc }
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
    }
}
