namespace QLHSSV
{
    partial class frmKhoa
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
            lbMaKhoa = new Label();
            txtMaKhoa = new TextBox();
            lbTenKhoa = new Label();
            txtTenKhoa = new TextBox();
            lbTenTiengAnh = new Label();
            txtTenTiengAnh = new TextBox();
            lbTenVietTat = new Label();
            txtTenVietTat = new TextBox();
            lbLoaiDonVi = new Label();
            cboLoaiDonVi = new ComboBox();
            lbTruongDonVi = new Label();
            txtTruongDonVi = new TextBox();
            lbSDT = new Label();
            txtSDT = new TextBox();
            lbSoNoiBo = new Label();
            txtSoNoiBo = new TextBox();
            lbEmail = new Label();
            txtEmail = new TextBox();
            lbWebsite = new Label();
            txtWebsite = new TextBox();
            lbDiaChi = new Label();
            txtDiaChi = new TextBox();
            lbMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvKhoa = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lbMaKhoa);
            grpThongTin.Controls.Add(txtMaKhoa);
            grpThongTin.Controls.Add(lbTenKhoa);
            grpThongTin.Controls.Add(txtTenKhoa);
            grpThongTin.Controls.Add(lbTenTiengAnh);
            grpThongTin.Controls.Add(txtTenTiengAnh);
            grpThongTin.Controls.Add(lbTenVietTat);
            grpThongTin.Controls.Add(txtTenVietTat);
            grpThongTin.Controls.Add(lbLoaiDonVi);
            grpThongTin.Controls.Add(cboLoaiDonVi);
            grpThongTin.Controls.Add(lbTruongDonVi);
            grpThongTin.Controls.Add(txtTruongDonVi);
            grpThongTin.Controls.Add(lbSDT);
            grpThongTin.Controls.Add(txtSDT);
            grpThongTin.Controls.Add(lbSoNoiBo);
            grpThongTin.Controls.Add(txtSoNoiBo);
            grpThongTin.Controls.Add(lbEmail);
            grpThongTin.Controls.Add(txtEmail);
            grpThongTin.Controls.Add(lbWebsite);
            grpThongTin.Controls.Add(txtWebsite);
            grpThongTin.Controls.Add(lbDiaChi);
            grpThongTin.Controls.Add(txtDiaChi);
            grpThongTin.Controls.Add(lbMoTa);
            grpThongTin.Controls.Add(txtMoTa);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 255);
            grpThongTin.TabIndex = 24;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khoa";
            // 
            // lbMaKhoa
            // 
            lbMaKhoa.AutoSize = true;
            lbMaKhoa.Location = new Point(15, 33);
            lbMaKhoa.Name = "lbMaKhoa";
            lbMaKhoa.Size = new Size(69, 15);
            lbMaKhoa.TabIndex = 0;
            lbMaKhoa.Text = "Mã khoa (*)";
            
            // 
            // txtMaKhoa
            // 
            txtMaKhoa.Location = new Point(130, 30);
            txtMaKhoa.Name = "txtMaKhoa";
            txtMaKhoa.Size = new Size(270, 23);
            txtMaKhoa.TabIndex = 1;
            // 
            // lbTenKhoa
            // 
            lbTenKhoa.AutoSize = true;
            lbTenKhoa.Location = new Point(15, 68);
            lbTenKhoa.Name = "lbTenKhoa";
            lbTenKhoa.Size = new Size(71, 15);
            lbTenKhoa.TabIndex = 2;
            lbTenKhoa.Text = "Tên khoa (*)";
            // 
            // txtTenKhoa
            // 
            txtTenKhoa.Location = new Point(130, 65);
            txtTenKhoa.Name = "txtTenKhoa";
            txtTenKhoa.Size = new Size(270, 23);
            txtTenKhoa.TabIndex = 3;
            // 
            // lbTenTiengAnh
            // 
            lbTenTiengAnh.AutoSize = true;
            lbTenTiengAnh.Location = new Point(15, 103);
            lbTenTiengAnh.Name = "lbTenTiengAnh";
            lbTenTiengAnh.Size = new Size(81, 15);
            lbTenTiengAnh.TabIndex = 4;
            lbTenTiengAnh.Text = "Tên tiếng Anh";
            // 
            // txtTenTiengAnh
            // 
            txtTenTiengAnh.Location = new Point(130, 100);
            txtTenTiengAnh.Name = "txtTenTiengAnh";
            txtTenTiengAnh.Size = new Size(270, 23);
            txtTenTiengAnh.TabIndex = 5;
            // 
            // lbTenVietTat
            // 
            lbTenVietTat.AutoSize = true;
            lbTenVietTat.Location = new Point(15, 138);
            lbTenVietTat.Name = "lbTenVietTat";
            lbTenVietTat.Size = new Size(65, 15);
            lbTenVietTat.TabIndex = 6;
            lbTenVietTat.Text = "Tên viết tắt";
            // 
            // txtTenVietTat
            // 
            txtTenVietTat.Location = new Point(130, 135);
            txtTenVietTat.Name = "txtTenVietTat";
            txtTenVietTat.Size = new Size(270, 23);
            txtTenVietTat.TabIndex = 7;
            // 
            // lbLoaiDonVi
            // 
            lbLoaiDonVi.AutoSize = true;
            lbLoaiDonVi.Location = new Point(15, 173);
            lbLoaiDonVi.Name = "lbLoaiDonVi";
            lbLoaiDonVi.Size = new Size(81, 15);
            lbLoaiDonVi.TabIndex = 8;
            lbLoaiDonVi.Text = "Loại đơn vị (*)";
            // 
            // cboLoaiDonVi
            // 
            cboLoaiDonVi.Location = new Point(130, 170);
            cboLoaiDonVi.Name = "cboLoaiDonVi";
            cboLoaiDonVi.Size = new Size(270, 23);
            cboLoaiDonVi.TabIndex = 9;
            // 
            // lbTruongDonVi
            // 
            lbTruongDonVi.AutoSize = true;
            lbTruongDonVi.Location = new Point(15, 208);
            lbTruongDonVi.Name = "lbTruongDonVi";
            lbTruongDonVi.Size = new Size(81, 15);
            lbTruongDonVi.TabIndex = 10;
            lbTruongDonVi.Text = "Trưởng đơn vị";
            // 
            // txtTruongDonVi
            // 
            txtTruongDonVi.Location = new Point(130, 205);
            txtTruongDonVi.Name = "txtTruongDonVi";
            txtTruongDonVi.Size = new Size(270, 23);
            txtTruongDonVi.TabIndex = 11;
            // 
            // lbSDT
            // 
            lbSDT.AutoSize = true;
            lbSDT.Location = new Point(430, 33);
            lbSDT.Name = "lbSDT";
            lbSDT.Size = new Size(61, 15);
            lbSDT.TabIndex = 12;
            lbSDT.Text = "Điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(540, 30);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 23);
            txtSDT.TabIndex = 13;
            // 
            // lbSoNoiBo
            // 
            lbSoNoiBo.AutoSize = true;
            lbSoNoiBo.Location = new Point(430, 68);
            lbSoNoiBo.Name = "lbSoNoiBo";
            lbSoNoiBo.Size = new Size(57, 15);
            lbSoNoiBo.TabIndex = 14;
            lbSoNoiBo.Text = "Số nội bộ";
            // 
            // txtSoNoiBo
            // 
            txtSoNoiBo.Location = new Point(540, 65);
            txtSoNoiBo.Name = "txtSoNoiBo";
            txtSoNoiBo.Size = new Size(300, 23);
            txtSoNoiBo.TabIndex = 15;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(430, 103);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(36, 15);
            lbEmail.TabIndex = 16;
            lbEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(540, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 17;
            // 
            // lbWebsite
            // 
            lbWebsite.AutoSize = true;
            lbWebsite.Location = new Point(430, 138);
            lbWebsite.Name = "lbWebsite";
            lbWebsite.Size = new Size(49, 15);
            lbWebsite.TabIndex = 18;
            lbWebsite.Text = "Website";
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(540, 135);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(300, 23);
            txtWebsite.TabIndex = 19;
            // 
            // lbDiaChi
            // 
            lbDiaChi.AutoSize = true;
            lbDiaChi.Location = new Point(430, 173);
            lbDiaChi.Name = "lbDiaChi";
            lbDiaChi.Size = new Size(43, 15);
            lbDiaChi.TabIndex = 20;
            lbDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(540, 170);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(300, 23);
            txtDiaChi.TabIndex = 21;
            // 
            // lbMoTa
            // 
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(430, 208);
            lbMoTa.Name = "lbMoTa";
            lbMoTa.Size = new Size(38, 15);
            lbMoTa.TabIndex = 22;
            lbMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(540, 205);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(300, 40);
            txtMoTa.TabIndex = 23;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 280);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 25;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(110, 280);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 26;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(208, 280);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 27;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(306, 280);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 28;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lbTimKiem
            // 
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(520, 287);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.Size = new Size(81, 15);
            lbTimKiem.TabIndex = 29;
            lbTimKiem.Text = "Tìm (mã/tên):";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(620, 284);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(160, 23);
            txtTimKiem.TabIndex = 30;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(790, 280);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(78, 32);
            btnTim.TabIndex = 31;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // dgvKhoa
            // 
            dgvKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoa.Location = new Point(12, 325);
            dgvKhoa.Name = "dgvKhoa";
            dgvKhoa.Size = new Size(856, 263);
            dgvKhoa.TabIndex = 32;
            // 
            // frmKhoa
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
            Controls.Add(dgvKhoa);
            Name = "frmKhoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khoa";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbMaKhoa;
        private TextBox txtMaKhoa;
        private Label lbTenKhoa;
        private TextBox txtTenKhoa;
        private Label lbTenTiengAnh;
        private TextBox txtTenTiengAnh;
        private Label lbTenVietTat;
        private TextBox txtTenVietTat;
        private Label lbLoaiDonVi;
        private ComboBox cboLoaiDonVi;
        private Label lbTruongDonVi;
        private TextBox txtTruongDonVi;
        private Label lbSDT;
        private TextBox txtSDT;
        private Label lbSoNoiBo;
        private TextBox txtSoNoiBo;
        private Label lbEmail;
        private TextBox txtEmail;
        private Label lbWebsite;
        private TextBox txtWebsite;
        private Label lbDiaChi;
        private TextBox txtDiaChi;
        private Label lbMoTa;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvKhoa;
    }
}