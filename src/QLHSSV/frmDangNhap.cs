using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmDangNhap : Form
    {
        TaiKhoan taiKhoan;

       
        public string TenDangNhap { get; private set; } = "";
        public string HoTen { get; private set; } = "";
        public string VaiTro { get; private set; } = "";

        public frmDangNhap()
        {
            InitializeComponent();
            taiKhoan = new TaiKhoan();

            btnDangNhap.Click += btnDangNhap_Click;
            btnThoat.Click += (s, e) => { DialogResult = DialogResult.Cancel; };
            chkHienMatKhau.CheckedChanged += (s, e) =>
            {
                txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            };
        }

        void btnDangNhap_Click(object? sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Nhập tên đăng nhập và mật khẩu.", "Thiếu thông tin");
                return;
            }
            try
            {
                DataRow? tk = taiKhoan.dangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
                if (tk == null)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại");
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }
                if (!(bool)tk["TRANGTHAI"])
                {
                    MessageBox.Show("Tài khoản này đã bị khóa.", "Đăng nhập thất bại");
                    return;
                }
                TenDangNhap = tk["TENDANGNHAP"].ToString() ?? "";
                HoTen = tk["HOTEN"].ToString() ?? "";
                VaiTro = tk["VAITRO"].ToString() ?? "";
                DialogResult = DialogResult.OK;    
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không kết nối được CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}