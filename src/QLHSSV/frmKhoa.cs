using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP GIAO DIỆN: nhận thao tác của người dùng, gọi lớp Khoa, hiện kết quả.
    public partial class frmKhoa : Form
    {
        Khoa khoa;

        public frmKhoa()
        {
            InitializeComponent();
            khoa = new Khoa();

            // Nối sự kiện với hàm xử lý (viết ở đây nên không cần bấm đúp từng nút bên Design)
            Load += frmKhoa_Load;
            dgvKhoa.CellClick += dgvKhoa_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
        }

        void frmKhoa_Load(object? sender, EventArgs e)
        {
            // Loại đơn vị: chỉ cho chọn trong danh sách
            cboLoaiDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiDonVi.Items.Clear();
            cboLoaiDonVi.Items.AddRange(new object[] { "Khoa", "Trường", "Viện", "Trung tâm" });

            // Lưới chỉ để xem và chọn dòng
            dgvKhoa.ReadOnly = true;
            dgvKhoa.AllowUserToAddRows = false;
            dgvKhoa.MultiSelect = false;
            dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Giới hạn số ký tự theo đúng độ dài cột trong CSDL
            txtMaKhoa.MaxLength = 10;
            txtTenKhoa.MaxLength = 100;
            txtTenTiengAnh.MaxLength = 100;
            txtTenVietTat.MaxLength = 10;
            txtTruongDonVi.MaxLength = 100;
            txtSDT.MaxLength = 15;
            txtSoNoiBo.MaxLength = 5;
            txtEmail.MaxLength = 100;
            txtWebsite.MaxLength = 100;
            txtDiaChi.MaxLength = 200;
            txtMoTa.MaxLength = 1000;

            napLuoi(khoa.getAllKhoa());
            lamMoi();
        }

        // Đổ dữ liệu lên lưới và đặt lại tiêu đề cột bằng tiếng Việt
        void napLuoi(DataTable bang)
        {
            dgvKhoa.DataSource = bang;
            dgvKhoa.Columns["MAKHOA"].HeaderText = "Mã khoa";
            dgvKhoa.Columns["TENKHOA"].HeaderText = "Tên khoa";
            dgvKhoa.Columns["TENTIENGANH"].HeaderText = "Tên tiếng Anh";
            dgvKhoa.Columns["TENVIETTAT"].HeaderText = "Viết tắt";
            dgvKhoa.Columns["LOAIDONVI"].HeaderText = "Loại đơn vị";
            dgvKhoa.Columns["TRUONGDONVI"].HeaderText = "Trưởng đơn vị";
            dgvKhoa.Columns["SDTKHOA"].HeaderText = "Điện thoại";
            dgvKhoa.Columns["SONOIBOKHOA"].HeaderText = "Số nội bộ";
            dgvKhoa.Columns["EMAILKHOA"].HeaderText = "Email";
            dgvKhoa.Columns["WEBSITEKHOA"].HeaderText = "Website";
            dgvKhoa.Columns["DIACHIKHOA"].HeaderText = "Địa chỉ";
            dgvKhoa.Columns["MOTAKHOA"].HeaderText = "Mô tả";
            dgvKhoa.Columns["TENKHOA"].Width = 200;
            dgvKhoa.ClearSelection();
        }

        // Xóa trắng các ô nhập, trở về trạng thái sẵn sàng thêm mới
        void lamMoi()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtTenTiengAnh.Clear();
            txtTenVietTat.Clear();
            cboLoaiDonVi.SelectedIndex = 0;
            txtTruongDonVi.Clear();
            txtSDT.Clear();
            txtSoNoiBo.Clear();
            txtEmail.Clear();
            txtWebsite.Clear();
            txtDiaChi.Clear();
            txtMoTa.Clear();

            txtMaKhoa.Enabled = true;      // đang thêm mới thì được gõ mã
            btnThem.Enabled = true;
            btnSua.Enabled = false;        // chưa chọn dòng nào thì chưa sửa, xóa được
            btnXoa.Enabled = false;
            dgvKhoa.ClearSelection();
            txtMaKhoa.Focus();
        }

        // Kiểm tra các ô bắt buộc. Trả về true nếu hợp lệ.
        bool duLieuHopLe()
        {
            if (txtMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã khoa.", "Thiếu thông tin");
                txtMaKhoa.Focus();
                return false;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên khoa.", "Thiếu thông tin");
                txtTenKhoa.Focus();
                return false;
            }
            if (cboLoaiDonVi.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại đơn vị.", "Thiếu thông tin");
                cboLoaiDonVi.Focus();
                return false;
            }
            return true;
        }

        // Bấm vào một dòng trên lưới: đưa dữ liệu dòng đó lên các ô nhập
        void dgvKhoa_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;    // bấm vào hàng tiêu đề thì bỏ qua
            DataGridViewRow dong = dgvKhoa.Rows[e.RowIndex];

            txtMaKhoa.Text = layO(dong, "MAKHOA");
            txtTenKhoa.Text = layO(dong, "TENKHOA");
            txtTenTiengAnh.Text = layO(dong, "TENTIENGANH");
            txtTenVietTat.Text = layO(dong, "TENVIETTAT");
            cboLoaiDonVi.SelectedItem = layO(dong, "LOAIDONVI");
            txtTruongDonVi.Text = layO(dong, "TRUONGDONVI");
            txtSDT.Text = layO(dong, "SDTKHOA");
            txtSoNoiBo.Text = layO(dong, "SONOIBOKHOA");
            txtEmail.Text = layO(dong, "EMAILKHOA");
            txtWebsite.Text = layO(dong, "WEBSITEKHOA");
            txtDiaChi.Text = layO(dong, "DIACHIKHOA");
            txtMoTa.Text = layO(dong, "MOTAKHOA");

            txtMaKhoa.Enabled = false;     // mã là khóa chính, không cho sửa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // Lấy giá trị một ô dưới dạng chuỗi (ô NULL thì trả về chuỗi rỗng)
        string layO(DataGridViewRow dong, string tenCot)
        {
            return dong.Cells[tenCot].Value?.ToString() ?? "";
        }

        void btnThem_Click(object? sender, EventArgs e)
        {
            if (!duLieuHopLe()) return;
            try
            {
                if (khoa.tonTaiMaKhoa(txtMaKhoa.Text))
                {
                    MessageBox.Show("Mã khoa này đã có rồi.", "Trùng mã");
                    txtMaKhoa.Focus();
                    return;
                }
                khoa.themKhoa(txtMaKhoa.Text, txtTenKhoa.Text, txtTenTiengAnh.Text, txtTenVietTat.Text,
                              cboLoaiDonVi.Text, txtTruongDonVi.Text, txtSDT.Text, txtSoNoiBo.Text,
                              txtEmail.Text, txtWebsite.Text, txtDiaChi.Text, txtMoTa.Text);
                napLuoi(khoa.getAllKhoa());
                lamMoi();
                MessageBox.Show("Đã thêm khoa.", "Thông báo");
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
                khoa.suaKhoa(txtMaKhoa.Text, txtTenKhoa.Text, txtTenTiengAnh.Text, txtTenVietTat.Text,
                             cboLoaiDonVi.Text, txtTruongDonVi.Text, txtSDT.Text, txtSoNoiBo.Text,
                             txtEmail.Text, txtWebsite.Text, txtDiaChi.Text, txtMoTa.Text);
                napLuoi(khoa.getAllKhoa());
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
                int soBoMon = khoa.demBoMon(txtMaKhoa.Text);
                if (soBoMon > 0)
                {
                    MessageBox.Show("Khoa này đang có " + soBoMon + " bộ môn nên không xóa được.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa khoa " + txtTenKhoa.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                khoa.xoaKhoa(txtMaKhoa.Text);
                napLuoi(khoa.getAllKhoa());
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
            napLuoi(khoa.getAllKhoa());
            lamMoi();
        }

        void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                napLuoi(khoa.timKhoa(txtTimKiem.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }
}