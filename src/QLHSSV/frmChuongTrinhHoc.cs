using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmChuongTrinhHoc : Form
    {
        ChuongTrinhHoc chuongTrinh;
        bool dangNapDanhMuc = false;

        public frmChuongTrinhHoc()
        {
            InitializeComponent();
            chuongTrinh = new ChuongTrinhHoc();

            Load += frmChuongTrinhHoc_Load;
            cboNganh.SelectedIndexChanged += cboNganh_SelectedIndexChanged;
            dgvChuongTrinh.CellClick += dgvChuongTrinh_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        void frmChuongTrinhHoc_Load(object? sender, EventArgs e)
        {
            dgvChuongTrinh.ReadOnly = true;
            dgvChuongTrinh.AllowUserToAddRows = false;
            dgvChuongTrinh.MultiSelect = false;
            dgvChuongTrinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cboHocKyDuKien.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                napDanhMuc();
                napHocKyDuKien();
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void napDanhMuc()
        {
            dangNapDanhMuc = true;
            cboNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNganh.DisplayMember = "TENNGANH";
            cboNganh.ValueMember = "MANGANH";
            cboNganh.DataSource = chuongTrinh.getDanhSachNganh();

            cboHocPhan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHocPhan.DisplayMember = "HIENTHI";
            cboHocPhan.ValueMember = "MAHP";
            cboHocPhan.DataSource = chuongTrinh.getDanhSachHocPhan();
            dangNapDanhMuc = false;
        }

        string maNganhDangChon()
        {
            return cboNganh.SelectedValue as string ?? "";
        }

        void napHocKyDuKien()
        {
            int soHocKy = 8;
            if (cboNganh.SelectedItem is DataRowView nganh && nganh["THOIGIANDAOTAO"] is decimal soNam)
                soHocKy = (int)Math.Ceiling(soNam * 2);
            cboHocKyDuKien.Items.Clear();
            for (int i = 1; i <= soHocKy; i++) cboHocKyDuKien.Items.Add(i.ToString());
            if (cboHocKyDuKien.Items.Count > 0) cboHocKyDuKien.SelectedIndex = 0;
        }

        void napLuoi()
        {
            if (dangNapDanhMuc) return;
            DataTable bang = chuongTrinh.getChuongTrinh(maNganhDangChon());
            dgvChuongTrinh.DataSource = bang;
            dgvChuongTrinh.Columns["BATBUOC"].Visible = false;
            dgvChuongTrinh.Columns["MAHP"].HeaderText = "Mã học phần";
            dgvChuongTrinh.Columns["TENHP"].HeaderText = "Tên học phần";
            dgvChuongTrinh.Columns["SOTINCHI"].HeaderText = "Số tín chỉ";
            dgvChuongTrinh.Columns["HOCKYDUKIEN"].HeaderText = "Học kỳ dự kiến";
            dgvChuongTrinh.Columns["LOAI"].HeaderText = "Loại";
            dgvChuongTrinh.Columns["TENHP"].Width = 320;
            dgvChuongTrinh.ClearSelection();

            int tongTC = 0, soBatBuoc = 0, tcBatBuoc = 0;
            foreach (DataRow r in bang.Rows)
            {
                int tc = Convert.ToInt32(r["SOTINCHI"]);
                tongTC += tc;
                if ((bool)r["BATBUOC"]) { soBatBuoc++; tcBatBuoc += tc; }
            }
            lblTongKet.Text = bang.Rows.Count + " học phần, " + tongTC + " tín chỉ (bắt buộc: " + soBatBuoc +
                              " học phần, " + tcBatBuoc + " tín chỉ; tự chọn: " + (bang.Rows.Count - soBatBuoc) +
                              " học phần, " + (tongTC - tcBatBuoc) + " tín chỉ)";
        }

        void lamMoi()
        {
            if (cboHocPhan.Items.Count > 0) cboHocPhan.SelectedIndex = 0;
            if (cboHocKyDuKien.Items.Count > 0) cboHocKyDuKien.SelectedIndex = 0;
            chkBatBuoc.Checked = true;

            cboHocPhan.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvChuongTrinh.ClearSelection();
        }

        void cboNganh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (dangNapDanhMuc) return;
            try
            {
                napHocKyDuKien();
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void dgvChuongTrinh_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dong = dgvChuongTrinh.Rows[e.RowIndex];

            cboHocPhan.SelectedValue = dong.Cells["MAHP"].Value?.ToString() ?? "";
            string hk = dong.Cells["HOCKYDUKIEN"].Value?.ToString() ?? "";
            if (!cboHocKyDuKien.Items.Contains(hk)) cboHocKyDuKien.Items.Add(hk);
            cboHocKyDuKien.SelectedItem = hk;
            chkBatBuoc.Checked = (bool)dong.Cells["BATBUOC"].Value;

            cboHocPhan.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        bool duLieuHopLe()
        {
            if (maNganhDangChon() == "")
            {
                MessageBox.Show("Chưa chọn ngành. Nếu danh sách trống, hãy thêm ngành trước.", "Thiếu thông tin");
                return false;
            }
            if (cboHocPhan.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn học phần. Nếu danh sách trống, hãy thêm học phần trước.", "Thiếu thông tin");
                return false;
            }
            if (cboHocKyDuKien.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn học kỳ dự kiến.", "Thiếu thông tin");
                return false;
            }
            return true;
        }

        string maHPDangChon()
        {
            return cboHocPhan.SelectedValue?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                if (chuongTrinh.daCoTrongChuongTrinh(maNganhDangChon(), maHPDangChon()))
                {
                    MessageBox.Show("Học phần này đã có trong chương trình của ngành " + cboNganh.Text + ".", "Trùng học phần");
                    return;
                }
                chuongTrinh.themVaoChuongTrinh(maNganhDangChon(), maHPDangChon(),
                                               int.Parse(cboHocKyDuKien.Text), chkBatBuoc.Checked);
                napLuoi();
                lamMoi();
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
                chuongTrinh.suaChuongTrinh(maNganhDangChon(), maHPDangChon(),
                                           int.Parse(cboHocKyDuKien.Text), chkBatBuoc.Checked);
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
            try
            {
                int soDangKy = chuongTrinh.demDangKy(maNganhDangChon(), maHPDangChon());
                if (soDangKy > 0)
                {
                    MessageBox.Show("Đã có " + soDangKy + " sinh viên ngành này đăng ký học phần này nên không bỏ ra khỏi chương trình được.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Bỏ học phần " + cboHocPhan.Text + " ra khỏi chương trình ngành " +
                                                      cboNganh.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                chuongTrinh.xoaKhoiChuongTrinh(maNganhDangChon(), maHPDangChon());
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnLamMoi_Click(object? sender, EventArgs e)
        {
            try
            {
                string nganhCu = maNganhDangChon();
                napDanhMuc();
                if (nganhCu != "") cboNganh.SelectedValue = nganhCu;
                napHocKyDuKien();
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}
