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
    public partial class fDangKyTheoCtr : Form
    {
        public fDangKyTheoCtr()
        {
            InitializeComponent();
            LoadData();
        }
        BLQuanLyMonHoc blQLMH = new BLQuanLyMonHoc();
        private void LoadData()
        {
            try
            {
                dgrDanhSach.DataSource = blQLMH.LayMonHocTrongChuongTrinh(PropertiesCls.tenDangNhap);
                dgrTinChi.DataSource = blQLMH.DanhSachDangKy(PropertiesCls.tenDangNhap);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }
        private void dgrDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
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
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                MessageBox.Show("Hello!");
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
    }
}
