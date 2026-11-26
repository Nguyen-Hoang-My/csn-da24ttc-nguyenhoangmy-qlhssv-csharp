namespace QLHSSV
{
    partial class frmNhapDiem
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
            lbHocKy = new Label();
            cboHocKy = new ComboBox();
            lbHocPhan = new Label();
            cboHocPhan = new ComboBox();
            lblTyLe = new Label();
            lbHuongDan = new Label();
            dgvDiem = new DataGridView();
            btnLuu = new Button();
            btnTaiLai = new Button();
            lblTrangThai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            //
            // lbHocKy
            //
            lbHocKy.AutoSize = true;
            lbHocKy.Location = new Point(12, 16);
            lbHocKy.Name = "lbHocKy";
            lbHocKy.TabIndex = 0;
            lbHocKy.Text = "Học kỳ:";
            //
            // cboHocKy
            //
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(70, 12);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(280, 23);
            cboHocKy.TabIndex = 1;
            //
            // lbHocPhan
            //
            lbHocPhan.AutoSize = true;
            lbHocPhan.Location = new Point(370, 16);
            lbHocPhan.Name = "lbHocPhan";
            lbHocPhan.TabIndex = 2;
            lbHocPhan.Text = "Học phần:";
            //
            // cboHocPhan
            //
            cboHocPhan.FormattingEnabled = true;
            cboHocPhan.Location = new Point(440, 12);
            cboHocPhan.Name = "cboHocPhan";
            cboHocPhan.Size = new Size(400, 23);
            cboHocPhan.TabIndex = 3;
            //
            // lblTyLe
            //
            lblTyLe.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTyLe.AutoSize = true;
            lblTyLe.Location = new Point(12, 50);
            lblTyLe.Name = "lblTyLe";
            lblTyLe.TabIndex = 4;
            lblTyLe.Text = "";
            //
            // lbHuongDan
            //
            lbHuongDan.ForeColor = SystemColors.GrayText;
            lbHuongDan.Location = new Point(12, 75);
            lbHuongDan.Name = "lbHuongDan";
            lbHuongDan.Size = new Size(976, 20);
            lbHuongDan.TabIndex = 5;
            lbHuongDan.Text = "Gõ điểm quá trình và điểm thi (0 đến 10, dùng dấu chấm hoặc phẩy). Thi lần 2 chỉ nhập cho sinh viên bị F ở lần 1, điểm học phần sau thi lại tối đa 6,9. Nhớ bấm Lưu điểm.";
            //
            // dgvDiem
            //
            dgvDiem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Location = new Point(12, 100);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.Size = new Size(976, 460);
            dgvDiem.TabIndex = 6;
            //
            // btnLuu
            //
            btnLuu.Location = new Point(12, 573);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 32);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu điểm";
            btnLuu.UseVisualStyleBackColor = true;
            //
            // btnTaiLai
            //
            btnTaiLai.Location = new Point(142, 573);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(120, 32);
            btnTaiLai.TabIndex = 8;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            //
            // lblTrangThai
            //
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(280, 581);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "";
            //
            // frmNhapDiem
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            Controls.Add(lbHocKy);
            Controls.Add(cboHocKy);
            Controls.Add(lbHocPhan);
            Controls.Add(cboHocPhan);
            Controls.Add(lblTyLe);
            Controls.Add(lbHuongDan);
            Controls.Add(dgvDiem);
            Controls.Add(btnLuu);
            Controls.Add(btnTaiLai);
            Controls.Add(lblTrangThai);
            Name = "frmNhapDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm học phần";
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbHocKy;
        private ComboBox cboHocKy;
        private Label lbHocPhan;
        private ComboBox cboHocPhan;
        private Label lblTyLe;
        private Label lbHuongDan;
        private DataGridView dgvDiem;
        private Button btnLuu;
        private Button btnTaiLai;
        private Label lblTrangThai;
    }
}
