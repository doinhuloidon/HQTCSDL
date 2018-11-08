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
    public partial class fDangKyNgoaiCtr : Form
    {
        public fDangKyNgoaiCtr()
        {
            InitializeComponent();
            LoadData();
        }
        //bool isThem = false;
        BLQuanLyMonHoc blQLMH = new BLQuanLyMonHoc();
        private void LoadData()
        {
            try
            {
                this.dgrDanhSach.DataSource = blQLMH.LayMonHocNgoaiChuongTrinh(PropertiesCls.tenDangNhap);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }
        private void dgrDanhSach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (null != dgrDanhSach)
            {
                foreach (DataGridViewRow r in dgrDanhSach.Rows)
                {
                    dgrDanhSach.Rows[r.Index].Cells[0].Value = (r.Index + 1).ToString();
                }
            }
        }
    }
}
