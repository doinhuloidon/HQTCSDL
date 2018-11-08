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
    class BLQuanLyMonHoc
    {
        DBMain dbMain = null;
        SqlDataReader sdr = null;
        QLDangKyMonHocDataContext ql = new QLDangKyMonHocDataContext();
        public BLQuanLyMonHoc()
        {
            dbMain = new DBMain();
        }
        public IEnumerable<dynamic> ChuongTrinhDaoTao(string maSV)
        {
            var monHoc = ql.Chuong_trinh_dao_tao(maSV);
            return monHoc;
        }
        public IEnumerable<dynamic> LayMonHocTrongChuongTrinh(string maSV)
        {
            var monHoc = ql.Chuong_trinh_theo_ke_hoach(maSV);
            return monHoc;
        }
        public IEnumerable<dynamic> LayMonHocNgoaiChuongTrinh(string maSV)
        {
            var monHoc = ql.Chuong_trinh_ngoai_ke_hoach(maSV);
            return monHoc;
        }
        public IEnumerable<dynamic> DanhSachDangKy(string maSV)
        {
            var dangKy = ql.Mon_dang_ky(maSV);
            return dangKy;
        }
        public void DangKyMonHoc(string maSV, string maLop)
        {
            var dangKy = ql.Dang_ky_mon_hoc(maSV, maLop);
        }
        public bool XoaMonHoc(string maMonHoc, ref string err)
        {
            string sqlString = "Delete From MonHoc Where MaMon='" + maMonHoc + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatMonHoc(string maMon, string tenMon, string soTinChi, string maTruongBoMon, string maKhoa, string maTrBoMon, ref string err)
        {
            string sqlString = "Update MonHoc Set TenMon = N'" + tenMon + "', SoTinChi = '" + soTinChi + "', MaTrBoMon = '" + maTrBoMon + "', MaKhoa = '" + maKhoa
                + "' where MaMon = '" + maMon + "'";
            return dbMain.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool KiemTraTrungLap(string maMon, string tenMon)
        {
            string sqlString = "Select MaMon, TenMon From MonHoc";
            sdr = dbMain.ExecuteReader(sqlString, CommandType.Text);
            while (sdr.Read())
            {
                string mamon = (string)sdr["MaMon"];
                string tenmon = (string)sdr["TenMon"];
                if (mamon.Trim().ToLower() == maMon.Trim().ToLower() || tenmon.Trim().ToLower() == tenMon.Trim().ToLower())
                {
                    return true;
                }
            }
            return false;
        }
       
        public SqlDataReader FilterKhoa()
        {
            string sqlString = "Select Khoa.MaKhoa, Khoa.TenKhoa From Khoa";
            return dbMain.ExecuteReader(sqlString, CommandType.Text);
        }
    }
}
