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
    public partial class TCLHocPhan : Form
    {
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
        public TCLHocPhan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {       
            try
            {
                dgv.DataSource = qlMH.Lop_hoc_phan();
                dgv.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbbLoai.Text == "Tên Môn")
                {
                    dgv.DataSource = qlMH.Tim_hoc_phan_theo_ten(txtTimKiem.Text.Trim());
                }
                else if (cbbLoai.Text == "Mã Môn")
                {
                    dgv.DataSource = qlMH.Tim_hoc_phan_theo_ma_mon(txtTimKiem.Text.Trim());
                }
                dgv.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Không Tìm Thấy!!!");
            }


        }
    }
}
