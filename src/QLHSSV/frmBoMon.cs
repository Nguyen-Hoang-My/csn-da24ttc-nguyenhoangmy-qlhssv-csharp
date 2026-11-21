using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP GIAO DIỆN cho bộ môn: nhận thao tác, gọi lớp BoMon, hiện kết quả.
    public partial class frmBoMon : Form
    {
        BoMon boMon;

        public frmBoMon()
        {
            InitializeComponent();
            boMon = new BoMon();

            Load += frmBoMon_Load;
            dgvBoMon.CellClick += dgvBoMon_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
        }

        void frmBoMon_Load(object? sender, EventArgs e)
        {
            
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.DisplayMember = "TENKHOA";
            cboKhoa.ValueMember = "MAKHOA";
            cboKhoa.DataSource = boMon.getDanhSachKhoa();

            dgvBoMon.ReadOnly = true;
            dgvBoMon.AllowUserToAddRows = false;
            dgvBoMon.MultiSelect = false;
            dgvBoMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtMaBoMon.MaxLength = 10;
            txtTenBoMon.MaxLength = 100;
            txtTruongBoMon.MaxLength = 100;
            txtEmail.MaxLength = 100;
            txtSoNoiBo.MaxLength = 5;
            txtTrangThongTin.MaxLength = 200;
            txtMoTa.MaxLength = 1000;

            napLuoi(boMon.getAllBoMon());
            lamMoi();
        }

        void napLuoi(DataTable bang)
        {
            dgvBoMon.DataSource = bang;
            dgvBoMon.Columns["MAKHOA"].Visible = false;   
            dgvBoMon.Columns["MABOMON"].HeaderText = "Mã bộ môn";
            dgvBoMon.Columns["TENBOMON"].HeaderText = "Tên bộ môn";
            dgvBoMon.Columns["TENKHOA"].HeaderText = "Thuộc khoa";
            dgvBoMon.Columns["TRUONGBOMON"].HeaderText = "Trưởng bộ môn";
            dgvBoMon.Columns["EMAILBOMON"].HeaderText = "Email";
            dgvBoMon.Columns["SONOIBOBOMON"].HeaderText = "Số nội bộ";
            dgvBoMon.Columns["TRANGTHONGTINBOMON"].HeaderText = "Trang thông tin";
            dgvBoMon.Columns["MOTABOMON"].HeaderText = "Mô tả";
            dgvBoMon.Columns["TENBOMON"].Width = 200;
            dgvBoMon.Columns["TENKHOA"].Width = 200;
            dgvBoMon.ClearSelection();
        }

        void lamMoi()
        {
            txtMaBoMon.Clear();
            txtTenBoMon.Clear();
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            txtTruongBoMon.Clear();
            txtEmail.Clear();
            txtSoNoiBo.Clear();
            txtTrangThongTin.Clear();
            txtMoTa.Clear();

            txtMaBoMon.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvBoMon.ClearSelection();
            txtMaBoMon.Focus();
        }

        bool duLieuHopLe()
        {
            if (txtMaBoMon.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã bộ môn.", "Thiếu thông tin");
                txtMaBoMon.Focus();
                return false;
            }
            if (txtTenBoMon.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên bộ môn.", "Thiếu thông tin");
                txtTenBoMon.Focus();
                return false;
            }
            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn khoa. Nếu danh sách trống, hãy thêm khoa trước.", "Thiếu thông tin");
                cboKhoa.Focus();
                return false;
            }
            return true;
        }

        void dgvBoMon_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvBoMon.Rows[e.RowIndex];

            txtMaBoMon.Text = layO(dong, "MABOMON");
            txtTenBoMon.Text = layO(dong, "TENBOMON");
            cboKhoa.SelectedValue = layO(dong, "MAKHOA");   
            txtTruongBoMon.Text = layO(dong, "TRUONGBOMON");
            txtEmail.Text = layO(dong, "EMAILBOMON");
            txtSoNoiBo.Text = layO(dong, "SONOIBOBOMON");
            txtTrangThongTin.Text = layO(dong, "TRANGTHONGTINBOMON");
            txtMoTa.Text = layO(dong, "MOTABOMON");

            txtMaBoMon.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        string layO(DataGridViewRow dong, string tenCot)
        {
            return dong.Cells[tenCot].Value?.ToString() ?? "";
        }

        string maKhoaDangChon()
        {
            return cboKhoa.SelectedValue?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                if (boMon.tonTaiMaBoMon(txtMaBoMon.Text))
                {
                    MessageBox.Show("Mã bộ môn này đã có rồi.", "Trùng mã");
                    txtMaBoMon.Focus();
                    return;
                }
                boMon.themBoMon(txtMaBoMon.Text, maKhoaDangChon(), txtTenBoMon.Text, txtTruongBoMon.Text,
                                txtEmail.Text, txtSoNoiBo.Text, txtTrangThongTin.Text, txtMoTa.Text);
                napLuoi(boMon.getAllBoMon());
                lamMoi();
                MessageBox.Show("Đã thêm bộ môn.", "Thông báo");
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
                boMon.suaBoMon(txtMaBoMon.Text, maKhoaDangChon(), txtTenBoMon.Text, txtTruongBoMon.Text,
                               txtEmail.Text, txtSoNoiBo.Text, txtTrangThongTin.Text, txtMoTa.Text);
                napLuoi(boMon.getAllBoMon());
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
                int soNganh = boMon.demNganh(txtMaBoMon.Text);
                if (soNganh > 0)
                {
                    MessageBox.Show("Bộ môn này đang quản lý " + soNganh + " ngành nên không xóa được.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa bộ môn " + txtTenBoMon.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                boMon.xoaBoMon(txtMaBoMon.Text);
                napLuoi(boMon.getAllBoMon());
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
            
            cboKhoa.DataSource = boMon.getDanhSachKhoa();
            napLuoi(boMon.getAllBoMon());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(boMon.timBoMon(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}