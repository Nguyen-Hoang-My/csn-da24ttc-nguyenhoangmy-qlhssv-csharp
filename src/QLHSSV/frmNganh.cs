using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP GIAO DIỆN cho ngành học
    public partial class frmNganh : Form
    {
        Nganh nganh;

        public frmNganh()
        {
            InitializeComponent();
            nganh = new Nganh();

            Load += frmNganh_Load;
            dgvNganh.CellClick += dgvNganh_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
        }

        void frmNganh_Load(object? sender, EventArgs e)
        {
            
            cboBoMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBoMon.DisplayMember = "TENBOMON";
            cboBoMon.ValueMember = "MABOMON";
            cboBoMon.DataSource = nganh.getDanhSachBoMon();

            dgvNganh.ReadOnly = true;
            dgvNganh.AllowUserToAddRows = false;
            dgvNganh.MultiSelect = false;
            dgvNganh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtMaNganh.MaxLength = 10;
            txtTenNganh.MaxLength = 100;
            txtThoiGian.MaxLength = 4;
            txtMoTa.MaxLength = 1000;

            napLuoi(nganh.getAllNganh());
            lamMoi();
        }

        void napLuoi(DataTable bang)
        {
            dgvNganh.DataSource = bang;
            dgvNganh.Columns["MABOMON"].Visible = false;
            dgvNganh.Columns["MANGANH"].HeaderText = "Mã ngành";
            dgvNganh.Columns["TENNGANH"].HeaderText = "Tên ngành";
            dgvNganh.Columns["TENBOMON"].HeaderText = "Bộ môn quản lý";
            dgvNganh.Columns["TENKHOA"].HeaderText = "Khoa";
            dgvNganh.Columns["THOIGIANDAOTAO"].HeaderText = "Số năm đào tạo";
            dgvNganh.Columns["MOTANGANHHOC"].HeaderText = "Mô tả";
            dgvNganh.Columns["TENNGANH"].Width = 180;
            dgvNganh.Columns["TENBOMON"].Width = 180;
            dgvNganh.Columns["TENKHOA"].Width = 180;
            dgvNganh.ClearSelection();
        }

        void lamMoi()
        {
            txtMaNganh.Clear();
            txtTenNganh.Clear();
            if (cboBoMon.Items.Count > 0) cboBoMon.SelectedIndex = 0;
            txtThoiGian.Text = "4";
            txtMoTa.Clear();

            txtMaNganh.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvNganh.ClearSelection();
            txtMaNganh.Focus();
        }

        
        decimal docThoiGian()
        {
            string s = txtThoiGian.Text.Trim().Replace(',', '.');
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal kq)
                && kq >= 1 && kq <= 9.9m)
                return Math.Round(kq, 1);
            return -1;
        }

        bool duLieuHopLe()
        {
            if (txtMaNganh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã ngành.", "Thiếu thông tin");
                txtMaNganh.Focus();
                return false;
            }
            if (txtTenNganh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên ngành.", "Thiếu thông tin");
                txtTenNganh.Focus();
                return false;
            }
            if (cboBoMon.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn bộ môn. Nếu danh sách trống, hãy thêm bộ môn trước.", "Thiếu thông tin");
                cboBoMon.Focus();
                return false;
            }
            if (docThoiGian() < 0)
            {
                MessageBox.Show("Số năm đào tạo phải là số từ 1 đến 9.9, ví dụ 4 hoặc 4.5.", "Sai dữ liệu");
                txtThoiGian.Focus();
                return false;
            }
            return true;
        }

        void dgvNganh_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvNganh.Rows[e.RowIndex];

            txtMaNganh.Text = layO(dong, "MANGANH");
            txtTenNganh.Text = layO(dong, "TENNGANH");
            cboBoMon.SelectedValue = layO(dong, "MABOMON");
            
            if (dong.Cells["THOIGIANDAOTAO"].Value is decimal tg)
                txtThoiGian.Text = tg.ToString("0.0", CultureInfo.InvariantCulture);
            txtMoTa.Text = layO(dong, "MOTANGANHHOC");

            txtMaNganh.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        string layO(DataGridViewRow dong, string tenCot)
        {
            return dong.Cells[tenCot].Value?.ToString() ?? "";
        }

        string maBoMonDangChon()
        {
            return cboBoMon.SelectedValue?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                if (nganh.tonTaiMaNganh(txtMaNganh.Text))
                {
                    MessageBox.Show("Mã ngành này đã có rồi.", "Trùng mã");
                    txtMaNganh.Focus();
                    return;
                }
                nganh.themNganh(txtMaNganh.Text, maBoMonDangChon(), txtTenNganh.Text, docThoiGian(), txtMoTa.Text);
                napLuoi(nganh.getAllNganh());
                lamMoi();
                MessageBox.Show("Đã thêm ngành.", "Thông báo");
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
                nganh.suaNganh(txtMaNganh.Text, maBoMonDangChon(), txtTenNganh.Text, docThoiGian(), txtMoTa.Text);
                napLuoi(nganh.getAllNganh());
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
                int soSV = nganh.demSinhVien(txtMaNganh.Text);
                int soHP = nganh.demHocPhanTrongChuongTrinh(txtMaNganh.Text);
                if (soSV > 0 || soHP > 0)
                {
                    MessageBox.Show("Ngành này đang có " + soSV + " sinh viên và " + soHP +
                                    " học phần trong chương trình học nên không xóa được.", "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa ngành " + txtTenNganh.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                nganh.xoaNganh(txtMaNganh.Text);
                napLuoi(nganh.getAllNganh());
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
            cboBoMon.DataSource = nganh.getDanhSachBoMon();
            napLuoi(nganh.getAllNganh());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(nganh.timNganh(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}