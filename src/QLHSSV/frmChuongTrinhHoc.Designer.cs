namespace QLHSSV
{
    partial class frmChuongTrinhHoc
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
            lbNganh = new Label();
            cboNganh = new ComboBox();
            lblTongKet = new Label();
            lbHocPhan = new Label();
            cboHocPhan = new ComboBox();
            lbHocKyDuKien = new Label();
            cboHocKyDuKien = new ComboBox();
            chkBatBuoc = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvChuongTrinh = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuongTrinh).BeginInit();
            SuspendLayout();
            //
            // lbNganh
            //
            lbNganh.AutoSize = true;
            lbNganh.Location = new Point(12, 16);
            lbNganh.Name = "lbNganh";
            lbNganh.TabIndex = 0;
            lbNganh.Text = "Ngành:";
            //
            // cboNganh
            //
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(70, 12);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(300, 23);
            cboNganh.TabIndex = 1;
            //
            // lblTongKet
            //
            lblTongKet.AutoSize = true;
            lblTongKet.Location = new Point(390, 16);
            lblTongKet.Name = "lblTongKet";
            lblTongKet.TabIndex = 2;
            lblTongKet.Text = "";
            //
            // lbHocPhan
            //
            lbHocPhan.AutoSize = true;
            lbHocPhan.Location = new Point(15, 33);
            lbHocPhan.Name = "lbHocPhan";
            lbHocPhan.TabIndex = 0;
            lbHocPhan.Text = "Học phần (*)";
            //
            // cboHocPhan
            //
            cboHocPhan.FormattingEnabled = true;
            cboHocPhan.Location = new Point(110, 30);
            cboHocPhan.Name = "cboHocPhan";
            cboHocPhan.Size = new Size(380, 23);
            cboHocPhan.TabIndex = 1;
            //
            // lbHocKyDuKien
            //
            lbHocKyDuKien.AutoSize = true;
            lbHocKyDuKien.Location = new Point(510, 33);
            lbHocKyDuKien.Name = "lbHocKyDuKien";
            lbHocKyDuKien.TabIndex = 2;
            lbHocKyDuKien.Text = "Học kỳ dự kiến (*)";
            //
            // cboHocKyDuKien
            //
            cboHocKyDuKien.FormattingEnabled = true;
            cboHocKyDuKien.Location = new Point(625, 30);
            cboHocKyDuKien.Name = "cboHocKyDuKien";
            cboHocKyDuKien.Size = new Size(80, 23);
            cboHocKyDuKien.TabIndex = 3;
            //
            // chkBatBuoc
            //
            chkBatBuoc.AutoSize = true;
            chkBatBuoc.Location = new Point(730, 32);
            chkBatBuoc.Name = "chkBatBuoc";
            chkBatBuoc.TabIndex = 4;
            chkBatBuoc.Text = "Bắt buộc (bỏ tích = tự chọn)";
            chkBatBuoc.UseVisualStyleBackColor = true;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lbHocPhan);
            grpThongTin.Controls.Add(cboHocPhan);
            grpThongTin.Controls.Add(lbHocKyDuKien);
            grpThongTin.Controls.Add(cboHocKyDuKien);
            grpThongTin.Controls.Add(chkBatBuoc);
            grpThongTin.Location = new Point(12, 48);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(976, 75);
            grpThongTin.TabIndex = 3;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Học phần trong chương trình";
            //
            // btnThem
            //
            btnThem.Location = new Point(12, 135);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(110, 135);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(208, 135);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(306, 135);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            //
            // dgvChuongTrinh
            //
            dgvChuongTrinh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChuongTrinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuongTrinh.Location = new Point(12, 180);
            dgvChuongTrinh.Name = "dgvChuongTrinh";
            dgvChuongTrinh.Size = new Size(976, 408);
            dgvChuongTrinh.TabIndex = 8;
            //
            // frmChuongTrinhHoc
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(lbNganh);
            Controls.Add(cboNganh);
            Controls.Add(lblTongKet);
            Controls.Add(grpThongTin);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvChuongTrinh);
            Name = "frmChuongTrinhHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chương trình học của ngành";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuongTrinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNganh;
        private ComboBox cboNganh;
        private Label lblTongKet;
        private Label lbHocPhan;
        private ComboBox cboHocPhan;
        private Label lbHocKyDuKien;
        private ComboBox cboHocKyDuKien;
        private CheckBox chkBatBuoc;
        private GroupBox grpThongTin;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvChuongTrinh;
    }
}
