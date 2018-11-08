using DoAnCuoiKi.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DoAnCuoiKi.BS_layer
{
    class BLQuanLyChuyenNganh
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        public BLQuanLyChuyenNganh()
        {
            dbMain = new DBMain();
        }
        public DataSet LayChuyenNganh()
        {
            string sqlString = "select * from ChuyenNganh";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ThemChuyenNganh(string maChuyenNganh, string tenChuyenNganh, string maKhoa, ref string err) 
        {
            string sqlString = "Insert Into ChuyenNganh Values(" + "'" + maChuyenNganh + "',N'" + tenChuyenNganh + "','" + maKhoa + "')";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaChuyenNganh(string maChuyenNganh, ref string err)
        {
            string sqlString = "Delete From ChuyenNganh Where MaChuyenNganh='" + maChuyenNganh + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatChuyenNganh(string maChuyenNganh, string tenChuyenNganh, string maKhoa, ref string err)
        {
            string sqlString = "Update ChuyenNganh Set TenChuyenNganh=N'" + tenChuyenNganh + "' Where MaChuyenNganh='" + maChuyenNganh + "' And MaKhoa='" + maKhoa + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet LayChuyenNganh(string TenKhoa)//Lay De Filter
        {
            string sqlString = "select ChuyenNganh.TenChuyenNganh from ChuyenNganh,Khoa Where ChuyenNganh.MaKhoa=Khoa.MaKhoa And Khoa.TenKhoa Like N'%"+ TenKhoa + "%'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ktrathem(string MaChuyenNganh,string TenChuyenNganh)
        {
            string sqlString = "select ChuyenNganh.MaChuyenNganh,ChuyenNganh.TenChuyenNganh from ChuyenNganh";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {

                string machuyennganh = (string)sdr["MaChuyenNganh"];
                string tenchuyennganh = (string)sdr["TenChuyenNganh"];
                if (machuyennganh.Trim().ToUpper()==MaChuyenNganh.Trim().ToUpper()||tenchuyennganh.Trim().ToUpper()==TenChuyenNganh.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        public bool ktrasua( string TenChuyenNganh)
        {
            string sqlString = "select ChuyenNganh.TenChuyenNganh from ChuyenNganh";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
             
                string tenchuyennganh = (string)sdr["TenChuyenNganh"];
                if ( tenchuyennganh.Trim().ToUpper() == TenChuyenNganh.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        public SqlDataReader FilterKhoa()
        {
            string sqlString = "Select Khoa.MaKhoa From Khoa";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
    }
}
