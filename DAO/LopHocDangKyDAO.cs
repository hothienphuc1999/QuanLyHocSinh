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
        static public List<LopHocDangKyDTO> GetLopHocDangKyByIDHocSinh(int mahs)
        {
            DataConnection dataConnection = new DataConnection();
            List<LopHocDangKyDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_lhdk_with_lophoc_by_idhocsinh",
                    new SqlParameter { ParameterName = "@mahs", Value = mahs });
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
                            new LopHocDTO(
                                (int)r["MaLopHoc"],
                                r["TenLopHoc"].ToString(),
                                -1,
                                "",
                                r["NienKhoa"].ToString(),
                                new GiaoVienDTO(-1, r["DanhXung"].ToString(), r["TenGiaoVien"].ToString(), "", null, null),
                                null,
                                null,
                                null),
                            0,
                            r["SoTienNo"] == System.DBNull.Value ? 0 : (int)r["SoTienNo"]
                            );
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
        static public int CreateLopHocDangKy(LopHocDangKyDTO dangky)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_create_lhdk",
                    new SqlParameter { ParameterName = "@ngaybd", Value = dangky.NgayBatDau },
                    new SqlParameter { ParameterName = "@ngaykt", Value = DBNull.Value },
                    new SqlParameter { ParameterName = "@tinhtrang", Value = dangky.TinhTrang },
                    new SqlParameter { ParameterName = "@mahs", Value = dangky.MaHocSinh },
                    new SqlParameter { ParameterName = "@malh", Value = dangky.MaLopHoc },
                    new SqlParameter { ParameterName = "@miengiam", Value = dangky.Miengiam }
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
        static public int UpdateLopHocDangKy(LopHocDangKyDTO dangky)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                if (dangky.NgayKetThuc == null)
                {
                    result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_lhdk",
                    new SqlParameter { ParameterName = "@madk", Value = dangky.MaDangKy },
                    new SqlParameter { ParameterName = "@ngaybd", Value = dangky.NgayBatDau },
                    new SqlParameter { ParameterName = "@ngaykt", Value = DBNull.Value },
                    new SqlParameter { ParameterName = "@tinhtrang", Value = dangky.TinhTrang },
                    new SqlParameter { ParameterName = "@mahs", Value = dangky.MaHocSinh },
                    new SqlParameter { ParameterName = "@malh", Value = dangky.MaLopHoc },
                    new SqlParameter { ParameterName = "@miengiam", Value = dangky.Miengiam }
                    );
                }
                else
                {
                    result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_lhdk",
                    new SqlParameter { ParameterName = "@madk", Value = dangky.MaDangKy },
                    new SqlParameter { ParameterName = "@ngaybd", Value = dangky.NgayBatDau },
                    new SqlParameter { ParameterName = "@ngaykt", Value = dangky.NgayKetThuc },
                    new SqlParameter { ParameterName = "@tinhtrang", Value = dangky.TinhTrang },
                    new SqlParameter { ParameterName = "@mahs", Value = dangky.MaHocSinh },
                    new SqlParameter { ParameterName = "@malh", Value = dangky.MaLopHoc },
                    new SqlParameter { ParameterName = "@miengiam", Value = dangky.Miengiam }
                    );
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
        static public int DeleteLopHocDangKy(int madk)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_delete_lhdk",
                    new SqlParameter { ParameterName = "@madk", Value = madk }
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
