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
            mnuDangXuat = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuKhoa = new ToolStripMenuItem();
            mnuBoMon = new ToolStripMenuItem();
            mnuNganh = new ToolStripMenuItem();
            mnuKhoaHoc = new ToolStripMenuItem();
            mnuSinhVien = new ToolStripMenuItem();
            mnuHoSoSV = new ToolStripMenuItem();
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
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(75, 20);
            mnuHeThong.Text = "Hệ thống";
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
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuKhoa, mnuBoMon, mnuNganh, mnuKhoaHoc });
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
            // mnuSinhVien
            //
            mnuSinhVien.DropDownItems.AddRange(new ToolStripItem[] { mnuHoSoSV });
            mnuSinhVien.Name = "mnuSinhVien";
            mnuSinhVien.Size = new Size(75, 20);
            mnuSinhVien.Text = "Sinh viên";
            //
            // mnuHoSoSV
            //
            mnuHoSoSV.Name = "mnuHoSoSV";
            mnuHoSoSV.Size = new Size(180, 22);
            mnuHoSoSV.Text = "Hồ sơ sinh viên";
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
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuKhoa;
        private ToolStripMenuItem mnuBoMon;
        private ToolStripMenuItem mnuNganh;
        private ToolStripMenuItem mnuKhoaHoc;
        private ToolStripMenuItem mnuSinhVien;
        private ToolStripMenuItem mnuHoSoSV;
        private StatusStrip statusChinh;
        private ToolStripStatusLabel lblNguoiDung;
        private Label lblTieuDe;
    }
}