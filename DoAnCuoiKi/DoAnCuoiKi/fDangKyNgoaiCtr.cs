using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCuoiKi.BS_layer;

namespace DoAnCuoiKi
{
    public partial class fDangKyNgoaiCtr : Form
    {
        public fDangKyNgoaiCtr()
        {
            InitializeComponent();
            LoadData();
        }
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        private void LoadData()
        {
            try
            {
                this.dgrDanhSach.DataSource = qlMH.Chuong_trinh_ngoai_ke_hoach(PropertiesCls.tenDangNhap);
                this.dgrTinChi.DataSource = qlMH.Mon_dang_ky(PropertiesCls.tenDangNhap);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }
        private void dgrDanhSach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (null != dgrDanhSach)
            {
                foreach (DataGridViewRow r in dgrDanhSach.Rows)
                {
                    dgrDanhSach.Rows[r.Index].Cells[0].Value = (r.Index + 1).ToString();
                }
            }
        }
        private void dgrDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSach.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int r = dgrDanhSach.CurrentCell.RowIndex;
                qlMH.Dang_ky_mon_hoc(PropertiesCls.tenDangNhap, dgrDanhSach.Rows[r].Cells[2].Value.ToString().Trim());
            }
            LoadData();
        }
        private void dgrTinChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrTinChi.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                int r = dgrTinChi.CurrentCell.RowIndex;
                qlMH.Xoa_mon_dang_ky(PropertiesCls.tenDangNhap, dgrTinChi.Rows[r].Cells[2].Value.ToString().Trim());
            }
            LoadData();
        }
    }
}
