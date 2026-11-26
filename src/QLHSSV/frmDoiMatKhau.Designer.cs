namespace QLHSSV
{
    partial class frmDoiMatKhau
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
            lblTaiKhoan = new Label();
            lbMatKhauCu = new Label();
            txtMatKhauCu = new TextBox();
            lbMatKhauMoi = new Label();
            txtMatKhauMoi = new TextBox();
            lbNhapLai = new Label();
            txtNhapLai = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDoi = new Button();
            btnHuy = new Button();

            SuspendLayout();
            //
            // lblTaiKhoan
            //
            lblTaiKhoan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(25, 15);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "";
            //
            // lbMatKhauCu
            //
            lbMatKhauCu.AutoSize = true;
            lbMatKhauCu.Location = new Point(25, 53);
            lbMatKhauCu.Name = "lbMatKhauCu";
            lbMatKhauCu.TabIndex = 1;
            lbMatKhauCu.Text = "Mật khẩu cũ";
            //
            // txtMatKhauCu
            //
            txtMatKhauCu.Location = new Point(150, 50);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(200, 23);
            txtMatKhauCu.TabIndex = 2;
            txtMatKhauCu.UseSystemPasswordChar = true;
            //
            // lbMatKhauMoi
            //
            lbMatKhauMoi.AutoSize = true;
            lbMatKhauMoi.Location = new Point(25, 88);
            lbMatKhauMoi.Name = "lbMatKhauMoi";
            lbMatKhauMoi.TabIndex = 3;
            lbMatKhauMoi.Text = "Mật khẩu mới";
            //
            // txtMatKhauMoi
            //
            txtMatKhauMoi.Location = new Point(150, 85);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(200, 23);
            txtMatKhauMoi.TabIndex = 4;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            //
            // lbNhapLai
            //
            lbNhapLai.AutoSize = true;
            lbNhapLai.Location = new Point(25, 123);
            lbNhapLai.Name = "lbNhapLai";
            lbNhapLai.TabIndex = 5;
            lbNhapLai.Text = "Nhập lại mật khẩu";
            //
            // txtNhapLai
            //
            txtNhapLai.Location = new Point(150, 120);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(200, 23);
            txtNhapLai.TabIndex = 6;
            txtNhapLai.UseSystemPasswordChar = true;
            //
            // chkHienMatKhau
            //
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(150, 153);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 7;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            //
            // btnDoi
            //
            btnDoi.Location = new Point(150, 190);
            btnDoi.Name = "btnDoi";
            btnDoi.Size = new Size(95, 32);
            btnDoi.TabIndex = 8;
            btnDoi.Text = "Đổi mật khẩu";
            btnDoi.UseVisualStyleBackColor = true;
            //
            // btnHuy
            //
            btnHuy.Location = new Point(255, 190);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 32);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            //
            // frmDoiMatKhau
            //
            AcceptButton = btnDoi;
            CancelButton = btnHuy;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 250);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lbMatKhauCu);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lbMatKhauMoi);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lbNhapLai);
            Controls.Add(txtNhapLai);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDoi);
            Controls.Add(btnHuy);
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaiKhoan;
        private Label lbMatKhauCu;
        private TextBox txtMatKhauCu;
        private Label lbMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Label lbNhapLai;
        private TextBox txtNhapLai;
        private CheckBox chkHienMatKhau;
        private Button btnDoi;
        private Button btnHuy;
    }
}
