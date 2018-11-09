namespace DoAnCuoiKi
{
    partial class TCLHocPhan
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TgBd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TgKt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttk = new System.Windows.Forms.TextBox();
            this.cbbtk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.TenMon,
            this.SoTC,
            this.PhongHoc,
            this.Thu,
            this.TuTiet,
            this.DenTiet,
            this.TenGv,
            this.SoLuong,
            this.TgBd,
            this.TgKt});
            this.dgv.Location = new System.Drawing.Point(0, 71);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1114, 391);
            this.dgv.TabIndex = 32;
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "maLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.Name = "MaLop";
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "tenMon";
            this.TenMon.HeaderText = "Tên Môn";
            this.TenMon.Name = "TenMon";
            // 
            // SoTC
            // 
            this.SoTC.DataPropertyName = "soTC";
            this.SoTC.HeaderText = "Số TC";
            this.SoTC.Name = "SoTC";
            // 
            // PhongHoc
            // 
            this.PhongHoc.DataPropertyName = "phongHoc";
            this.PhongHoc.HeaderText = "Phòng Học";
            this.PhongHoc.Name = "PhongHoc";
            // 
            // Thu
            // 
            this.Thu.DataPropertyName = "Thu";
            this.Thu.HeaderText = "Thứ";
            this.Thu.Name = "Thu";
            // 
            // TuTiet
            // 
            this.TuTiet.DataPropertyName = "TuTiet";
            this.TuTiet.HeaderText = "Từ Tiết";
            this.TuTiet.Name = "TuTiet";
            // 
            // DenTiet
            // 
            this.DenTiet.DataPropertyName = "DenTiet";
            this.DenTiet.HeaderText = "Đến Tiết";
            this.DenTiet.Name = "DenTiet";
            // 
            // TenGv
            // 
            this.TenGv.DataPropertyName = "TenGV";
            this.TenGv.HeaderText = "Tên GV";
            this.TenGv.Name = "TenGv";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "soLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // TgBd
            // 
            this.TgBd.DataPropertyName = "tgBatDau";
            this.TgBd.HeaderText = "TG Bắt Đầu";
            this.TgBd.Name = "TgBd";
            // 
            // TgKt
            // 
            this.TgKt.DataPropertyName = "tgKetThuc";
            this.TgKt.HeaderText = "TG Kết Thúc";
            this.TgKt.Name = "TgKt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btntimkiem);
            this.groupBox1.Controls.Add(this.txttk);
            this.groupBox1.Controls.Add(this.cbbtk);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1114, 190);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra Cứu Môn học";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(715, 29);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.TabIndex = 59;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // txttk
            // 
            this.txttk.Location = new System.Drawing.Point(481, 29);
            this.txttk.Name = "txttk";
            this.txttk.Size = new System.Drawing.Size(206, 22);
            this.txttk.TabIndex = 58;
            // 
            // cbbtk
            // 
            this.cbbtk.FormattingEnabled = true;
            this.cbbtk.Items.AddRange(new object[] {
            "Tên Môn",
            "Mã Môn",
            "Tên Khoa"});
            this.cbbtk.Location = new System.Drawing.Point(338, 29);
            this.cbbtk.Name = "cbbtk";
            this.cbbtk.Size = new System.Drawing.Size(121, 23);
            this.cbbtk.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(265, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Tìm Theo : ";
            // 
            // TCLHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 463);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Name = "TCLHocPhan";
            this.Text = "TCLHocPhan";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TgBd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TgKt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txttk;
        private System.Windows.Forms.ComboBox cbbtk;
        private System.Windows.Forms.Label label3;
    }
}