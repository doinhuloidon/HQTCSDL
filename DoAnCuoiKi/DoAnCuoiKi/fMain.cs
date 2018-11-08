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
    public partial class fMain : Form
    {
        public fMain()
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
                dgrMonHoc.DataSource = blQLMH.ChuongTrinhDaoTao(PropertiesCls.tenDangNhap);
                if(PropertiesCls.quyenDangNhap=="2")
                {
                    btnDSC.Visible = true;
                    btnLHP.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy nội dung!");
                return;
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            this.dgrMonHoc.Visible = true;

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
            }
            this.dgrMonHoc.Visible = false;
        }

        //private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    fDoiMatKhau fdoimatkhau = new fDoiMatKhau();
        //    fdoimatkhau.ShowDialog();
        //}

        //private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //}

        //private void btnQLND_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fQLNguoiDung"))
        //    {
        //        fQLNguoiDung f = new fQLNguoiDung();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fQLNguoiDung");
        //    }
        //}

        //private void btnQLMH_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fMonHoc"))
        //    {
        //        fMonHoc f = new fMonHoc();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fMonHoc");
        //    }
        //}

        //private void btnQLK_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fKhoa"))
        //    {
        //        fKhoa f = new fKhoa();
        //        f.MdiParent = this;
        //        f.Show();
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fKhoa");
        //    }
        //}

        //private void btnQLCN_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fChuyenNganh"))
        //    {
        //        fChuyenNganh f = new fChuyenNganh();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fChuyenNganh");
        //    }
        //}

        //private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    PropertiesCls.GioiTinh = "";
        //    PropertiesCls.TenDangNhap = "";
        //    PropertiesCls.MatKhau = "";
        //    PropertiesCls.HoVaTen = "";
        //    PropertiesCls.Quyen = "";
        //    PropertiesCls.MaUSer = "";
        //    if (PropertiesCls.MaUSer == "")
        //    {
        //        this.đăngXuấtToolStripMenuItem.Enabled = false;
        //        this.đăngNhậpToolStripMenuItem.Enabled = true;
        //        this.đổiMậtKhẩuToolStripMenuItem.Enabled = false;

        //        foreach (Form frm in this.MdiChildren)
        //        {
        //            frm.Close();
        //        }

        //        quảnLýToolStripMenuItem.Enabled = false;
        //        thốngKêToolStripMenuItem.Enabled = false;
        //        TìmKiếmToolStripMenuItem.Enabled = false;
        //        btnQLCN.Enabled = false;
        //        btnQLDSD.Enabled = false;
        //        btnQLDSNT.Enabled = false;
        //        btnQLK.Enabled = false;
        //        btnQLL.Enabled = false;
        //        btnQLMH.Enabled = false;
        //        btnQLND.Enabled = false;
        //        btnQLSV.Enabled = false;
        //    }

        //}

        //private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    fDangNhap f = new fDangNhap();
        //    f.ShowDialog();
        //    while (PropertiesCls.MaUSer == "" && f.IsDisposed == false)
        //    {
        //        f.ShowDialog();
        //    }
        //    btnQLCN.Enabled = true;
        //    btnQLDSD.Enabled = true;
        //    btnQLDSNT.Enabled = true;
        //    btnQLK.Enabled = true;
        //    btnQLL.Enabled = true;
        //    btnQLMH.Enabled = true;
        //    btnQLND.Enabled = true;
        //    btnQLSV.Enabled = true;
        //    quảnLýToolStripMenuItem.Enabled = true;
        //    thốngKêToolStripMenuItem.Enabled = true;
        //    TìmKiếmToolStripMenuItem.Enabled = true;
        //    //if (PropertiesCls.MaUSer != "")
        //    //{
        //    //    this.đăngNhậpToolStripMenuItem.Enabled = false;
        //    //    this.đăngXuấtToolStripMenuItem.Enabled = true;
        //    //    this.đổiMậtKhẩuToolStripMenuItem.Enabled = true;

        //    //    if (PropertiesCls.Quyen != "User")
        //    //    {
        //    //        btnQLCN.Enabled = true;
        //    //        btnQLDSD.Enabled = true;
        //    //        btnQLDSNT.Enabled = true;
        //    //        btnQLK.Enabled = true;
        //    //        btnQLL.Enabled = true;
        //    //        btnQLMH.Enabled = true;
        //    //        btnQLND.Enabled = true;
        //    //        btnQLSV.Enabled = true;
        //    //        quảnLýToolStripMenuItem.Enabled = true;
        //    //        thốngKêToolStripMenuItem.Enabled = true;
        //    //        TìmKiếmToolStripMenuItem.Enabled = true;
        //    //        if (PropertiesCls.Quyen == "Caption")
        //    //        {
        //    //            ngườiDùngToolStripMenuItem.Enabled = false;
        //    //        }

        //    //    }
        //    //    else
        //    //    {
        //    //        btnQLCN.Enabled = false;
        //    //        btnQLDSD.Enabled = false;
        //    //        btnQLDSNT.Enabled = false;
        //    //        btnQLK.Enabled = false;
        //    //        btnQLL.Enabled = false;
        //    //        btnQLMH.Enabled = false;
        //    //        btnQLND.Enabled = false;
        //    //        btnQLSV.Enabled = false;
        //    //        quảnLýToolStripMenuItem.Enabled = false;
        //    //        thốngKêToolStripMenuItem.Enabled = true;
        //    //        TìmKiếmToolStripMenuItem.Enabled = true;

        //    //    }
        //    //}
        //}

        //private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fTimKiemThongTinSV"))
        //    {
        //        fTimKiemThongTinSV f = new fTimKiemThongTinSV();
        //        f.MdiParent = this;
        //        f.Show();
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fTimKiemThongTinSV");
        //    }
        //}

        //private void btnQLDSD_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fQLDiem"))
        //    {
        //        fQLDiem f = new fQLDiem();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fQLDiem");
        //    }
        //}

        //private void btnQLDSNT_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fNguoiThan"))
        //    {
        //        fNguoiThan f = new fNguoiThan();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fNguoiThan");
        //    }
        //}

        //private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fTimKiemDiem"))
        //    {
        //        fTimKiemDiem f = new fTimKiemDiem();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fTimKiemDiem");
        //    }
        //}

        //private void fMain_Load(object sender, EventArgs e)
        //{
        //    btnQLCN.Enabled = false;
        //    btnQLDSD.Enabled = false;
        //    btnQLDSNT.Enabled = false;
        //    btnQLK.Enabled = false;
        //    btnQLL.Enabled = false;
        //    btnQLMH.Enabled = false;
        //    btnQLND.Enabled = false;
        //    btnQLSV.Enabled = false;
        //    quảnLýToolStripMenuItem.Enabled = false;
        //    thốngKêToolStripMenuItem.Enabled = false;
        //    TìmKiếmToolStripMenuItem.Enabled = false;
        //}

        //private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Khai báo biến traloi
        //    DialogResult traloi;
        //    // Hiện hộp thoại hỏi đáp
        //    traloi = MessageBox.Show("Chắc không?", "Trả lời",
        //    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //    // Kiểm tra có nhắp chọn nút Ok không?
        //    if (traloi == DialogResult.OK) this.Close();
        //}

        //private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    fHelp f = new fHelp();
        //    f.ShowDialog();
        //}

        //private void bảngĐiểmCáNhânCủaSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fThongKeBangDiemCaNhan"))
        //    {
        //        fThongKeBangDiemCaNhan f = new fThongKeBangDiemCaNhan();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fThongKeBangDiemCaNhan");
        //    }
        //}

        //private void thốngKêTỉLệĐậuRớtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!CheckExistForm("fThongKeTiLeDauRotCuaCacMon"))
        //    {
        //        fThongKeTiLeDauRotCuaCacMon f = new fThongKeTiLeDauRotCuaCacMon();
        //        f.MdiParent = this;
        //        f.WindowState = FormWindowState.Maximized;
        //        f.Show();
        //        f.Top = 0;
        //        f.Left = 0;
        //    }
        //    else
        //    {
        //        ActiveChildForm("fThongKeTiLeDauRotCuaCacMon");
        //    }
        //}
    }
}
