using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DoAnCuoiKi.BS_layer;

namespace DoAnCuoiKi
{
    public partial class fMonHoc : Form
    {

        DataTable dtMonHoc = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        bool Tim;
        string err;
        BLQuanLyMonHoc dbMonHoc = new BLQuanLyMonHoc();
        public fMonHoc()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Lấy dữ liệu
                dtMonHoc = new DataTable();
                dtMonHoc.Clear();
                DataSet ds = new DataSet();
                ds = dbMonHoc.LayMonHoc(txtMaMon.Text, txtTenMon.Text, cboTenKhoa.Text, cboMaKhoa.Text);
                dtMonHoc = ds.Tables[0];
                dtMonHoc.Columns[0].ColumnName = "Mã môn học";
                dtMonHoc.Columns[1].ColumnName = "Tên môn học";
                dtMonHoc.Columns[2].ColumnName = "Mã khoa";
                dtMonHoc.Columns[3].ColumnName = "Khoa";
                dtMonHoc.Columns[4].ColumnName = "Số tín chỉ";
                dtMonHoc.Columns[5].ColumnName = "Trưởng bộ môn";
                // Đưa dữ liệu lên DataGridView
                dgrMonHoc.DataSource = dtMonHoc;
                // Thay đổi độ rộng cột
                dgrMonHoc.AutoResizeColumns();

                CapNhatKhoa();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table MonHoc. Lỗi rồi!!!");
            }
        }
        private void CapNhatKhoa()
        {
            cboTenKhoa.Items.Clear();
            cboMaKhoa.Items.Clear();
            SqlDataReader sdr = dbMonHoc.FilterKhoa();
            while (sdr.Read())
            {
                cboTenKhoa.Items.Add(sdr.GetString(1).ToString().Trim());
                cboMaKhoa.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }

        private void fMonHoc_Load(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            ResetData();
            LoadData();
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            // Cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            this.btnTimKiem.Enabled = true;
            //
            dgrMonHoc_CellClick(null, null);
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            ResetData();
            CapNhatKhoa();
            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMaMon.Enabled = true;
            this.cboTenKhoa.Enabled = true;
            this.txtSoTinChi.Enabled = true;
            this.txtMaTrBoMon.Enabled = true;
            this.txtTenMon.Enabled = true;
            // Không cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTimKiem.Enabled = false;
            // Đưa con trỏ đến TextField txtMSSV
            this.txtMaMon.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            dgrMonHoc_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.gbxQuanly.Enabled = true;
            this.txtTenMon.Enabled = true;
            this.cboTenKhoa.Enabled = true;
            this.txtMaTrBoMon.Enabled = true;
            this.txtSoTinChi.Enabled = true;
            // Không cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTimKiem.Enabled = false;
            // // Đưa con trỏ đến TextField diemTB
            this.txtTenMon.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Tim = false;
            Them = false;
            fMonHoc_Load(sender, e);
            // Cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            this.btnTimKiem.Enabled = true;
            this.dgrMonHoc.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            dgrMonHoc_CellClick(null, null);
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
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    BLQuanLyMonHoc blMonHoc = new BLQuanLyMonHoc();
                    if (blMonHoc.KiemTraTrungLap(txtMaMon.Text.Trim(), txtTenMon.Text.Trim()))
                    {
                        MessageBox.Show("Dữ liệu bị trùng!");
                    }
                    else
                    {
                        if (blMonHoc.ThemMonHoc(this.txtMaMon.Text, this.txtTenMon.Text, this.cboMaKhoa.Text,
                            this.txtSoTinChi.Text, this.txtMaTrBoMon.Text, ref err))
                            MessageBox.Show("Đã thêm xong!");
                        else
                            MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                }
            }
            else
            {
                try
                {
                    // Thực hiện lệnh
                    BLQuanLyMonHoc blMonHoc = new BLQuanLyMonHoc();
                    if (blMonHoc.KiemTraTrungLap("", txtTenMon.Text.Trim()))
                    {
                        MessageBox.Show("Dữ liệu bị trùng!");
                    }
                    else
                    {
                        if (blMonHoc.CapNhatMonHoc(this.txtMaMon.Text.Trim(), this.txtTenMon.Text.Trim(), this.txtSoTinChi.Text.Trim(),
                            this.txtMaTrBoMon.Text.Trim(), this.cboMaKhoa.Text.Trim(), this.txtMaTrBoMon.Text.Trim(), ref err))
                            // Thông báo
                            MessageBox.Show("Đã sửa xong!");
                        else MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                }
            }
            // Load lại dữ liệu trên DataGridView
            ResetData();
            fMonHoc_Load(sender, e);
            this.dgrMonHoc.Enabled = true;
            // Đóng kết nối
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dgrMonHoc.CurrentCell.RowIndex;
                // Lấy MSSV của record hiện hành
                string strMaMon = dgrMonHoc.Rows[r].Cells[0].Value.ToString();
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    dbMonHoc.XoaMonHoc(strMaMon, ref err);
                    // Cập nhật lại DataGridView
                    fMonHoc_Load(sender, e);
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }
        private void dgrMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them && !Tim)
            {
                // Thứ tự dòng hiện hành
                int r = dgrMonHoc.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMaMon.Text = dgrMonHoc.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtTenMon.Text = dgrMonHoc.Rows[r].Cells[1].Value.ToString().Trim();
                this.cboMaKhoa.Text = dgrMonHoc.Rows[r].Cells[2].Value.ToString().Trim();
                this.cboTenKhoa.Text = dgrMonHoc.Rows[r].Cells[3].Value.ToString().Trim();
                this.txtSoTinChi.Text = dgrMonHoc.Rows[r].Cells[4].Value.ToString().Trim();
                this.txtMaTrBoMon.Text = dgrMonHoc.Rows[r].Cells[5].Value.ToString().Trim();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!Tim)
            {
                Tim = true;
                // Xóa trống ô tìm kiếm
                ResetData();
                CapNhatKhoa();
                // Cho thao tác trên nút Hủy
                this.btnHuy.Enabled = true;
                this.gbxQuanly.Enabled = true;
                // Đưa con trỏ đến TextField txtMaMon
                this.txtMaMon.Enabled = true;
                this.txtTenMon.Enabled = true;
                this.cboMaKhoa.Enabled = true;
                this.cboTenKhoa.Enabled = true;
                this.txtMaMon.Focus();
                // Không cho thao tác trên các nút khác
                this.btnThemmoi.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnLuu.Enabled = false;
            }
            else
            {
                LoadData();
            }
        }
        private void ResetData()
        {
            // Xóa trống và khóa textbox
            foreach (Control ctrl in gbxQuanly.Controls)
                if (ctrl is TextBox)
                {
                    ctrl.ResetText();
                    ctrl.Enabled = false;
                }
            cboMaKhoa.Items.Clear();
            cboTenKhoa.Items.Clear();
            cboMaKhoa.ResetText();
            cboTenKhoa.ResetText();
            cboTenKhoa.Enabled = false;
            cboMaKhoa.Enabled = false;
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTenKhoa.SelectedIndex = cboMaKhoa.SelectedIndex;
        }

        private void cboTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMaKhoa.SelectedIndex = cboTenKhoa.SelectedIndex;
        }

        private void fMonHoc_Activated(object sender, EventArgs e)
        {
            fMonHoc_Load(null, null);
        }
    }
}
