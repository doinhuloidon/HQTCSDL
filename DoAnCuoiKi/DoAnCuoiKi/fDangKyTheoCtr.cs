﻿using System;
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
    public partial class fDangKyTheoCtr : Form
    {
        public fDangKyTheoCtr()
        {
            InitializeComponent();
            LoadData();
        }
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext();
        public void LoadData()
        {
            try
            {
                dgrDanhSach.DataSource = qlMH.Chuong_trinh_theo_ke_hoach(PropertiesCls.tenDangNhap);
                dgrTinChi.DataSource = qlMH.Mon_dang_ky(PropertiesCls.tenDangNhap);
                label1.Text = "Số tín chỉ đã đăng ký: " + qlMH.Dem_so_tin_chi(PropertiesCls.tenDangNhap) + " tín chỉ";
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }
        private void dgrDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSach.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                int r = dgrDanhSach.CurrentCell.RowIndex;           
                qlMH.Dang_ky_mon_hoc(PropertiesCls.tenDangNhap, dgrDanhSach.Rows[r].Cells[2].Value.ToString().Trim());
                LoadData();
            }
        }
        private void dgrTinChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                int r = dgrTinChi.CurrentCell.RowIndex;
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.OK)
                {
                    qlMH.Xoa_mon_dang_ky(PropertiesCls.tenDangNhap, dgrTinChi.Rows[r].Cells[2].Value.ToString().Trim());
                }
                LoadData();
            }
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                int r = dgrTinChi.CurrentCell.RowIndex;
                string s = dgrTinChi.Rows[r].Cells[2].Value.ToString().Trim();
                fChuyenLop f = new fChuyenLop();
                f.Text = "Học phần: " + dgrTinChi.Rows[r].Cells[3].Value.ToString().Trim();
                f.maHP = s.Substring(0, s.Length - 3);
                f.LoadData();
                f.Show();
                f.FormClosed += new FormClosedEventHandler(Form_Closed);
                LoadData();
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
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
    }
}
