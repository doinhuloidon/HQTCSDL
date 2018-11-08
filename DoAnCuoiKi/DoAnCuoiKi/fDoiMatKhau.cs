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
    public partial class fDoiMatKhau : Form
    {
        public fDoiMatKhau()
        {
            InitializeComponent();
        }
        BLNguoiDung blND = new BLNguoiDung();
        string err = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MatKhauCu = txtMKcu.Text.ToString().Trim();
            string MatKhauMoi = txtMKmoi.Text.ToString().Trim();
            string MatKhauNhapLai = txtNhapLaiMk.Text.ToString().Trim();
            if(MatKhauCu != PropertiesCls.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ nhập không chính xác !");
                return;
            }
            if(MatKhauMoi!=MatKhauNhapLai)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp !");
                return;
            }
            if(MatKhauMoi=="")
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ !");
                return;
            }
            blND.CapNhatNguoiDung(PropertiesCls.MaUSer, MatKhauMoi, PropertiesCls.HoVaTen, PropertiesCls.Quyen, PropertiesCls.GioiTinh, ref err);
            PropertiesCls.MatKhau = MatKhauMoi;
            txtMKcu.ResetText();
            txtMKmoi.ResetText();
            txtNhapLaiMk.ResetText();
            MessageBox.Show("Thay đổi mật khẩu thành công !");
        }
    }
}
