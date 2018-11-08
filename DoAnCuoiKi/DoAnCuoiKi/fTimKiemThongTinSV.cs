using DoAnCuoiKi.BS_layer;
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
    public partial class fTimKiemThongTinSV : Form
    {
        public fTimKiemThongTinSV()
        {
            InitializeComponent();
        }
        DataTable dt = null;
        DataSet ds = null;
        BLQuanLySinhVien blQLSV = new BLQuanLySinhVien();
        private void LoadData()
        {
            try
            {
                CapNhatTenKhoa();
                CapNhatTenChuyenNganh();
                CapNhatTenLop();

                dt = new DataTable();
                dt.Clear();
                ds = blQLSV.LaySinhVien(txtMSSV.Text.Trim(), txtHoVaTen.Text.Trim(), cboTenKhoa.Text.Trim(), cboTenChuyenNganh.Text.Trim(), cboTenLop.Text.Trim(), cboGioiTinh.Text, txtNienKhoa.Text.Trim(), txtQueQuan.Text.Trim());
                dt = ds.Tables[0];
                dgrDSSV.DataSource = dt;


                dgrDSSV.Columns[0].HeaderText = "MSSV";
                dgrDSSV.Columns[1].HeaderText = "Họ và tên";
                dgrDSSV.Columns[2].HeaderText = "Quê quán";
                dgrDSSV.Columns[3].HeaderText = "Ngày sinh";
                dgrDSSV.Columns[4].HeaderText = "CMND";
                dgrDSSV.Columns[5].HeaderText = "Giới tính";
                dgrDSSV.Columns[6].HeaderText = "Địa chỉ";
                dgrDSSV.Columns[7].HeaderText = "Niên khóa";
                dgrDSSV.Columns[8].HeaderText = "Mã lớp";
                dgrDSSV.Columns[9].HeaderText = "Tên lớp";
                dgrDSSV.Columns[10].HeaderText = "Tên chuyên ngành";
                dgrDSSV.Columns[11].HeaderText = "Tên khoa";

                dgrDSSV.AutoResizeColumns();
                dgrDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
                //MessageBox.Show("Không tìm thấy nộ");
                return;
            }
            lbSoLuong.Text = "Số lượng : " + (dgrDSSV.Rows.Count - 1).ToString();
        }

        private void CapNhatTenKhoa()
        {
            cboTenKhoa.Items.Clear();
            SqlDataReader sdr = blQLSV.FilterKhoa();
            while (sdr.Read())
            {
                cboTenKhoa.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }
        private void CapNhatTenChuyenNganh()
        {
            cboTenChuyenNganh.Items.Clear();
            SqlDataReader sdr = blQLSV.FilterChuyenNganh(cboTenKhoa.Text.Trim());
            while (sdr.Read())
            {
                cboTenChuyenNganh.Items.Add(sdr.GetString(0).ToString().Trim());
            }
            CapNhatTenLop();
        }
        private void CapNhatTenLop()
        {
            cboTenLop.Items.Clear();
            SqlDataReader sdr = blQLSV.FilterLop(cboTenChuyenNganh.Text.Trim());
            while (sdr.Read())
            {
                cboTenLop.Items.Add(sdr.GetString(0).ToString().Trim());
            }
        }

        private void fTimKiemThongTinSV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenChuyenNganh();
            cboTenChuyenNganh.ResetText();
            cboTenLop.Items.Clear();
            cboTenLop.ResetText();
        }

        private void cboTenChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTenLop();
            cboTenLop.ResetText();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcelTimKiemThongTinSV(this.dgrDSSV, lbSoLuong.Text);
        }

        private void fTimKiemThongTinSV_Activated(object sender, EventArgs e)
        {
            fTimKiemThongTinSV_Load(null, null);
        }
    }
}
