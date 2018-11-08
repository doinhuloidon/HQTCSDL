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
    public partial class fTimKiemDiem : Form
    {
        DataTable dtDiem = null;
        BLQuanLyDiem dbDiem = new BLQuanLyDiem();
        public fTimKiemDiem()
        {
            InitializeComponent();
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
        void LoadData()
        {
            try
            {
                dtDiem = new DataTable();
                dtDiem.Clear();
                DataSet ds = new DataSet();
                ds = dbDiem.LayDiem(txtTenMon.Text, txtMaMon.Text,
                    txtHoTen.Text, txtMSSV.Text, cboTenKhoa.Text,
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
        private void fTimKiemDiem_Load(object sender, EventArgs e)
        {
            CapNhatTenKhoa();
            CapNhatTenChuyenNganh();
            CapNhatTenLop();
            LoadData();
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

        private void Calculate()
        {
            BLQuanLyDiem blDiem = new BLQuanLyDiem();
            lbSoLuongMon.Text = "Số lượng môn : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "SoLuongMon");
            lbSoTinChi.Text = "Số lượng tín chỉ : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "SoTinChi");
            lbDiemTBB.Text = "Điểm TB Bảng : " + blDiem.TinhToan(txtTenMon.Text, txtMaMon.Text,
                        txtHoTen.Text, txtMSSV.Text, cboTenKhoa.Text,
                        cboTenChuyenNganh.Text, cboTenLop.Text, "DiemTB");
        }

        private void cboTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenChuyenNganh();
            cboTenChuyenNganh.ResetText();
            cboTenLop.ResetText();
            cboTenLop.Items.Clear();
        }

        private void cboTenChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenLop();
            cboTenLop.ResetText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcelTimKiemDiem(dgrDiem,lbDiemTBB.Text.ToString(),lbSoLuongMon.Text.ToString(),lbSoTinChi.Text.ToString());
        }

        private void fTimKiemDiem_Activated(object sender, EventArgs e)
        {
            fTimKiemDiem_Load(null, null);
        }
    }
}
