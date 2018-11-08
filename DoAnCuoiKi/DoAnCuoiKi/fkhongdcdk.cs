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
    public partial class fkhongdcdk : Form
    {

        DataSet ds = null;
        BLkhongduocdangky bcn = new BLkhongduocdangky();
        bool them = false;
        public fkhongdcdk()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            txtghi.Enabled = false;
            txtmasv.Enabled = false;
            try
            {
                dgv.DataSource = bcn.loadda();
                dgv.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nộ");
                return;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv.CurrentCell.RowIndex;
            txtmasv.Text = dgv.Rows[r].Cells[0].Value.ToString();
            txtghi.Text = dgv.Rows[r].Cells[5].Value.ToString();
        }

        private void addsv_Click(object sender, EventArgs e)
        {
            
            them = true;
            txtghi.ResetText();
            txtmasv.ResetText();
            txtghi.Enabled = true;
            txtmasv.Enabled = true;
            btnluu.Enabled = true;

            btnaddsv.Enabled = false;
            btneditsv.Enabled = false;
            btndeletesv.Enabled = false;
        }

        private void fkhongdcdk_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btneditsv_Click(object sender, EventArgs e)
        {
            them = false;
            dgv_CellClick(null, null);
            btnluu.Enabled = true;
            txtghi.Enabled = true;
            btnaddsv.Enabled = false;
            btneditsv.Enabled = false;
            btndeletesv.Enabled = false;
            txtmasv.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(them)
            {
                try
                {
                    bcn.themsvkodk(txtmasv.Text, txtghi.Text);
                    LoadData();
                    MessageBox.Show("Đã thêm xong ...");
                }
                catch
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                bcn.editsv(txtmasv.Text, txtghi.Text);
                LoadData();
                MessageBox.Show("Đã sửa xong!");
            }
            btnaddsv.Enabled = true;
            btneditsv.Enabled = true;
            btndeletesv.Enabled = true;
            btnluu.Enabled = false;
            txtghi.Enabled = false;
            txtmasv.Enabled = false;
            txtmasv.Enabled = false;

        }

        private void btndeletesv_Click(object sender, EventArgs e)
        {
            try 
            {
                int r = dgv.CurrentCell.RowIndex;
                string masv = dgv.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    bcn.deletesvkodk(masv);
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
