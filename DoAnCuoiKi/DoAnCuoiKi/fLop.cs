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
    public partial class fLop : Form
    {
        DataTable dtLop = null;
        bool Them;
       // string err;
        BLQuanLyLop dbL = new BLQuanLyLop();
        DataSet ds = null;
        bool Tim = false;
        public fLop()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtLop = new DataTable();
                dtLop.Clear();
                //resettext();
                ds = dbL.LayLop();
                dtLop = ds.Tables[0];
                dgrLop.DataSource = dtLop;

                dgrLop.AutoResizeColumns();
                dgrLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //gbxLuaChon.Enabled = false;

                //btnLuu.Enabled = false;
                //btnHuy.Enabled = false;

                //btnThemmoi.Enabled = true;
                //btnSua.Enabled = true;
                //btnXoa.Enabled = true;
                //btnTimKiem.Enabled = true;
                //dgrLop_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("LoadData bị lỗi !!!");
            }
        }

        private void fLop_Load(object sender, EventArgs e)
        {
            //CapNhatMaKhoa();
            //CapNhatMaChuyenNganh();
            //LoadData();
            //if (PropertiesCls.Quyen != "Admin")
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
            LoadData();
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            //Them = true;
            //gbxLuaChon.Enabled = true;
            //resettext();
            //btnLuu.Enabled = true;
            //btnHuy.Enabled = true;
            //this.txtMaLop.Enabled = true;
            //this.txtMaMon.Enabled = true;
            //this.cboMaChuyenNganh.Enabled = true;
            //this.cboMaKhoa.Enabled = true;
            //btnThemmoi.Enabled = false;
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            //btnTimKiem.Enabled = false;
            //cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            //cboMaChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void resettext()
        {
            //txtMaLop.ResetText();
            //txtMaMon.ResetText();
            //cboMaChuyenNganh.ResetText();
            //cboMaKhoa.ResetText();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Them = false;
            //dgrLop_CellClick(null, null);
            //btnLuu.Enabled = true;
            //btnHuy.Enabled = true;

            //btnThemmoi.Enabled = false;
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            //btnTimKiem.Enabled = false;
            //gbxLuaChon.Enabled = true;

            //txtMaMon.Enabled = true;
            //this.txtMaLop.Enabled = false;
            //this.cboMaKhoa.Enabled = false;
            //this.cboMaChuyenNganh.Enabled = false;
            //this.txtMaMon.Focus();
            //cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            //cboMaChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dgrLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Tim && !Them)
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

        private void CapNhatMaKhoa()
        {
            //cboMaKhoa.Items.Clear();
            //SqlDataReader sdr1 = dbL.FilterMaKhoa();
            //while (sdr1.Read())
            //    cboMaKhoa.Items.Add(sdr1.GetString(0).ToString().Trim());
        }
        private void CapNhatMaChuyenNganh()
        {
            //cboMaChuyenNganh.Items.Clear();
            //SqlDataReader sdr = dbL.FilterMaChuyenNganh(cboMaKhoa.Text.ToString().Trim());
            //while (sdr.Read())
            //{
            //    cboMaChuyenNganh.Items.Add(sdr.GetString(0).ToString().Trim());
            //}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
        //    cboMaChuyenNganh.DropDownStyle = ComboBoxStyle.DropDown;
        //    cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDown;
        //    cboMaChuyenNganh.Enabled = true;
        //    resettext();
        //    btnThemmoi.Enabled = true;
        //    btnSua.Enabled = true;
        //    btnXoa.Enabled = true;
        //    btnTimKiem.Enabled = true;
        //    dgrLop.Enabled = true;
        //    btnLuu.Enabled = false;
        //    btnHuy.Enabled = false;
        //    gbxLuaChon.Enabled = false;
        //    Tim = false;
        //    Them = false;
        //    LoadData();
        //    //dgrLop_CellClick(null, null);

        //    if (PropertiesCls.Quyen != "Admin")
        //    {
        //        btnHuy.Enabled = false;
        //        btnLuu.Enabled = false;
        //        btnSua.Enabled = false;
        //        btnThemmoi.Enabled = false;
        //        btnXoa.Enabled = false;
        //    }
        //    else
        //    {
        //        btnSua.Enabled = true;
        //        btnThemmoi.Enabled = true;
        //        btnXoa.Enabled = true;
        //    }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
        //    if (Them)
        //    {
        //        try
        //        {
        //            BLQuanLyLop blL = new BLQuanLyLop();
        //            if (blL.ktrathem(txtMaLop.Text.Trim(), txtMaMon.Text.Trim()))
        //            {
        //                MessageBox.Show("Đã bị trùng ...!!!");

        //            }
        //            else
        //            {
        //                if (blL.ThemLop(txtMaLop.Text, txtMaMon.Text, cboMaChuyenNganh.Text, ref err))
        //                {
        //                    LoadData();
        //                    MessageBox.Show("Đã Thêm xong!!!");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Dữ liệu thêm vào không hợp lệ !!!");
        //                }
        //            }

        //        }
        //        catch (SqlException)
        //        {
        //            MessageBox.Show("không thêm được !!!");
        //        }
        //    }
        //    else
        //    {
        //        BLQuanLyLop blL = new BLQuanLyLop();
        //        if (blL.ktrasua(txtMaMon.Text.Trim()))
        //        {
        //            MessageBox.Show("Đã bị trùng ...!!!");

        //        }
        //        else
        //        {
        //            blL.CapNhatLop(txtMaLop.Text, txtMaMon.Text, cboMaChuyenNganh.Text, ref err);
        //            LoadData();
        //            MessageBox.Show("Đã sửa xong !!!");
        //        }

        //    }
        //    dgrLop.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int r = dgrLop.CurrentCell.RowIndex;
            //    string strMaLop = dgrLop.Rows[r].Cells[0].Value.ToString();
            //    DialogResult traloi;
            //    traloi = MessageBox.Show("Bạn muốn xóa không ?", "trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (traloi == DialogResult.Yes)
            //    {
            //        dbL.XoaLop(strMaLop, ref err);
            //        LoadData();
            //        MessageBox.Show("Đã Xóa Xong !!!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thể thực hiện xóa !!!");
            //    }
            //}
            //catch (SqlException)
            //{
            //    MessageBox.Show("Không xóa được !!! Lỗi rồi !!!");
            //}

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        //    btnLuu.Enabled = false;
        //    btnThemmoi.Enabled = false;
        //    btnSua.Enabled = false;
        //    btnXoa.Enabled = false;
        //    if (Tim == false)
        //    {
        //        resettext();
        //        Tim = true;
        //        txtMaLop.Enabled = false;
        //        txtMaMon.Enabled = false;
        //        this.btnHuy.Enabled = true;
        //        gbxLuaChon.Enabled = true;
        //        cboMaKhoa.Enabled = true;
        //        cboMaChuyenNganh.Enabled = true;
        //    }
        //    else
        //    {
        //        dtLop = new DataTable();
        //        dtLop.Clear();
        //        DataSet ds = dbL.LayLop(cboMaKhoa.Text, cboMaChuyenNganh.Text);
        //        dtLop = ds.Tables[0];
        //        dgrLop.DataSource = dtLop;
        //        dgrLop.AutoResizeColumns();
        //    }

        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CapNhatMaChuyenNganh();
        }

        private void cboMaChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fLop_Activated(object sender, EventArgs e)
        {
            //fLop_Load(null, null);
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
