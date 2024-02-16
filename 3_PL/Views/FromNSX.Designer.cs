namespace _3_PL.Views
{
    partial class FromNSX
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.tb_ten = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_hienthi = new System.Windows.Forms.Button();
            this.dtg_nsx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_nsx)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "mã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "tên";
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(122, 47);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(220, 27);
            this.tb_ma.TabIndex = 2;
            // 
            // tb_ten
            // 
            this.tb_ten.Location = new System.Drawing.Point(122, 129);
            this.tb_ten.Name = "tb_ten";
            this.tb_ten.Size = new System.Drawing.Size(220, 27);
            this.tb_ten.TabIndex = 3;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(422, 47);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(94, 29);
            this.btn_them.TabIndex = 4;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(580, 47);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(94, 29);
            this.btn_sua.TabIndex = 5;
            this.btn_sua.Text = "sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(422, 120);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(94, 29);
            this.btn_xoa.TabIndex = 6;
            this.btn_xoa.Text = "xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_hienthi
            // 
            this.btn_hienthi.Location = new System.Drawing.Point(580, 120);
            this.btn_hienthi.Name = "btn_hienthi";
            this.btn_hienthi.Size = new System.Drawing.Size(94, 29);
            this.btn_hienthi.TabIndex = 7;
            this.btn_hienthi.Text = "hiển thị";
            this.btn_hienthi.UseVisualStyleBackColor = true;
            this.btn_hienthi.Click += new System.EventHandler(this.btn_hienthi_Click);
            // 
            // dtg_nsx
            // 
            this.dtg_nsx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_nsx.Location = new System.Drawing.Point(42, 222);
            this.dtg_nsx.Name = "dtg_nsx";
            this.dtg_nsx.RowHeadersWidth = 51;
            this.dtg_nsx.RowTemplate.Height = 29;
            this.dtg_nsx.Size = new System.Drawing.Size(718, 188);
            this.dtg_nsx.TabIndex = 8;
            this.dtg_nsx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_nsx_CellClick);
            // 
            // FromNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtg_nsx);
            this.Controls.Add(this.btn_hienthi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.tb_ten);
            this.Controls.Add(this.tb_ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FromNSX";
            this.Text = "FromNSX";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_nsx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_ma;
        private TextBox tb_ten;
        private Button btn_them;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_hienthi;
        private DataGridView dtg_nsx;
    }
}