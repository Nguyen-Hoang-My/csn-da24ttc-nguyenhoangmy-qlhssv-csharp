using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmHocKy : Form
    {
        HocKy hocKy;

        public frmHocKy()
        {
            InitializeComponent();
            hocKy = new HocKy();

            Load += frmHocKy_Load;
            dgvHocKy.CellClick += dgvHocKy_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            txtNamHoc.TextChanged += (s, e) => tuDienMaVaTen();
            cboHocKySo.SelectedIndexChanged += (s, e) => tuDienMaVaTen();
        }

        void frmHocKy_Load(object? sender, EventArgs e)
        {
            cboHocKySo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocKySo.Items.AddRange(new object[] { "1", "2", "3" });

            dgvHocKy.ReadOnly = true;
            dgvHocKy.AllowUserToAddRows = false;
            dgvHocKy.MultiSelect = false;
            dgvHocKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtMaHocKy.MaxLength = 10;
            txtTenHocKy.MaxLength = 50;
            txtNamHoc.MaxLength = 9;

            napLuoi(hocKy.getAllHocKy());
            lamMoi();
        }

        void napLuoi(DataTable bang)
        {
            dgvHocKy.DataSource = bang;
            dgvHocKy.Columns["MAHOCKY"].HeaderText = "Mã học kỳ";
            dgvHocKy.Columns["TENHOCKY"].HeaderText = "Tên học kỳ";
            dgvHocKy.Columns["NAMHOC"].HeaderText = "Năm học";
            dgvHocKy.Columns["HOCKYSO"].HeaderText = "Học kỳ";
            dgvHocKy.Columns["NGAYBATDAU"].HeaderText = "Ngày bắt đầu";
            dgvHocKy.Columns["NGAYKETTHUC"].HeaderText = "Ngày kết thúc";
            dgvHocKy.Columns["NGAYBATDAU"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHocKy.Columns["NGAYKETTHUC"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHocKy.Columns["TENHOCKY"].Width = 260;
            dgvHocKy.ClearSelection();
        }

        void lamMoi()
        {
            int namDau = DateTime.Today.Month >= 8 ? DateTime.Today.Year : DateTime.Today.Year - 1;
            txtNamHoc.Text = namDau + "-" + (namDau + 1);
            cboHocKySo.SelectedIndex = 0;
            dtpNgayBatDau.Value = new DateTime(namDau, 9, 1);
            dtpNgayKetThuc.Value = new DateTime(namDau + 1, 1, 15);

            txtMaHocKy.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tuDienMaVaTen();
            dgvHocKy.ClearSelection();
            txtNamHoc.Focus();
        }

        void tuDienMaVaTen()
        {
            if (!btnThem.Enabled) return;
            int namDau = docNamDau();
            if (namDau < 0 || cboHocKySo.SelectedIndex < 0) return;
            string so = cboHocKySo.Text;
            txtMaHocKy.Text = namDau + so;
            txtTenHocKy.Text = (so == "3" ? "Học kỳ hè" : "Học kỳ " + so) + ", năm học " + txtNamHoc.Text.Trim();
        }

        int docNamDau()
        {
            Match m = Regex.Match(txtNamHoc.Text.Trim(), @"^(\d{4})-(\d{4})$");
            if (!m.Success) return -1;
            int dau = int.Parse(m.Groups[1].Value), cuoi = int.Parse(m.Groups[2].Value);
            if (cuoi != dau + 1 || dau < 2000 || dau > 2100) return -1;
            return dau;
        }

        bool duLieuHopLe(bool dangThem)
        {
            int namDau = docNamDau();
            if (namDau < 0)
            {
                MessageBox.Show("Năm học phải có dạng 2025-2026, năm sau hơn năm trước 1 năm.", "Sai dữ liệu");
                txtNamHoc.Focus();
                return false;
            }
            if (txtMaHocKy.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã học kỳ.", "Thiếu thông tin");
                txtMaHocKy.Focus();
                return false;
            }
            if (txtTenHocKy.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên học kỳ.", "Thiếu thông tin");
                txtTenHocKy.Focus();
                return false;
            }
            DateTime bd = dtpNgayBatDau.Value.Date, kt = dtpNgayKetThuc.Value.Date;
            if (kt <= bd)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Sai dữ liệu");
                dtpNgayKetThuc.Focus();
                return false;
            }
            if (bd.Year != namDau && bd.Year != namDau + 1)
            {
                MessageBox.Show("Ngày bắt đầu phải nằm trong năm học " + txtNamHoc.Text.Trim() + ".", "Sai dữ liệu");
                dtpNgayBatDau.Focus();
                return false;
            }
            if (dangThem && hocKy.tonTaiMaHocKy(txtMaHocKy.Text))
            {
                MessageBox.Show("Mã học kỳ này đã có rồi.", "Trùng mã");
                txtMaHocKy.Focus();
                return false;
            }
            if (hocKy.trungHocKy(txtNamHoc.Text.Trim(), int.Parse(cboHocKySo.Text), dangThem ? "" : txtMaHocKy.Text))
            {
                MessageBox.Show("Năm học " + txtNamHoc.Text.Trim() + " đã có học kỳ " + cboHocKySo.Text + " rồi.", "Trùng học kỳ");
                cboHocKySo.Focus();
                return false;
            }
            return true;
        }

        void dgvHocKy_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvHocKy.Rows[e.RowIndex];

            btnThem.Enabled = false;
            txtMaHocKy.Text = layO(dong, "MAHOCKY");
            txtNamHoc.Text = layO(dong, "NAMHOC");
            cboHocKySo.SelectedItem = layO(dong, "HOCKYSO");
            txtTenHocKy.Text = layO(dong, "TENHOCKY");
            dtpNgayBatDau.Value = (DateTime)dong.Cells["NGAYBATDAU"].Value;
            dtpNgayKetThuc.Value = (DateTime)dong.Cells["NGAYKETTHUC"].Value;

            txtMaHocKy.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        string layO(DataGridViewRow dong, string tenCot)
        {
            return dong.Cells[tenCot].Value?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!duLieuHopLe(true)) return;
                hocKy.themHocKy(txtMaHocKy.Text, txtTenHocKy.Text, txtNamHoc.Text, int.Parse(cboHocKySo.Text),
                                dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
                napLuoi(hocKy.getAllHocKy());
                lamMoi();
                MessageBox.Show("Đã thêm học kỳ.", "Thông báo");
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
                hocKy.suaHocKy(txtMaHocKy.Text, txtTenHocKy.Text, txtNamHoc.Text, int.Parse(cboHocKySo.Text),
                               dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
                napLuoi(hocKy.getAllHocKy());
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
                int soDangKy = hocKy.demDangKy(txtMaHocKy.Text);
                if (soDangKy > 0)
                {
                    MessageBox.Show("Học kỳ này đã có " + soDangKy + " lượt đăng ký học nên không xóa được.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa " + txtTenHocKy.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                hocKy.xoaHocKy(txtMaHocKy.Text);
                napLuoi(hocKy.getAllHocKy());
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
            napLuoi(hocKy.getAllHocKy());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(hocKy.timHocKy(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}
