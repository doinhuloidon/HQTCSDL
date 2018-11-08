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

namespace DoAnCuoiKi
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private string TenDangNhap;
        private string MatKhau;
        BLTaiKhoan blQLTK = new BLTaiKhoan();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không ?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TenDangNhap = txtTenDN.Text.Trim();
            MatKhau = txtMatKhau.Text.Trim();

            if (blQLTK.KiemTraDangNhap(TenDangNhap, MatKhau))
            {
                this.Hide();
                fMain main = new fMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác, vui lòng nhập lại !");
                txtTenDN.ResetText();
                txtMatKhau.ResetText();
                txtTenDN.Focus();
            }
        }

    }
}
