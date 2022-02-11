using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DAO
{
    public class LopHocDangKyDAO
    {
        static public List<LopHocDangKyDTO> FindLopHocDangKyByIDLopHoc(int malophoc, DateTime month)
        {
            DataConnection dataConnection = new DataConnection();
            List<LopHocDangKyDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_lhdk_by_month_idlophoc",
                    new SqlParameter { ParameterName = "@malophoc", Value = malophoc },
                    new SqlParameter { ParameterName = "@thang", Value = month });
                if (dt != null)
                {
                    result = new List<LopHocDangKyDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        LopHocDangKyDTO lophocdangky = new LopHocDangKyDTO(
                            (int)r["MaDangKy"],
                            string.IsNullOrEmpty(r["NgayBatDau"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayBatDau"].ToString()),
                            string.IsNullOrEmpty(r["NgayKetThuc"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayKetThuc"].ToString()),
                            (bool)r["TinhTrang"],
                            (int)r["MaHocSinh"],
                            (int)r["MaLopHoc"],
                            r["MienGiam"].ToString(),
                            null,
                            null,
                            r["SoTienDong"] == System.DBNull.Value ? 0 : (int)r["SoTienDong"],
                            r["SoTienNo"] == System.DBNull.Value ? 0 : (int)r["SoTienNo"]
                            );
                        lophocdangky.Hocsinh = new HocSinhDTO(
                            0, r["HoLot"].ToString(), r["Ten"].ToString(), "", "", "", "", true, null);
                        result.Add(lophocdangky);
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
