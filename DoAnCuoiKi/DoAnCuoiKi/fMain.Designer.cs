namespace DoAnCuoiKi
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.picbIntro = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDX = new System.Windows.Forms.Button();
            this.btnLHP = new System.Windows.Forms.Button();
            this.btnDSC = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnTKB = new System.Windows.Forms.Button();
            this.btnTCHP = new System.Windows.Forms.Button();
            this.btnDKNCT = new System.Windows.Forms.Button();
            this.btnDKTCT = new System.Windows.Forms.Button();
            this.dgrMonHoc = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picbIntro)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // picbIntro
            // 
            this.picbIntro.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.picbIntro, "picbIntro");
            this.picbIntro.Name = "picbIntro";
            this.picbIntro.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDX);
            this.groupBox1.Controls.Add(this.btnLHP);
            this.groupBox1.Controls.Add(this.btnDSC);
            this.groupBox1.Controls.Add(this.btnTrangChu);
            this.groupBox1.Controls.Add(this.btnTKB);
            this.groupBox1.Controls.Add(this.btnTCHP);
            this.groupBox1.Controls.Add(this.btnDKNCT);
            this.groupBox1.Controls.Add(this.btnDKTCT);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnDX
            // 
            resources.ApplyResources(this.btnDX, "btnDX");
            this.btnDX.Name = "btnDX";
            this.btnDX.UseVisualStyleBackColor = true;
            this.btnDX.Click += new System.EventHandler(this.btnDX_Click);
            // 
            // btnLHP
            // 
            resources.ApplyResources(this.btnLHP, "btnLHP");
            this.btnLHP.Name = "btnLHP";
            this.btnLHP.UseVisualStyleBackColor = true;
            this.btnLHP.Click += new System.EventHandler(this.btnLHP_Click);
            // 
            // btnDSC
            // 
            resources.ApplyResources(this.btnDSC, "btnDSC");
            this.btnDSC.Name = "btnDSC";
            this.btnDSC.UseVisualStyleBackColor = true;
            this.btnDSC.Click += new System.EventHandler(this.btnDSC_Click);
            // 
            // btnTrangChu
            // 
            resources.ApplyResources(this.btnTrangChu, "btnTrangChu");
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnTKB
            // 
            resources.ApplyResources(this.btnTKB, "btnTKB");
            this.btnTKB.Name = "btnTKB";
            this.btnTKB.UseVisualStyleBackColor = true;
            // 
            // btnTCHP
            // 
            resources.ApplyResources(this.btnTCHP, "btnTCHP");
            this.btnTCHP.Name = "btnTCHP";
            this.btnTCHP.UseVisualStyleBackColor = true;
            this.btnTCHP.Click += new System.EventHandler(this.btnTCHP_Click);
            // 
            // btnDKNCT
            // 
            resources.ApplyResources(this.btnDKNCT, "btnDKNCT");
            this.btnDKNCT.Name = "btnDKNCT";
            this.btnDKNCT.UseVisualStyleBackColor = true;
            this.btnDKNCT.Click += new System.EventHandler(this.btnDKNCT_Click);
            // 
            // btnDKTCT
            // 
            resources.ApplyResources(this.btnDKTCT, "btnDKTCT");
            this.btnDKTCT.Name = "btnDKTCT";
            this.btnDKTCT.UseVisualStyleBackColor = true;
            this.btnDKTCT.Click += new System.EventHandler(this.btnDKTCT_Click);
            // 
            // dgrMonHoc
            // 
            this.dgrMonHoc.AllowUserToAddRows = false;
            this.dgrMonHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgrMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.maMH,
            this.tenMH,
            this.loaiMon,
            this.soTC});
            resources.ApplyResources(this.dgrMonHoc, "dgrMonHoc");
            this.dgrMonHoc.Name = "dgrMonHoc";
            this.dgrMonHoc.ReadOnly = true;
            this.dgrMonHoc.RowHeadersVisible = false;
            this.dgrMonHoc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrMonHoc_DataBindingComplete);
            // 
            // stt
            // 
            resources.ApplyResources(this.stt, "stt");
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            this.stt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // maMH
            // 
            this.maMH.DataPropertyName = "maMon";
            resources.ApplyResources(this.maMH, "maMH");
            this.maMH.Name = "maMH";
            this.maMH.ReadOnly = true;
            this.maMH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tenMH
            // 
            this.tenMH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenMH.DataPropertyName = "tenMon";
            resources.ApplyResources(this.tenMH, "tenMH");
            this.tenMH.Name = "tenMH";
            this.tenMH.ReadOnly = true;
            this.tenMH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // loaiMon
            // 
            this.loaiMon.DataPropertyName = "loaiMon";
            resources.ApplyResources(this.loaiMon, "loaiMon");
            this.loaiMon.Name = "loaiMon";
            this.loaiMon.ReadOnly = true;
            // 
            // soTC
            // 
            this.soTC.DataPropertyName = "soTC";
            resources.ApplyResources(this.soTC, "soTC");
            this.soTC.Name = "soTC";
            this.soTC.ReadOnly = true;
            this.soTC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // fMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dgrMonHoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picbIntro);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "fMain";
            ((System.ComponentModel.ISupportInitialize)(this.picbIntro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrMonHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picbIntro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDKNCT;
        private System.Windows.Forms.Button btnDKTCT;
        private System.Windows.Forms.Button btnTKB;
        private System.Windows.Forms.Button btnTCHP;
        private System.Windows.Forms.DataGridView dgrMonHoc;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnLHP;
        private System.Windows.Forms.Button btnDSC;
        private System.Windows.Forms.Button btnDX;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTC;
    }
}