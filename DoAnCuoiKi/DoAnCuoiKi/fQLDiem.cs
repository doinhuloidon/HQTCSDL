using DoAnCuoiKi.BS_layer;
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

namespace DoAnCuoiKi
{
    public partial class fQLDiem : Form
    {
        DataTable dtDiem = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        bool Tim;
        string err;
        BLQuanLyDiem dbDiem = new BLQuanLyDiem();
        public fQLDiem()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                // Lấy dữ liệu
                dtDiem = new DataTable();
                dtDiem.Clear();
                DataSet ds = new DataSet();
                ds = dbDiem.LayDiem(txtTenMon.Text, txtMaMon.Text,
                        txtHoVaTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text);
                dtDiem = ds.Tables[0];
                dtDiem.Columns[0].ColumnName = "MSSV";
                dtDiem.Columns[1].ColumnName = "Họ và tên";
                dtDiem.Columns[2].ColumnName = "Khoa sinh viên";
                dtDiem.Columns[3].ColumnName = "Ngành";
                dtDiem.Columns[4].ColumnName = "Lớp";
                dtDiem.Columns[5].ColumnName = "Mã môn";
                dtDiem.Columns[6].ColumnName = "Tên môn";
                dtDiem.Columns[7].ColumnName = "Số tín chỉ";
                dtDiem.Columns[8].ColumnName = "Khoa môn học";
                dtDiem.Columns[9].ColumnName = "Điểm TB";
                dtDiem.Columns[10].ColumnName = "Trạng thái";
                // Đưa dữ liệu lên DataGridView
                dgrDiem.DataSource = dtDiem;
                // Thay đổi độ rộng cột
                dgrDiem.AutoResizeColumns();
                // Tính toán các giá trị ngầm
                Calculate();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table Diem. Lỗi rồi!!!");
            }
        }
        private void fQLDiem_Load(object sender, EventArgs e)
        {
            CapNhatTenKhoa();
            CapNhatTenChuyenNganh();
            CapNhatTenLop();

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
            dgrDiem_CellClick(null, null);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!dbDiem.KiemTraTruongBoMon(PropertiesCls.MaUSer, txtMaMon.Text) && PropertiesCls.Quyen != "Admin")
            {
                MessageBox.Show("Không có quyền để thêm điểm môn này !");
                return;
            }
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            ResetData();
            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Không cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTimKiem.Enabled = false;
            // Đưa con trỏ đến TextField txtMSSV
            this.txtMSSV.Enabled = true;
            this.txtMaMon.Enabled = true;
            this.txtDiemTB.Enabled = true;

            this.txtMSSV.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!dbDiem.KiemTraTruongBoMon(PropertiesCls.MaUSer, txtMaMon.Text) && PropertiesCls.Quyen != "Admin")
            {
                MessageBox.Show("Không có quyền để sửa điểm môn này !");
                return;
            }
            // Kích hoạt biến Sửa
            Them = false;
            dgrDiem_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.gbxQuanly.Enabled = true;
            // Không cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTimKiem.Enabled = false;
            cboSoTinChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTenChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTenKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTenLop.DropDownStyle = ComboBoxStyle.DropDownList;
            // // Đưa con trỏ đến TextField diemTB
            this.txtDiemTB.Enabled = true;
            this.txtDiemTB.Focus();
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
            fQLDiem_Load(sender, e);
            ResetData();
            // Cho thao tác trên các nút khác
            this.btnThemmoi.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            this.btnTimKiem.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;

            cboSoTinChi.Enabled = false;
            cboTenChuyenNganh.Enabled = false;
            cboTenKhoa.Enabled = false;
            cboTenLop.Enabled = false;

            cboSoTinChi.DropDownStyle = ComboBoxStyle.DropDown;
            cboTenChuyenNganh.DropDownStyle = ComboBoxStyle.DropDown;
            cboTenKhoa.DropDownStyle = ComboBoxStyle.DropDown;
            cboTenLop.DropDownStyle = ComboBoxStyle.DropDown;
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
            dgrDiem_CellClick(null, null);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    BLQuanLyDiem blDiem = new BLQuanLyDiem();
                    if (float.Parse(this.txtDiemTB.Text) < 10 && float.Parse(this.txtDiemTB.Text) > 0)
                    {
                        if (float.Parse(this.txtDiemTB.Text) >= 5)
                            txtTrangThai.Text = "Đậu";
                        else txtTrangThai.Text = "Rớt";
                        if (blDiem.KiemTraTrungLap(txtMSSV.Text.Trim(), txtMaMon.Text.Trim()))
                        {
                            MessageBox.Show("Dữ liệu bị trùng!");
                        }
                        else
                        {
                            if (blDiem.ThemDiem(this.txtMSSV.Text, this.txtMaMon.Text, this.txtTrangThai.Text, this.txtDiemTB.Text, ref err))
                                MessageBox.Show("Đã thêm xong!");
                            else
                                MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                        }
                    }
                    else
                        MessageBox.Show("Dữ liệu nhập không hợp lệ!");
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
                    BLQuanLyDiem blDiem = new BLQuanLyDiem();
                    if (float.Parse(this.txtDiemTB.Text) < 10 && float.Parse(this.txtDiemTB.Text) > 0)
                    {
                        if (float.Parse(this.txtDiemTB.Text) >= 5)
                            txtTrangThai.Text = "Đậu";
                        else txtTrangThai.Text = "Rớt";
                        blDiem.CapNhatDiem(this.txtMSSV.Text, this.txtMaMon.Text, this.txtDiemTB.Text, this.txtTrangThai.Text, ref err);
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    else MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                }
            }
            // Load lại dữ liệu trên DataGridView
            fQLDiem_Load(sender, e);
            Them = false;
            Tim = false;
            // Đóng kết nối
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!dbDiem.KiemTraTruongBoMon(PropertiesCls.MaUSer, txtMaMon.Text) && PropertiesCls.Quyen != "Admin")
            {
                MessageBox.Show("Không có quyền để xóa điểm môn này !");
                return;
            }
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dgrDiem.CurrentCell.RowIndex;
                // Lấy MSSV và mã môn của record hiện hành
                string strMSSV = dgrDiem.Rows[r].Cells[0].Value.ToString();
                string strMaMon = dgrDiem.Rows[r].Cells[5].Value.ToString();
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    dbDiem.XoaDiem(strMSSV, strMaMon, ref err);
                    // Cập nhật lại DataGridView
                    fQLDiem_Load(sender, e);
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
        private void dgrDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Them && !Tim)
            {
                // Thứ tự dòng hiện hành
                int r = dgrDiem.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                this.txtMaMon.Text = dgrDiem.Rows[r].Cells[5].Value.ToString().Trim();
                this.txtTenMon.Text = dgrDiem.Rows[r].Cells[6].Value.ToString().Trim();
                this.txtMSSV.Text = dgrDiem.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtHoVaTen.Text = dgrDiem.Rows[r].Cells[1].Value.ToString().Trim();
                this.cboTenKhoa.Text = dgrDiem.Rows[r].Cells[2].Value.ToString().Trim();
                this.cboTenChuyenNganh.Text = dgrDiem.Rows[r].Cells[3].Value.ToString().Trim();
                this.cboTenLop.Text = dgrDiem.Rows[r].Cells[4].Value.ToString().Trim();
                this.txtDiemTB.Text = dgrDiem.Rows[r].Cells[9].Value.ToString().Trim();
                this.txtTrangThai.Text = dgrDiem.Rows[r].Cells[10].Value.ToString().Trim();
                this.cboSoTinChi.Text = dgrDiem.Rows[r].Cells[7].Value.ToString().Trim();
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
            cboSoTinChi.Enabled = false;
            cboTenChuyenNganh.Enabled = false;
            cboTenKhoa.Enabled = false;
            cboTenLop.Enabled = false;
            cboSoTinChi.ResetText();
            cboTenChuyenNganh.ResetText();
            cboTenKhoa.ResetText();
            cboTenLop.ResetText();
        }

        private void CapNhatTenKhoa()
        {
            cboTenKhoa.Items.Clear();
            SqlDataReader sdr = dbDiem.FilterKhoa();
            while (sdr.Read())
            {
                cboTenKhoa.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }
        private void CapNhatTenChuyenNganh()
        {
            cboTenChuyenNganh.Items.Clear();
            SqlDataReader sdr = dbDiem.FilterChuyenNganh(cboTenKhoa.Text.Trim());
            while (sdr.Read())
            {
                cboTenChuyenNganh.Items.Add(sdr.GetString(0).ToString().Trim());
            }
            CapNhatTenLop();
        }
        private void CapNhatTenLop()
        {
            cboTenLop.Items.Clear();
            SqlDataReader sdr = dbDiem.FilterLop(cboTenChuyenNganh.Text.Trim());
            while (sdr.Read())
            {
                cboTenLop.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!Tim)
            {
                Tim = true;
                // Xóa trống ô tìm kiếm
                ResetData();
                CapNhatTenKhoa();
                CapNhatTenChuyenNganh();
                CapNhatTenLop();

                // Đưa con trỏ đến TextField txtMSSV
                this.txtHoVaTen.Enabled = true;
                this.txtMSSV.Enabled = true;
                this.txtMaMon.Enabled = true;
                this.cboTenChuyenNganh.Enabled = true;
                this.cboTenKhoa.Enabled = true;
                this.cboTenLop.Enabled = true;
                this.txtTenMon.Enabled = true;
                this.txtMSSV.Focus();
                // Cho thao tác trên nút Hủy
                this.btnHuy.Enabled = true;
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
        private void Calculate()
        {
            BLQuanLyDiem blDiem = new BLQuanLyDiem();
            lbSoLuongMon.Text = "Số lượng môn : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoVaTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "SoLuongMon");
            lbSoTinChi.Text = "Số lượng tín chỉ : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoVaTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "SoTinChi");
            lbDiemTBB.Text = "Điểm TB Bảng : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoVaTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "DiemTB");
        }

        private void cboTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenChuyenNganh();
            cboTenChuyenNganh.ResetText();
            cboTenLop.ResetText();
        }

        private void cboTenChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenLop();
            cboTenLop.ResetText();
        }

        private void fQLDiem_Activated(object sender, EventArgs e)
        {
            fQLDiem_Load(null, null);
        }
    }
}
