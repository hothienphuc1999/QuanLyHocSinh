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
    public class HocPhiNoDAO
    {
        static public List<HocPhiNoDTO> GetHocPhiNoByIDHocSinh(int mahocsinh)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocPhiNoDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_hocphino_by_mahs",
                    new SqlParameter { ParameterName = "@mahs", Value = mahocsinh });
                if (dt != null)
                {
                    result = new List<HocPhiNoDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocPhiNoDTO hpno = new HocPhiNoDTO(
                            (int)r["MaNo"],
                            (DateTime)r["ThangNo"],
                            (int)r["TienNo"],
                            (int)r["MaDangKy"],
                            new LopHocDangKyDTO((int)r["MaDangKy"], null, null, true, mahocsinh, -1, "", null, new LopHocDTO(-1, r["TenLopHoc"].ToString(), -1, "", "", new GiaoVienDTO(-1, r["DanhXung"].ToString(), r["TenGiaoVien"].ToString(), "", null, null), null, null, null), 0, 0));
                        result.Add(hpno);
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
        static public List<HocPhiNoDTO> GetHocPhiNoByIDLopHocAndMonth(int malh, DateTime thang)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocPhiNoDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_hocphino_by_idlophoc_thang",
                    new SqlParameter { ParameterName = "@malh", Value = malh },
                    new SqlParameter { ParameterName = "@thang", Value = thang });
                if (dt != null)
                {
                    result = new List<HocPhiNoDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocPhiNoDTO hpno = new HocPhiNoDTO(
                            (int)r["MaNo"],
                            (DateTime)r["ThangNo"],
                            (int)r["TienNo"],
                            (int)r["MaDangKy"],
                            new LopHocDangKyDTO((int)r["MaDangKy"], string.IsNullOrEmpty(r["NgayBatDau"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayBatDau"].ToString()), string.IsNullOrEmpty(r["NgayKetThuc"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayKetThuc"].ToString()), true, -1, -1, "", new HocSinhDTO(-1, r["HoLot"].ToString(), r["Ten"].ToString(), "", "", "", "", false, null), null, 0, 0));
                        result.Add(hpno);
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
        static public List<HocPhiNoDTO> GetLopHocDangKyByIDLopHocAndMonth(int malh, DateTime thang)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocPhiNoDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_lhdk_by_month_idlophoc",
                    new SqlParameter { ParameterName = "@malophoc", Value = malh },
                    new SqlParameter { ParameterName = "@thang", Value = thang });
                if (dt != null)
                {
                    result = new List<HocPhiNoDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocPhiNoDTO hpno = new HocPhiNoDTO(
                            -1,
                            thang,
                            0,
                            (int)r["MaDangKy"],
                            new LopHocDangKyDTO((int)r["MaDangKy"], string.IsNullOrEmpty(r["NgayBatDau"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayBatDau"].ToString()), string.IsNullOrEmpty(r["NgayKetThuc"].ToString()) ? (DateTime?)null : DateTime.Parse(r["NgayKetThuc"].ToString()), true, -1, -1, r["MienGiam"].ToString(), new HocSinhDTO(-1, r["HoLot"].ToString(), r["Ten"].ToString(), "", "", "", "", false, null), null, r["SoTienDong"] == System.DBNull.Value ? 0 : (int)r["SoTienDong"], 0));
                        result.Add(hpno);
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
        static public int CreateHocPhiNo(HocPhiNoDTO hocphino)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_create_hocphino",
                    new SqlParameter { ParameterName = "@thangno", Value = hocphino.ThangNo },
                    new SqlParameter { ParameterName = "@tienno", Value = hocphino.TienNo },
                    new SqlParameter { ParameterName = "@madk", Value = hocphino.MaDangKy }
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
        static public int UpdateHocPhiNo(HocPhiNoDTO hocphino)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_hocphino",
                    new SqlParameter { ParameterName = "@mano", Value = hocphino.MaNo },
                    new SqlParameter { ParameterName = "@thangno", Value = hocphino.ThangNo },
                    new SqlParameter { ParameterName = "@tienno", Value = hocphino.TienNo },
                    new SqlParameter { ParameterName = "@madk", Value = hocphino.MaDangKy }
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
        static public int DeleteHocPhiNo(int madk, int mano)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_delete_hocphino",
                    new SqlParameter { ParameterName = "@madk", Value = madk },
                    new SqlParameter { ParameterName = "@mano", Value = mano }
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
