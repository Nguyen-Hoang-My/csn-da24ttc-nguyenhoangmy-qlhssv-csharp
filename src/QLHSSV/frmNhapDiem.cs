using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    public partial class frmNhapDiem : Form
    {
        DangKyHoc dangKyHoc;
        DataTable? bangDiem;
        string maHocKyDangNhap = "";
        string maHPDangNhap = "";
        decimal tyLeQuaTrinh = 0.5m;
        bool dangNapDanhMuc = false;

        public frmNhapDiem()
        {
            InitializeComponent();
            dangKyHoc = new DangKyHoc();

            Load += frmNhapDiem_Load;
            FormClosing += frmNhapDiem_FormClosing;
            cboHocKy.SelectedIndexChanged += (s, e) => { if (!dangNapDanhMuc) { hoiLuuTruocKhiDoi(); napHocPhan(); } };
            cboHocPhan.SelectedIndexChanged += (s, e) => { if (!dangNapDanhMuc) { hoiLuuTruocKhiDoi(); napDiem(); } };
            dgvDiem.CellValidating += dgvDiem_CellValidating;
            dgvDiem.CellParsing += dgvDiem_CellParsing;
            dgvDiem.CellValueChanged += dgvDiem_CellValueChanged;
            dgvDiem.DataError += (s, e) =>
            {
                e.ThrowException = false;
                MessageBox.Show("Điểm không hợp lệ. Điểm phải là số từ 0 đến 10.", "Sai dữ liệu");
            };
            btnLuu.Click += (s, e) => luuDiem(true);
            btnTaiLai.Click += (s, e) => napDiem();
        }

        void frmNhapDiem_Load(object? sender, EventArgs e)
        {
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToDeleteRows = false;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDiem.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
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
                cboHocPhan.DropDownStyle = ComboBoxStyle.DropDownList;
                cboHocPhan.DisplayMember = "HIENTHI";
                cboHocPhan.ValueMember = "MAHP";
                dangNapDanhMuc = false;
                napHocPhan();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void napHocPhan()
        {
            try
            {
                dangNapDanhMuc = true;
                cboHocPhan.DataSource = dangKyHoc.getHocPhanCoDangKy(cboHocKy.SelectedValue as string ?? "");
                dangNapDanhMuc = false;
                napDiem();
            }
            catch (SqlException ex)
            {
                dangNapDanhMuc = false;
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        void napDiem()
        {
            maHocKyDangNhap = cboHocKy.SelectedValue as string ?? "";
            maHPDangNhap = cboHocPhan.SelectedValue as string ?? "";
            if (maHPDangNhap == "")
            {
                bangDiem = null;
                dgvDiem.DataSource = null;
                lblTyLe.Text = "Học kỳ này chưa có sinh viên nào đăng ký học phần.";
                lblTrangThai.Text = "";
                return;
            }
            try
            {
                tyLeQuaTrinh = 0.5m;
                if (cboHocPhan.SelectedItem is DataRowView hp && hp["TYLEQUATRINH"] is decimal tl) tyLeQuaTrinh = tl;
                int phanTramQT = (int)Math.Round(tyLeQuaTrinh * 100);
                lblTyLe.Text = "Điểm học phần = Quá trình × " + phanTramQT + "% + Thi × " + (100 - phanTramQT) + "%";

                bangDiem = dangKyHoc.getDanhSachNhapDiem(maHocKyDangNhap, maHPDangNhap);
                dgvDiem.DataSource = bangDiem;
                foreach (DataGridViewColumn cot in dgvDiem.Columns) cot.ReadOnly = true;
                dgvDiem.Columns["DIEMQUATRINH"].ReadOnly = tyLeQuaTrinh == 0;
                dgvDiem.Columns["DIEMTHI"].ReadOnly = false;
                dgvDiem.Columns["DIEMTHILAN2"].ReadOnly = false;
                dgvDiem.Columns["MASV"].HeaderText = "Mã SV";
                dgvDiem.Columns["HOTEN"].HeaderText = "Họ và tên";
                dgvDiem.Columns["MALOP"].HeaderText = "Lớp";
                dgvDiem.Columns["DIEMQUATRINH"].HeaderText = tyLeQuaTrinh == 0 ? "Quá trình (không có)" : "Điểm quá trình";
                dgvDiem.Columns["DIEMTHI"].HeaderText = "Điểm thi lần 1";
                dgvDiem.Columns["DIEMTHILAN2"].HeaderText = "Điểm thi lần 2";
                dgvDiem.Columns["DIEMHP"].HeaderText = "Điểm học phần";
                dgvDiem.Columns["DIEMCHU"].HeaderText = "Điểm chữ";
                dgvDiem.Columns["DIEMQUATRINH"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["DIEMTHI"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["DIEMTHILAN2"].DefaultCellStyle.Format = "0.##";
                dgvDiem.Columns["DIEMHP"].DefaultCellStyle.Format = "0.0";
                dgvDiem.Columns["HOTEN"].Width = 220;
                Color nenNhap = Color.FromArgb(255, 255, 225);
                if (tyLeQuaTrinh > 0) dgvDiem.Columns["DIEMQUATRINH"].DefaultCellStyle.BackColor = nenNhap;
                dgvDiem.Columns["DIEMTHI"].DefaultCellStyle.BackColor = nenNhap;
                dgvDiem.Columns["DIEMTHILAN2"].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 225);
                lblTrangThai.Text = bangDiem.Rows.Count + " sinh viên.";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
        }

        bool laCotDiem(int cot)
        {
            if (cot < 0) return false;
            string ten = dgvDiem.Columns[cot].Name;
            return ten == "DIEMQUATRINH" || ten == "DIEMTHI" || ten == "DIEMTHILAN2";
        }

        decimal? docDiem(string s, out bool hopLe)
        {
            hopLe = true;
            s = s.Trim().Replace(',', '.');
            if (s == "") return null;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal d) && d >= 0 && d <= 10)
                return Math.Round(d, 2, MidpointRounding.AwayFromZero);
            hopLe = false;
            return null;
        }

        decimal? giaTri(DataRow dong, string cot)
        {
            return dong[cot] == DBNull.Value ? null : (decimal)dong[cot];
        }

        decimal? diemLan1(DataRow dong)
        {
            return QuyCheDiem.diemHocPhan(giaTri(dong, "DIEMQUATRINH"), giaTri(dong, "DIEMTHI"), null, tyLeQuaTrinh);
        }

        void dgvDiem_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!laCotDiem(e.ColumnIndex) || dgvDiem.Columns[e.ColumnIndex].ReadOnly) return;
            decimal? d = docDiem(e.FormattedValue?.ToString() ?? "", out bool hopLe);
            string loi = hopLe ? "" : "Điểm phải là số từ 0 đến 10";
            if (hopLe && d != null && dgvDiem.Columns[e.ColumnIndex].Name == "DIEMTHILAN2"
                && dgvDiem.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                decimal? lan1 = diemLan1(drv.Row);
                if (lan1 == null) loi = "Chưa có đủ điểm lần 1 nên chưa nhập điểm thi lần 2 được";
                else if (lan1 >= 4.0m) loi = "Chỉ sinh viên bị điểm F ở lần 1 mới được thi lần 2";
            }
            dgvDiem.Rows[e.RowIndex].ErrorText = loi;
            if (loi != "")
            {
                e.Cancel = true;
                MessageBox.Show(loi + ".", "Sai dữ liệu");
            }
        }

        void dgvDiem_CellParsing(object? sender, DataGridViewCellParsingEventArgs e)
        {
            if (!laCotDiem(e.ColumnIndex)) return;
            decimal? d = docDiem(e.Value?.ToString() ?? "", out bool hopLe);
            if (!hopLe) return;
            e.Value = d.HasValue ? (object)d.Value : DBNull.Value;
            e.ParsingApplied = true;
        }

        void dgvDiem_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !laCotDiem(e.ColumnIndex)) return;
            if (dgvDiem.Rows[e.RowIndex].DataBoundItem is not DataRowView drv) return;
            DataRow dong = drv.Row;
            decimal? diemHP = QuyCheDiem.diemHocPhan(giaTri(dong, "DIEMQUATRINH"), giaTri(dong, "DIEMTHI"),
                                                     giaTri(dong, "DIEMTHILAN2"), tyLeQuaTrinh);
            dong["DIEMHP"] = diemHP.HasValue ? (object)diemHP.Value : DBNull.Value;
            dong["DIEMCHU"] = QuyCheDiem.diemChu(diemHP);
            lblTrangThai.Text = "Có điểm chưa lưu.";
        }

        bool coThayDoiChuaLuu()
        {
            dgvDiem.EndEdit();
            return bangDiem != null && bangDiem.GetChanges(DataRowState.Modified) != null;
        }

        void hoiLuuTruocKhiDoi()
        {
            if (!coThayDoiChuaLuu()) return;
            DialogResult traLoi = MessageBox.Show("Có điểm chưa lưu của học phần " + maHPDangNhap + ". Lưu trước khi chuyển?",
                                                  "Chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi == DialogResult.Yes) luuDiem(false);
        }

        bool luuDiem(bool napLai)
        {
            if (!coThayDoiChuaLuu() || bangDiem == null)
            {
                if (napLai) MessageBox.Show("Không có điểm nào thay đổi.", "Thông báo");
                return true;
            }
            DataTable? thayDoi = bangDiem.GetChanges(DataRowState.Modified);
            if (thayDoi == null) return true;
            List<string> saiThiLan2 = new List<string>();
            foreach (DataRow dong in thayDoi.Rows)
            {
                if (dong["DIEMTHILAN2"] == DBNull.Value) continue;
                decimal? lan1 = diemLan1(dong);
                if (lan1 == null || lan1 >= 4.0m) saiThiLan2.Add(dong["MASV"].ToString() ?? "");
            }
            if (saiThiLan2.Count > 0)
            {
                MessageBox.Show("Các sinh viên sau có điểm thi lần 2 nhưng lần 1 không bị F (hoặc chưa đủ điểm lần 1): " +
                                string.Join(", ", saiThiLan2) + ". Xóa điểm thi lần 2 hoặc sửa lại điểm lần 1 rồi lưu.", "Chưa lưu");
                return false;
            }
            int daLuu = 0;
            try
            {
                foreach (DataRow dong in thayDoi.Rows)
                {
                    dangKyHoc.capNhatDiem(dong["MASV"].ToString() ?? "", maHPDangNhap, maHocKyDangNhap,
                                          dong["DIEMQUATRINH"], dong["DIEMTHI"], dong["DIEMTHILAN2"]);
                    daLuu++;
                }
                bangDiem.AcceptChanges();
                if (napLai)
                {
                    napDiem();
                    MessageBox.Show("Đã lưu điểm của " + daLuu + " sinh viên.", "Thông báo");
                }
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lưu được " + daLuu + " sinh viên rồi bị lỗi: " + DangKyHoc.loiSQL(ex), "Lỗi");
                return false;
            }
        }

        void frmNhapDiem_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!coThayDoiChuaLuu()) return;
            DialogResult traLoi = MessageBox.Show("Có điểm chưa lưu. Lưu trước khi đóng?", "Chưa lưu",
                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (traLoi == DialogResult.Cancel) e.Cancel = true;
            else if (traLoi == DialogResult.Yes && !luuDiem(false)) e.Cancel = true;
        }
    }
}
