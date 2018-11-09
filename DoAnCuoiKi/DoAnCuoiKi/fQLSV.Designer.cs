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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fkhongdcdk));
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.gbxChiTiet = new System.Windows.Forms.GroupBox();
            this.txtghi = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.maSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nienKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnluu = new System.Windows.Forms.Button();
            this.btndeletesv = new System.Windows.Forms.Button();
            this.btneditsv = new System.Windows.Forms.Button();
            this.btnaddsv = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.gbxChiTiet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(95, 26);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.Size = new System.Drawing.Size(133, 23);
            this.txtmasv.TabIndex = 1;
            // 
            // gbxChiTiet
            // 
            this.gbxChiTiet.Controls.Add(this.txtghi);
            this.gbxChiTiet.Controls.Add(this.label16);
            this.gbxChiTiet.Controls.Add(this.txtmasv);
            this.gbxChiTiet.Controls.Add(this.label2);
            this.gbxChiTiet.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxChiTiet.Location = new System.Drawing.Point(2, 3);
            this.gbxChiTiet.Name = "gbxChiTiet";
            this.gbxChiTiet.Size = new System.Drawing.Size(247, 519);
            this.gbxChiTiet.TabIndex = 23;
            this.gbxChiTiet.TabStop = false;
            this.gbxChiTiet.Text = "Thông tin chi tiết";
            // 
            // txtghi
            // 
            this.txtghi.Location = new System.Drawing.Point(95, 52);
            this.txtghi.Multiline = true;
            this.txtghi.Name = "txtghi";
            this.txtghi.Size = new System.Drawing.Size(133, 51);
            this.txtghi.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 34;
            this.label16.Text = "Ghi Chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã Sinh Viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(255, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 519);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
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
            this.dgv.Location = new System.Drawing.Point(6, 19);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(768, 455);
            this.dgv.TabIndex = 1;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
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
            this.btnluu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnluu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.Image = ((System.Drawing.Image)(resources.GetObject("btnluu.Image")));
            this.btnluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluu.Location = new System.Drawing.Point(1035, 202);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(92, 39);
            this.btnluu.TabIndex = 38;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btndeletesv
            // 
            this.btndeletesv.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletesv.ForeColor = System.Drawing.Color.Black;
            this.btndeletesv.Image = ((System.Drawing.Image)(resources.GetObject("btndeletesv.Image")));
            this.btndeletesv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletesv.Location = new System.Drawing.Point(1035, 157);
            this.btndeletesv.Name = "btndeletesv";
            this.btndeletesv.Size = new System.Drawing.Size(92, 39);
            this.btndeletesv.TabIndex = 36;
            this.btndeletesv.Text = "Xóa";
            this.btndeletesv.UseVisualStyleBackColor = true;
            this.btndeletesv.Click += new System.EventHandler(this.btndeletesv_Click);
            // 
            // btneditsv
            // 
            this.btneditsv.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditsv.ForeColor = System.Drawing.Color.Black;
            this.btneditsv.Image = ((System.Drawing.Image)(resources.GetObject("btneditsv.Image")));
            this.btneditsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneditsv.Location = new System.Drawing.Point(1035, 67);
            this.btneditsv.Name = "btneditsv";
            this.btneditsv.Size = new System.Drawing.Size(92, 39);
            this.btneditsv.TabIndex = 35;
            this.btneditsv.Text = "Sửa";
            this.btneditsv.UseVisualStyleBackColor = true;
            this.btneditsv.Click += new System.EventHandler(this.btneditsv_Click);
            // 
            // btnaddsv
            // 
            this.btnaddsv.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddsv.ForeColor = System.Drawing.Color.Black;
            this.btnaddsv.Image = ((System.Drawing.Image)(resources.GetObject("btnaddsv.Image")));
            this.btnaddsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddsv.Location = new System.Drawing.Point(1035, 22);
            this.btnaddsv.Name = "btnaddsv";
            this.btnaddsv.Size = new System.Drawing.Size(92, 39);
            this.btnaddsv.TabIndex = 34;
            this.btnaddsv.Text = "Thêm mới";
            this.btnaddsv.UseVisualStyleBackColor = true;
            this.btnaddsv.Click += new System.EventHandler(this.addsv_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(1035, 112);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 39);
            this.btnHuy.TabIndex = 39;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // fkhongdcdk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 523);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btndeletesv);
            this.Controls.Add(this.btneditsv);
            this.Controls.Add(this.btnaddsv);
            this.Controls.Add(this.gbxChiTiet);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(889, 502);
            this.Name = "fkhongdcdk";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.fkhongdcdk_Load);
            this.gbxChiTiet.ResumeLayout(false);
            this.gbxChiTiet.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.GroupBox gbxChiTiet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtghi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btndeletesv;
        private System.Windows.Forms.Button btneditsv;
        private System.Windows.Forms.Button btnaddsv;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn nienKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
    }
}