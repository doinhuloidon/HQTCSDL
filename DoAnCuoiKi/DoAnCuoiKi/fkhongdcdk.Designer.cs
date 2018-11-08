namespace DoAnCuoiKi
{
    partial class fkhongdcdk
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
            this.btnaddsv = new System.Windows.Forms.Button();
            this.btneditsv = new System.Windows.Forms.Button();
            this.btndeletesv = new System.Windows.Forms.Button();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtghi = new System.Windows.Forms.TextBox();
            this.maSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nienKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnluu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSV,
            this.tenSV,
            this.tenKhoa,
            this.lop,
            this.nienKhoa,
            this.ghiChu});
            this.dgv.Location = new System.Drawing.Point(1, 90);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(924, 429);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // btnaddsv
            // 
            this.btnaddsv.Location = new System.Drawing.Point(995, 107);
            this.btnaddsv.Name = "btnaddsv";
            this.btnaddsv.Size = new System.Drawing.Size(75, 23);
            this.btnaddsv.TabIndex = 1;
            this.btnaddsv.Text = "Thêm";
            this.btnaddsv.UseVisualStyleBackColor = true;
            this.btnaddsv.Click += new System.EventHandler(this.addsv_Click);
            // 
            // btneditsv
            // 
            this.btneditsv.Location = new System.Drawing.Point(995, 185);
            this.btneditsv.Name = "btneditsv";
            this.btneditsv.Size = new System.Drawing.Size(75, 23);
            this.btneditsv.TabIndex = 2;
            this.btneditsv.Text = "Sửa";
            this.btneditsv.UseVisualStyleBackColor = true;
            this.btneditsv.Click += new System.EventHandler(this.btneditsv_Click);
            // 
            // btndeletesv
            // 
            this.btndeletesv.Location = new System.Drawing.Point(995, 263);
            this.btndeletesv.Name = "btndeletesv";
            this.btndeletesv.Size = new System.Drawing.Size(75, 23);
            this.btndeletesv.TabIndex = 3;
            this.btndeletesv.Text = "Xóa";
            this.btndeletesv.UseVisualStyleBackColor = true;
            this.btndeletesv.Click += new System.EventHandler(this.btndeletesv_Click);
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(100, 38);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.Size = new System.Drawing.Size(100, 20);
            this.txtmasv.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã sv :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ghi chú :";
            // 
            // txtghi
            // 
            this.txtghi.Location = new System.Drawing.Point(373, 12);
            this.txtghi.Multiline = true;
            this.txtghi.Name = "txtghi";
            this.txtghi.Size = new System.Drawing.Size(246, 72);
            this.txtghi.TabIndex = 7;
            // 
            // maSV
            // 
            this.maSV.DataPropertyName = "maSV";
            this.maSV.HeaderText = "Mã sinh viên";
            this.maSV.Name = "maSV";
            // 
            // tenSV
            // 
            this.tenSV.DataPropertyName = "tenSV";
            this.tenSV.HeaderText = "Tên sinh viên";
            this.tenSV.Name = "tenSV";
            // 
            // tenKhoa
            // 
            this.tenKhoa.DataPropertyName = "tenKhoa";
            this.tenKhoa.HeaderText = "Tên Khoa";
            this.tenKhoa.Name = "tenKhoa";
            // 
            // lop
            // 
            this.lop.DataPropertyName = "lop";
            this.lop.HeaderText = "Lớp";
            this.lop.Name = "lop";
            // 
            // nienKhoa
            // 
            this.nienKhoa.DataPropertyName = "nienKhoa";
            this.nienKhoa.HeaderText = "Niên khóa";
            this.nienKhoa.Name = "nienKhoa";
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "ghiChu";
            this.ghiChu.HeaderText = "Ghi chú";
            this.ghiChu.Name = "ghiChu";
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(995, 329);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 23);
            this.btnluu.TabIndex = 8;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // fkhongdcdk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 523);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.txtghi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmasv);
            this.Controls.Add(this.btndeletesv);
            this.Controls.Add(this.btneditsv);
            this.Controls.Add(this.btnaddsv);
            this.Controls.Add(this.dgv);
            this.Name = "fkhongdcdk";
            this.Text = "fkhongdcdk";
            this.Load += new System.EventHandler(this.fkhongdcdk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnaddsv;
        private System.Windows.Forms.Button btneditsv;
        private System.Windows.Forms.Button btndeletesv;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn nienKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
        private System.Windows.Forms.Button btnluu;
    }
}