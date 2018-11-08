using DoAnCuoiKi.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi.BS_layer
{
    class BLQuanLyKhoa
    {
        DBMain dbMain = null;
        public BLQuanLyKhoa()
        {
            dbMain = new DBMain();
        }
        public DataSet LayKhoa()
        {
            string sqlString = "select * from Khoa";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ThemKhoa(string maKhoa, string tenKhoa, ref string err)
        {
            if(maKhoa==""||tenKhoa=="")
            {
                err = "Không đủ thông tin để thêm !";
                return false;
            }
            string sqlString = "Insert Into Khoa Values(" + "'" + maKhoa + "',N'" + tenKhoa + "')";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaKhoa(string maKhoa, ref string err)
        {
            string sqlString = "Delete From Khoa Where MaKhoa='" + maKhoa + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatKhoa(string maKhoa, string tenKhoa, ref string err)
        {
            string sqlString = "Select Khoa.TenKhoa From Khoa";
            SqlDataReader sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                if (sdr.GetString(0).ToLower().Trim() == tenKhoa.ToLower().Trim())
                {
                    err = "Tên khoa đã tồn tại !";
                    return false;
                }
            }
            sqlString = "Update Khoa Set TenKhoa=N'" + tenKhoa + "' Where MaKhoa='" + maKhoa + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool KiemTraTrungLap(string maKhoa, string tenKhoa, ref string err)
        {
            string sqlString = "Select Khoa.MaKhoa, Khoa.TenKhoa From Khoa";
            SqlDataReader sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                string makhoa = (string)sdr["MaKhoa"];
                string tenkhoa = (string)sdr["TenKhoa"];
                if (makhoa.Trim() == maKhoa)
                {
                    err = "Không thêm được, mã khoa đã tồn tại !";
                    return true;
                }
                if (tenkhoa.ToLower().Trim() == tenKhoa.ToLower().Trim())
                {
                    err = "Tên khoa đã tồn tại !";
                    return true;
                }
            }
            return false;
        }
    }
}
