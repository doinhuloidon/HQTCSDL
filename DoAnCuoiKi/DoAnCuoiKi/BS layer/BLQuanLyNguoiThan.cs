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
    class BLQuanLyNguoiThan
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        public BLQuanLyNguoiThan()
        {
            dbMain = new DBMain();
        }
        public DataSet LayNguoiThan(string MSSV, string TenSV, string Khoa, string ChuyenNganh, string Lop)//Co them TenSV,TenKhoa,TenChuyenNganh,TenLop de thuan tien tim kiem
        {
            string sqlString = "select SinhVien.MSSV,SinhVien.HoVaTen,ThanNhan.HoVaTen,ThanNhan.DiaChi,ThanNhan.SDT,ThanNhan.QuanHe,Khoa.TenKhoa,ChuyenNganh.TenChuyenNganh,Lop.TenLop" +
                " from ThanNhan,SinhVien,Lop,ChuyenNganh,Khoa Where ThanNhan.MSSV=SinhVien.MSSV And SinhVien.MaLop=Lop.MaLop" +
                " And Lop.MaChuyenNganh=ChuyenNganh.MaChuyenNganh And ChuyenNganh.MaKhoa = Khoa.MaKhoa" +
                " And SinhVien.MSSV Like '%" + MSSV + "%' And SinhVien.HoVaTen Like N'%" + TenSV + "%' And Khoa.TenKhoa Like N'%" + Khoa + "%' And ChuyenNganh.TenChuyenNganh Like N'%" + ChuyenNganh + "%' And Lop.TenLop Like N'%" + Lop + "%'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ThemNguoiThan(string HoVaTen, string MSSV, string DiaChi, string SDT, string QuanHe, ref string err)
        {
            string sqlString = "Insert Into ThanNhan Values(" + "N'" + HoVaTen + "','" + MSSV + "',N'" + DiaChi + "','" + SDT + "',N'" + QuanHe + "')";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNguoiThan(string HoVaTen, string MSSV, ref string err)
        {
            string sqlString = "Delete From ThanNhan Where HoVaTen=N'" + HoVaTen + "' And MSSV='" + MSSV + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatNguoiThan(string HoVaTen, string MSSV, string DiaChi, string SDT, string QuanHe, ref string err)
        {
            string sqlString = "Update ThanNhan Set DiaChi=N'" + DiaChi + "',SDT='" + SDT + "',QuanHe=N'" + QuanHe + "' Where HoVaTen=N'" + HoVaTen + "' And MSSV='" + MSSV + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool ktra(string Mssv, string Tennt)
        {

            string sqlString = "select ThanNhan.MSSV,ThanNhan.HoVaTen from ThanNhan";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                string mssv = (string)sdr["MSSV"];
                string tennt = (string)sdr["HoVaTen"];
                if (mssv.Trim() == Mssv && tennt.Trim() == Tennt)
                {

                    return true;
                }

            }

            return false;
        }
        public SqlDataReader FilterKhoa()
        {
            string sqlString = "Select Khoa.TenKhoa From Khoa";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
        public SqlDataReader FilterChuyenNganh(string TenKhoa)
        {
            string sqlString = "Select ChuyenNganh.TenChuyenNganh From ChuyenNganh,Khoa" +
                " Where ChuyenNganh.MaKhoa=Khoa.MaKhoa And Khoa.TenKhoa=N'" + TenKhoa + "'";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
        public SqlDataReader FilterLop(string TenChuyenNganh)
        {
            string sqlString = "Select Lop.TenLop From Lop,ChuyenNganh" +
                " Where Lop.MaChuyenNganh=ChuyenNganh.MaChuyenNganh And ChuyenNganh.TenChuyenNganh=N'" + TenChuyenNganh + "'";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
    }
}
