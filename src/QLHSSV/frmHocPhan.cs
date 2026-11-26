using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmHocPhan : Form
    {
        HocPhan hocPhan;

        public frmHocPhan()
        {
            InitializeComponent();
            hocPhan = new HocPhan();

            Load += frmHocPhan_Load;
            dgvHocPhan.CellClick += dgvHocPhan_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
        }

        void frmHocPhan_Load(object? sender, EventArgs e)
        {
            dgvHocPhan.ReadOnly = true;
            dgvHocPhan.AllowUserToAddRows = false;
            dgvHocPhan.MultiSelect = false;
            dgvHocPhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtMaHP.MaxLength = 10;
            txtTenHP.MaxLength = 100;
            txtSoTinChi.MaxLength = 2;
            txtTyLe.MaxLength = 3;

            napLuoi(hocPhan.getAllHocPhan());
            lamMoi();
        }

        void napLuoi(DataTable bang)
        {
            dgvHocPhan.DataSource = bang;
            dgvHocPhan.Columns["MAHP"].HeaderText = "Mã học phần";
            dgvHocPhan.Columns["TENHP"].HeaderText = "Tên học phần";
            dgvHocPhan.Columns["SOTINCHI"].HeaderText = "Số tín chỉ";
            dgvHocPhan.Columns["TYLEQUATRINH"].HeaderText = "Điểm quá trình";
            dgvHocPhan.Columns["TYLEQUATRINH"].DefaultCellStyle.Format = "0%";
            dgvHocPhan.Columns["TENHP"].Width = 300;
            dgvHocPhan.ClearSelection();
        }

        void lamMoi()
        {
            txtMaHP.Clear();
            txtTenHP.Clear();
            txtSoTinChi.Text = "3";
            txtTyLe.Text = "50";

            txtMaHP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvHocPhan.ClearSelection();
            txtMaHP.Focus();
        }

        int docSoTinChi()
        {
            if (int.TryParse(txtSoTinChi.Text.Trim(), out int tc) && tc >= 1 && tc <= 10) return tc;
            return -1;
        }

        int docTyLe()
        {
            if (int.TryParse(txtTyLe.Text.Trim().TrimEnd('%'), out int tl) && tl >= 0 && tl <= 100) return tl;
            return -1;
        }

        bool duLieuHopLe()
        {
            if (txtMaHP.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã học phần.", "Thiếu thông tin");
                txtMaHP.Focus();
                return false;
            }
            if (txtTenHP.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên học phần.", "Thiếu thông tin");
                txtTenHP.Focus();
                return false;
            }
            if (docSoTinChi() < 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên từ 1 đến 10.", "Sai dữ liệu");
                txtSoTinChi.Focus();
                return false;
            }
            if (docTyLe() < 0)
            {
                MessageBox.Show("Tỷ lệ điểm quá trình phải là số nguyên từ 0 đến 100, ví dụ 50.", "Sai dữ liệu");
                txtTyLe.Focus();
                return false;
            }
            return true;
        }

        void dgvHocPhan_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvHocPhan.Rows[e.RowIndex];

            txtMaHP.Text = layO(dong, "MAHP");
            txtTenHP.Text = layO(dong, "TENHP");
            txtSoTinChi.Text = layO(dong, "SOTINCHI");
            if (dong.Cells["TYLEQUATRINH"].Value is decimal tl)
                txtTyLe.Text = ((int)Math.Round(tl * 100)).ToString();

            txtMaHP.Enabled = false;
            btnThem.Enabled = false;
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
                if (hocPhan.tonTaiMaHP(txtMaHP.Text))
                {
                    MessageBox.Show("Mã học phần này đã có rồi.", "Trùng mã");
                    txtMaHP.Focus();
                    return;
                }
                hocPhan.themHocPhan(txtMaHP.Text, txtTenHP.Text, docSoTinChi(), docTyLe() / 100m);
                napLuoi(hocPhan.getAllHocPhan());
                lamMoi();
                MessageBox.Show("Đã thêm học phần.", "Thông báo");
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
                hocPhan.suaHocPhan(txtMaHP.Text, txtTenHP.Text, docSoTinChi(), docTyLe() / 100m);
                napLuoi(hocPhan.getAllHocPhan());
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
                int soNganh = hocPhan.demChuongTrinh(txtMaHP.Text);
                int soDangKy = hocPhan.demDangKy(txtMaHP.Text);
                if (soNganh > 0 || soDangKy > 0)
                {
                    MessageBox.Show("Học phần này đang nằm trong chương trình của " + soNganh + " ngành và có " +
                                    soDangKy + " lượt đăng ký nên không xóa được.", "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa học phần " + txtTenHP.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                hocPhan.xoaHocPhan(txtMaHP.Text);
                napLuoi(hocPhan.getAllHocPhan());
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
            napLuoi(hocPhan.getAllHocPhan());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(hocPhan.timHocPhan(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}
