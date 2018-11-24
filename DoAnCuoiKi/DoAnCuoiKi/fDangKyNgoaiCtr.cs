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
    public partial class fDangKyNgoaiCtr : Form
    {
        public fDangKyNgoaiCtr()
        {
            InitializeComponent();
            LoadData();
        }
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
        public void LoadData()
        {
            try
            {
                this.dgrDanhSach.DataSource = qlMH.Chuong_trinh_ngoai_ke_hoach(PropertiesCls.tenDangNhap);
                this.dgrTinChi.DataSource = qlMH.Mon_dang_ky(PropertiesCls.tenDangNhap);
                label1.Text = "Số tín chỉ đã đăng ký: " + qlMH.Dem_so_tin_chi(PropertiesCls.tenDangNhap) + " tín chỉ";
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
                try
                {
                    int r = dgrDanhSach.CurrentCell.RowIndex;
                    qlMH.Dang_ky_mon_hoc(PropertiesCls.tenDangNhap, dgrDanhSach.Rows[r].Cells[2].Value.ToString().Trim());
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Không thể đăng ký!");
                }
            }
        }
        private void dgrTinChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                int r = dgrTinChi.CurrentCell.RowIndex;
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.OK)
                {
                    qlMH.Xoa_mon_dang_ky(PropertiesCls.tenDangNhap, dgrTinChi.Rows[r].Cells[2].Value.ToString().Trim());
                }
                LoadData();
            }
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                int r = dgrTinChi.CurrentCell.RowIndex;
                string s = dgrTinChi.Rows[r].Cells[2].Value.ToString().Trim();
                fChuyenLop f = new fChuyenLop();
                f.Text = "Học phần: " + dgrTinChi.Rows[r].Cells[3].Value.ToString().Trim();
                f.maHP = s.Substring(0, s.Length - 3);
                f.LoadData();
                f.Show();
                f.FormClosed += new FormClosedEventHandler(Form_Closed);
                LoadData();
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
    }
}
