namespace QLHSSV
{
    partial class frmHocPhan
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
            grpThongTin = new GroupBox();
            lbMaHP = new Label();
            txtMaHP = new TextBox();
            lbTenHP = new Label();
            txtTenHP = new TextBox();
            lbSoTinChi = new Label();
            txtSoTinChi = new TextBox();
            lbTyLe = new Label();
            txtTyLe = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvHocPhan = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocPhan).BeginInit();
            SuspendLayout();
            //
            // lbMaHP
            //
            lbMaHP.AutoSize = true;
            lbMaHP.Location = new Point(15, 33);
            lbMaHP.Name = "lbMaHP";
            lbMaHP.TabIndex = 0;
            lbMaHP.Text = "Mã học phần (*)";
            //
            // txtMaHP
            //
            txtMaHP.Location = new Point(130, 30);
            txtMaHP.Name = "txtMaHP";
            txtMaHP.Size = new Size(270, 23);
            txtMaHP.TabIndex = 1;
            //
            // lbTenHP
            //
            lbTenHP.AutoSize = true;
            lbTenHP.Location = new Point(15, 68);
            lbTenHP.Name = "lbTenHP";
            lbTenHP.TabIndex = 2;
            lbTenHP.Text = "Tên học phần (*)";
            //
            // txtTenHP
            //
            txtTenHP.Location = new Point(130, 65);
            txtTenHP.Name = "txtTenHP";
            txtTenHP.Size = new Size(270, 23);
            txtTenHP.TabIndex = 3;
            //
            // lbSoTinChi
            //
            lbSoTinChi.AutoSize = true;
            lbSoTinChi.Location = new Point(430, 33);
            lbSoTinChi.Name = "lbSoTinChi";
            lbSoTinChi.TabIndex = 4;
            lbSoTinChi.Text = "Số tín chỉ (*)";
            //
            // txtSoTinChi
            //
            txtSoTinChi.Location = new Point(540, 30);
            txtSoTinChi.Name = "txtSoTinChi";
            txtSoTinChi.Size = new Size(300, 23);
            txtSoTinChi.TabIndex = 5;
            //
            // lbTyLe
            //
            lbTyLe.AutoSize = true;
            lbTyLe.Location = new Point(430, 68);
            lbTyLe.Name = "lbTyLe";
            lbTyLe.TabIndex = 6;
            lbTyLe.Text = "Tỷ lệ QT (%) (*)";
            //
            // txtTyLe
            //
            txtTyLe.Location = new Point(540, 65);
            txtTyLe.Name = "txtTyLe";
            txtTyLe.Size = new Size(300, 23);
            txtTyLe.TabIndex = 7;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbMaHP);
            grpThongTin.Controls.Add(txtMaHP);
            grpThongTin.Controls.Add(lbTenHP);
            grpThongTin.Controls.Add(txtTenHP);
            grpThongTin.Controls.Add(lbSoTinChi);
            grpThongTin.Controls.Add(txtSoTinChi);
            grpThongTin.Controls.Add(lbTyLe);
            grpThongTin.Controls.Add(txtTyLe);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 115);
            grpThongTin.TabIndex = 8;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin học phần";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 140);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 140);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 140);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 140);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // lbTimKiem
            //
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(520, 147);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.TabIndex = 13;
            lbTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(620, 144);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(160, 23);
            txtTimKiem.TabIndex = 14;
            //
            // btnTim
            //
            btnTim.Location = new Point(790, 140);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(78, 32);
            btnTim.TabIndex = 15;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            //
            // dgvHocPhan
            //
            dgvHocPhan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHocPhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocPhan.Location = new Point(12, 185);
            dgvHocPhan.Name = "dgvHocPhan";
            dgvHocPhan.Size = new Size(856, 403);
            dgvHocPhan.TabIndex = 16;
            //
            // frmHocPhan
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 600);
            Controls.Add(grpThongTin);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lbTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTim);
            Controls.Add(dgvHocPhan);
            Name = "frmHocPhan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý học phần";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocPhan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbMaHP;
        private TextBox txtMaHP;
        private Label lbTenHP;
        private TextBox txtTenHP;
        private Label lbSoTinChi;
        private TextBox txtSoTinChi;
        private Label lbTyLe;
        private TextBox txtTyLe;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvHocPhan;
    }
}
