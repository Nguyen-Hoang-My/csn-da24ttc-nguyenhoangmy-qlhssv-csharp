namespace QLHSSV
{
    partial class frmBoMon
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
            lbMaBoMon = new Label();
            txtMaBoMon = new TextBox();
            lbTenBoMon = new Label();
            txtTenBoMon = new TextBox();
            lbKhoa = new Label();
            cboKhoa = new ComboBox();
            lbTruongBoMon = new Label();
            txtTruongBoMon = new TextBox();
            lbEmail = new Label();
            txtEmail = new TextBox();
            lbSoNoiBo = new Label();
            txtSoNoiBo = new TextBox();
            lbTrangThongTin = new Label();
            txtTrangThongTin = new TextBox();
            lbMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvBoMon = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBoMon).BeginInit();
            SuspendLayout();
            //
            // lbMaBoMon
            //
            lbMaBoMon.AutoSize = true;
            lbMaBoMon.Location = new Point(15, 33);
            lbMaBoMon.Name = "lbMaBoMon";
            lbMaBoMon.TabIndex = 0;
            lbMaBoMon.Text = "Mã bộ môn (*)";
            //
            // txtMaBoMon
            //
            txtMaBoMon.Location = new Point(130, 30);
            txtMaBoMon.Name = "txtMaBoMon";
            txtMaBoMon.Size = new Size(270, 23);
            txtMaBoMon.TabIndex = 1;
            //
            // lbTenBoMon
            //
            lbTenBoMon.AutoSize = true;
            lbTenBoMon.Location = new Point(15, 68);
            lbTenBoMon.Name = "lbTenBoMon";
            lbTenBoMon.TabIndex = 2;
            lbTenBoMon.Text = "Tên bộ môn (*)";
            //
            // txtTenBoMon
            //
            txtTenBoMon.Location = new Point(130, 65);
            txtTenBoMon.Name = "txtTenBoMon";
            txtTenBoMon.Size = new Size(270, 23);
            txtTenBoMon.TabIndex = 3;
            //
            // lbKhoa
            //
            lbKhoa.AutoSize = true;
            lbKhoa.Location = new Point(15, 103);
            lbKhoa.Name = "lbKhoa";
            lbKhoa.TabIndex = 4;
            lbKhoa.Text = "Thuộc khoa (*)";
            //
            // cboKhoa
            //
            cboKhoa.Location = new Point(130, 100);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(270, 23);
            cboKhoa.TabIndex = 5;
            //
            // lbTruongBoMon
            //
            lbTruongBoMon.AutoSize = true;
            lbTruongBoMon.Location = new Point(15, 138);
            lbTruongBoMon.Name = "lbTruongBoMon";
            lbTruongBoMon.TabIndex = 6;
            lbTruongBoMon.Text = "Trưởng bộ môn";
            //
            // txtTruongBoMon
            //
            txtTruongBoMon.Location = new Point(130, 135);
            txtTruongBoMon.Name = "txtTruongBoMon";
            txtTruongBoMon.Size = new Size(270, 23);
            txtTruongBoMon.TabIndex = 7;
            //
            // lbEmail
            //
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(430, 33);
            lbEmail.Name = "lbEmail";
            lbEmail.TabIndex = 8;
            lbEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(540, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 9;
            //
            // lbSoNoiBo
            //
            lbSoNoiBo.AutoSize = true;
            lbSoNoiBo.Location = new Point(430, 68);
            lbSoNoiBo.Name = "lbSoNoiBo";
            lbSoNoiBo.TabIndex = 10;
            lbSoNoiBo.Text = "Số nội bộ";
            //
            // txtSoNoiBo
            //
            txtSoNoiBo.Location = new Point(540, 65);
            txtSoNoiBo.Name = "txtSoNoiBo";
            txtSoNoiBo.Size = new Size(300, 23);
            txtSoNoiBo.TabIndex = 11;
            //
            // lbTrangThongTin
            //
            lbTrangThongTin.AutoSize = true;
            lbTrangThongTin.Location = new Point(430, 103);
            lbTrangThongTin.Name = "lbTrangThongTin";
            lbTrangThongTin.TabIndex = 12;
            lbTrangThongTin.Text = "Trang thông tin";
            //
            // txtTrangThongTin
            //
            txtTrangThongTin.Location = new Point(540, 100);
            txtTrangThongTin.Name = "txtTrangThongTin";
            txtTrangThongTin.Size = new Size(300, 23);
            txtTrangThongTin.TabIndex = 13;
            //
            // lbMoTa
            //
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(430, 138);
            lbMoTa.Name = "lbMoTa";
            lbMoTa.TabIndex = 14;
            lbMoTa.Text = "Mô tả";
            //
            // txtMoTa
            //
            txtMoTa.Multiline = true;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Location = new Point(540, 135);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(300, 40);
            txtMoTa.TabIndex = 15;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbMaBoMon);
            grpThongTin.Controls.Add(txtMaBoMon);
            grpThongTin.Controls.Add(lbTenBoMon);
            grpThongTin.Controls.Add(txtTenBoMon);
            grpThongTin.Controls.Add(lbKhoa);
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Controls.Add(lbTruongBoMon);
            grpThongTin.Controls.Add(txtTruongBoMon);
            grpThongTin.Controls.Add(lbEmail);
            grpThongTin.Controls.Add(txtEmail);
            grpThongTin.Controls.Add(lbSoNoiBo);
            grpThongTin.Controls.Add(txtSoNoiBo);
            grpThongTin.Controls.Add(lbTrangThongTin);
            grpThongTin.Controls.Add(txtTrangThongTin);
            grpThongTin.Controls.Add(lbMoTa);
            grpThongTin.Controls.Add(txtMoTa);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 185);
            grpThongTin.TabIndex = 16;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin bộ môn";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 210);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 210);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 210);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 210);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 20;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // lbTimKiem
            //
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(520, 217);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.TabIndex = 21;
            lbTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(620, 214);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(160, 23);
            txtTimKiem.TabIndex = 22;
            //
            // btnTim
            //
            btnTim.Location = new Point(790, 210);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(78, 32);
            btnTim.TabIndex = 23;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            //
            // dgvBoMon
            //
            dgvBoMon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBoMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBoMon.Location = new Point(12, 255);
            dgvBoMon.Name = "dgvBoMon";
            dgvBoMon.Size = new Size(856, 333);
            dgvBoMon.TabIndex = 24;
            //
            // frmBoMon
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
            Controls.Add(dgvBoMon);
            Name = "frmBoMon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý bộ môn";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBoMon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbMaBoMon;
        private TextBox txtMaBoMon;
        private Label lbTenBoMon;
        private TextBox txtTenBoMon;
        private Label lbKhoa;
        private ComboBox cboKhoa;
        private Label lbTruongBoMon;
        private TextBox txtTruongBoMon;
        private Label lbEmail;
        private TextBox txtEmail;
        private Label lbSoNoiBo;
        private TextBox txtSoNoiBo;
        private Label lbTrangThongTin;
        private TextBox txtTrangThongTin;
        private Label lbMoTa;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvBoMon;
    }
}