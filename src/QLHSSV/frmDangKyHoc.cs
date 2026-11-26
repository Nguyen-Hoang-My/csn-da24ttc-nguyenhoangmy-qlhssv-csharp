using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmDangKyHoc : Form
    {
        DangKyHoc dangKyHoc;
        string maSVDangChon = "";
        string tinhTrangSV = "";
        bool dangNapDanhMuc = false;

        public frmDangKyHoc()
        {
            InitializeComponent();
            dangKyHoc = new DangKyHoc();

            Load += frmDangKyHoc_Load;
            btnTimSV.Click += (s, e) => napSinhVien();
            txtTimSV.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { napSinhVien(); e.SuppressKeyPress = true; }
            };
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            cboHocKy.SelectedIndexChanged += (s, e) => napHocPhan();
            btnDangKy.Click += btnDangKy_Click;
            btnHuyDangKy.Click += btnHuyDangKy_Click;
        }

        void frmDangKyHoc_Load(object? sender, EventArgs e)
        {
            caiDatLuoi(dgvSinhVien, false);
            caiDatLuoi(dgvCoThe, true);
            caiDatLuoi(dgvDaDangKy, true);
            try
            {
                dangNapDanhMuc = true;
                cboHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
                cboHocKy.DisplayMember = "TENHOCKY";
                cboHocKy.ValueMember = "MAHOCKY";
                DataTable hocKy = dangKyHoc.getDanhSachHocKy();
                cboHocKy.DataSource = hocKy;
                for (int i = 0; i < hocKy.Rows.Count; i++)
                {
                    DateTime bd = (DateTime)hocKy.Rows[i]["NGAYBATDAU"], kt = (DateTime)hocKy.Rows[i]["NGAYKETTHUC"];
                    if (DateTime.Today >= bd && DateTime.Today <= kt) { cboHocKy.SelectedIndex = i; break; }
                }
                dangNapDanhMuc = false;
                napSinhVien();
                napHocPhan();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void caiDatLuoi(DataGridView luoi, bool chonNhieu)
        {
            luoi.ReadOnly = true;
            luoi.AllowUserToAddRows = false;
            luoi.MultiSelect = chonNhieu;
            luoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        string maHocKyDangChon()
        {
            return cboHocKy.SelectedValue as string ?? "";
        }

        void napSinhVien()
        {
            try
            {
                dgvSinhVien.DataSource = dangKyHoc.timSinhVien(txtTimSV.Text);
                dgvSinhVien.Columns["MASV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["HOTEN"].HeaderText = "Họ và tên";
                dgvSinhVien.Columns["TENNGANH"].HeaderText = "Ngành";
                dgvSinhVien.Columns["MALOP"].HeaderText = "Lớp";
                dgvSinhVien.Columns["TINHTRANG"].HeaderText = "Tình trạng";
                dgvSinhVien.Columns["HOTEN"].Width = 150;
                dgvSinhVien.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void dgvSinhVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            maSVDangChon = dgvSinhVien.Rows[e.RowIndex].Cells["MASV"].Value?.ToString() ?? "";
            napHocPhan();
        }

        void napHocPhan()
        {
            if (dangNapDanhMuc) return;
            if (maSVDangChon == "" || maHocKyDangChon() == "")
            {
                dgvCoThe.DataSource = null;
                dgvDaDangKy.DataSource = null;
                lblTongTC.Text = "";
                return;
            }
            try
            {
                DataRow? sv = dangKyHoc.getThongTinSinhVien(maSVDangChon);
                if (sv == null) return;
                tinhTrangSV = sv["TINHTRANG"].ToString() ?? "";
                lblSinhVien.Text = sv["MASV"] + " - " + sv["HOTEN"] + "   |   Ngành: " + sv["TENNGANH"] +
                                   "   |   Lớp: " + sv["MALOP"] + "   |   " + tinhTrangSV;

                dgvCoThe.DataSource = dangKyHoc.getHocPhanCoTheDangKy(maSVDangChon, maHocKyDangChon());
                dgvCoThe.Columns["MAHP"].HeaderText = "Mã HP";
                dgvCoThe.Columns["TENHP"].HeaderText = "Tên học phần";
                dgvCoThe.Columns["SOTINCHI"].HeaderText = "TC";
                dgvCoThe.Columns["HOCKYDUKIEN"].HeaderText = "HK dự kiến";
                dgvCoThe.Columns["LOAI"].HeaderText = "Loại";
                dgvCoThe.Columns["DAHOC"].HeaderText = "Đã học trước đó";
                dgvCoThe.Columns["TENHP"].Width = 230;
                dgvCoThe.Columns["SOTINCHI"].Width = 40;
                dgvCoThe.Columns["DAHOC"].Width = 150;
                dgvCoThe.ClearSelection();

                DataTable daDangKy = dangKyHoc.getHocPhanDaDangKy(maSVDangChon, maHocKyDangChon());
                dgvDaDangKy.DataSource = daDangKy;
                dgvDaDangKy.Columns["MAHP"].HeaderText = "Mã HP";
                dgvDaDangKy.Columns["TENHP"].HeaderText = "Tên học phần";
                dgvDaDangKy.Columns["SOTINCHI"].HeaderText = "TC";
                dgvDaDangKy.Columns["NGAYDANGKY"].HeaderText = "Ngày đăng ký";
                dgvDaDangKy.Columns["NGAYDANGKY"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDaDangKy.Columns["DIEMQUATRINH"].HeaderText = "Điểm QT";
                dgvDaDangKy.Columns["DIEMTHI"].HeaderText = "Thi lần 1";
                dgvDaDangKy.Columns["DIEMTHILAN2"].HeaderText = "Thi lần 2";
                dgvDaDangKy.Columns["DIEMHP"].HeaderText = "Điểm HP";
                dgvDaDangKy.Columns["DIEMCHU"].HeaderText = "Điểm chữ";
                dgvDaDangKy.Columns["TENHP"].Width = 230;
                dgvDaDangKy.Columns["SOTINCHI"].Width = 40;
                dgvDaDangKy.ClearSelection();

                int tongTC = 0;
                foreach (DataRow r in daDangKy.Rows) tongTC += Convert.ToInt32(r["SOTINCHI"]);
                lblTongTC.Text = "Đã đăng ký: " + daDangKy.Rows.Count + " học phần, " + tongTC + " tín chỉ";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void btnDangKy_Click(object? sender, EventArgs e)
        {
            if (maSVDangChon == "")
            {
                MessageBox.Show("Chọn sinh viên trước.", "Thông báo");
                return;
            }
            if (tinhTrangSV != "Đang học")
            {
                MessageBox.Show("Sinh viên đang ở tình trạng \"" + tinhTrangSV + "\" nên không đăng ký học được.", "Không thể đăng ký");
                return;
            }
            if (dgvCoThe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất một học phần ở bảng trên.", "Thông báo");
                return;
            }
            int thanhCong = 0;
            List<string> loi = new List<string>();
            foreach (DataGridViewRow dong in dgvCoThe.SelectedRows)
            {
                string maHP = dong.Cells["MAHP"].Value?.ToString() ?? "";
                try
                {
                    dangKyHoc.dangKy(maSVDangChon, maHP, maHocKyDangChon());
                    thanhCong++;
                }
                catch (SqlException ex)
                {
                    loi.Add(maHP + ": " + DangKyHoc.loiSQL(ex));
                }
            }
            napHocPhan();
            string thongBao = "Đã đăng ký " + thanhCong + " học phần.";
            if (loi.Count > 0) thongBao += "\n\nKhông đăng ký được:\n" + string.Join("\n", loi);
            MessageBox.Show(thongBao, "Kết quả đăng ký");
        }

        void btnHuyDangKy_Click(object? sender, EventArgs e)
        {
            if (dgvDaDangKy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn học phần cần hủy ở bảng dưới.", "Thông báo");
                return;
            }
            List<DataGridViewRow> chon = new List<DataGridViewRow>();
            List<string> coDiem = new List<string>();
            foreach (DataGridViewRow dong in dgvDaDangKy.SelectedRows)
            {
                if (dong.Cells["DIEMQUATRINH"].Value != DBNull.Value || dong.Cells["DIEMTHI"].Value != DBNull.Value)
                    coDiem.Add(dong.Cells["MAHP"].Value?.ToString() ?? "");
                else
                    chon.Add(dong);
            }
            if (coDiem.Count > 0)
                MessageBox.Show("Các học phần đã có điểm không hủy được: " + string.Join(", ", coDiem), "Thông báo");
            if (chon.Count == 0) return;

            DialogResult traLoi = MessageBox.Show("Hủy đăng ký " + chon.Count + " học phần?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi != DialogResult.Yes) return;
            try
            {
                foreach (DataGridViewRow dong in chon)
                    dangKyHoc.huyDangKy(maSVDangChon, dong.Cells["MAHP"].Value?.ToString() ?? "", maHocKyDangChon());
                napHocPhan();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }
    }
}
