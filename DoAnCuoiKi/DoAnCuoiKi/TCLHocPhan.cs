using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnCuoiKi.BS_layer;
namespace DoAnCuoiKi
{
    public partial class TCLHocPhan : Form
    {
        BLTCLHocPhan dbcn = new BLTCLHocPhan();
        bool them = false;
        public TCLHocPhan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            txtmalop.Enabled = false;
            txttenmon.Enabled = false;
            txtsotc.Enabled = false;
            txtphong.Enabled = false;
            txtthu.Enabled = false;
            txttutiet.Enabled = false;
            txtdentiet.Enabled = false;
            txtgiaovien.Enabled = false;
            txtsoluong.Enabled = false;
            txttgbd.Enabled = false;
            txttgkt.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            try
            {
                dgv.DataSource = dbcn.Laylhp();
                dgv.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nộ");
                return;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbbtk.Text == "Tên Môn")
                {
                    dgv.DataSource = dbcn.tklhptenmon(txttk.Text.Trim());
                }
                else if (cbbtk.Text == "Mã Môn")
                {
                    dgv.DataSource = dbcn.tklhpmamon(txttk.Text.Trim());
                }
                else
                {
                    dgv.DataSource = dbcn.tklhpkhoa(txttk.Text.Trim());
                }
                dgv.AutoResizeColumns();
            }
            catch
            {

            }


        }

        private void TCLHocPhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv.CurrentCell.RowIndex;
            txtmalop.Text = dgv.Rows[r].Cells[0].Value.ToString();
            txttenmon.Text = dgv.Rows[r].Cells[1].Value.ToString();
            txtsotc.Text = dgv.Rows[r].Cells[2].Value.ToString();
            txtphong.Text = dgv.Rows[r].Cells[3].Value.ToString();
            txtthu.Text = dgv.Rows[r].Cells[4].Value.ToString();
            txttutiet.Text = dgv.Rows[r].Cells[5].Value.ToString();
            txtdentiet.Text = dgv.Rows[r].Cells[6].Value.ToString();
            txtgiaovien.Text = dgv.Rows[r].Cells[7].Value.ToString();
            txtsoluong.Text = dgv.Rows[r].Cells[8].Value.ToString();
            txttgbd.Text = dgv.Rows[r].Cells[9].Value.ToString();
            txttgkt.Text = dgv.Rows[r].Cells[10].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            dgv_CellClick(null, null);
            txtphong.Enabled = true;
            txtthu.Enabled = true;
            txttutiet.Enabled = true;
            txtdentiet.Enabled = true;
            txtsoluong.Enabled = true;
            txttgbd.Enabled = true;
            txttgkt.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {

            }
            else
            {
                dbcn.sualophocphan(txtmalop.Text, txtphong.Text, txtthu.Text, int.Parse(txttutiet.Text), int.Parse(txtdentiet.Text),
               int.Parse(txtsoluong.Text),
                txttgbd.Text,
                txttgkt.Text);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
            txtphong.Enabled = false;
            txtthu.Enabled = false;
            txttutiet.Enabled = false;
            txtdentiet.Enabled = false;
            txtsoluong.Enabled = false;
            txttgbd.Enabled = false;
            txttgkt.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgv.CurrentCell.RowIndex;
                string malop = dgv.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbcn.xoalhp(malop);
                    LoadData();
                    MessageBox.Show("Đã xóa xong!");
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
    }
}
