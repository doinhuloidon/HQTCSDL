﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    static class PropertiesCls
    {
        private static string DataSource = "192.168.137.1";
        private static string InitialCatalog = "DangKyQuanLyMonHoc";
        public static string connectionStringNoLogin = "Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + ";Integrated Security = True" + ";";
        public static string tenDangNhap;
        public static string matkhau;
        public static string makhoa;
        public static string quyenDangNhap;
        public static bool isClosed = false;
        public static string connectionStringLogin;
      
    }
}
