using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi
{   
    public partial class fTKB : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
        public fTKB()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            dgrTKB.DataSource = qlMH.Thoi_khoa_bieu(PropertiesCls.tenDangNhap);
        }
    }
}
