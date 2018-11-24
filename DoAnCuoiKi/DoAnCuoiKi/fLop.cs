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

namespace DoAnCuoiKi
{
    public partial class fLop : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
        bool Them;
        public fLop()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dgrLop.DataSource = qlMH.Lop_hoc_phan();
                cbbMaMon.DataSource = qlMH.Bang_mon_hoc();
                cbbMaMon.DisplayMember = "tenMon";
                cbbMaMon.ValueMember = "maMon";
                cbbMaGV.DataSource = qlMH.Bang_giao_vien();
                cbbMaGV.DisplayMember = "tenGV";
                cbbMaGV.ValueMember = "maGV";

                gbxLuaChon.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnThemmoi.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch
            {
                MessageBox.Show("LoadData bị lỗi !!!");
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            Them = true;
            gbxLuaChon.Enabled = true;
            resettext();
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            this.txtMaLop.Enabled = false;
            this.dtpNgayKetThuc.Enabled = false;
            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        void resettext()
        {
            txtMaLop.ResetText();
            cbbMaMon.ResetText();
            cbbMaGV.ResetText();
            txtPhongHoc.ResetText();
            txtSoLuong.ResetText();
            cbbThu.ResetText();
            cbbTietBatDau.ResetText();
            cbbTietKetThuc.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            gbxLuaChon.Enabled = true;
            this.cbbMaMon.Enabled = false;
            this.txtMaLop.Enabled = false;
            this.cbbMaGV.Focus();
        }

        private void dgrLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them)
            {
                int r = dgrLop.CurrentCell.RowIndex;
                this.txtMaLop.Text = dgrLop.Rows[r].Cells[1].Value.ToString().Trim();
                this.cbbMaMon.Text = dgrLop.Rows[r].Cells[2].Value.ToString().Trim();
                this.txtPhongHoc.Text = dgrLop.Rows[r].Cells[3].Value.ToString().Trim();
                this.cbbThu.Text = dgrLop.Rows[r].Cells[4].Value.ToString().Trim();
                this.cbbTietBatDau.Text = dgrLop.Rows[r].Cells[5].Value.ToString().Trim();
                this.cbbTietKetThuc.Text = dgrLop.Rows[r].Cells[6].Value.ToString().Trim();
                this.cbbMaGV.Text = dgrLop.Rows[r].Cells[7].Value.ToString().Trim();
                this.txtSoLuong.Text = dgrLop.Rows[r].Cells[8].Value.ToString().Trim();
                this.dtpNgayBatDau.Text = dgrLop.Rows[r].Cells[9].Value.ToString().Trim();
                this.dtpNgayKetThuc.Text = dgrLop.Rows[r].Cells[10].Value.ToString().Trim();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resettext();
            btnThemmoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            gbxLuaChon.Enabled = false;
            Them = false;
            LoadData();
            dgrLop_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    qlMH.Them_lop_hoc_phan((string)cbbMaMon.SelectedValue, txtPhongHoc.Text, Int32.Parse(cbbThu.Text), 
                         Int32.Parse(cbbTietBatDau.Text), Int32.Parse(cbbTietKetThuc.Text), 
                         (string)cbbMaGV.SelectedValue, Int32.Parse(txtSoLuong.Text), DateTime.Parse(dtpNgayBatDau.Text));
                    MessageBox.Show("Thêm thành công !!!");
                }
                catch 
                {
                    MessageBox.Show("Không thêm được !!!");
                }
            }
            else
            {
                try
                {
                    qlMH.Sua_lop_hoc_phan(txtMaLop.Text, (string)cbbMaMon.SelectedValue, txtPhongHoc.Text, Int32.Parse(cbbThu.Text),
                         Int32.Parse(cbbTietBatDau.Text), Int32.Parse(cbbTietKetThuc.Text),
                         (string)cbbMaGV.SelectedValue, Int32.Parse(txtSoLuong.Text), DateTime.Parse(dtpNgayBatDau.Text));
                    MessageBox.Show("Sửa thành công !!!");
                }
                catch
                {
                    MessageBox.Show("Không sửa được !!!");
                }
            }
            Them = false;
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgrLop.CurrentCell.RowIndex;
                string strMaLop = dgrLop.Rows[r].Cells[1].Value.ToString().Trim();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa không ?", "trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    qlMH.Xoa_lop_hoc_phan(strMaLop);
                    MessageBox.Show("Đã Xóa Xong !!!");
                }
                else
                {
                    MessageBox.Show("Không xóa được !!!");
                }
            }
            catch 
            {
                MessageBox.Show("Không xóa được !!! Lỗi rồi !!!");
            }
            LoadData();
            Them = false;
        } 

        private void dgrLop_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
    }
}
