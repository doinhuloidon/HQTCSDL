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
    public partial class fChuyenNganh : Form
    {
        DataTable dtcn = null;
        bool Them;
        string err;
        BLQuanLyChuyenNganh dbcn = new BLQuanLyChuyenNganh();
        public fChuyenNganh()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtcn = new DataTable();
                dtcn.Clear();
                Reset();
                DataSet ds = dbcn.LayChuyenNganh();
                dtcn = ds.Tables[0];
                dgrKhoa.DataSource = dtcn;

                dgrKhoa.Columns[0].HeaderText = "Mã Chuyên Ngành";
                dgrKhoa.Columns[1].HeaderText = "Tên Chuyên Ngành";
                dgrKhoa.Columns[2].HeaderText = "Mã Khoa";
                dgrKhoa.AutoResizeColumns();
                dgrKhoa.AutoResizeRows();
                gbxLuaChon.Enabled = false;

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnThemmoi.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                dgrKhoa_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("LoadData bị lỗi !!!");
            }
        }

        private void fChuyenNganh_Load(object sender, EventArgs e)
        {
            CapNhatTenKhoa();
            LoadData();
            if (PropertiesCls.Quyen != "Admin")
            {
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnThemmoi.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnThemmoi.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void CapNhatTenKhoa()
        {
            cboMaKhoa.Items.Clear();
            SqlDataReader sdr = dbcn.FilterKhoa();
            while (sdr.Read())
            {
                cboMaKhoa.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            Them = true;
            Reset();
            txtMaChuyenNganh.Enabled = true;
            txtTenChuyenNganh.Enabled = true;
            gbxLuaChon.Enabled = true;          
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaChuyenNganh.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
           
            dgrKhoa_CellClick(null, null);
            gbxLuaChon.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaChuyenNganh.Enabled = false;
            cboMaKhoa.Enabled = false;
            this.txtTenChuyenNganh.Focus();
        }

        private void dgrKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them)
            {
                int r = dgrKhoa.CurrentCell.RowIndex;
                this.txtMaChuyenNganh.Text = dgrKhoa.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtTenChuyenNganh.Text = dgrKhoa.Rows[r].Cells[1].Value.ToString().Trim();
                this.cboMaKhoa.Text = dgrKhoa.Rows[r].Cells[2].Value.ToString().Trim();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không ?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Them = false;
            gbxLuaChon.Enabled = false;
            Reset();
            btnThemmoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            dgrKhoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            if (PropertiesCls.Quyen != "Admin")
            {
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnThemmoi.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnThemmoi.Enabled = true;
                btnXoa.Enabled = true;
            }

            dgrKhoa_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLQuanLyChuyenNganh blcn = new BLQuanLyChuyenNganh();
                    if (blcn.ktrathem(txtMaChuyenNganh.Text.Trim(), txtTenChuyenNganh.Text.Trim()))
                    {
                        MessageBox.Show("Dữ liệu thêm bị trùng !!!");
                    }
                    else
                    {
                        if (blcn.ThemChuyenNganh(txtMaChuyenNganh.Text, txtTenChuyenNganh.Text, cboMaKhoa.Text, ref err))
                        {
                            LoadData();
                            MessageBox.Show("Đã Thêm xong !!!");
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu không hợp lệ !!!");
                        }
                    }

                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được ... Lỗi !!!");
                }
            }
            else
            {

                BLQuanLyChuyenNganh blcn = new BLQuanLyChuyenNganh();
                if (blcn.ktrasua(txtTenChuyenNganh.Text.Trim()))
                {
                    MessageBox.Show("Tên Chuyên ngành bị trùng !!!");
                }
                else
                {
                    blcn.CapNhatChuyenNganh(txtMaChuyenNganh.Text, txtTenChuyenNganh.Text, cboMaKhoa.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã sửa xong !!!");
                }
            }
            dgrKhoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgrKhoa.CurrentCell.RowIndex;
                string strtn = dgrKhoa.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa không ?", "trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbcn.XoaChuyenNganh(txtMaChuyenNganh.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã Xóa Xong !!!");
                }
                else
                {
                    MessageBox.Show("Không thể thực hiện xóa !!!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được !!! Lỗi rồi !!!");
            }

        }
        void Reset()
        {
            this.txtMaChuyenNganh.ResetText();
            this.txtTenChuyenNganh.ResetText();
            this.cboMaKhoa.ResetText();     
        }

        private void fChuyenNganh_Activated(object sender, EventArgs e)
        {
            fChuyenNganh_Load(null, null);
        }
    }

}
