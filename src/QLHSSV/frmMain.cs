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

            Load += frmMain_Load;
            mnuDangXuat.Click += mnuDangXuat_Click;
            mnuThoat.Click += (s, e) => Close();
            mnuKhoa.Click += (s, e) => moForm<frmKhoa>();
            mnuBoMon.Click += (s, e) => moForm<frmBoMon>();
            mnuNganh.Click += (s, e) => moForm<frmNganh>();
            mnuKhoaHoc.Click += (s, e) => moForm<frmKhoaHoc>();
            mnuHoSoSV.Click += (s, e) =>
                MessageBox.Show("Chức năng đang xây dựng.", "Thông báo");
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
            if (vaiTro == "SINHVIEN")
            {
                mnuDanhMuc.Visible = false;
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