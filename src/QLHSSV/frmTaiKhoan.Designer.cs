namespace QLHSSV
{
    partial class frmTaiKhoan
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
            lbTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lbVaiTro = new Label();
            cboVaiTro = new ComboBox();
            lbMaSV = new Label();
            cboMaSV = new ComboBox();
            lbHoTen = new Label();
            txtHoTen = new TextBox();
            lbMatKhau = new Label();
            txtMatKhau = new TextBox();
            lbTrangThai = new Label();
            cboTrangThai = new ComboBox();
            lbGhiChu = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnDatLaiMK = new Button();
            btnTaoHangLoat = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            lbLocVaiTro = new Label();
            cboLocVaiTro = new ComboBox();
            dgvTaiKhoan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            //
            // lbTenDangNhap
            //
            lbTenDangNhap.AutoSize = true;
            lbTenDangNhap.Location = new Point(15, 33);
            lbTenDangNhap.Name = "lbTenDangNhap";
            lbTenDangNhap.TabIndex = 0;
            lbTenDangNhap.Text = "Tên đăng nhập (*)";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(130, 30);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(250, 23);
            txtTenDangNhap.TabIndex = 1;
            //
            // lbVaiTro
            //
            lbVaiTro.AutoSize = true;
            lbVaiTro.Location = new Point(15, 68);
            lbVaiTro.Name = "lbVaiTro";
            lbVaiTro.TabIndex = 2;
            lbVaiTro.Text = "Vai trò (*)";
            //
            // cboVaiTro
            //
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(130, 65);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(250, 23);
            cboVaiTro.TabIndex = 3;
            //
            // lbMaSV
            //
            lbMaSV.AutoSize = true;
            lbMaSV.Location = new Point(15, 103);
            lbMaSV.Name = "lbMaSV";
            lbMaSV.TabIndex = 4;
            lbMaSV.Text = "Mã sinh viên";
            //
            // cboMaSV
            //
            cboMaSV.FormattingEnabled = true;
            cboMaSV.Location = new Point(130, 100);
            cboMaSV.Name = "cboMaSV";
            cboMaSV.Size = new Size(250, 23);
            cboMaSV.TabIndex = 5;
            //
            // lbHoTen
            //
            lbHoTen.AutoSize = true;
            lbHoTen.Location = new Point(420, 33);
            lbHoTen.Name = "lbHoTen";
            lbHoTen.TabIndex = 6;
            lbHoTen.Text = "Họ tên (*)";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(535, 30);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(320, 23);
            txtHoTen.TabIndex = 7;
            //
            // lbMatKhau
            //
            lbMatKhau.AutoSize = true;
            lbMatKhau.Location = new Point(420, 68);
            lbMatKhau.Name = "lbMatKhau";
            lbMatKhau.TabIndex = 8;
            lbMatKhau.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(535, 65);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(320, 23);
            txtMatKhau.TabIndex = 9;
            //
            // lbTrangThai
            //
            lbTrangThai.AutoSize = true;
            lbTrangThai.Location = new Point(420, 103);
            lbTrangThai.Name = "lbTrangThai";
            lbTrangThai.TabIndex = 10;
            lbTrangThai.Text = "Trạng thái";
            //
            // cboTrangThai
            //
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(535, 100);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(320, 23);
            cboTrangThai.TabIndex = 11;
            //
            // lbGhiChu
            //
            lbGhiChu.ForeColor = SystemColors.GrayText;
            lbGhiChu.Location = new Point(15, 132);
            lbGhiChu.Name = "lbGhiChu";
            lbGhiChu.Size = new Size(840, 20);
            lbGhiChu.TabIndex = 12;
            lbGhiChu.Text = "Mật khẩu: bắt buộc khi thêm (ít nhất 6 ký tự); khi sửa để trống là giữ nguyên mật khẩu cũ. Chọn mã sinh viên thì tên đăng nhập, họ tên, mật khẩu ban đầu tự điền.";
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbTenDangNhap);
            grpThongTin.Controls.Add(txtTenDangNhap);
            grpThongTin.Controls.Add(lbVaiTro);
            grpThongTin.Controls.Add(cboVaiTro);
            grpThongTin.Controls.Add(lbMaSV);
            grpThongTin.Controls.Add(cboMaSV);
            grpThongTin.Controls.Add(lbHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lbMatKhau);
            grpThongTin.Controls.Add(txtMatKhau);
            grpThongTin.Controls.Add(lbTrangThai);
            grpThongTin.Controls.Add(cboTrangThai);
            grpThongTin.Controls.Add(lbGhiChu);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(876, 160);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin tài khoản";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 185);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 185);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 185);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 185);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // btnDatLaiMK
            //
            btnDatLaiMK.Location = new Point(404, 185);
            btnDatLaiMK.Name = "btnDatLaiMK";
            btnDatLaiMK.Size = new Size(130, 32);
            btnDatLaiMK.TabIndex = 5;
            btnDatLaiMK.Text = "Đặt lại mật khẩu";
            btnDatLaiMK.UseVisualStyleBackColor = true;
            //
            // btnTaoHangLoat
            //
            btnTaoHangLoat.Location = new Point(542, 185);
            btnTaoHangLoat.Name = "btnTaoHangLoat";
            btnTaoHangLoat.Size = new Size(250, 32);
            btnTaoHangLoat.TabIndex = 6;
            btnTaoHangLoat.Text = "Tạo tài khoản cho sinh viên chưa có";
            btnTaoHangLoat.UseVisualStyleBackColor = true;
            //
            // lbTimKiem
            //
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(12, 234);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.TabIndex = 7;
            lbTimKiem.Text = "Tìm (tên, họ tên):";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(125, 230);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 23);
            txtTimKiem.TabIndex = 8;
            //
            // btnTim
            //
            btnTim.Location = new Point(335, 227);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(70, 30);
            btnTim.TabIndex = 9;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            //
            // lbLocVaiTro
            //
            lbLocVaiTro.AutoSize = true;
            lbLocVaiTro.Location = new Point(425, 234);
            lbLocVaiTro.Name = "lbLocVaiTro";
            lbLocVaiTro.TabIndex = 10;
            lbLocVaiTro.Text = "Vai trò:";
            //
            // cboLocVaiTro
            //
            cboLocVaiTro.FormattingEnabled = true;
            cboLocVaiTro.Location = new Point(480, 230);
            cboLocVaiTro.Name = "cboLocVaiTro";
            cboLocVaiTro.Size = new Size(150, 23);
            cboLocVaiTro.TabIndex = 11;
            //
            // dgvTaiKhoan
            //
            dgvTaiKhoan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new Point(12, 265);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.Size = new Size(876, 323);
            dgvTaiKhoan.TabIndex = 12;
            //
            // frmTaiKhoan
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(grpThongTin);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDatLaiMK);
            Controls.Add(btnTaoHangLoat);
            Controls.Add(lbTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTim);
            Controls.Add(lbLocVaiTro);
            Controls.Add(cboLocVaiTro);
            Controls.Add(dgvTaiKhoan);
            Name = "frmTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý tài khoản";
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lbVaiTro;
        private ComboBox cboVaiTro;
        private Label lbMaSV;
        private ComboBox cboMaSV;
        private Label lbHoTen;
        private TextBox txtHoTen;
        private Label lbMatKhau;
        private TextBox txtMatKhau;
        private Label lbTrangThai;
        private ComboBox cboTrangThai;
        private Label lbGhiChu;
        private GroupBox grpThongTin;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnDatLaiMK;
        private Button btnTaoHangLoat;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private Label lbLocVaiTro;
        private ComboBox cboLocVaiTro;
        private DataGridView dgvTaiKhoan;
    }
}
