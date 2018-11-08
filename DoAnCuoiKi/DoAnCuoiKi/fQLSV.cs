using DoAnCuoiKi.BS_layer;
using DoAnCuoiKi.DB_layer;
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
    public partial class fQLSV : Form
    {
        //string err = "";
        //DataTable dt = null;
        //DataSet ds = null;
        //bool Them = false;
        //BLQuanLySinhVien blQLSV = new BLQuanLySinhVien();
        public fQLSV()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            //try
            //{
            //    //Xóa trống các textbox
            //    ResetTextThongTin();
            //    //Lấy dữ liệu lên datagridview
            //    dt = new DataTable();
            //    dt.Clear();
            //    ds = blQLSV.LaySinhVien(cboTenKhoa.Text, cboTenChuyenNganh.Text, cboTenLop.Text);
            //    dt = ds.Tables[0];
            //    dgrDSSV.DataSource = dt;
            //    //Đổi tên các cột
            //    dgrDSSV.Columns[0].HeaderText = "MSSV";
            //    dgrDSSV.Columns[1].HeaderText = "Họ và tên";
            //    dgrDSSV.Columns[2].HeaderText = "Quê quán";
            //    dgrDSSV.Columns[3].HeaderText = "Ngày sinh";
            //    dgrDSSV.Columns[4].HeaderText = "CMND";
            //    dgrDSSV.Columns[5].HeaderText = "Giới tính";
            //    dgrDSSV.Columns[6].HeaderText = "Địa chỉ";
            //    dgrDSSV.Columns[7].HeaderText = "Niên khóa";
            //    dgrDSSV.Columns[8].HeaderText = "Mã lớp";
            //    dgrDSSV.Columns[9].HeaderText = "Tên lớp";
            //    dgrDSSV.Columns[10].HeaderText = "Tên chuyên ngành";
            //    dgrDSSV.Columns[11].HeaderText = "Tên khoa";
            //    dgrDSSV.AutoResizeColumns();
            //    dgrDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //    //
            //    dgrDSSV_CellClick(null, null);
            //    //Khóa và mở thao tác các nút
            //    DisableEdit(true);
            //    DisableFunc(false);
            //    cboTenKhoa.Enabled = false;
            //    cboTenLop.Enabled = false;
            //    cboTenChuyenNganh.Enabled = false;
            //    //
            //    lbSoLuong.Text = "Số lượng : " + (dgrDSSV.Rows.Count - 1).ToString();
            //}
            //catch
            //{
            //    return;
            //}
        }
        //Xóa trống các textbox
        private void ResetTextThongTin()
        {
            //txtMaSV.ResetText();
            //txtHoTen.ResetText();
            //txtNgaySinh.ResetText();
            //cboGioiTinh.ResetText();
            //txtDiaChi.ResetText();
            //txtMaLop.ResetText();
            //txtQueQuan.ResetText();
            //txtCMND.ResetText();
            //txtNienKhoa.ResetText();
        }
        //
        private void ResetTextTimKiem()
        {
            //cboTenKhoa.ResetText();
            //cboTenChuyenNganh.ResetText();
            //cboTenLop.ResetText();
        }
        //Khóa các nút
        private void DisableEdit(bool b)
        {
            //btnSua.Enabled = b;
            //btnThemmoi.Enabled = b;
            //btnXoa.Enabled = b;
            //btnThoat.Enabled = b;
        }
        //
        private void DisableFunc(bool b)
        {
            //btnLuu.Enabled = b;
            //btnHuy.Enabled = b;
            //gbxChiTiet.Enabled = b;
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            //Them = true;
            ////
            //ResetTextThongTin();
            ////
            //DisableEdit(false);
            //DisableFunc(true);
            //btnTimKiem.Enabled = false;
            ////
            //txtMaSV.Enabled = true;
            //txtMaLop.Enabled = true;
            //txtMaSV.Focus();
        }
        private void CapNhatTenKhoa()
        {
            //cboTenKhoa.Items.Clear();
            //SqlDataReader sdr = blQLSV.FilterKhoa();
            //while (sdr.Read())
            //{
            //    cboTenKhoa.Items.Add(sdr.GetString(0).ToString().Trim());
            //}
        }
        private void CapNhatTenChuyenNganh()
        {
            //cboTenChuyenNganh.Items.Clear();
            //SqlDataReader sdr = blQLSV.FilterChuyenNganh(cboTenKhoa.Text.Trim());
            //while (sdr.Read())
            //{
            //    cboTenChuyenNganh.Items.Add(sdr.GetString(0).ToString().Trim());
            //}
            //CapNhatTenLop();
        }
        private void CapNhatTenLop()
        {
            //cboTenLop.Items.Clear();
            //SqlDataReader sdr = blQLSV.FilterLop(cboTenChuyenNganh.Text.Trim());
            //while (sdr.Read())
            //{
            //    cboTenLop.Items.Add(sdr.GetString(0).ToString().Trim());
            //}
        }
        private void fQLSV_Load(object sender, EventArgs e)
        {
            //CapNhatTenKhoa();
            //CapNhatTenChuyenNganh();
            //CapNhatTenLop();
            //LoadData();
            //if (PropertiesCls.quyenDangNhap != "1")
            //{
            //    btnHuy.Enabled = false;
            //    btnLuu.Enabled = false;
            //    btnSua.Enabled = false;
            //    btnThemmoi.Enabled = false;
            //    btnXoa.Enabled = false;
            //}
            //else
            //{
            //    btnSua.Enabled = true;
            //    btnThemmoi.Enabled = true;
            //    btnXoa.Enabled = true;
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Them = false;
            //DisableEdit(false);
            //DisableFunc(true);
            //btnTimKiem.Enabled = false;
            ////
            //dgrDSSV_CellClick(null, null);
            ////
            //txtMaSV.Enabled = false;
            //txtHoTen.Enabled = true;
            //txtQueQuan.Enabled = true;
            //txtNgaySinh.Enabled = true;
            //txtCMND.Enabled = true;
            //cboGioiTinh.Enabled = true;
            //txtDiaChi.Enabled = true;
            //txtNienKhoa.Enabled = true;
            //txtMaLop.Enabled = false;
            ////
            //txtHoTen.Focus();
        }

        private void dgrDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (!Them)
            //{
            //    int r = dgrDSSV.CurrentCell.RowIndex;
            //    txtMaSV.Text = dgrDSSV.Rows[r].Cells[0].Value.ToString().Trim();
            //    txtHoTen.Text = dgrDSSV.Rows[r].Cells[1].Value.ToString().Trim(); ;
            //    txtQueQuan.Text = dgrDSSV.Rows[r].Cells[2].Value.ToString().Trim();
            //    txtNgaySinh.Text = dgrDSSV.Rows[r].Cells[3].Value.ToString().Trim();
            //    txtCMND.Text = dgrDSSV.Rows[r].Cells[4].Value.ToString().Trim();
            //    cboGioiTinh.Text = dgrDSSV.Rows[r].Cells[5].Value.ToString().Trim();
            //    txtDiaChi.Text = dgrDSSV.Rows[r].Cells[6].Value.ToString().Trim();
            //    txtNienKhoa.Text = dgrDSSV.Rows[r].Cells[7].Value.ToString().Trim();
            //    txtMaLop.Text = dgrDSSV.Rows[r].Cells[8].Value.ToString().Trim();
            //}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //ResetTextThongTin();
            //ResetTextTimKiem();
            //cboTenLop.Items.Clear();
            //cboTenChuyenNganh.Items.Clear();
            //DisableFunc(false);
            //DisableEdit(true);
            //btnTimKiem.Enabled = true;
            //LoadData();
            //dgrDSSV_CellClick(null, null);
            //if (PropertiesCls.quyenDangNhap != "Admin")
            //{
            //    btnHuy.Enabled = false;
            //    btnLuu.Enabled = false;
            //    btnSua.Enabled = false;
            //    btnThemmoi.Enabled = false;
            //    btnXoa.Enabled = false;
            //}
            //else
            //{
            //    btnSua.Enabled = true;
            //    btnThemmoi.Enabled = true;
            //    btnXoa.Enabled = true;
            //}
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if (Them)
            //{
            //    try
            //    {
            //        if (blQLSV.ThemSinhVien(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), cboGioiTinh.Text.Trim(), 
            //            txtQueQuan.Text.Trim(), txtNgaySinh.Text.Trim(), txtCMND.Text.Trim(), txtDiaChi.Text.Trim(), txtNienKhoa.Text.Trim(), txtMaLop.Text.Trim(), ref err))
            //        {
            //            ResetTextTimKiem();
            //            LoadData();
            //            MessageBox.Show("Đã thêm xong!");
            //        }
            //        else
            //        {
            //            if (err == "Không thêm được, mã số sinh viên đã tồn tại !")
            //            {
            //                MessageBox.Show(err);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Không đủ thông tin để thêm !");
            //            }
            //        }

            //    }
            //    catch (SqlException)
            //    {
            //        MessageBox.Show("Không đủ thông tin để thêm !");
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        if (blQLSV.CapNhatSinhVien(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), cboGioiTinh.Text.Trim(), txtQueQuan.Text.Trim(), txtNgaySinh.Text.Trim(), txtCMND.Text.Trim(), txtDiaChi.Text.Trim(), txtNienKhoa.Text.Trim(), txtMaLop.Text.Trim(), ref err))
            //        {
            //            ResetTextTimKiem();
            //            LoadData();
            //            MessageBox.Show("Đã sửa xong!");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Định dạng thông tin bị sai !");
            //        }

            //    }
            //    catch (SqlException)
            //    {
            //        MessageBox.Show("Không đủ thông tin để cập nhật !");
            //    }
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int r = dgrDSSV.CurrentCell.RowIndex;
            //    string MSSV = dgrDSSV.Rows[r].Cells[0].Value.ToString();

            //    DialogResult traloi;
            //    traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (traloi == DialogResult.Yes)
            //    {
            //        if (blQLSV.XoaSinhVien(MSSV, ref err))
            //        {
            //            LoadData();
            //            MessageBox.Show("Đã xóa xong!");
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Không xóa được. Lỗi rồi!");
            //}
        }

        private void cboTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CapNhatTenChuyenNganh();
            //cboTenChuyenNganh.ResetText();
            //cboTenLop.ResetText();
            //cboTenLop.Items.Clear();
        }

        private void cboTenChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CapNhatTenLop();
            //cboTenLop.ResetText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //LoadData();
            //btnHuy.Enabled = true;
            //cboTenKhoa.Enabled = true;
            //cboTenLop.Enabled = true;
            //cboTenChuyenNganh.Enabled = true;
            //DisableEdit(false);
        }

        private void fQLSV_Activated(object sender, EventArgs e)
        {
            //fQLSV_Load(null,null);
        }
    }
}
