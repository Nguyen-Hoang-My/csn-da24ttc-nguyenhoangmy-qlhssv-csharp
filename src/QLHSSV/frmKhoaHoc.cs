using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP GIAO DIỆN cho khóa học
    public partial class frmKhoaHoc : Form
    {
        KhoaHoc khoaHoc;

        public frmKhoaHoc()
        {
            InitializeComponent();
            khoaHoc = new KhoaHoc();

            Load += frmKhoaHoc_Load;
            dgvKhoaHoc.CellClick += dgvKhoaHoc_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            
            txtNamBatDau.TextChanged += txtNamBatDau_TextChanged;
        }

        void frmKhoaHoc_Load(object? sender, EventArgs e)
        {
            dgvKhoaHoc.ReadOnly = true;
            dgvKhoaHoc.AllowUserToAddRows = false;
            dgvKhoaHoc.MultiSelect = false;
            dgvKhoaHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtMaKhoaHoc.MaxLength = 10;
            txtTenKhoaHoc.MaxLength = 50;
            txtNamBatDau.MaxLength = 4;
            txtNamKetThuc.MaxLength = 4;

            napLuoi(khoaHoc.getAllKhoaHoc());
            lamMoi();
        }

        void napLuoi(DataTable bang)
        {
            dgvKhoaHoc.DataSource = bang;
            dgvKhoaHoc.Columns["MAKHOAHOC"].HeaderText = "Mã khóa học";
            dgvKhoaHoc.Columns["TENKHOAHOC"].HeaderText = "Tên khóa học";
            dgvKhoaHoc.Columns["NAMBATDAU"].HeaderText = "Năm bắt đầu";
            dgvKhoaHoc.Columns["NAMKETTHUC"].HeaderText = "Năm kết thúc";
            dgvKhoaHoc.Columns["TENKHOAHOC"].Width = 200;
            dgvKhoaHoc.ClearSelection();
        }

        void lamMoi()
        {
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();
            txtNamBatDau.Clear();
            txtNamKetThuc.Clear();

            txtMaKhoaHoc.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvKhoaHoc.ClearSelection();
            txtMaKhoaHoc.Focus();
        }

        void txtNamBatDau_TextChanged(object? sender, EventArgs e)
        {
            
            if (!btnThem.Enabled) return;
            if (int.TryParse(txtNamBatDau.Text, out int nam) && txtNamBatDau.Text.Length == 4)
            {
                if (txtMaKhoaHoc.Text.Trim() == "") txtMaKhoaHoc.Text = "K" + nam;
                if (txtTenKhoaHoc.Text.Trim() == "") txtTenKhoaHoc.Text = "Khóa " + nam;
                if (txtNamKetThuc.Text.Trim() == "") txtNamKetThuc.Text = (nam + 4).ToString();
            }
        }

        
        int docNam(TextBox o)
        {
            if (int.TryParse(o.Text.Trim(), out int nam) && nam >= 2000 && nam <= 2100) return nam;
            return -1;
        }

        bool duLieuHopLe()
        {
            if (txtMaKhoaHoc.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã khóa học.", "Thiếu thông tin");
                txtMaKhoaHoc.Focus();
                return false;
            }
            if (txtTenKhoaHoc.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên khóa học.", "Thiếu thông tin");
                txtTenKhoaHoc.Focus();
                return false;
            }
            int bd = docNam(txtNamBatDau), kt = docNam(txtNamKetThuc);
            if (bd < 0)
            {
                MessageBox.Show("Năm bắt đầu phải là năm từ 2000 đến 2100.", "Sai dữ liệu");
                txtNamBatDau.Focus();
                return false;
            }
            if (kt < 0)
            {
                MessageBox.Show("Năm kết thúc phải là năm từ 2000 đến 2100.", "Sai dữ liệu");
                txtNamKetThuc.Focus();
                return false;
            }
            if (kt <= bd)
            {
                MessageBox.Show("Năm kết thúc phải lớn hơn năm bắt đầu.", "Sai dữ liệu");
                txtNamKetThuc.Focus();
                return false;
            }
            return true;
        }

        void dgvKhoaHoc_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvKhoaHoc.Rows[e.RowIndex];

            
            btnThem.Enabled = false;
            txtMaKhoaHoc.Text = layO(dong, "MAKHOAHOC");
            txtTenKhoaHoc.Text = layO(dong, "TENKHOAHOC");
            txtNamBatDau.Text = layO(dong, "NAMBATDAU");
            txtNamKetThuc.Text = layO(dong, "NAMKETTHUC");

            txtMaKhoaHoc.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        string layO(DataGridViewRow dong, string tenCot)
        {
            return dong.Cells[tenCot].Value?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                if (khoaHoc.tonTaiMaKhoaHoc(txtMaKhoaHoc.Text))
                {
                    MessageBox.Show("Mã khóa học này đã có rồi.", "Trùng mã");
                    txtMaKhoaHoc.Focus();
                    return;
                }
                khoaHoc.themKhoaHoc(txtMaKhoaHoc.Text, txtTenKhoaHoc.Text,
                                    docNam(txtNamBatDau), docNam(txtNamKetThuc));
                napLuoi(khoaHoc.getAllKhoaHoc());
                lamMoi();
                MessageBox.Show("Đã thêm khóa học.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnSua_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                khoaHoc.suaKhoaHoc(txtMaKhoaHoc.Text, txtTenKhoaHoc.Text,
                                   docNam(txtNamBatDau), docNam(txtNamKetThuc));
                napLuoi(khoaHoc.getAllKhoaHoc());
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
            try
            {
                int soSV = khoaHoc.demSinhVien(txtMaKhoaHoc.Text);
                if (soSV > 0)
                {
                    MessageBox.Show("Khóa học này đang có " + soSV + " sinh viên nên không xóa được.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa " + txtTenKhoaHoc.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                khoaHoc.xoaKhoaHoc(txtMaKhoaHoc.Text);
                napLuoi(khoaHoc.getAllKhoaHoc());
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            napLuoi(khoaHoc.getAllKhoaHoc());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(khoaHoc.timKhoaHoc(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}