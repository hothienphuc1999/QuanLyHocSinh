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
        static public List<HocPhiNoDTO> FindHocPhiNoByIDHocSinh(int mahocsinh)
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
                            new LopHocDangKyDTO((int)r["MaDangKy"], null, null, true, mahocsinh, -1, "", null,new LopHocDTO(-1, r["TenLopHoc"].ToString(), -1,"", "", new GiaoVienDTO(-1, r["DanhXung"].ToString(), r["TenGiaoVien"].ToString(), "", null, null), null, null, null), 0, 0));
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
    }
}
