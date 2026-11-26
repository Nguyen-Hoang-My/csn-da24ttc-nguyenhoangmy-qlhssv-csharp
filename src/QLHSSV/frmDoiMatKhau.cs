using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmDoiMatKhau : Form
    {
        TaiKhoan taiKhoan;

        public frmDoiMatKhau()
        {
            InitializeComponent();
            taiKhoan = new TaiKhoan();

            Load += (s, e) => lblTaiKhoan.Text = "Tài khoản: " + PhienDangNhap.TenDangNhap + " - " + PhienDangNhap.HoTen;
            chkHienMatKhau.CheckedChanged += (s, e) =>
            {
                bool an = !chkHienMatKhau.Checked;
                txtMatKhauCu.UseSystemPasswordChar = an;
                txtMatKhauMoi.UseSystemPasswordChar = an;
                txtNhapLai.UseSystemPasswordChar = an;
            };
            btnDoi.Click += btnDoi_Click;
            btnHuy.Click += (s, e) => Close();
        }

        void btnDoi_Click(object? sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLai.Text == "")
            {
                MessageBox.Show("Nhập đủ 3 ô.", "Thiếu thông tin");
                return;
            }
            if (txtMatKhauMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Sai dữ liệu");
                txtMatKhauMoi.Focus();
                return;
            }
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu mới không khớp.", "Sai dữ liệu");
                txtNhapLai.Focus();
                return;
            }
            if (txtMatKhauMoi.Text == txtMatKhauCu.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.", "Sai dữ liệu");
                txtMatKhauMoi.Focus();
                return;
            }
            try
            {
                if (taiKhoan.dangNhap(PhienDangNhap.TenDangNhap, txtMatKhauCu.Text) == null)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng.", "Sai mật khẩu");
                    txtMatKhauCu.Clear();
                    txtMatKhauCu.Focus();
                    return;
                }
                taiKhoan.doiMatKhau(PhienDangNhap.TenDangNhap, txtMatKhauMoi.Text);
                MessageBox.Show("Đã đổi mật khẩu. Lần đăng nhập sau dùng mật khẩu mới.", "Thông báo");
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}
