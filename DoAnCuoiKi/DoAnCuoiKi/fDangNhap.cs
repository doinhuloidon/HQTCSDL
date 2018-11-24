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
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace DoAnCuoiKi
{
    public partial class fDangNhap : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        public fDangNhap()
        {
            InitializeComponent();
            //Process netUtility = new Process();
            //netUtility.StartInfo.FileName = "net.exe";
            //netUtility.StartInfo.CreateNoWindow = true;
            //netUtility.StartInfo.Arguments = "view";
            //netUtility.StartInfo.RedirectStandardOutput = true;
            //netUtility.StartInfo.UseShellExecute = false;
            //netUtility.StartInfo.RedirectStandardError = true;
            //netUtility.Start();
            //StreamReader streamReader = new StreamReader(netUtility.StandardOutput.BaseStream, netUtility.StandardOutput.CurrentEncoding);
            //string line = "";
            //while ((line = streamReader.ReadLine()) != null)
            //{
            //    if (line.StartsWith("\\"))
            //    {
            //        ComboboxItem item = new ComboboxItem();
            //        item.Text = Convert.ToString(line.Substring(2).Substring(0, line.Substring(2).IndexOf(" ")).ToUpper());
            //        item.Value = Convert.ToString(Dns.GetHostByName(line.Substring(2).Substring(0, line.Substring(2).IndexOf(" ")).ToUpper()).AddressList[0].ToString());
            //        cbbIP.Items.Add(item);
            //    }
            //}
            //streamReader.Close();
            //netUtility.WaitForExit(1000);
        }

        private string tenDangNhap;
        private string matKhau;
        private string dataSource;
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
            tenDangNhap = txtTenDN.Text.Trim();
            matKhau = txtMatKhau.Text.Trim();
            dataSource = cbbIP.Text.ToString().Trim();       
            PropertiesCls.connectionStringLogin = "Server=" + dataSource +",1433\\sqlexpress; Initial Catalog = DangKyQuanLyMonHoc"
                                        + ";User ID=" + tenDangNhap +";Password=" + matKhau + ";";
            PropertiesCls.tenDangNhap = tenDangNhap;
            PropertiesCls.matkhau = matKhau;
            PropertiesCls.quyenDangNhap = qlMH.Lay_quyen_dang_nhap(tenDangNhap).ToString();
            SqlConnection cnt = new SqlConnection(PropertiesCls.connectionStringLogin);
            try
            {
                cnt.Open();
                this.Hide();
                fMain main = new fMain();
                main.Show();
                MessageBox.Show("Open connection! ");
            }
            catch
            {
                txtTenDN.ResetText();
                txtMatKhau.ResetText();
                txtTenDN.Focus();
                PropertiesCls.connectionStringLogin = null;
                MessageBox.Show("Can not open connection! ");
            }

        }

    }
}
