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
    public class HocSinhDAO
    {
        static public List<HocSinhDTO> SearchHocSinh(string holot, string ten)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocSinhDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_search_hocsinh",
                    new SqlParameter { ParameterName = "@holot", Value = holot },
                    new SqlParameter { ParameterName = "@ten", Value = ten });
                if (dt != null)
                {
                    result = new List<HocSinhDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocSinhDTO hocsinh = new HocSinhDTO(
                            (int)r["MaHS"],
                            r["HoLot"].ToString(),
                            r["Ten"].ToString(),
                            r["SDTHocSinh"].ToString(),
                            r["SDTPhuHuynh"].ToString(),
                            r["Lop"].ToString(),
                            r["NienKhoa"].ToString(),
                            (bool)r["XacNhanSDT"],
                            null);
                        result.Add(hocsinh);
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

        static public List<HocSinhDTO> SearchHocSinhByPhone(string sdthocsinh)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocSinhDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_search_hocsinh_sdthocsinh",
                    new SqlParameter { ParameterName = "@sdthocsinh", Value = sdthocsinh });
                if (dt != null)
                {
                    result = new List<HocSinhDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocSinhDTO hocsinh = new HocSinhDTO(
                            (int)r["MaHS"],
                            r["HoLot"].ToString(),
                            r["Ten"].ToString(),
                            r["SDTHocSinh"].ToString(),
                            r["SDTPhuHuynh"].ToString(),
                            r["Lop"].ToString(),
                            r["NienKhoa"].ToString(),
                            (bool)r["XacNhanSDT"],
                            null);
                        result.Add(hocsinh);
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
        static public List<HocSinhDTO> SearchHocSinhByParentPhone(string sdtphuhuynh)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocSinhDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_search_hocsinh_sdtphuhuynh",
                    new SqlParameter { ParameterName = "@sdtphuhuynh", Value = sdtphuhuynh});
                if (dt != null)
                {
                    result = new List<HocSinhDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocSinhDTO hocsinh = new HocSinhDTO(
                            (int)r["MaHS"],
                            r["HoLot"].ToString(),
                            r["Ten"].ToString(),
                            r["SDTHocSinh"].ToString(),
                            r["SDTPhuHuynh"].ToString(),
                            r["Lop"].ToString(),
                            r["NienKhoa"].ToString(),
                            (bool)r["XacNhanSDT"],
                            null);
                        result.Add(hocsinh);
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

        static public List<HocSinhDTO> SearchHocSinhExact(string holot, string ten)
        {
            DataConnection dataConnection = new DataConnection();
            List<HocSinhDTO> result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_search_hocsinh_exact",
                    new SqlParameter { ParameterName = "@holot", Value = holot },
                    new SqlParameter { ParameterName = "@ten", Value = ten });
                if (dt != null)
                {
                    result = new List<HocSinhDTO>();
                    foreach (DataRow r in dt.Rows)
                    {
                        HocSinhDTO hocsinh = new HocSinhDTO(
                            (int)r["MaHS"],
                            r["HoLot"].ToString(),
                            r["Ten"].ToString(),
                            r["SDTHocSinh"].ToString(),
                            r["SDTPhuHuynh"].ToString(),
                            r["Lop"].ToString(),
                            r["NienKhoa"].ToString(),
                            (bool)r["XacNhanSDT"],
                            null);
                        result.Add(hocsinh);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public HocSinhDTO SearchHocSinhByID(int mahs)
        {
            DataConnection dataConnection = new DataConnection();
            HocSinhDTO result = null;
            try
            {
                dataConnection.Connect();
                DataTable dt = dataConnection.Select(
                    CommandType.StoredProcedure,
                    "usp_search_hocsinh_by_id",
                    new SqlParameter { ParameterName = "@mahs", Value = mahs });
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        result = new HocSinhDTO(
                            (int)r["MaHS"],
                            r["HoLot"].ToString(),
                            r["Ten"].ToString(),
                            r["SDTHocSinh"].ToString(),
                            r["SDTPhuHuynh"].ToString(),
                            r["Lop"].ToString(),
                            r["NienKhoa"].ToString(),
                            (bool)r["XacNhanSDT"],
                            null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataConnection.Disconnect();
            }
            return result;
        }
        static public int CreateHocSinh(HocSinhDTO hocsinh)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_create_hocsinh",
                    new SqlParameter { ParameterName = "@holot", Value = hocsinh.HoLot },
                    new SqlParameter { ParameterName = "@ten", Value = hocsinh.Ten },
                    new SqlParameter { ParameterName = "@sdthocsinh", Value = hocsinh.SdtHocSinh },
                    new SqlParameter { ParameterName = "@sdtphuhuynh", Value = hocsinh.SdtPhuHuynh },
                    new SqlParameter { ParameterName = "@lop", Value = hocsinh.Lop },
                    new SqlParameter { ParameterName = "@xacnhansdt", Value = hocsinh.XacNhanSDT},
                    new SqlParameter { ParameterName = "@nienkhoa", Value = hocsinh.NienKhoa }
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
        static public int UpdateHocSinh(HocSinhDTO hocsinh)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_update_hocsinh",
                    new SqlParameter { ParameterName = "@mahs", Value = hocsinh.MaHS },
                    new SqlParameter { ParameterName = "@holot", Value = hocsinh.HoLot },
                    new SqlParameter { ParameterName = "@ten", Value = hocsinh.Ten },
                    new SqlParameter { ParameterName = "@sdthocsinh", Value = hocsinh.SdtHocSinh },
                    new SqlParameter { ParameterName = "@sdtphuhuynh", Value = hocsinh.SdtPhuHuynh },
                    new SqlParameter { ParameterName = "@lop", Value = hocsinh.Lop },
                    new SqlParameter { ParameterName = "@xacnhansdt", Value = hocsinh.XacNhanSDT },
                    new SqlParameter { ParameterName = "@nienkhoa", Value = hocsinh.NienKhoa }
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
        static public int DeleteHocSinh(int mahs)
        {
            DataConnection dataConnection = new DataConnection();
            int result = 0;
            try
            {
                dataConnection.Connect();
                result = dataConnection.ExecuteNonQuery(
                    CommandType.StoredProcedure,
                    "usp_delete_hocsinh",
                    new SqlParameter { ParameterName = "@mahs", Value = mahs }
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
