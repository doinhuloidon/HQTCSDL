using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKi
{
    public partial class fChuyenLop : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        public string maHP;
        public fChuyenLop()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                dgrDanhSach.DataSource = qlMH.Chon_lop_hoc_phan(maHP);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }
        private void dgrDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgrDanhSach.Rows)
            {
                row.Cells["Column1"].Value = false;
            }
            dgrDanhSach.CurrentRow.Cells["Column1"].Value = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string maLop;
            foreach (DataGridViewRow row in dgrDanhSach.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
                if (isSelected)
                {
                    maLop =  row.Cells["Column9"].Value.ToString().Trim();
                    qlMH.Chuyen_lop_hoc_phan(PropertiesCls.tenDangNhap, maLop, maHP);
                    break;
                }
            }
            MessageBox.Show("Chuyển lớp thành công!");
            this.Close();
            this.Dispose();
        }
    }
}
