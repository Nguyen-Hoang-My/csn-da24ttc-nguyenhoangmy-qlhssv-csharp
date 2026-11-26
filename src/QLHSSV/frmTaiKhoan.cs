using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmTaiKhoan : Form
    {
        TaiKhoan taiKhoan;
        bool dangNapDanhMuc = false;

        public frmTaiKhoan()
        {
            InitializeComponent();
            taiKhoan = new TaiKhoan();

            Load += frmTaiKhoan_Load;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            cboVaiTro.SelectedIndexChanged += (s, e) => capNhatOMaSV();
            cboMaSV.SelectedIndexChanged += cboMaSV_SelectedIndexChanged;
            cboLocVaiTro.SelectedIndexChanged += (s, e) => { if (!dangNapDanhMuc) napLuoi(); };
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += (s, e) => { txtTimKiem.Clear(); napLuoi(); lamMoi(); };
            btnDatLaiMK.Click += btnDatLaiMK_Click;
            btnTaoHangLoat.Click += btnTaoHangLoat_Click;
            btnTim.Click += (s, e) => napLuoi();
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { napLuoi(); e.SuppressKeyPress = true; }
            };
        }

        void frmTaiKhoan_Load(object? sender, EventArgs e)
        {
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtTenDangNhap.MaxLength = 50;
            txtHoTen.MaxLength = 100;
            txtMatKhau.UseSystemPasswordChar = true;

            dangNapDanhMuc = true;
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.Items.AddRange(new object[] { "Quản trị", "Giáo vụ", "Sinh viên" });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Hoạt động", "Đã khóa" });
            cboLocVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocVaiTro.Items.AddRange(new object[] { "(Tất cả)", "Quản trị", "Giáo vụ", "Sinh viên" });
            cboLocVaiTro.SelectedIndex = 0;
            cboMaSV.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaSV.DisplayMember = "HIENTHI";
            cboMaSV.ValueMember = "MASV";
            dangNapDanhMuc = false;

            napLuoi();
            lamMoi();
        }

        string maVaiTro(string ten)
        {
            switch (ten)
            {
                case "Quản trị": return "ADMIN";
                case "Giáo vụ": return "GIAOVU";
                case "Sinh viên": return "SINHVIEN";
                default: return "";
            }
        }

        void napLuoi()
        {
            try
            {
                string vt = cboLocVaiTro.SelectedIndex <= 0 ? "" : maVaiTro(cboLocVaiTro.Text);
                dgvTaiKhoan.DataSource = taiKhoan.locTaiKhoan(vt, txtTimKiem.Text);
                dgvTaiKhoan.Columns["VAITRO"].Visible = false;
                dgvTaiKhoan.Columns["TRANGTHAI"].Visible = false;
                dgvTaiKhoan.Columns["TENDANGNHAP"].HeaderText = "Tên đăng nhập";
                dgvTaiKhoan.Columns["HOTEN"].HeaderText = "Họ tên";
                dgvTaiKhoan.Columns["TENVAITRO"].HeaderText = "Vai trò";
                dgvTaiKhoan.Columns["MASV"].HeaderText = "Mã sinh viên";
                dgvTaiKhoan.Columns["TENTRANGTHAI"].HeaderText = "Trạng thái";
                dgvTaiKhoan.Columns["HOTEN"].Width = 220;
                dgvTaiKhoan.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void napSinhVien(string maSVGiuLai)
        {
            dangNapDanhMuc = true;
            cboMaSV.DataSource = taiKhoan.getSinhVienChuaCoTaiKhoan(maSVGiuLai);
            cboMaSV.SelectedIndex = -1;
            dangNapDanhMuc = false;
        }

        void lamMoi()
        {
            txtTenDangNhap.Clear();
            txtHoTen.Clear();
            txtMatKhau.Clear();
            cboTrangThai.SelectedIndex = 0;
            try { napSinhVien(""); } catch (SqlException ex) { MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi"); }
            cboVaiTro.SelectedIndex = 1;

            txtTenDangNhap.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDatLaiMK.Enabled = false;
            dgvTaiKhoan.ClearSelection();
            txtTenDangNhap.Focus();
        }

        void capNhatOMaSV()
        {
            bool laSV = cboVaiTro.Text == "Sinh viên";
            cboMaSV.Enabled = laSV;
            if (!laSV) cboMaSV.SelectedIndex = -1;
        }

        void cboMaSV_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (dangNapDanhMuc || !btnThem.Enabled) return;
            if (cboMaSV.SelectedItem is DataRowView sv)
            {
                txtTenDangNhap.Text = sv["MASV"].ToString();
                txtHoTen.Text = sv["HOTEN"].ToString();
                if (txtMatKhau.Text == "") txtMatKhau.Text = sv["MASV"].ToString();
            }
        }

        void dgvTaiKhoan_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvTaiKhoan.Rows[e.RowIndex];
            btnThem.Enabled = false;

            string maSV = dong.Cells["MASV"].Value?.ToString() ?? "";
            try { napSinhVien(maSV); } catch (SqlException ex) { MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi"); }
            txtTenDangNhap.Text = dong.Cells["TENDANGNHAP"].Value?.ToString() ?? "";
            txtHoTen.Text = dong.Cells["HOTEN"].Value?.ToString() ?? "";
            cboVaiTro.SelectedItem = dong.Cells["TENVAITRO"].Value?.ToString() ?? "";
            if (maSV != "") cboMaSV.SelectedValue = maSV;
            cboTrangThai.SelectedIndex = (bool)dong.Cells["TRANGTHAI"].Value ? 0 : 1;
            txtMatKhau.Clear();

            txtTenDangNhap.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDatLaiMK.Enabled = true;
        }

        bool duLieuHopLe(bool dangThem)
        {
            string ten = txtTenDangNhap.Text.Trim();
            if (ten == "" || ten.Contains(' '))
            {
                MessageBox.Show("Tên đăng nhập không được để trống và không có khoảng trắng.", "Sai dữ liệu");
                txtTenDangNhap.Focus();
                return false;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập họ tên.", "Thiếu thông tin");
                txtHoTen.Focus();
                return false;
            }
            if (cboVaiTro.Text == "Sinh viên" && cboMaSV.SelectedValue == null)
            {
                MessageBox.Show("Tài khoản sinh viên phải chọn mã sinh viên.", "Thiếu thông tin");
                cboMaSV.Focus();
                return false;
            }
            if (dangThem && txtMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Sai dữ liệu");
                txtMatKhau.Focus();
                return false;
            }
            if (dangThem && taiKhoan.tonTaiTenDangNhap(ten))
            {
                MessageBox.Show("Tên đăng nhập này đã có rồi.", "Trùng tên");
                txtTenDangNhap.Focus();
                return false;
            }
            string maSV = maSVDangChon();
            if (maSV != "" && taiKhoan.sinhVienDaCoTaiKhoan(maSV, dangThem ? "" : ten))
            {
                MessageBox.Show("Sinh viên " + maSV + " đã có tài khoản khác.", "Trùng sinh viên");
                return false;
            }
            if (!dangThem && !conQuanTriSauKhiDoi(ten, maVaiTro(cboVaiTro.Text) == "ADMIN" && cboTrangThai.SelectedIndex == 0))
                return false;
            return true;
        }

        bool conQuanTriSauKhiDoi(string ten, bool vanLaQuanTriHoatDong)
        {
            if (vanLaQuanTriHoatDong) return true;
            if (taiKhoan.demQuanTriHoatDongKhac(ten) == 0)
            {
                MessageBox.Show("Phải còn ít nhất một tài khoản quản trị đang hoạt động.", "Không thể thực hiện");
                return false;
            }
            if (ten == PhienDangNhap.TenDangNhap)
            {
                MessageBox.Show("Không tự khóa, tự xóa hoặc tự bỏ quyền quản trị của tài khoản đang đăng nhập.", "Không thể thực hiện");
                return false;
            }
            return true;
        }

        string maSVDangChon()
        {
            return cboVaiTro.Text == "Sinh viên" ? (cboMaSV.SelectedValue?.ToString() ?? "") : "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!duLieuHopLe(true)) return;
                taiKhoan.themTaiKhoan(txtTenDangNhap.Text, txtHoTen.Text, maVaiTro(cboVaiTro.Text), maSVDangChon(),
                                      cboTrangThai.SelectedIndex == 0, txtMatKhau.Text);
                napLuoi();
                lamMoi();
                MessageBox.Show("Đã tạo tài khoản.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!duLieuHopLe(false)) return;
                taiKhoan.suaTaiKhoan(txtTenDangNhap.Text, txtHoTen.Text, maVaiTro(cboVaiTro.Text), maSVDangChon(),
                                     cboTrangThai.SelectedIndex == 0);
                if (txtMatKhau.Text != "")
                {
                    if (txtMatKhau.Text.Length < 6)
                    {
                        MessageBox.Show("Đã lưu thông tin, nhưng mật khẩu mới phải có ít nhất 6 ký tự nên chưa đổi mật khẩu.", "Thông báo");
                        return;
                    }
                    taiKhoan.doiMatKhau(txtTenDangNhap.Text.Trim(), txtMatKhau.Text);
                }
                napLuoi();
                lamMoi();
                MessageBox.Show("Đã cập nhật.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnXoa_Click(object? sender, EventArgs e)
        {
            string ten = txtTenDangNhap.Text.Trim();
            try
            {
                if (!conQuanTriSauKhiDoi(ten, false)) return;
                DialogResult traLoi = MessageBox.Show("Xóa tài khoản " + ten + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;
                taiKhoan.xoaTaiKhoan(ten);
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnDatLaiMK_Click(object? sender, EventArgs e)
        {
            string ten = txtTenDangNhap.Text.Trim();
            string matKhauMoi = maSVDangChon() != "" ? maSVDangChon() : ten + "@123";
            DialogResult traLoi = MessageBox.Show("Đặt lại mật khẩu của " + ten + " thành \"" + matKhauMoi + "\"?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi != DialogResult.Yes) return;
            try
            {
                taiKhoan.doiMatKhau(ten, matKhauMoi);
                MessageBox.Show("Đã đặt lại. Mật khẩu mới: " + matKhauMoi + "\nNhắc người dùng đổi mật khẩu sau khi đăng nhập.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnTaoHangLoat_Click(object? sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Tạo tài khoản cho tất cả sinh viên chưa có tài khoản?\n" +
                                                  "Tên đăng nhập và mật khẩu ban đầu đều là mã sinh viên.",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi != DialogResult.Yes) return;
            try
            {
                int soLuong = taiKhoan.taoTaiKhoanChoSinhVienChuaCo();
                napLuoi();
                lamMoi();
                MessageBox.Show("Đã tạo " + soLuong + " tài khoản sinh viên.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}
