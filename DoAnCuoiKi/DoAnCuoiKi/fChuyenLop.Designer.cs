namespace DoAnCuoiKi
{
    partial class fChuyenLop
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
            this.dgrDanhSach = new System.Windows.Forms.DataGridView();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrDanhSach
            // 
            this.dgrDanhSach.AllowUserToAddRows = false;
            this.dgrDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgrDanhSach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgrDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column13,
            this.Column9,
            this.Column11,
            this.Column12,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column20});
            this.dgrDanhSach.Location = new System.Drawing.Point(0, 0);
            this.dgrDanhSach.Name = "dgrDanhSach";
            this.dgrDanhSach.RowHeadersVisible = false;
            this.dgrDanhSach.Size = new System.Drawing.Size(772, 321);
            this.dgrDanhSach.TabIndex = 5;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "loaiMon";
            this.Column13.HeaderText = "Loại HP";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 70;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "maLop";
            this.Column9.FillWeight = 150F;
            this.Column9.HeaderText = "Lớp HP";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "soTC";
            this.Column11.HeaderText = "Số TC";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column11.Width = 62;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "soTiet";
            this.Column12.HeaderText = "Số Tiết";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column12.Width = 66;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "soLuong";
            this.Column14.HeaderText = "Số Lượng";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 78;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "daDK";
            this.Column15.HeaderText = "Đã ĐK";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 64;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "tenGV";
            this.Column16.HeaderText = "Giảng Viên";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 84;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column17.DataPropertyName = "lichHoc";
            this.Column17.HeaderText = "Lịch Học";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Đăng Ký";
            this.Column20.Name = "Column20";
            this.Column20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column20.Text = "Đăng ký";
            this.Column20.UseColumnTextForButtonValue = true;
            this.Column20.Width = 54;
            // 
            // fChuyenLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 320);
            this.Controls.Add(this.dgrDanhSach);
            this.Name = "fChuyenLop";
            this.Text = "fChuyenLop";
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewButtonColumn Column20;
    }
}