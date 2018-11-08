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

    public partial class fQLNguoiDung : Form
    {
        DataTable dtnd = null;
        bool Them;
        string err;
        BLNguoiDung dbnd = new BLNguoiDung();
        public fQLNguoiDung()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtnd = new DataTable();
                dtnd.Clear();
                Reset();
                DataSet ds = dbnd.LayNguoiDung();
                dtnd = ds.Tables[0];
                dgrLogin.DataSource = dtnd;
                dgrLogin.Columns[0].HeaderText = "Mã User";
                dgrLogin.Columns[1].HeaderText = "Tên Đăng Nhập";
                dgrLogin.Columns[2].HeaderText = "Mật Khẩu";
                dgrLogin.Columns[3].HeaderText = "Họ Và Tên";
                dgrLogin.Columns[4].HeaderText = "Giới Tính";
                dgrLogin.Columns[5].HeaderText = "Quyền";
                dgrLogin.AutoResizeColumns();
                dgrLogin.Columns[3].Width = 250;
                groupBox1.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnThemmoi.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                dgrLogin_CellClick(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("LoadData bị lỗi !!!");
            }
        }

        private void fQLNguoiDung_Load(object sender, EventArgs e)
        {

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

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            Them = true;
            txtHoTen.ResetText();
            txtMaNguoiDung.ResetText();
            txtMK.ResetText();
            txtTaikhoan.ResetText();
            cboGioiTinh.ResetText();
            cboQuyen.ResetText();
            groupBox1.Enabled = true;
            dgrLogin.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMK.Enabled = true;
            txtMaNguoiDung.Enabled = true;
            txtTaikhoan.Enabled = true;
            txtMaNguoiDung.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            dgrLogin_CellClick(null, null);
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            groupBox1.Enabled = true;
            txtMaNguoiDung.Enabled = false;
            txtTaikhoan.Enabled = false;
            btnThemmoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            this.txtMaNguoiDung.Enabled = false;


            this.txtTaikhoan.Focus();
        }

        private void dgrLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them)
            {
                int r = dgrLogin.CurrentCell.RowIndex;
                this.txtMaNguoiDung.Text = dgrLogin.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtTaikhoan.Text = dgrLogin.Rows[r].Cells[1].Value.ToString().Trim();
                this.txtMK.Text = dgrLogin.Rows[r].Cells[2].Value.ToString().Trim();
                this.txtHoTen.Text = dgrLogin.Rows[r].Cells[3].Value.ToString().Trim();
                this.cboGioiTinh.Text = dgrLogin.Rows[r].Cells[4].Value.ToString().Trim();
                this.cboQuyen.Text = dgrLogin.Rows[r].Cells[5].Value.ToString().Trim();
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
            Reset();
            groupBox1.Enabled = false;
            dgrLogin.Enabled = true;
            btnThemmoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            Them = false;
            dgrLogin_CellClick(null, null);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLNguoiDung blnd = new BLNguoiDung();
                    if (blnd.ktrathem(txtMaNguoiDung.Text.Trim(), txtTaikhoan.Text.Trim()))
                    {
                        MessageBox.Show("Dữ liệu thêm vào bị trùng Hoặc lỗi !!!");
                    }
                    else
                    {
                        if (blnd.ThemNguoiDung(txtMaNguoiDung.Text, txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, cboQuyen.Text, cboGioiTinh.Text, ref err))
                        {
                            LoadData();
                            MessageBox.Show("Đã Thêm xong !!!");
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu nhập vào không hợp lệ !!!");
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
                BLNguoiDung blnd = new BLNguoiDung();
                blnd.CapNhatNguoiDung(txtMaNguoiDung.Text, txtMK.Text, txtHoTen.Text, cboQuyen.Text, cboGioiTinh.Text, ref err);
                LoadData();
                MessageBox.Show("Đã sửa xong !!!");
            }
            dgrLogin.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgrLogin.CurrentCell.RowIndex;
                string strtn = dgrLogin.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa không ?", "trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbnd.XoaNguoiDung(strtn, ref err);
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
            txtHoTen.ResetText();
            txtMaNguoiDung.ResetText();
            txtMK.ResetText();
            txtTaikhoan.ResetText();
            cboGioiTinh.ResetText();
            cboQuyen.ResetText();
        }

        private void fQLNguoiDung_Activated(object sender, EventArgs e)
        {
            fQLNguoiDung_Load(null, null);
        }
    }
}
