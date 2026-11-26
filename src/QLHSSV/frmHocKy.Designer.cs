namespace QLHSSV
{
    partial class frmHocKy
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
            lbNamHoc = new Label();
            txtNamHoc = new TextBox();
            lbHocKySo = new Label();
            cboHocKySo = new ComboBox();
            lbMaHocKy = new Label();
            txtMaHocKy = new TextBox();
            lbTenHocKy = new Label();
            txtTenHocKy = new TextBox();
            lbNgayBatDau = new Label();
            dtpNgayBatDau = new DateTimePicker();
            lbNgayKetThuc = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvHocKy = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).BeginInit();
            SuspendLayout();
            //
            // lbNamHoc
            //
            lbNamHoc.AutoSize = true;
            lbNamHoc.Location = new Point(15, 33);
            lbNamHoc.Name = "lbNamHoc";
            lbNamHoc.TabIndex = 0;
            lbNamHoc.Text = "Năm học (*)";
            //
            // txtNamHoc
            //
            txtNamHoc.Location = new Point(130, 30);
            txtNamHoc.Name = "txtNamHoc";
            txtNamHoc.Size = new Size(270, 23);
            txtNamHoc.TabIndex = 1;
            //
            // lbHocKySo
            //
            lbHocKySo.AutoSize = true;
            lbHocKySo.Location = new Point(15, 68);
            lbHocKySo.Name = "lbHocKySo";
            lbHocKySo.TabIndex = 2;
            lbHocKySo.Text = "Học kỳ (*)";
            //
            // cboHocKySo
            //
            cboHocKySo.Location = new Point(130, 65);
            cboHocKySo.Name = "cboHocKySo";
            cboHocKySo.Size = new Size(270, 23);
            cboHocKySo.TabIndex = 3;
            //
            // lbMaHocKy
            //
            lbMaHocKy.AutoSize = true;
            lbMaHocKy.Location = new Point(15, 103);
            lbMaHocKy.Name = "lbMaHocKy";
            lbMaHocKy.TabIndex = 4;
            lbMaHocKy.Text = "Mã học kỳ (*)";
            //
            // txtMaHocKy
            //
            txtMaHocKy.Location = new Point(130, 100);
            txtMaHocKy.Name = "txtMaHocKy";
            txtMaHocKy.Size = new Size(270, 23);
            txtMaHocKy.TabIndex = 5;
            //
            // lbTenHocKy
            //
            lbTenHocKy.AutoSize = true;
            lbTenHocKy.Location = new Point(430, 33);
            lbTenHocKy.Name = "lbTenHocKy";
            lbTenHocKy.TabIndex = 6;
            lbTenHocKy.Text = "Tên học kỳ (*)";
            //
            // txtTenHocKy
            //
            txtTenHocKy.Location = new Point(540, 30);
            txtTenHocKy.Name = "txtTenHocKy";
            txtTenHocKy.Size = new Size(300, 23);
            txtTenHocKy.TabIndex = 7;
            //
            // lbNgayBatDau
            //
            lbNgayBatDau.AutoSize = true;
            lbNgayBatDau.Location = new Point(430, 68);
            lbNgayBatDau.Name = "lbNgayBatDau";
            lbNgayBatDau.TabIndex = 8;
            lbNgayBatDau.Text = "Ngày bắt đầu (*)";
            //
            // dtpNgayBatDau
            //
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.Location = new Point(540, 65);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(300, 23);
            dtpNgayBatDau.TabIndex = 9;
            //
            // lbNgayKetThuc
            //
            lbNgayKetThuc.AutoSize = true;
            lbNgayKetThuc.Location = new Point(430, 103);
            lbNgayKetThuc.Name = "lbNgayKetThuc";
            lbNgayKetThuc.TabIndex = 10;
            lbNgayKetThuc.Text = "Ngày kết thúc (*)";
            //
            // dtpNgayKetThuc
            //
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.Location = new Point(540, 100);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(300, 23);
            dtpNgayKetThuc.TabIndex = 11;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbNamHoc);
            grpThongTin.Controls.Add(txtNamHoc);
            grpThongTin.Controls.Add(lbHocKySo);
            grpThongTin.Controls.Add(cboHocKySo);
            grpThongTin.Controls.Add(lbMaHocKy);
            grpThongTin.Controls.Add(txtMaHocKy);
            grpThongTin.Controls.Add(lbTenHocKy);
            grpThongTin.Controls.Add(txtTenHocKy);
            grpThongTin.Controls.Add(lbNgayBatDau);
            grpThongTin.Controls.Add(dtpNgayBatDau);
            grpThongTin.Controls.Add(lbNgayKetThuc);
            grpThongTin.Controls.Add(dtpNgayKetThuc);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 150);
            grpThongTin.TabIndex = 12;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin học kỳ";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 175);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 175);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 175);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 175);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // lbTimKiem
            //
            lbTimKiem.AutoSize = true;
            lbTimKiem.Location = new Point(520, 182);
            lbTimKiem.Name = "lbTimKiem";
            lbTimKiem.TabIndex = 17;
            lbTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(620, 179);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(160, 23);
            txtTimKiem.TabIndex = 18;
            //
            // btnTim
            //
            btnTim.Location = new Point(790, 175);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(78, 32);
            btnTim.TabIndex = 19;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            //
            // dgvHocKy
            //
            dgvHocKy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHocKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocKy.Location = new Point(12, 220);
            dgvHocKy.Name = "dgvHocKy";
            dgvHocKy.Size = new Size(856, 368);
            dgvHocKy.TabIndex = 20;
            //
            // frmHocKy
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
            Controls.Add(dgvHocKy);
            Name = "frmHocKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý học kỳ";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbNamHoc;
        private TextBox txtNamHoc;
        private Label lbHocKySo;
        private ComboBox cboHocKySo;
        private Label lbMaHocKy;
        private TextBox txtMaHocKy;
        private Label lbTenHocKy;
        private TextBox txtTenHocKy;
        private Label lbNgayBatDau;
        private DateTimePicker dtpNgayBatDau;
        private Label lbNgayKetThuc;
        private DateTimePicker dtpNgayKetThuc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvHocKy;
    }
}
