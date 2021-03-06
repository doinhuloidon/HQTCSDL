﻿using System;
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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            LoadData();
        }
        QLDangKyMonHocDataContext qlMH = new QLDangKyMonHocDataContext(PropertiesCls.connectionStringLogin);
        private void LoadData()
        {
            if (PropertiesCls.quyenDangNhap == "1")
            {
                btnDSC.Visible = false;
                btnLHP.Visible = false;
                try
                {
                    dgrMonHoc.DataSource = qlMH.Chuong_trinh_dao_tao(PropertiesCls.tenDangNhap);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không tìm thấy nội dung!");
                    return;
                }
            }
            else
            {
                btnDKNCT.Visible = false;
                btnDKTCT.Visible = false;
                btnTCHP.Visible = false;
                btnTKB.Visible = false;
                btnTrangChu.Visible = false;
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            this.dgrMonHoc.Visible = true;
            LoadData();           
        }
        private void btnDKTCT_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fDangKyTheoCtr"))
            {
                fDangKyTheoCtr f = new fDangKyTheoCtr();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                this.dgrMonHoc.Visible = false;
                f.Show();
                f.Top = 98;
                f.Left = 142;
            }
            else
            {
                ActiveChildForm("fDangKyTheoCtr");
                ((fDangKyTheoCtr)this.ActiveMdiChild).LoadData();
            }
            this.dgrMonHoc.Visible = false;
        }

        private bool CheckExistForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    return;
                }
            }
        }


        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Close();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
        }

        private void btnDSC_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fQLSV"))
            {
                fQLSV f = new fQLSV();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.Show();
                f.Top = 0;
                f.Left = 0;
            }
            else
            {
                ActiveChildForm("fQLSV");
            }
            this.dgrMonHoc.Visible = false;
        }

        private void btnLHP_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fLop"))
            {
                fLop f = new fLop();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.Show();
                f.Top = 0;
                f.Left = 0;
            }
            else
            {
                ActiveChildForm("fLop");
            }
            this.dgrMonHoc.Visible = false;
        }

        private void dgrMonHoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (null != dgrMonHoc)
            {
                foreach (DataGridViewRow r in dgrMonHoc.Rows)
                {
                    dgrMonHoc.Rows[r.Index].Cells[0].Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnTCHP_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("TCLHocPhan"))
            {
                TCLHocPhan f = new TCLHocPhan();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                f.Show();
                f.Top = 0;
                f.Left = 0;
            }
            else
            {
                ActiveChildForm("TCLHocPhan");
            }
            this.dgrMonHoc.Visible = false;
        }

        private void btnDKNCT_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fDangKyNgoaiCtr"))
            {
                fDangKyNgoaiCtr f = new fDangKyNgoaiCtr();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                this.dgrMonHoc.Visible = false;
                f.Show();
                f.Top = 98;
                f.Left = 142;
            }
            else
            {
                ActiveChildForm("fDangKyNgoaiCtr");
                ((fDangKyNgoaiCtr)this.ActiveMdiChild).LoadData();
            }
            this.dgrMonHoc.Visible = false;
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fTKB"))
            {
                fTKB f = new fTKB();
                f.MdiParent = this;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                this.dgrMonHoc.Visible = false;
                f.Show();
                f.Top = 98;
                f.Left = 142;
            }
            else
            {
                ActiveChildForm("fTKB");
                ((fTKB)this.ActiveMdiChild).LoadData();
            }
            this.dgrMonHoc.Visible = false;
        }
    }
}
