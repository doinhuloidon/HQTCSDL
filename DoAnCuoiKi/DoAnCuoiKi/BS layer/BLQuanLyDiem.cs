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
    class BLQuanLyDiem
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        public BLQuanLyDiem()
        {
            dbMain = new DBMain();
        }
        public DataSet LayDiem(string tenMon, string maMon, string HoVaTen, string MSSV, string Khoa, string ChuyenNganh, string Lop)
        {
            //Thay đổi
            string sqlString = "select SinhVien.MSSV, SinhVien.HoVaTen, Khoa.TenKhoa, ChuyenNganh.TenChuyenNganh, Lop.TenLop, "
                             + "BangDiem.MaMon, BangDiem.TenMon, BangDiem.SoTinChi, BangDiem.TenKhoa, BangDiem.DiemTB, BangDiem.TrangThai "
                             + "from SinhVien inner join Lop on SinhVien.MaLop = Lop.MaLop "
                             + "inner join ChuyenNganh on ChuyenNganh.MaChuyenNganh = Lop.MaChuyenNganh "
                             + "inner join Khoa on Khoa.MaKhoa = ChuyenNganh.MaKhoa "
                             + "inner join (select SinhVien.MSSV, MonHoc.MaMon, MonHoc.SoTinChi, MonHoc.TenMon, Khoa.TenKhoa, Diem.DiemTB, Diem.TrangThai "
                             + "from MonHoc inner join Khoa on MonHoc.MaKhoa = Khoa.MaKhoa "
                             + "inner join Diem on Diem.MaMon = MonHoc.MaMon "
                             + "inner join SinhVien on SinhVien.MSSV = Diem.MSSV) as BangDiem "
                             + "on bangdiem.MSSV = SinhVien.MSSV "
                             + "Where SinhVien.MSSV Like '%" + MSSV + "%' And SinhVien.HoVaTen Like N'%" + HoVaTen
                             + "%' And BangDiem.MaMon Like '%" + maMon + "%' And BangDiem.TenMon Like N'%" + tenMon
                             + "%' And Khoa.TenKhoa Like N'%" + Khoa + "%' And ChuyenNganh.TenChuyenNganh Like N'%" + ChuyenNganh + "%' And Lop.TenLop Like N'%" + Lop + "%'";
            return dbMain.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public bool ThemDiem(string MSSV, string maMon, string TrangThai, string DiemSo, ref string err)
        {
            string sqlString = "Insert Into Diem Values('" + MSSV + "','" + maMon + "',N'" + TrangThai + "','" + DiemSo + "')";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaDiem(string MSSV, string maMon, ref string err)
        {
            string sqlString = "Delete From Diem Where MSSV='" + MSSV + "' And MaMon='" + maMon + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatDiem(string MSSV, string maMon, string DiemSo, string TrangThai, ref string err)
        {
            string sqlString = "Update Diem Set DiemTB ='" + DiemSo + "',TrangThai= N'" + TrangThai + "' Where MSSV='" + MSSV + "' And MaMon ='" + maMon + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public string TinhToan(string tenMon, string maMon, string HoVaTen, string MSSV, string Khoa, string ChuyenNganh, string Lop, string giatri)
        {
            string sqlString = "select SinhVien.MSSV, SinhVien.HoVaTen, Khoa.TenKhoa, ChuyenNganh.TenChuyenNganh, Lop.TenLop, "
                             + "BangDiem.MaMon, BangDiem.TenMon, BangDiem.SoTinChi, BangDiem.DiemTB, BangDiem.TrangThai "
                             + "from SinhVien inner join Lop on SinhVien.MaLop = Lop.MaLop "
                             + "inner join ChuyenNganh on ChuyenNganh.MaChuyenNganh = Lop.MaChuyenNganh "
                             + "inner join Khoa on Khoa.MaKhoa = ChuyenNganh.MaKhoa "
                             + "inner join (select SinhVien.MSSV, MonHoc.MaMon, MonHoc.SoTinChi, MonHoc.TenMon, Khoa.TenKhoa, Diem.DiemTB, Diem.TrangThai "
                             + "from MonHoc inner join Khoa on MonHoc.MaKhoa = Khoa.MaKhoa "
                             + "inner join Diem on Diem.MaMon = MonHoc.MaMon "
                             + "inner join SinhVien on SinhVien.MSSV = Diem.MSSV) as BangDiem "
                             + "on bangdiem.MSSV = SinhVien.MSSV "
                             + "Where SinhVien.MSSV Like '%" + MSSV + "%' And SinhVien.HoVaTen Like N'%" + HoVaTen
                             + "%' And BangDiem.MaMon Like '%" + maMon + "%' And BangDiem.TenMon Like N'%" + tenMon
                             + "%' And Khoa.TenKhoa Like N'%" + Khoa + "%' And ChuyenNganh.TenChuyenNganh Like N'%" + ChuyenNganh + "%' And Lop.TenLop Like N'%" + Lop + "%'";
            string soMon = "select count(BangPhu.MaMon) as 'Mã Môn' from (" + sqlString + ") as BangPhu";
            string soTinChi = "select Sum(BangPhu.SoTinChi) As 'Số Tín Chỉ' from (" + sqlString + ") as BangPhu";
            string diemTB = "select Round(AVG(BangPhu.DiemTB), 2) as 'Điểm TB' from (" + sqlString + ") as BangPhu";
            if (giatri == "SoLuongMon")
                return dbMain.ExecuteScalar(soMon, CommandType.Text);
            else if (giatri == "SoTinChi")
                return dbMain.ExecuteScalar(soTinChi, CommandType.Text);
            else
                return dbMain.ExecuteScalar(diemTB, CommandType.Text);
        }
        public bool KiemTraTrungLap(string MSSV, string maMon)
        {
            string sqlString = "Select Diem.MSSV, Diem.MaMon From Diem";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                string maSV = (string)sdr["MSSV"];
                string mamon = (string)sdr["MaMon"];
                if (maSV.Trim() == MSSV && mamon.Trim() == maMon)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KiemTraTruongBoMon(string MaTrBoMon, string MaMon)
        {
            string sqlString = "Select MonHoc.MaTrBoMon From MonHoc Where MonHoc.MaMon ='" + MaMon + "'";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            if (sdr.Read())
            {
                string s = (string)sdr["MaTrBoMon"].ToString().Trim() + "-------" + MaTrBoMon;
                if ((string)sdr["MaTrBoMon"].ToString().Trim() == MaTrBoMon)
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
