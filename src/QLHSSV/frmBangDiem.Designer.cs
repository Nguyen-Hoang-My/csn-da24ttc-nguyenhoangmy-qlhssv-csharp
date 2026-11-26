namespace QLHSSV
{
    partial class frmBangDiem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbMaSV = new Label();
            txtMaSV = new TextBox();
            btnXem = new Button();
            lblSinhVien = new Label();
            lbDiem = new Label();
            dgvDiem = new DataGridView();
            lbTongKet = new Label();
            dgvTongKet = new DataGridView();
            lblTichLuy = new Label();
            btnIn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTongKet).BeginInit();
            SuspendLayout();
            //
            // lbMaSV
            //
            lbMaSV.AutoSize = true;
            lbMaSV.Location = new Point(12, 16);
            lbMaSV.Name = "lbMaSV";
            lbMaSV.TabIndex = 0;
            lbMaSV.Text = "Mã sinh viên:";
            //
            // txtMaSV
            //
            txtMaSV.Location = new Point(100, 12);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(140, 23);
            txtMaSV.TabIndex = 1;
            //
            // btnXem
            //
            btnXem.Location = new Point(250, 9);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(80, 30);
            btnXem.TabIndex = 2;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = true;
            //
            // lblSinhVien
            //
            lblSinhVien.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(345, 15);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.TabIndex = 3;
            lblSinhVien.Text = "";
            //
            // lbDiem
            //
            lbDiem.AutoSize = true;
            lbDiem.Location = new Point(12, 50);
            lbDiem.Name = "lbDiem";
            lbDiem.TabIndex = 4;
            lbDiem.Text = "Điểm các học phần (mỗi lần học là một dòng, kể cả học lại):";
            //
            // dgvDiem
            //
            dgvDiem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(12, 70);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.Size = new Size(976, 330);
            dgvDiem.TabIndex = 5;
            //
            // lbTongKet
            //
            lbTongKet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbTongKet.AutoSize = true;
            lbTongKet.Location = new Point(12, 410);
            lbTongKet.Name = "lbTongKet";
            lbTongKet.TabIndex = 6;
            lbTongKet.Text = "Tổng kết theo học kỳ:";
            //
            // dgvTongKet
            //
            dgvTongKet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTongKet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTongKet.Location = new Point(12, 430);
            dgvTongKet.Name = "dgvTongKet";
            dgvTongKet.Size = new Size(976, 170);
            dgvTongKet.TabIndex = 7;
            //
            // lblTichLuy
            //
            lblTichLuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTichLuy.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTichLuy.AutoSize = true;
            lblTichLuy.Location = new Point(12, 610);
            lblTichLuy.Name = "lblTichLuy";
            lblTichLuy.TabIndex = 8;
            lblTichLuy.Text = "";
            //
            // btnIn
            //
            btnIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIn.Location = new Point(868, 604);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(120, 30);
            btnIn.TabIndex = 9;
            btnIn.Text = "In bảng điểm";
            btnIn.UseVisualStyleBackColor = true;
            //
            // frmBangDiem
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(lbMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(btnXem);
            Controls.Add(lblSinhVien);
            Controls.Add(lbDiem);
            Controls.Add(dgvDiem);
            Controls.Add(lbTongKet);
            Controls.Add(dgvTongKet);
            Controls.Add(lblTichLuy);
            Controls.Add(btnIn);
            Name = "frmBangDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bảng điểm toàn khóa";
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTongKet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbMaSV;
        private TextBox txtMaSV;
        private Button btnXem;
        private Label lblSinhVien;
        private Label lbDiem;
        private DataGridView dgvDiem;
        private Label lbTongKet;
        private DataGridView dgvTongKet;
        private Label lblTichLuy;
        private Button btnIn;
    }
}
