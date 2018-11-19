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
    public partial class fGhiChu : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        public string maSV;
        public string ghiChu;
        public fGhiChu()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
                {
                    qlMH.Xoa_sinh_vien_bi_cam(maSV);
                    MessageBox.Show("Đã gỡ sinh viên khỏi danh sách cấm!");
                }
                else
                {
                    qlMH.Them_sinh_vien_bi_cam(maSV, txtGhiChu.Text);
                    MessageBox.Show("Thêm sinh viên vào danh sách cấm thành công!");
                }
                this.Close();
                this.Dispose();
            }
            catch
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
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

        private void fGhiChu_Load(object sender, EventArgs e)
        {
            txtGhiChu.Text = ghiChu;
        }
    }
}
