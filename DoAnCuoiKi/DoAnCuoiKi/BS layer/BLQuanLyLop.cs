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
    class BLQuanLyLop
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        public BLQuanLyLop()
        {
            dbMain = new DBMain();
        }
        public DataSet LayLop()
        {
            string sqlString = "select * from Mon_hoc;";           
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet LayGiaoVien()
        {
            string sqlString = "select* from Giao_vien";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool XoaLop(string maLop, ref string err)
        {
            string sqlString = "Delete From Lop Where MaLop='" + maLop + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatLop(string maLop, string tenLop, string maChuyenNganh, ref string err)
        {
            string sqlString = "Update Lop Set TenLop=N'" + tenLop + "' Where MaLop='" + maLop + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet LayLop(string TenChuyenNganh)//Lay De Filter
        {
            string sqlString = "select Lop.TenLop From ChuyenNganh,Khoa,Lop " +
                "Where Lop.MaChuyenNganh = ChuyenNganh.MaChuyenNganh And ChuyenNganh.MaKhoa = Khoa.MaKhoa And ChuyenNganh.TenChuyenNganh=N'" + TenChuyenNganh + "'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ktrathem(string MaLop, string TenLop)
        {
            string sqlString = "select Lop.MaLop,Lop.TenLop from Lop";

            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                string malop = (string)sdr["MaLop"].ToString();
                string tenlop = (string)sdr["TenLop"].ToString();
                if (malop.Trim() == MaLop && tenlop.Trim() == TenLop)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ktrasua(string TenLop)
        {
            string sqlString = "select Lop.TenLop from Lop";

            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {

                string tenlop = (string)sdr["TenLop"].ToString();
                if (tenlop.Trim() == TenLop)
                {
                    return true;
                }
            }
            return false;
        }
        public SqlDataReader FilterMaKhoa()
        {
            string sqlString = "Select Khoa.MaKhoa From Khoa";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
        public SqlDataReader FilterMaChuyenNganh(string MaKhoa)
        {
            string sqlString = "Select ChuyenNganh.MaChuyenNganh From ChuyenNganh Where ChuyenNganh.MaKhoa='" + MaKhoa + "'";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
    }
}
