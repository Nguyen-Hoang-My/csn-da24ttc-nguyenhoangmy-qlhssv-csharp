namespace QLHSSV
{
    partial class frmKhoaHoc
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
            lbMaKhoaHoc = new Label();
            txtMaKhoaHoc = new TextBox();
            lbTenKhoaHoc = new Label();
            txtTenKhoaHoc = new TextBox();
            lbNamBatDau = new Label();
            txtNamBatDau = new TextBox();
            lbNamKetThuc = new Label();
            txtNamKetThuc = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lbTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvKhoaHoc = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHoc).BeginInit();
            SuspendLayout();
            //
            // lbMaKhoaHoc
            //
            lbMaKhoaHoc.AutoSize = true;
            lbMaKhoaHoc.Location = new Point(15, 33);
            lbMaKhoaHoc.Name = "lbMaKhoaHoc";
            lbMaKhoaHoc.TabIndex = 0;
            lbMaKhoaHoc.Text = "Mã khóa học (*)";
            //
            // txtMaKhoaHoc
            //
            txtMaKhoaHoc.Location = new Point(130, 30);
            txtMaKhoaHoc.Name = "txtMaKhoaHoc";
            txtMaKhoaHoc.Size = new Size(270, 23);
            txtMaKhoaHoc.TabIndex = 1;
            //
            // lbTenKhoaHoc
            //
            lbTenKhoaHoc.AutoSize = true;
            lbTenKhoaHoc.Location = new Point(15, 68);
            lbTenKhoaHoc.Name = "lbTenKhoaHoc";
            lbTenKhoaHoc.TabIndex = 2;
            lbTenKhoaHoc.Text = "Tên khóa học (*)";
            //
            // txtTenKhoaHoc
            //
            txtTenKhoaHoc.Location = new Point(130, 65);
            txtTenKhoaHoc.Name = "txtTenKhoaHoc";
            txtTenKhoaHoc.Size = new Size(270, 23);
            txtTenKhoaHoc.TabIndex = 3;
            //
            // lbNamBatDau
            //
            lbNamBatDau.AutoSize = true;
            lbNamBatDau.Location = new Point(430, 33);
            lbNamBatDau.Name = "lbNamBatDau";
            lbNamBatDau.TabIndex = 4;
            lbNamBatDau.Text = "Năm bắt đầu (*)";
            //
            // txtNamBatDau
            //
            txtNamBatDau.Location = new Point(540, 30);
            txtNamBatDau.Name = "txtNamBatDau";
            txtNamBatDau.Size = new Size(300, 23);
            txtNamBatDau.TabIndex = 5;
            //
            // lbNamKetThuc
            //
            lbNamKetThuc.AutoSize = true;
            lbNamKetThuc.Location = new Point(430, 68);
            lbNamKetThuc.Name = "lbNamKetThuc";
            lbNamKetThuc.TabIndex = 6;
            lbNamKetThuc.Text = "Năm kết thúc (*)";
            //
            // txtNamKetThuc
            //
            txtNamKetThuc.Location = new Point(540, 65);
            txtNamKetThuc.Name = "txtNamKetThuc";
            txtNamKetThuc.Size = new Size(300, 23);
            txtNamKetThuc.TabIndex = 7;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbMaKhoaHoc);
            grpThongTin.Controls.Add(txtMaKhoaHoc);
            grpThongTin.Controls.Add(lbTenKhoaHoc);
            grpThongTin.Controls.Add(txtTenKhoaHoc);
            grpThongTin.Controls.Add(lbNamBatDau);
            grpThongTin.Controls.Add(txtNamBatDau);
            grpThongTin.Controls.Add(lbNamKetThuc);
            grpThongTin.Controls.Add(txtNamKetThuc);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(856, 115);
            grpThongTin.TabIndex = 8;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khóa học";
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
            // dgvKhoaHoc
            //
            dgvKhoaHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhoaHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoaHoc.Location = new Point(12, 185);
            dgvKhoaHoc.Name = "dgvKhoaHoc";
            dgvKhoaHoc.Size = new Size(856, 403);
            dgvKhoaHoc.TabIndex = 16;
            //
            // frmKhoaHoc
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
            Controls.Add(dgvKhoaHoc);
            Name = "frmKhoaHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khóa học";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoaHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lbMaKhoaHoc;
        private TextBox txtMaKhoaHoc;
        private Label lbTenKhoaHoc;
        private TextBox txtTenKhoaHoc;
        private Label lbNamBatDau;
        private TextBox txtNamBatDau;
        private Label lbNamKetThuc;
        private TextBox txtNamKetThuc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lbTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvKhoaHoc;
    }
}