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
    public class HocPhiDAO
    {
        static public int CreateHocPhi(HocPhiDTO hocphi)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_create_hocphi",
                    new SqlParameter { ParameterName = "@thangdong", Value = hocphi.ThangDong },
                    new SqlParameter { ParameterName = "@giatien", Value = hocphi.GiaTien },
                    new SqlParameter { ParameterName = "@thoigiandong", Value = hocphi.ThoiGianDong },
                    new SqlParameter { ParameterName = "@nguoidong", Value = hocphi.NguoiDong },
                    new SqlParameter { ParameterName = "@nguoithu", Value = hocphi.NguoiThu },
                    new SqlParameter { ParameterName = "@dongtai", Value = hocphi.DongTai },
                    new SqlParameter { ParameterName = "@sobienlaigiay", Value = hocphi.SoBienLaiGiay },
                    new SqlParameter { ParameterName = "@thoigianchinhsua", Value = DBNull.Value },
                    new SqlParameter { ParameterName = "@madk", Value = hocphi.MaDangKy }
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
        static public List<HocPhiDTO> GetHocPhi(DateTime ngay)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocPhiDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_get_hocphi_by_ngay",
                    new SqlParameter { ParameterName = "@ngay", Value = ngay });
                if (dt != null)
                {
                    result = new List<HocPhiDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocPhiDTO hocphi = new HocPhiDTO(
                            (int)r["MaHocPhi"],
                            (DateTime)r["ThangDong"],
                            (int)r["GiaTien"],
                            (DateTime)r["ThoiGianDong"],
                            r["NguoiDong"].ToString(),
                            r["NguoiThu"].ToString(),
                            r["DongTai"].ToString(),
                            r["SoBienLaiGiay"].ToString(),
                            string.IsNullOrEmpty(r["ThoiGianChinhSua"].ToString()) ? (DateTime?)null : DateTime.Parse(r["ThoiGianChinhSua"].ToString()),
                            (int)r["MaDangKy"],
                            new LopHocDangKyDTO((int)r["MaDangKy"], null, null, true, -1, -1, "", new HocSinhDTO(-1, r["HoLot"].ToString(), r["Ten"].ToString(), "", "", "", "", false, null), new LopHocDTO(-1, r["TenLopHoc"].ToString(), -1, "", "", new GiaoVienDTO(-1, r["DanhXung"].ToString(), r["TenGiaoVien"].ToString(), "", null, null), null, null, null), 0, 0));
                        result.Add(hocphi);
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
        static public int UpdateHocPhi(HocPhiDTO hocphi)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_hocphi",
                    new SqlParameter { ParameterName = "@mahp", Value = hocphi.MaHocPhi },
                    new SqlParameter { ParameterName = "@thangdong", Value = hocphi.ThangDong },
                    new SqlParameter { ParameterName = "@giatien", Value = hocphi.GiaTien },
                    new SqlParameter { ParameterName = "@thoigiandong", Value = hocphi.ThoiGianDong },
                    new SqlParameter { ParameterName = "@nguoidong", Value = hocphi.NguoiDong },
                    new SqlParameter { ParameterName = "@nguoithu", Value = hocphi.NguoiThu },
                    new SqlParameter { ParameterName = "@dongtai", Value = hocphi.DongTai },
                    new SqlParameter { ParameterName = "@sobienlaigiay", Value = hocphi.SoBienLaiGiay },
                    new SqlParameter { ParameterName = "@thoigianchinhsua", Value = hocphi.ThoiGianChinhSua },
                    new SqlParameter { ParameterName = "@madk", Value = hocphi.MaDangKy }
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
        static public int DeleteHocPhi(int madk, int mahp)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_delete_hocphi",
                    new SqlParameter { ParameterName = "@mahp", Value = mahp },
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
