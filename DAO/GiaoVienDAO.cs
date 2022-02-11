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
    public class GiaoVienDAO
    {
        static public List<GiaoVienDTO> LoadAllGiaoVien()
        {
            DataConnection dataConnection = new DataConnection();
            List<GiaoVienDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_load_giaovien");
                if (dt != null)
                {
                    result = new List<GiaoVienDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        GiaoVienDTO giaovien = new GiaoVienDTO(
                            (int)r["MaGiaoVien"],
                            r["DanhXung"].ToString(),
                            r["TenGiaoVien"].ToString(),
                            r["SDTGiaoVien"].ToString(),
                            null,
                            null);
                        result.Add(giaovien);
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
        static public GiaoVienDTO FindGiaoVienByID(int magv)
        {
            DataConnection dataConnection = new DataConnection();
            GiaoVienDTO result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_find_giaovien_by_id",
                    new SqlParameter { ParameterName = "@magv", Value = magv });
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        result = new GiaoVienDTO(
                            (int)r["MaGiaoVien"],
                            r["DanhXung"].ToString(),
                            r["TenGiaoVien"].ToString(),
                            r["SDTGiaoVien"].ToString(),
                            null,
                            null);
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
    }
}
