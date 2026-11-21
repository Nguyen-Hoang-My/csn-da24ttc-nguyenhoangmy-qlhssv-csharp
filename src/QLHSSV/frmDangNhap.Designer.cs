namespace QLHSSV
{
    partial class frmDangNhap
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
            lblTieuDe = new Label();
            lbTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lbMatKhau = new Label();
            txtMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(340, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lbTenDangNhap
            //
            lbTenDangNhap.AutoSize = true;
            lbTenDangNhap.Location = new Point(25, 63);
            lbTenDangNhap.Name = "lbTenDangNhap";
            lbTenDangNhap.TabIndex = 1;
            lbTenDangNhap.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(130, 60);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(220, 23);
            txtTenDangNhap.TabIndex = 2;
            //
            // lbMatKhau
            //
            lbMatKhau.AutoSize = true;
            lbMatKhau.Location = new Point(25, 98);
            lbMatKhau.Name = "lbMatKhau";
            lbMatKhau.TabIndex = 3;
            lbMatKhau.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(130, 95);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(220, 23);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;
            //
            // chkHienMatKhau
            //
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(130, 128);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            //
            // btnDangNhap
            //
            btnDangNhap.Location = new Point(130, 165);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(105, 32);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            //
            // btnThoat
            //
            btnThoat.Location = new Point(245, 165);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(105, 32);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            //
            // frmDangNhap
            //
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;
            ClientSize = new Size(380, 220);
            Controls.Add(lblTieuDe);
            Controls.Add(lbTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lbMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(btnThoat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lbTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lbMatKhau;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}