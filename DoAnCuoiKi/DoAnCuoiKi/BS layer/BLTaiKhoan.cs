using DoAnCuoiKi.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.BS_layer
{
    class BLTaiKhoan
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        public BLTaiKhoan()
        {
            dbMain = new DBMain();
        }
        //public DataSet LayTaiKhoan()
        //{
        //    string sqlString = "select * from TaiKhoan";
        //    return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        //}
        //public bool ThemTaiKhoan(string maUser, string tenDangNhap, string matkhau, string hovaten, string quyen, string gioitinh, ref string err)
        //{
        //    string sqlString = "Insert Into UserLogin Values(" + "'" + maUser + "','" + tenDangNhap + "','" + matkhau + "',N'" + hovaten + "',N'" + gioitinh + "',N'" + quyen + "')";
        //    return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //public bool XoaTaiKhoan(string maUser, ref string err)
        //{
        //    string sqlString = "Delete From UserLogin Where maUser='" + maUser + "'";
        //    return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //public bool CapNhatTaiKhoan(string maUser, string matkhau, string hovaten, string quyen, string gioitinh, ref string err)
        //{
        //    string sqlString = "Update UserLogin Set MatKhau='" +
        //        matkhau + "',HoVaTen=N'" + hovaten + "',Quyen=N'" + quyen + "',GioiTinh=N'" + gioitinh + "' Where MaUser='" + maUser + "'";
        //    return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        public bool KiemTraDangNhap(string TenDangNhap, string MatKhau)
        {
            string sqlString = "Select * From TaiKhoan";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            try
            {
                while (sdr.Read())
                {
                    string username = (string)sdr["tenDangNhap"].ToString().Trim();
                    string password = (string)sdr["matkhau"].ToString().Trim();
                    if (username.ToLower() == TenDangNhap.ToLower() && password.ToLower() == MatKhau.ToLower())
                    {
                        PropertiesCls.tenDangNhap = sdr["tenDangNhap"].ToString().Trim();
                        PropertiesCls.matkhau = sdr["matKhau"].ToString().Trim();
                        PropertiesCls.quyenDangNhap = sdr["quyenDangNhap"].ToString().Trim();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
        //public bool ktrathem(string MaNguoiDung,string TenDN)
        //{
        //    String sqlString = "Select UserLogin.MaUser, UserLogin.TenDangNhap From UserLogin";
        //    sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
        //    while (sdr.Read())
        //    {
        //        string manguoidung = (string)sdr["MaUser"];
        //        string tendangnhap = (string)sdr["TenDangNhap"];
        //        if (manguoidung.Trim().ToUpper()== MaNguoiDung.ToUpper().Trim() || tendangnhap.Trim().ToUpper()==TenDN.Trim().ToUpper())
        //        {
        //            return true;
        //        }
        //        if( MaNguoiDung.Trim() == "" || TenDN.Trim() == "")
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public bool ktrasua( string TenDN)
        //{
        //    String sqlString = "Select UserLogin.TenDangNhap From UserLogin";
        //    sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
        //    while (sdr.Read())
        //    {
              
        //        string tendangnhap = (string)sdr["TenDangNhap"];
        //        if ( tendangnhap.Trim() == TenDN)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
