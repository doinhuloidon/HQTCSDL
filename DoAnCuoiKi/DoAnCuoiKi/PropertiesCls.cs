using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    static class PropertiesCls
    {
        private static string DataSource = "(local)";
        private static string InitialCatalog = "DangKyQuanLyMonHoc";
        //public static string connectionStringLogin = "Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + ";Integrated Security = False" +
        //    ";User ID=" + UserID + ";Password=" + Password + ";";
        public static string connectionStringNoLogin = "Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + ";Integrated Security = True" + ";";
        public static string tenDangNhap;
        public static string matkhau;
        public static string makhoa;
        public static string quyenDangNhap;
        public static bool isClosed = false;
    }
}
