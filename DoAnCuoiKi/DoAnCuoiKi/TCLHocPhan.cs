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
        public TCLHocPhan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
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

        
    }
}
