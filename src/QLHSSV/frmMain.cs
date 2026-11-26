namespace QLHSSV
{
    // FORM CHÍNH: menu mở các chức năng, phân quyền theo vai trò
    public partial class frmMain : Form
    {
        string tenDangNhap, hoTen, vaiTro;

        
        public bool DangXuat { get; private set; } = false;

        public frmMain(string tenDangNhap, string hoTen, string vaiTro)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            this.hoTen = hoTen;
            this.vaiTro = vaiTro;
            PhienDangNhap.TenDangNhap = tenDangNhap;
            PhienDangNhap.HoTen = hoTen;
            PhienDangNhap.VaiTro = vaiTro;

            Load += frmMain_Load;
            mnuDangXuat.Click += mnuDangXuat_Click;
            mnuThoat.Click += (s, e) => Close();
            mnuTaiKhoan.Click += (s, e) => moForm<frmTaiKhoan>();
            mnuDoiMatKhau.Click += (s, e) => { using frmDoiMatKhau f = new frmDoiMatKhau(); f.ShowDialog(this); };
            mnuKhoa.Click += (s, e) => moForm<frmKhoa>();
            mnuBoMon.Click += (s, e) => moForm<frmBoMon>();
            mnuNganh.Click += (s, e) => moForm<frmNganh>();
            mnuKhoaHoc.Click += (s, e) => moForm<frmKhoaHoc>();
            mnuHocPhan.Click += (s, e) => moForm<frmHocPhan>();
            mnuChuongTrinh.Click += (s, e) => moForm<frmChuongTrinhHoc>();
            mnuHocKy.Click += (s, e) => moForm<frmHocKy>();
            mnuHoSoSV.Click += mnuHoSoSV_Click;
            mnuDangKyHoc.Click += (s, e) => moForm<frmDangKyHoc>();
            mnuNhapDiem.Click += (s, e) => moForm<frmNhapDiem>();
            mnuBangDiem.Click += mnuBangDiem_Click;
            mnuThongKe.Click += (s, e) => moForm<frmThongKe>();
        }

        void frmMain_Load(object? sender, EventArgs e)
        {
            lblNguoiDung.Text = "Người dùng: " + hoTen + " (" + tenDangNhap + ")   |   Vai trò: " + tenVaiTro(vaiTro);
            phanQuyen();
        }

        
        string tenVaiTro(string ma)
        {
            switch (ma)
            {
                case "ADMIN": return "Quản trị";
                case "GIAOVU": return "Giáo vụ";
                case "SINHVIEN": return "Sinh viên";
                default: return ma;
            }
        }

        
        void phanQuyen()
        {
            mnuDanhMuc.Visible = vaiTro == "ADMIN";
            mnuTaiKhoan.Visible = vaiTro == "ADMIN";
            mnuSinhVien.Visible = vaiTro == "GIAOVU" || vaiTro == "SINHVIEN";
            if (vaiTro == "SINHVIEN")
            {
                mnuHoSoSV.Text = "Hồ sơ của tôi";
                mnuDangKyHoc.Visible = false;
                mnuNhapDiem.Visible = false;
                mnuThongKe.Visible = false;
                mnuBangDiem.Text = "Đăng ký học và bảng điểm của tôi";
            }
        }

        
        void moForm<T>() where T : Form, new()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is T)
                {
                    if (f.WindowState == FormWindowState.Minimized) f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    return;
                }
            }
            T formMoi = new T();
            formMoi.Show(this);    
        }

       
        void mnuHoSoSV_Click(object? sender, EventArgs e)
        {
            if (vaiTro != "SINHVIEN")
            {
                moForm<frmSinhVien>();
                return;
            }
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmSinhVien) { f.Activate(); return; }
            }
            string maSV = new TaiKhoan().layMaSV(tenDangNhap);
            if (maSV == "")
            {
                MessageBox.Show("Tài khoản này chưa được gắn với hồ sơ sinh viên nào.", "Thông báo");
                return;
            }
            new frmSinhVien(maSV).Show(this);
        }

        void mnuBangDiem_Click(object? sender, EventArgs e)
        {
            if (vaiTro != "SINHVIEN")
            {
                moForm<frmBangDiem>();
                return;
            }
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmBangDiem) { f.Activate(); return; }
            }
            string maSV = new TaiKhoan().layMaSV(tenDangNhap);
            if (maSV == "")
            {
                MessageBox.Show("Tài khoản này chưa được gắn với hồ sơ sinh viên nào.", "Thông báo");
                return;
            }
            new frmBangDiem(maSV).Show(this);
        }

        void mnuDangXuat_Click(object? sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Đăng xuất khỏi hệ thống?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi != DialogResult.Yes) return;
            DangXuat = true;
            Close();
        }
    }
}