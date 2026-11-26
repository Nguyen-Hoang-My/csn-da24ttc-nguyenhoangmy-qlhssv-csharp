namespace QLHSSV
{
    partial class frmDangKyHoc
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
            lbTimSV = new Label();
            txtTimSV = new TextBox();
            btnTimSV = new Button();
            dgvSinhVien = new DataGridView();
            lblSinhVien = new Label();
            lbCoThe = new Label();
            dgvCoThe = new DataGridView();
            btnDangKy = new Button();
            btnHuyDangKy = new Button();
            lblTongTC = new Label();
            lbDaDangKy = new Label();
            dgvDaDangKy = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCoThe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDaDangKy).BeginInit();
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
            cboHocKy.Size = new Size(300, 23);
            cboHocKy.TabIndex = 1;
            //
            // lbTimSV
            //
            lbTimSV.AutoSize = true;
            lbTimSV.Location = new Point(400, 16);
            lbTimSV.Name = "lbTimSV";
            lbTimSV.TabIndex = 2;
            lbTimSV.Text = "Tìm sinh viên (mã, tên):";
            //
            // txtTimSV
            //
            txtTimSV.Location = new Point(545, 12);
            txtTimSV.Name = "txtTimSV";
            txtTimSV.Size = new Size(200, 23);
            txtTimSV.TabIndex = 3;
            //
            // btnTimSV
            //
            btnTimSV.Location = new Point(755, 9);
            btnTimSV.Name = "btnTimSV";
            btnTimSV.Size = new Size(80, 30);
            btnTimSV.TabIndex = 4;
            btnTimSV.Text = "Tìm";
            btnTimSV.UseVisualStyleBackColor = true;
            //
            // dgvSinhVien
            //
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(12, 50);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.Size = new Size(420, 583);
            dgvSinhVien.TabIndex = 5;
            //
            // lblSinhVien
            //
            lblSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSinhVien.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSinhVien.Location = new Point(445, 50);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(643, 40);
            lblSinhVien.TabIndex = 6;
            lblSinhVien.Text = "Chọn một sinh viên ở danh sách bên trái.";
            //
            // lbCoThe
            //
            lbCoThe.AutoSize = true;
            lbCoThe.Location = new Point(445, 95);
            lbCoThe.Name = "lbCoThe";
            lbCoThe.TabIndex = 7;
            lbCoThe.Text = "Học phần trong chương trình học chưa đăng ký ở học kỳ này (chọn được nhiều dòng):";
            //
            // dgvCoThe
            //
            dgvCoThe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCoThe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCoThe.Location = new Point(445, 115);
            dgvCoThe.Name = "dgvCoThe";
            dgvCoThe.Size = new Size(643, 215);
            dgvCoThe.TabIndex = 8;
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(445, 338);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 32);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "Đăng ký ▼";
            btnDangKy.UseVisualStyleBackColor = true;
            //
            // btnHuyDangKy
            //
            btnHuyDangKy.Location = new Point(605, 338);
            btnHuyDangKy.Name = "btnHuyDangKy";
            btnHuyDangKy.Size = new Size(150, 32);
            btnHuyDangKy.TabIndex = 10;
            btnHuyDangKy.Text = "▲ Hủy đăng ký";
            btnHuyDangKy.UseVisualStyleBackColor = true;
            //
            // lblTongTC
            //
            lblTongTC.AutoSize = true;
            lblTongTC.Location = new Point(770, 346);
            lblTongTC.Name = "lblTongTC";
            lblTongTC.TabIndex = 11;
            lblTongTC.Text = "";
            //
            // lbDaDangKy
            //
            lbDaDangKy.AutoSize = true;
            lbDaDangKy.Location = new Point(445, 380);
            lbDaDangKy.Name = "lbDaDangKy";
            lbDaDangKy.TabIndex = 12;
            lbDaDangKy.Text = "Học phần đã đăng ký trong học kỳ:";
            //
            // dgvDaDangKy
            //
            dgvDaDangKy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDaDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDaDangKy.Location = new Point(445, 400);
            dgvDaDangKy.Name = "dgvDaDangKy";
            dgvDaDangKy.Size = new Size(643, 233);
            dgvDaDangKy.TabIndex = 13;
            //
            // frmDangKyHoc
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 645);
            Controls.Add(lbHocKy);
            Controls.Add(cboHocKy);
            Controls.Add(lbTimSV);
            Controls.Add(txtTimSV);
            Controls.Add(btnTimSV);
            Controls.Add(dgvSinhVien);
            Controls.Add(lblSinhVien);
            Controls.Add(lbCoThe);
            Controls.Add(dgvCoThe);
            Controls.Add(btnDangKy);
            Controls.Add(btnHuyDangKy);
            Controls.Add(lblTongTC);
            Controls.Add(lbDaDangKy);
            Controls.Add(dgvDaDangKy);
            Name = "frmDangKyHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký học theo học kỳ";
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCoThe).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDaDangKy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbHocKy;
        private ComboBox cboHocKy;
        private Label lbTimSV;
        private TextBox txtTimSV;
        private Button btnTimSV;
        private DataGridView dgvSinhVien;
        private Label lblSinhVien;
        private Label lbCoThe;
        private DataGridView dgvCoThe;
        private Button btnDangKy;
        private Button btnHuyDangKy;
        private Label lblTongTC;
        private Label lbDaDangKy;
        private DataGridView dgvDaDangKy;
    }
}
