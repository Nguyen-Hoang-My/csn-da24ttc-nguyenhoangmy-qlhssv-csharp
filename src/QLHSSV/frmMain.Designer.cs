namespace QLHSSV
{
    partial class frmMain
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
            menuChinh = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuTaiKhoan = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuNgan2 = new ToolStripSeparator();
            mnuDangXuat = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuKhoa = new ToolStripMenuItem();
            mnuBoMon = new ToolStripMenuItem();
            mnuNganh = new ToolStripMenuItem();
            mnuKhoaHoc = new ToolStripMenuItem();
            mnuNgan1 = new ToolStripSeparator();
            mnuHocPhan = new ToolStripMenuItem();
            mnuChuongTrinh = new ToolStripMenuItem();
            mnuHocKy = new ToolStripMenuItem();
            mnuSinhVien = new ToolStripMenuItem();
            mnuHoSoSV = new ToolStripMenuItem();
            mnuDangKyHoc = new ToolStripMenuItem();
            mnuNhapDiem = new ToolStripMenuItem();
            mnuBangDiem = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            statusChinh = new StatusStrip();
            lblNguoiDung = new ToolStripStatusLabel();
            lblTieuDe = new Label();
            menuChinh.SuspendLayout();
            statusChinh.SuspendLayout();
            SuspendLayout();
            //
            // menuChinh
            //
            menuChinh.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuSinhVien });
            menuChinh.Location = new Point(0, 0);
            menuChinh.Name = "menuChinh";
            menuChinh.Size = new Size(900, 24);
            menuChinh.TabIndex = 0;
            menuChinh.Text = "menuChinh";
            //
            // mnuHeThong
            //
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuTaiKhoan, mnuDoiMatKhau, mnuNgan2, mnuDangXuat, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(75, 20);
            mnuHeThong.Text = "Hệ thống";
            //
            // mnuTaiKhoan
            //
            mnuTaiKhoan.Name = "mnuTaiKhoan";
            mnuTaiKhoan.Size = new Size(180, 22);
            mnuTaiKhoan.Text = "Quản lý tài khoản";
            //
            // mnuDoiMatKhau
            //
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(180, 22);
            mnuDoiMatKhau.Text = "Đổi mật khẩu";
            //
            // mnuNgan2
            //
            mnuNgan2.Name = "mnuNgan2";
            mnuNgan2.Size = new Size(177, 6);
            //
            // mnuDangXuat
            //
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(180, 22);
            mnuDangXuat.Text = "Đăng xuất";
            //
            // mnuThoat
            //
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(180, 22);
            mnuThoat.Text = "Thoát";
            //
            // mnuDanhMuc
            //
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuKhoa, mnuBoMon, mnuNganh, mnuKhoaHoc, mnuNgan1, mnuHocPhan, mnuChuongTrinh, mnuHocKy });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(75, 20);
            mnuDanhMuc.Text = "Danh mục";
            //
            // mnuKhoa
            //
            mnuKhoa.Name = "mnuKhoa";
            mnuKhoa.Size = new Size(180, 22);
            mnuKhoa.Text = "Khoa";
            //
            // mnuBoMon
            //
            mnuBoMon.Name = "mnuBoMon";
            mnuBoMon.Size = new Size(180, 22);
            mnuBoMon.Text = "Bộ môn";
            //
            // mnuNganh
            //
            mnuNganh.Name = "mnuNganh";
            mnuNganh.Size = new Size(180, 22);
            mnuNganh.Text = "Ngành học";
            //
            // mnuKhoaHoc
            //
            mnuKhoaHoc.Name = "mnuKhoaHoc";
            mnuKhoaHoc.Size = new Size(180, 22);
            mnuKhoaHoc.Text = "Khóa học";
            //
            // mnuNgan1
            //
            mnuNgan1.Name = "mnuNgan1";
            mnuNgan1.Size = new Size(177, 6);
            //
            // mnuHocPhan
            //
            mnuHocPhan.Name = "mnuHocPhan";
            mnuHocPhan.Size = new Size(180, 22);
            mnuHocPhan.Text = "Học phần";
            //
            // mnuChuongTrinh
            //
            mnuChuongTrinh.Name = "mnuChuongTrinh";
            mnuChuongTrinh.Size = new Size(180, 22);
            mnuChuongTrinh.Text = "Chương trình học";
            //
            // mnuHocKy
            //
            mnuHocKy.Name = "mnuHocKy";
            mnuHocKy.Size = new Size(180, 22);
            mnuHocKy.Text = "Học kỳ";
            //
            // mnuSinhVien
            //
            mnuSinhVien.DropDownItems.AddRange(new ToolStripItem[] { mnuHoSoSV, mnuDangKyHoc, mnuNhapDiem, mnuBangDiem, mnuThongKe });
            mnuSinhVien.Name = "mnuSinhVien";
            mnuSinhVien.Size = new Size(75, 20);
            mnuSinhVien.Text = "Sinh viên";
            //
            // mnuHoSoSV
            //
            mnuHoSoSV.Name = "mnuHoSoSV";
            mnuHoSoSV.Size = new Size(200, 22);
            mnuHoSoSV.Text = "Hồ sơ sinh viên";
            //
            // mnuDangKyHoc
            //
            mnuDangKyHoc.Name = "mnuDangKyHoc";
            mnuDangKyHoc.Size = new Size(200, 22);
            mnuDangKyHoc.Text = "Đăng ký học";
            //
            // mnuNhapDiem
            //
            mnuNhapDiem.Name = "mnuNhapDiem";
            mnuNhapDiem.Size = new Size(200, 22);
            mnuNhapDiem.Text = "Nhập điểm";
            //
            // mnuBangDiem
            //
            mnuBangDiem.Name = "mnuBangDiem";
            mnuBangDiem.Size = new Size(200, 22);
            mnuBangDiem.Text = "Bảng điểm toàn khóa";
            //
            // mnuThongKe
            //
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(200, 22);
            mnuThongKe.Text = "Thống kê";
            //
            // statusChinh
            //
            statusChinh.Items.AddRange(new ToolStripItem[] { lblNguoiDung });
            statusChinh.Location = new Point(0, 528);
            statusChinh.Name = "statusChinh";
            statusChinh.Size = new Size(900, 22);
            statusChinh.TabIndex = 1;
            statusChinh.Text = "statusChinh";
            //
            // lblNguoiDung
            //
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(100, 17);
            lblNguoiDung.Text = "Người dùng:";
            //
            // lblTieuDe
            //
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.Location = new Point(0, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(900, 504);
            lblTieuDe.TabIndex = 2;
            lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ HỒ SƠ SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // frmMain
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(lblTieuDe);
            Controls.Add(statusChinh);
            Controls.Add(menuChinh);
            MainMenuStrip = menuChinh;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hồ sơ sinh viên";
            menuChinh.ResumeLayout(false);
            menuChinh.PerformLayout();
            statusChinh.ResumeLayout(false);
            statusChinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuChinh;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuTaiKhoan;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripSeparator mnuNgan2;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuKhoa;
        private ToolStripMenuItem mnuBoMon;
        private ToolStripMenuItem mnuNganh;
        private ToolStripMenuItem mnuKhoaHoc;
        private ToolStripSeparator mnuNgan1;
        private ToolStripMenuItem mnuHocPhan;
        private ToolStripMenuItem mnuChuongTrinh;
        private ToolStripMenuItem mnuHocKy;
        private ToolStripMenuItem mnuSinhVien;
        private ToolStripMenuItem mnuHoSoSV;
        private ToolStripMenuItem mnuDangKyHoc;
        private ToolStripMenuItem mnuNhapDiem;
        private ToolStripMenuItem mnuBangDiem;
        private ToolStripMenuItem mnuThongKe;
        private StatusStrip statusChinh;
        private ToolStripStatusLabel lblNguoiDung;
        private Label lblTieuDe;
    }
}