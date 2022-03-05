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
        //static public List<HocPhiDTO> GetHocPhi(DateTime ngay)
        //{
        //    DataConnection dataConnection = new DataConnection();
        //    List<HocPhiDTO> result = null;
        //    try
        //    {
        //        dataConnection.Connect();
        //        DataTable dt = dataConnection.Select(
        //            CommandType.StoredProcedure,
        //            "usp_get_hocphi_by_ngay",
        //            new SqlParameter { ParameterName = "@ngay", Value = ngay });
        //        if (dt != null)
        //        {
        //            result = new List<HocPhiDTO>();
        //            foreach (DataRow r in dt.Rows)
        //            {
        //                HocPhiDTO hocphi = new HocPhiDTO(
        //                    (int)r["MaHocPhi"],
        //                    (DateTime)r["ThangDong"],
        //                    (int)r["GiaTien"],
        //                    r["Ten"].ToString(),
        //                    r["SDTHocSinh"].ToString(),
        //                    r["SDTPhuHuynh"].ToString(),
        //                    r["Lop"].ToString(),
        //                    r["NienKhoa"].ToString(),
        //                    (bool)r["XacNhanSDT"],
        //                    null);
        //                result.Add(hocsinh);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        dataConnection.Disconnect();
        //    }
        //    return result;
        //}
    }
}
