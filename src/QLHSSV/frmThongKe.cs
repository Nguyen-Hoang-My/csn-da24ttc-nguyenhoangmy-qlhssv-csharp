using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmThongKe : Form
    {
        ThongKe thongKe;
        bool dangNap = false;          // chặn sự kiện khi đang gán DataSource cho combobox
        DataTable? bangThongKe;

        // tiêu đề tiếng Việt cho các cột có thể xuất hiện
        static readonly Dictionary<string, string> TieuDe = new()
        {
            ["NHOM"] = "Nhóm", ["TONG"] = "Số SV", ["NU"] = "Nữ", ["DANGHOC"] = "Đang học",
            ["BAOLUU"] = "Bảo lưu", ["THOIHOC"] = "Thôi học", ["TOTNGHIEP"] = "Đã tốt nghiệp",
            ["DUGIAYTO"] = "Đủ giấy tờ", ["THIEUGIAYTO"] = "Còn thiếu", ["TILE"] = "Tỉ lệ (%)",
            ["MASV"] = "Mã SV", ["HOTEN"] = "Họ tên", ["NGAYSINH"] = "Ngày sinh", ["GIOITINH"] = "Giới tính",
            ["MALOP"] = "Lớp", ["TENNGANH"] = "Ngành", ["TENKHOA"] = "Khoa", ["TENKHOAHOC"] = "Khóa học",
            ["TINHTRANG"] = "Tình trạng", ["TCTICHLUY"] = "TC tích lũy", ["DTBTLHE10"] = "ĐTB TL (10)",
            ["DTBTLHE4"] = "ĐTB TL (4)", ["XEPLOAI"] = "Xếp loại", ["SOGIAYTOTHIEU"] = "Giấy tờ thiếu"
        };

        public frmThongKe()
        {
            InitializeComponent();
            thongKe = new ThongKe();

            Load += frmThongKe_Load;
            cboLoai.SelectedIndexChanged += (s, e) => napThongKe();
            cboKhoaHoc.SelectedIndexChanged += (s, e) => napThongKe();
            cboNganh.SelectedIndexChanged += (s, e) => napThongKe();
            dgvThongKe.SelectionChanged += (s, e) => napChiTiet();
            pnlBieuDo.Paint += pnlBieuDo_Paint;
            pnlBieuDo.Resize += (s, e) => pnlBieuDo.Invalidate();
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        void frmThongKe_Load(object? sender, EventArgs e)
        {
            foreach (DataGridView luoi in new[] { dgvThongKe, dgvChiTiet })
            {
                luoi.ReadOnly = true;
                luoi.AllowUserToAddRows = false;
                luoi.MultiSelect = false;
                luoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                luoi.RowHeadersVisible = false;
            }
            foreach (ComboBox c in new[] { cboLoai, cboKhoaHoc, cboNganh })
                c.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                dangNap = true;
                cboLoai.Items.AddRange(ThongKe.KieuThongKe);
                cboLoai.SelectedIndex = 0;
                cboKhoaHoc.DataSource = thongKe.getDanhSachKhoaHoc();
                cboKhoaHoc.DisplayMember = "TENKHOAHOC";
                cboKhoaHoc.ValueMember = "MAKHOAHOC";
                cboNganh.DataSource = thongKe.getDanhSachNganh();
                cboNganh.DisplayMember = "TENNGANH";
                cboNganh.ValueMember = "MANGANH";
                dangNap = false;
                napThongKe();
            }
            catch (SqlException ex)
            {
                dangNap = false;
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex) +
                                "\n\nNếu báo thiếu vw_SinhVienTongHop thì chạy file setup\\08_ThongKe.sql trước.", "Lỗi");
            }
        }

        string maKhoaHoc => cboKhoaHoc.SelectedValue as string ?? "";
        string maNganh => cboNganh.SelectedValue as string ?? "";

        void napThongKe()
        {
            if (dangNap || cboLoai.SelectedIndex < 0) return;
            try
            {
                bangThongKe = thongKe.thongKe(cboLoai.SelectedIndex, maKhoaHoc, maNganh);
                dangNap = true;                       // không nạp chi tiết nhiều lần khi lưới đổi dữ liệu
                dgvThongKe.DataSource = bangThongKe;
                dgvThongKe.Columns["MANHOM"].Visible = false;
                datTieuDe(dgvThongKe);
                dgvThongKe.Columns["NHOM"].HeaderText = new[] { "Khoa", "Ngành", "Khóa học", "Xếp loại", "Ngành" }[cboLoai.SelectedIndex];
                dgvThongKe.Columns["NHOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvThongKe.Columns["NHOM"].MinimumWidth = 150;
                foreach (DataGridViewColumn c in dgvThongKe.Columns)
                    if (c.Name != "NHOM") { c.Width = 62; c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }
                dgvThongKe.Columns["TILE"].DefaultCellStyle.Format = "0.00";
                dgvThongKe.ClearSelection();
                dangNap = false;

                int tong = bangThongKe.AsEnumerable().Sum(r => Convert.ToInt32(r["TONG"]));
                lblTong.Text = "Tổng cộng: " + tong + " sinh viên   (bấm vào một dòng ở bảng trên để xem danh sách của nhóm đó)";
                napChiTiet();
                pnlBieuDo.Invalidate();
            }
            catch (SqlException ex)
            {
                dangNap = false;
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        // Chưa chọn dòng nào thì hiện toàn bộ sinh viên theo bộ lọc
        void napChiTiet()
        {
            if (dangNap) return;
            pnlBieuDo.Invalidate();              // tô màu cột đang chọn trên biểu đồ
            string maNhom = "", tenNhom = "";
            if (dgvThongKe.SelectedRows.Count > 0)
            {
                maNhom = dgvThongKe.SelectedRows[0].Cells["MANHOM"].Value?.ToString() ?? "";
                tenNhom = dgvThongKe.SelectedRows[0].Cells["NHOM"].Value?.ToString() ?? "";
            }
            try
            {
                DataTable ds = thongKe.danhSach(cboLoai.SelectedIndex, maNhom, maKhoaHoc, maNganh);
                dgvChiTiet.DataSource = ds;
                datTieuDe(dgvChiTiet);
                dgvChiTiet.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvChiTiet.Columns["DTBTLHE10"].DefaultCellStyle.Format = "0.00";
                dgvChiTiet.Columns["DTBTLHE4"].DefaultCellStyle.Format = "0.00";
                dgvChiTiet.Columns["HOTEN"].Width = 170;
                dgvChiTiet.Columns["TENNGANH"].Width = 160;
                dgvChiTiet.Columns["TENKHOA"].Width = 160;
                lblChiTiet.Text = "Danh sách sinh viên" + (tenNhom == "" ? " (tất cả)" : " - " + tenNhom) +
                                  ": " + ds.Rows.Count + " sinh viên";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void datTieuDe(DataGridView luoi)
        {
            foreach (DataGridViewColumn c in luoi.Columns)
                if (TieuDe.TryGetValue(c.Name, out string? td)) c.HeaderText = td;
        }

        // Biểu đồ cột ngang vẽ tay bằng GDI+ (WinForms trên .NET mới không còn control Chart)
        void pnlBieuDo_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (bangThongKe == null || bangThongKe.Rows.Count == 0)
            {
                g.DrawString("Không có dữ liệu", Font, Brushes.Gray, 10, 10);
                return;
            }

            int soNhom = bangThongKe.Rows.Count;
            int max = Math.Max(1, bangThongKe.AsEnumerable().Max(r => Convert.ToInt32(r["TONG"])));
            int rongNhan = 120, le = 8;
            float cao = (pnlBieuDo.ClientSize.Height - 2 * le) / (float)soNhom;
            float caoThanh = Math.Min(26, cao * 0.65f);
            float rongToiDa = pnlBieuDo.ClientSize.Width - rongNhan - 50;

            using Font chu = new Font("Segoe UI", 8.5f);
            using SolidBrush mau = new SolidBrush(Color.FromArgb(52, 120, 196));
            using SolidBrush mauChon = new SolidBrush(Color.FromArgb(230, 126, 34));
            StringFormat canhPhai = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
            StringFormat canhGiua = new StringFormat { LineAlignment = StringAlignment.Center };
            int dongChon = dgvThongKe.SelectedRows.Count > 0 ? dgvThongKe.SelectedRows[0].Index : -1;

            for (int i = 0; i < soNhom; i++)
            {
                string ten = bangThongKe.Rows[i]["NHOM"].ToString() ?? "";
                int giaTri = Convert.ToInt32(bangThongKe.Rows[i]["TONG"]);
                float y = le + i * cao + (cao - caoThanh) / 2;
                g.DrawString(ten, chu, Brushes.Black, new RectangleF(2, y - 4, rongNhan - 6, caoThanh + 8), canhPhai);
                float rong = rongToiDa * giaTri / max;
                g.FillRectangle(i == dongChon ? mauChon : mau, rongNhan, y, Math.Max(rong, 1), caoThanh);
                g.DrawString(giaTri.ToString(), chu, Brushes.Black, new RectangleF(rongNhan + rong + 4, y - 4, 45, caoThanh + 8), canhGiua);
            }
            g.DrawLine(Pens.Gray, rongNhan, le, rongNhan, pnlBieuDo.ClientSize.Height - le);
        }

        void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            if (bangThongKe == null) return;
            string loc = "Khóa: " + cboKhoaHoc.Text + ", ngành: " + cboNganh.Text;
            // xuất danh sách toàn bộ sinh viên theo bộ lọc, không chỉ nhóm đang chọn
            dgvThongKe.ClearSelection();
            XuatExcel.xuat("ThongKe",
                ("Thống kê", "THỐNG KÊ SINH VIÊN THEO " + cboLoai.Text.ToUpper() + " (" + loc + ")", dgvThongKe),
                ("Danh sách SV", "DANH SÁCH SINH VIÊN (" + loc + ")", dgvChiTiet));
        }
    }
}
