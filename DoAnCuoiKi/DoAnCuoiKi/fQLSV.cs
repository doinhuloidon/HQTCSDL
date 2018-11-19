using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCuoiKi.BS_layer;

namespace DoAnCuoiKi
{
    public partial class fQLSV : Form
    {
        bool Them;
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        public fQLSV()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Them = false;
                ResetText();
                dgrDSSV.DataSource = qlMH.Danh_sach_sinh_vien();
                cbbKhoa.DataSource = qlMH.Bang_khoa();
                cbbKhoa.DisplayMember = "tenKhoa";
                cbbKhoa.ValueMember = "maKhoa";

                gbxChiTiet.Enabled = false;
                txtMaSV.Enabled = true;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;                

                btnThemmoi.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Không thể lấy nội dung!!!");
            }
        }
        private void ResetText()
        {
            txtMaSV.ResetText();
            txtNienKhoa.ResetText();
            txtTenSV.ResetText();
            cbbKhoa.ResetText();
            txtLop.ResetText();
            txtMatKhau.ResetText();
        }
        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            Them = true;
            ResetText();       
            gbxChiTiet.Enabled = true;
            txtMaSV.Focus();
            btnSua.Enabled = false;
            btnThemmoi.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }   

        private void dgrDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them)
            {
                int r = dgrDSSV.CurrentCell.RowIndex;
                txtMaSV.Text = dgrDSSV.Rows[r].Cells[2].Value.ToString().Trim();
                cbbKhoa.Text = dgrDSSV.Rows[r].Cells[5].Value.ToString().Trim();
                txtLop.Text = dgrDSSV.Rows[r].Cells[6].Value.ToString().Trim();
                txtTenSV.Text = dgrDSSV.Rows[r].Cells[3].Value.ToString().Trim();
                txtNienKhoa.Text = dgrDSSV.Rows[r].Cells[7].Value.ToString().Trim();
                txtMatKhau.Text = dgrDSSV.Rows[r].Cells[4].Value.ToString().Trim();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    qlMH.Tao_tai_khoan(txtMaSV.Text, txtMatKhau.Text, txtTenSV.Text,
                        (string)cbbKhoa.SelectedValue, txtLop.Text, txtNienKhoa.Text);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi dữ liệu nhập!");
                }
            }
            else
            {
                try
                {
                    qlMH.Sua_thong_tin(txtMaSV.Text, txtMatKhau.Text, txtTenSV.Text,
                        (string)cbbKhoa.SelectedValue, txtLop.Text, txtNienKhoa.Text);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không đủ thông tin để cập nhật !");
                }
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgrDSSV.CurrentCell.RowIndex;
                string MSSV = dgrDSSV.Rows[r].Cells[2].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    qlMH.Xoa_tai_khoan(MSSV);
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch
            {
               MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
            LoadData();
        }
        private void dgrDSSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].Cells[0].Value = (r.Index + 1).ToString();
                }
            }
        }
        private void dgrDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDSSV.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int r = dgrDSSV.CurrentCell.RowIndex;
                fGhiChu f = new fGhiChu();
                f.Text = "Sinh viên " + dgrDSSV.Rows[r].Cells[3].Value.ToString().Trim();
                f.maSV = dgrDSSV.Rows[r].Cells[2].Value.ToString().Trim();
                if (dgrDSSV.Rows[r].Cells[8].Value != null)
                    f.ghiChu = dgrDSSV.Rows[r].Cells[8].Value.ToString().Trim();
                f.Show();
                f.FormClosed += new FormClosedEventHandler(Form_Closed);
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            gbxChiTiet.Enabled = true;
            this.txtMaSV.Enabled = false;
            txtTenSV.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetText();
            btnThemmoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            gbxChiTiet.Enabled = false;
            Them = false;
            LoadData();
            dgrDSSV_CellClick(null, null);
        }
    }
}
