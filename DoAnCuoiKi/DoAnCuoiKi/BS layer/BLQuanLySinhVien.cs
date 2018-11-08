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
    class BLQuanLySinhVien
    {
        DBMain dbMain = null;
        public BLQuanLySinhVien()
        {
            dbMain = new DBMain();
        }
        public DataSet LaySinhVien(string Khoa, string ChuyenNganh, string Lop)
        {
            string sqlString = "Select SinhVien.MSSV, SinhVien.HoVaTen, SinhVien.QueQuan, CONVERT( VARCHAR, SinhVien.NgaySinh, 105 ), SinhVien.CMND, SinhVien.GioiTinh, SinhVien.DiaChi, SinhVien.NienKhoa, SinhVien.MaLop, Lop.TenLop, ChuyenNganh.TenChuyenNganh, Khoa.TenKhoa " +
                " From SinhVien,Lop,ChuyenNganh,Khoa" +
                " Where SinhVien.MaLop = Lop.MaLop And Lop.MaChuyenNganh = ChuyenNganh.MaChuyenNganh And ChuyenNganh.MaKhoa = Khoa.MaKhoa And Khoa.TenKhoa Like N'%" + Khoa +
                "%' And ChuyenNganh.TenChuyenNganh Like N'%" + ChuyenNganh + "%' And Lop.TenLop Like N'%" + Lop + "%'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet LaySinhVien(string MSSV, string HoVaTen, string Khoa, string ChuyenNganh, string Lop, string GioiTinh, string NienKhoa, string QueQuan)
        {
            string sqlString = "Select SinhVien.MSSV, SinhVien.HoVaTen, SinhVien.QueQuan, CONVERT( VARCHAR, SinhVien.NgaySinh, 105 ), SinhVien.CMND, SinhVien.GioiTinh, SinhVien.DiaChi, SinhVien.NienKhoa, SinhVien.MaLop, Lop.TenLop, ChuyenNganh.TenChuyenNganh, Khoa.TenKhoa " +
                " From SinhVien,Lop,ChuyenNganh,Khoa" +
                " Where SinhVien.MaLop = Lop.MaLop And Lop.MaChuyenNganh = ChuyenNganh.MaChuyenNganh And ChuyenNganh.MaKhoa = Khoa.MaKhoa And Khoa.TenKhoa Like N'%" + Khoa +
                "%' And ChuyenNganh.TenChuyenNganh Like N'%" + ChuyenNganh + "%' And Lop.TenLop Like N'%" + Lop + "%' And SinhVien.MSSV Like '%" + MSSV + "%' And SinhVien.HoVaTen Like N'%" + HoVaTen + "%'" +
                " And SinhVien.GioiTinh Like N'%" + GioiTinh + "%' And SinhVien.NienKhoa Like '%" + NienKhoa + "%' And SinhVien.QueQuan Like '%" + QueQuan + "%'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ThemSinhVien(string MSSV, string HoVaTen, string GioiTinh, string QueQuan, string NgaySinh, string CMND, string DiaChi, string NienKhoa, string maLop, ref string err)
        {
            string sqlString = "Select SinhVien.MSSV From SinhVien Where SinhVien.MSSV='" + MSSV + "'";
            SqlDataReader sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            if (sdr.Read())
            {
                err = "Không thêm được, mã số sinh viên đã tồn tại !";
                return false;
            }
            sqlString = "Insert Into SinhVien Values('" + MSSV + "',N'" + HoVaTen + "',N'" + QueQuan + "','" + NgaySinh + "','" + CMND + "',N'" + GioiTinh + "',N'" + DiaChi + "','" + NienKhoa + "','" + maLop + "')";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaSinhVien(string MSSV, ref string err)
        {
            string sqlString = "Delete From SinhVien Where MSSV='" + MSSV + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatSinhVien(string MSSV, string HoVaTen, string GioiTinh, string QueQuan, string NgaySinh, string CMND, string DiaChi, string NienKhoa, string maLop, ref string err)
        {
            string sqlString = "Update SinhVien Set MSSV='" + MSSV + "',HoVaTen=N'"
                + HoVaTen + "',QueQuan=N'" + QueQuan + "',NgaySinh='" + NgaySinh + "',CMND='" + CMND + "',GioiTinh=N'" + GioiTinh + "',DiaChi=N'" +
                 DiaChi + "',NienKhoa='" + NienKhoa + "',MaLop='" + maLop + "'"
                + " Where MSSV='" + MSSV + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
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
