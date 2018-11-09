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
            try
            {
                PropertiesCls.connectionStringLogin = "Data Source=192.168.137.1 ;Initial Catalog=DangKyQuanLyMonHoc;Integrated Security = False" + ";User ID=" + TenDangNhap + ";Password=" + MatKhau + ";";
                QLDangKyMonHocDataContext abc = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
                this.Hide();
                fMain main = new fMain();
                main.Show();      
            }
            catch
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác, vui lòng nhập lại !");
                txtTenDN.ResetText();
                txtMatKhau.ResetText();
                txtTenDN.Focus();
                PropertiesCls.connectionStringLogin = null;
            }
           

            //PropertiesCls.connectionStringLogin= "Data Source=192.168.137.1 ;Initial Catalog=DangKyQuanLyMonHoc;Integrated Security = False" + ";User ID=" + TenDangNhap + ";Password=" + MatKhau + ";"; ;

            //SqlConnection cnt = new SqlConnection(PropertiesCls.connectionStringLogin);
            //try
            //{
            //    cnt.Open();

            //    //this.Hide();
            //    // fMain main = new fMain();
            //    // main.Show();
            //    MessageBox.Show("open connection ! ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("can not open connection ! ");
            //}

        }

    }
}
