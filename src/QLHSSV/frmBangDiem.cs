using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmBangDiem : Form
    {
        DangKyHoc dangKyHoc;
        string maSVChiXem = "";
        string maSVDangXem = "";   // sinh viên đang hiện bảng điểm, dùng cho nút In

        public frmBangDiem()
        {
            InitializeComponent();
            dangKyHoc = new DangKyHoc();

            Load += frmBangDiem_Load;
            btnXem.Click += (s, e) => napBangDiem(txtMaSV.Text.Trim());
            txtMaSV.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { napBangDiem(txtMaSV.Text.Trim()); e.SuppressKeyPress = true; }
            };
            dgvDiem.DataBindingComplete += (s, e) => toMauDongRot();
            btnIn.Click += (s, e) => { if (maSVDangXem != "") frmXemIn.inBangDiem(maSVDangXem); };
        }

        public frmBangDiem(string maSVChiXem) : this()
        {
            this.maSVChiXem = maSVChiXem;
        }

        void frmBangDiem_Load(object? sender, EventArgs e)
        {
            foreach (DataGridView luoi in new[] { dgvDiem, dgvTongKet })
            {
                luoi.ReadOnly = true;
                luoi.AllowUserToAddRows = false;
                luoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            txtMaSV.MaxLength = 10;
            btnIn.Enabled = false;
            if (maSVChiXem != "")
            {
                Text = "Kết quả học tập của tôi";
                lbMaSV.Visible = false;
                txtMaSV.Visible = false;
                btnXem.Visible = false;
                btnIn.Visible = false;      // in ấn là việc của giáo vụ
                lblSinhVien.Left = lbMaSV.Left;
                napBangDiem(maSVChiXem);
            }
        }

        void napBangDiem(string maSV)
        {
            if (maSV == "")
            {
                MessageBox.Show("Nhập mã sinh viên.", "Thiếu thông tin");
                return;
            }
            try
            {
                DataRow? sv = dangKyHoc.getThongTinSinhVien(maSV);
                if (sv == null)
                {
                    maSVDangXem = "";
                    btnIn.Enabled = false;
                    MessageBox.Show("Không có sinh viên mã " + maSV + ".", "Thông báo");
                    return;
                }
                lblSinhVien.Text = sv["MASV"] + " - " + sv["HOTEN"] + "   |   Ngành: " + sv["TENNGANH"] +
                                   "   |   Lớp: " + sv["MALOP"] + "   |   " + sv["TENKHOAHOC"];

                maSVDangXem = sv["MASV"].ToString() ?? "";
                btnIn.Enabled = true;
                dgvDiem.DataSource = dangKyHoc.getBangDiem(maSV);
                dgvDiem.Columns["MAHOCKY"].Visible = false;
                dgvDiem.Columns["TENHOCKY"].HeaderText = "Học kỳ";
                dgvDiem.Columns["MAHP"].HeaderText = "Mã HP";
                dgvDiem.Columns["TENHP"].HeaderText = "Tên học phần";
                dgvDiem.Columns["SOTINCHI"].HeaderText = "TC";
                dgvDiem.Columns["DIEMQUATRINH"].HeaderText = "Điểm QT";
                dgvDiem.Columns["DIEMTHI"].HeaderText = "Thi lần 1";
                dgvDiem.Columns["DIEMTHILAN2"].HeaderText = "Thi lần 2";
                dgvDiem.Columns["DIEMHP"].HeaderText = "Điểm HP";
                dgvDiem.Columns["DIEMCHU"].HeaderText = "Điểm chữ";
                dgvDiem.Columns["DIEMHE4"].HeaderText = "Hệ 4";
                dgvDiem.Columns["KETQUA"].HeaderText = "Kết quả";
                dgvDiem.Columns["DIEMQUATRINH"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["DIEMTHI"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["DIEMTHILAN2"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["TENHOCKY"].Width = 210;
                dgvDiem.Columns["TENHP"].Width = 230;
                dgvDiem.Columns["SOTINCHI"].Width = 40;

                DataTable tongKet = dangKyHoc.getTongKetHocKy(maSV);
                dgvTongKet.DataSource = tongKet;
                dgvTongKet.Columns["MAHOCKY"].Visible = false;
                dgvTongKet.Columns["TENHOCKY"].HeaderText = "Học kỳ";
                dgvTongKet.Columns["TCHOC"].HeaderText = "TC học";
                dgvTongKet.Columns["TCDAT"].HeaderText = "TC đạt";
                dgvTongKet.Columns["DTBHE10"].HeaderText = "ĐTB HK (10)";
                dgvTongKet.Columns["DTBHE4"].HeaderText = "ĐTB HK (4)";
                dgvTongKet.Columns["TCTICHLUY"].HeaderText = "TC tích lũy";
                dgvTongKet.Columns["DTBTLHE10"].HeaderText = "ĐTB tích lũy (10)";
                dgvTongKet.Columns["DTBTLHE4"].HeaderText = "ĐTB tích lũy (4)";
                dgvTongKet.Columns["XEPLOAI"].HeaderText = "Xếp loại";
                dgvTongKet.Columns["TENHOCKY"].Width = 210;

                if (tongKet.Rows.Count == 0)
                {
                    lblTichLuy.Text = "Chưa có học phần nào có điểm.";
                }
                else
                {
                    DataRow cuoi = tongKet.Rows[tongKet.Rows.Count - 1];
                    lblTichLuy.Text = "Tích lũy: " + cuoi["TCTICHLUY"] + " tín chỉ   |   ĐTB tích lũy hệ 10: " +
                                      cuoi["DTBTLHE10"] + "   |   hệ 4: " + cuoi["DTBTLHE4"] +
                                      "   |   Xếp loại: " + cuoi["XEPLOAI"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void toMauDongRot()
        {
            foreach (DataGridViewRow dong in dgvDiem.Rows)
            {
                string kq = dong.Cells["KETQUA"].Value?.ToString() ?? "";
                dong.DefaultCellStyle.ForeColor = kq == "Không đạt" ? Color.Firebrick
                                                : kq == "Chưa có điểm" ? SystemColors.GrayText
                                                : SystemColors.ControlText;
            }
        }
    }
}
