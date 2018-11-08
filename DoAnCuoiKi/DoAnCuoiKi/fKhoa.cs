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
    public partial class fKhoa : Form
    {
        public fKhoa()
        {
            InitializeComponent();
        }

        string err = "";
        DataTable dt = null;
        DataSet ds = null;
        bool isThem = false;
        BLQuanLyKhoa blQLK = new BLQuanLyKhoa();
        private void LoadData()
        {
            try
            {
                ResetTextThongTin();
                dt = new DataTable();
                dt.Clear();
                ds = ds = blQLK.LayKhoa();
                dt = ds.Tables[0];
                dgrKhoa.DataSource = dt;


                dgrKhoa.Columns[0].HeaderText = "Mã khoa";
                dgrKhoa.Columns[1].HeaderText = "Tên khoa";
                dgrKhoa.Columns[2].HeaderText = "Vị trí";

                dgrKhoa.AutoResizeColumns();
                dgrKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgrKhoa_CellClick(null, null);


                DisableEdit(true);

                DisableFunc(false);
            }
            catch
            {
                //MessageBox.Show("Không tìm thấy nộ");
                return;
            }
        }
        private void ResetTextThongTin()
        {
            txtMaKhoa.ResetText();
            txtTenKhoa.ResetText();
            txtViTri.ResetText();
        }
        private void DisableEdit(bool b)
        {
            btnSua.Enabled = b;
            btnThemmoi.Enabled = b;
            btnXoa.Enabled = b;
            btnThoat.Enabled = b;
        }

        private void DisableFunc(bool b)
        {
            btnLuu.Enabled = b;
            btnHuy.Enabled = b;
            gbxChiTiet.Enabled = b;
        }

        private void dgrKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isThem)
            {
                int r = dgrKhoa.CurrentCell.RowIndex;
                txtMaKhoa.Text = dgrKhoa.Rows[r].Cells[0].Value.ToString().Trim();
                txtTenKhoa.Text = dgrKhoa.Rows[r].Cells[1].Value.ToString().Trim(); ;
                txtViTri.Text = dgrKhoa.Rows[r].Cells[2].Value.ToString().Trim();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            isThem = true;

            ResetTextThongTin();

            DisableEdit(false);
            DisableFunc(true);

            txtMaKhoa.Enabled = true;
            txtMaKhoa.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetTextThongTin();
            DisableFunc(false);
            DisableEdit(true);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            DisableEdit(false);
            DisableFunc(true);

            dgrKhoa_CellClick(null, null);

            gbxChiTiet.Enabled = true;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = true;
            txtViTri.Enabled = true;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgrKhoa.CurrentCell.RowIndex;
                string MSSV = dgrKhoa.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (blQLK.XoaKhoa(MSSV, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã xóa xong!");
                    }
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                try
                {
                    if (blQLK.KiemTraTrungLap(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim(), ref err))
                        MessageBox.Show(err);
                    else
                    {
                        if (blQLK.ThemKhoa(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim(), txtViTri.Text.Trim(), ref err))
                        {
                            LoadData();
                            MessageBox.Show("Đã thêm xong!");
                        }
                        else
                            MessageBox.Show(err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không đủ thông tin để thêm !");
                }
            }
            else
            {
                try
                {
                    if (blQLK.CapNhatKhoa(txtMaKhoa.Text.Trim(), txtTenKhoa.Text.Trim(), txtViTri.Text.Trim(), ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        if (err == "Tên khoa đã tồn tại !")
                        {
                            MessageBox.Show(err.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Định dạng thông tin bị sai !");

                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không đủ thông tin để cập nhật !");
                }
            }
        }

        private void fKhoa_Load(object sender, EventArgs e)
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

        private void fKhoa_Activated(object sender, EventArgs e)
        {
            fKhoa_Load(null, null);
        }
    }
}
