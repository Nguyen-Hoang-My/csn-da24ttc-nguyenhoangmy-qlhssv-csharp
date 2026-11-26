using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP GIAO DIỆN cho hồ sơ sinh viên
    public partial class frmSinhVien : Form
    {
        SinhVien sinhVien;
        string anhThe = "";           
        bool dangNapDanhMuc = false;   
        string maSVChiXem = "";        

        public frmSinhVien()
        {
            InitializeComponent();
            sinhVien = new SinhVien();

            Load += frmSinhVien_Load;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnInHoSo.Click += (s, e) => frmXemIn.inHoSo(txtMaSV.Text.Trim());
            btnTim.Click += (s, e) => napLuoi();
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { napLuoi(); e.SuppressKeyPress = true; }
            };
            cboLocNganh.SelectedIndexChanged += (s, e) => napLuoi();
            cboLocKhoaHoc.SelectedIndexChanged += (s, e) => napLuoi();
            cboTinh.SelectedIndexChanged += (s, e) => napXa();
            btnChonAnh.Click += btnChonAnh_Click;
            btnBoAnh.Click += (s, e) => { anhThe = ""; hienAnh(); };
            
            clbGiayTo.ItemCheck += (s, e) => BeginInvoke(new Action(capNhatGiayToThieu));
        }

        
        public frmSinhVien(string maSVChiXem) : this()
        {
            this.maSVChiXem = maSVChiXem;
        }

        void frmSinhVien_Load(object? sender, EventArgs e)
        {
            
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboHeDaoTao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHeDaoTao.Items.AddRange(new object[] { "Chính quy", "Vừa làm vừa học", "Liên thông", "Văn bằng 2" });
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Thôi học", "Đã tốt nghiệp" });
            cboKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhuVuc.Items.AddRange(new object[] { "", "KV1", "KV2-NT", "KV2", "KV3" });
            
            cboPhuongThuc.Items.AddRange(new object[] { "Điểm thi tốt nghiệp THPT", "Học bạ THPT",
                                                        "Đánh giá năng lực", "Xét tuyển thẳng" });

            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
            txtMaSV.MaxLength = 10; txtHoLot.MaxLength = 50; txtTen.MaxLength = 20;
            txtSoCCCD.MaxLength = 12; txtDanToc.MaxLength = 30; txtTonGiao.MaxLength = 30;
            txtQuocTich.MaxLength = 30; txtNoiSinh.MaxLength = 100; txtQueQuan.MaxLength = 100;
            txtMaLop.MaxLength = 10; txtSDT.MaxLength = 10; txtEmail.MaxLength = 100;
            txtEmailPhu.MaxLength = 100; txtSoNha.MaxLength = 50; txtTenDuong.MaxLength = 100;
            txtHoTenCha.MaxLength = 100; txtHoTenMe.MaxLength = 100; txtTruongTHPT.MaxLength = 100;
            txtNamTN.MaxLength = 4; cboPhuongThuc.MaxLength = 50; txtToHop.MaxLength = 5;
            txtDiemXT.MaxLength = 6; txtDoiTuong.MaxLength = 5;

            try
            {
                napDanhMuc();
                if (maSVChiXem != "")
                {
                    cheDoChiXem();
                    return;
                }
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        
        void cheDoChiXem()
        {
            Text = "Hồ sơ của tôi";
            foreach (Control c in new Control[] { btnThem, btnSua, btnXoa, btnLamMoi, btnInHoSo, lbTimKiem, txtTimKiem,
                                                  btnTim, lbLocNganh, cboLocNganh, lbLocKhoaHoc, cboLocKhoaHoc,
                                                  lblTongSo, dgvSinhVien, btnChonAnh, btnBoAnh })
                c.Visible = false;

            foreach (TabPage trang in tabHoSo.TabPages)
            {
                foreach (Control c in trang.Controls)
                {
                    if (c is TextBox o) o.ReadOnly = true;
                    else if (c is ComboBox || c is DateTimePicker || c is CheckedListBox) c.Enabled = false;
                }
            }
            ClientSize = new Size(1000, 275);    

            DataRow? sv = sinhVien.getSinhVien(maSVChiXem);
            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy hồ sơ của sinh viên " + maSVChiXem + ".", "Thông báo");
                return;
            }
            hienSinhVien(sv);
        }

        

        void napDanhMuc()
        {
            dangNapDanhMuc = true;
            ganCombo(cboNganh, sinhVien.getDanhSachNganh(), "TENNGANH", "MANGANH");
            ganCombo(cboKhoaHoc, sinhVien.getDanhSachKhoaHoc(), "TENKHOAHOC", "MAKHOAHOC");
            ganCombo(cboTinh, sinhVien.getDanhSachTinh(), "TENTINH", "MATINH");
            cboXa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboXa.DisplayMember = "TENXA";
            cboXa.ValueMember = "MAXA";
            
            ganCombo(cboLocNganh, themDongTatCa(sinhVien.getDanhSachNganh(), "MANGANH", "TENNGANH"),
                     "TENNGANH", "MANGANH");
            ganCombo(cboLocKhoaHoc, themDongTatCa(sinhVien.getDanhSachKhoaHoc(), "MAKHOAHOC", "TENKHOAHOC"),
                     "TENKHOAHOC", "MAKHOAHOC");

            clbGiayTo.Items.Clear();
            foreach (DataRow r in sinhVien.getDanhSachGiayTo().Rows)
            {
                clbGiayTo.Items.Add(new MucGiayTo
                {
                    Ma = r["MAGIAYTO"].ToString() ?? "",
                    Ten = r["TENGIAYTO"].ToString() ?? "",
                    BatBuoc = (bool)r["BATBUOC"]
                });
            }
            dangNapDanhMuc = false;
            napXa();
        }

        void ganCombo(ComboBox c, DataTable bang, string cotHien, string cotGiaTri)
        {
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            c.DisplayMember = cotHien;
            c.ValueMember = cotGiaTri;
            c.DataSource = bang;
        }

        
        DataTable themDongTatCa(DataTable bang, string cotMa, string cotTen)
        {
            DataRow dong = bang.NewRow();
            dong[cotMa] = "";
            dong[cotTen] = "(Tất cả)";
            bang.Rows.InsertAt(dong, 0);
            return bang;
        }

        
        void napXa()
        {
            if (dangNapDanhMuc) return;
            string maTinh = cboTinh.SelectedValue as string ?? "";
            cboXa.DataSource = sinhVien.getDanhSachXa(maTinh);
        }

        

        void napLuoi()
        {
            if (dangNapDanhMuc) return;
            try
            {
                string nganh = cboLocNganh.SelectedValue as string ?? "";
                string khoa = cboLocKhoaHoc.SelectedValue as string ?? "";
                DataTable bang = sinhVien.locSinhVien(nganh, khoa, txtTimKiem.Text);

                dgvSinhVien.DataSource = bang;
                dgvSinhVien.Columns["MASV"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["HOTEN"].HeaderText = "Họ và tên";
                dgvSinhVien.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvSinhVien.Columns["GIOITINH"].HeaderText = "Giới tính";
                dgvSinhVien.Columns["TENNGANH"].HeaderText = "Ngành";
                dgvSinhVien.Columns["TENKHOAHOC"].HeaderText = "Khóa";
                dgvSinhVien.Columns["MALOP"].HeaderText = "Lớp";
                dgvSinhVien.Columns["TINHTRANG"].HeaderText = "Tình trạng";
                dgvSinhVien.Columns["HOTEN"].Width = 180;
                dgvSinhVien.Columns["TENNGANH"].Width = 180;
                dgvSinhVien.ClearSelection();
                lblTongSo.Text = "Tổng: " + bang.Rows.Count + " sinh viên";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        

        void lamMoi()
        {
            foreach (TextBox t in new[] { txtMaSV, txtHoLot, txtTen, txtSoCCCD, txtTonGiao, txtNoiSinh,
                                          txtQueQuan, txtMaLop, txtSDT, txtEmail, txtEmailPhu, txtSoNha,
                                          txtTenDuong, txtHoTenCha, txtHoTenMe, txtTruongTHPT, txtNamTN,
                                          txtToHop, txtDiemXT, txtDoiTuong })
                t.Clear();

            
            txtDanToc.Text = "Kinh";
            txtQuocTich.Text = "Việt Nam";
            dtpNgaySinh.Value = new DateTime(DateTime.Today.Year - 18, 1, 1);
            dtpNgayCap.Value = DateTime.Today;
            dtpNgayCap.Checked = false;
            dtpNgayNhapHoc.Value = DateTime.Today;
            cboGioiTinh.SelectedIndex = 0;
            cboHeDaoTao.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;
            cboKhuVuc.SelectedIndex = 0;
            cboPhuongThuc.Text = "";
            if (cboNganh.Items.Count > 0) cboNganh.SelectedIndex = 0;
            if (cboKhoaHoc.Items.Count > 0) cboKhoaHoc.SelectedIndex = 0;
            if (cboTinh.Items.Count > 0) cboTinh.SelectedIndex = 0;

            anhThe = "";
            hienAnh();
            for (int i = 0; i < clbGiayTo.Items.Count; i++) clbGiayTo.SetItemChecked(i, false);
            capNhatGiayToThieu();

            txtMaSV.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoSo.Enabled = false;
            dgvSinhVien.ClearSelection();
            tabHoSo.SelectedIndex = 0;
            txtMaSV.Focus();
        }

        void dgvSinhVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maSV = dgvSinhVien.Rows[e.RowIndex].Cells["MASV"].Value?.ToString() ?? "";
            try
            {
                DataRow? sv = sinhVien.getSinhVien(maSV);
                if (sv == null) return;
                hienSinhVien(sv);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        
        void hienSinhVien(DataRow sv)
        {
            
            txtMaSV.Text = chuoi(sv, "MASV");
            txtHoLot.Text = chuoi(sv, "HOLOT");
            txtTen.Text = chuoi(sv, "TEN");
            dtpNgaySinh.Value = (DateTime)sv["NGAYSINH"];
            chonMuc(cboGioiTinh, chuoi(sv, "GIOITINH"));
            txtSoCCCD.Text = chuoi(sv, "SOCCCD");
            if (sv["NGAYCAPCCCD"] is DateTime ngayCap)
            {
                dtpNgayCap.Value = ngayCap;
                dtpNgayCap.Checked = true;
            }
            else
            {
                dtpNgayCap.Value = DateTime.Today;
                dtpNgayCap.Checked = false;
            }
            txtDanToc.Text = chuoi(sv, "DANTOC");
            txtTonGiao.Text = chuoi(sv, "TONGIAO");
            txtQuocTich.Text = chuoi(sv, "QUOCTICH");
            txtNoiSinh.Text = chuoi(sv, "NOISINH");
            txtQueQuan.Text = chuoi(sv, "QUEQUAN");

            
            cboNganh.SelectedValue = chuoi(sv, "MANGANH");
            cboKhoaHoc.SelectedValue = chuoi(sv, "MAKHOAHOC");
            txtMaLop.Text = chuoi(sv, "MALOP");
            chonMuc(cboHeDaoTao, chuoi(sv, "HEDAOTAO"));
            dtpNgayNhapHoc.Value = (DateTime)sv["NGAYNHAPHOC"];
            chonMuc(cboTinhTrang, chuoi(sv, "TINHTRANG"));

            
            txtSDT.Text = chuoi(sv, "SODIENTHOAI");
            txtEmail.Text = chuoi(sv, "EMAIL");
            txtEmailPhu.Text = chuoi(sv, "EMAILPHU");
            cboTinh.SelectedValue = chuoi(sv, "MATINH");
            cboXa.SelectedValue = chuoi(sv, "MAXA");
            txtSoNha.Text = chuoi(sv, "SONHA");
            txtTenDuong.Text = chuoi(sv, "TENDUONG");

            
            txtHoTenCha.Text = chuoi(sv, "HOTENCHA");
            txtHoTenMe.Text = chuoi(sv, "HOTENME");
            txtTruongTHPT.Text = chuoi(sv, "TRUONGTHPT");
            txtNamTN.Text = chuoi(sv, "NAMTNTHPT");
            cboPhuongThuc.Text = chuoi(sv, "PHUONGTHUCXETTUYEN");
            txtToHop.Text = chuoi(sv, "TOHOPXETTUYEN");
            txtDiemXT.Text = sv["DIEMXETTUYEN"] is decimal diem
                             ? diem.ToString("0.00", CultureInfo.InvariantCulture) : "";
            txtDoiTuong.Text = chuoi(sv, "DOITUONGUUTIEN");
            chonMuc(cboKhuVuc, chuoi(sv, "KHUVUCUUTIEN"));

            
            anhThe = chuoi(sv, "ANHTHE");
            hienAnh();

            
            HashSet<string> daNop = new HashSet<string>();
            foreach (DataRow r in sinhVien.getGiayToDaNop(txtMaSV.Text).Rows)
                daNop.Add(r["MAGIAYTO"].ToString() ?? "");
            for (int i = 0; i < clbGiayTo.Items.Count; i++)
                clbGiayTo.SetItemChecked(i, daNop.Contains(((MucGiayTo)clbGiayTo.Items[i]).Ma));
            capNhatGiayToThieu();

            txtMaSV.Enabled = false;     
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnInHoSo.Enabled = true;   // chỉ in hồ sơ đã lưu trong CSDL
        }

        string chuoi(DataRow dong, string cot)
        {
            return dong[cot] == DBNull.Value ? "" : dong[cot].ToString() ?? "";
        }

        
        void chonMuc(ComboBox c, string giaTri)
        {
            int viTri = c.Items.IndexOf(giaTri);
            if (viTri < 0)
            {
                c.Items.Add(giaTri);
                viTri = c.Items.IndexOf(giaTri);
            }
            c.SelectedIndex = viTri;
        }

       
        bool baoLoi(Control o, string thongBao)
        {
            Control? cha = o.Parent;
            while (cha != null && !(cha is TabPage)) cha = cha.Parent;
            if (cha is TabPage trang) tabHoSo.SelectedTab = trang;
            MessageBox.Show(thongBao, "Kiểm tra dữ liệu");
            o.Focus();
            return false;
        }

        bool duLieuHopLe(bool dangThem)
        {
            string maSV = txtMaSV.Text.Trim();
            if (maSV == "") return baoLoi(txtMaSV, "Chưa nhập mã sinh viên.");
            if (txtHoLot.Text.Trim() == "") return baoLoi(txtHoLot, "Chưa nhập họ lót.");
            if (txtTen.Text.Trim() == "") return baoLoi(txtTen, "Chưa nhập tên.");

            DateTime ngaySinh = dtpNgaySinh.Value.Date, ngayNhapHoc = dtpNgayNhapHoc.Value.Date;
            if (ngaySinh.AddYears(15) > ngayNhapHoc)
                return baoLoi(dtpNgaySinh, "Ngày sinh không hợp lý: sinh viên phải đủ 15 tuổi khi nhập học.");

            if (!Regex.IsMatch(txtSoCCCD.Text.Trim(), @"^\d{12}$"))
                return baoLoi(txtSoCCCD, "Số CCCD phải gồm đúng 12 chữ số.");
            if (dtpNgayCap.Checked && (dtpNgayCap.Value.Date > DateTime.Today || dtpNgayCap.Value.Date < ngaySinh))
                return baoLoi(dtpNgayCap, "Ngày cấp CCCD phải sau ngày sinh và không quá hôm nay.");
            if (txtDanToc.Text.Trim() == "") return baoLoi(txtDanToc, "Chưa nhập dân tộc.");
            if (txtQuocTich.Text.Trim() == "") return baoLoi(txtQuocTich, "Chưa nhập quốc tịch.");

            if (cboNganh.SelectedValue == null) return baoLoi(cboNganh, "Chưa chọn ngành.");
            if (cboKhoaHoc.SelectedValue == null) return baoLoi(cboKhoaHoc, "Chưa chọn khóa học.");
            if (txtMaLop.Text.Trim() == "") return baoLoi(txtMaLop, "Chưa nhập mã lớp.");

            string sdt = txtSDT.Text.Trim();
            if (sdt != "" && !Regex.IsMatch(sdt, @"^0\d{9}$"))
                return baoLoi(txtSDT, "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng số 0.");
            if (!emailHopLe(txtEmail.Text)) return baoLoi(txtEmail, "Email không đúng dạng, ví dụ ten@gmail.com.");
            if (!emailHopLe(txtEmailPhu.Text)) return baoLoi(txtEmailPhu, "Email phụ không đúng dạng.");
            if (cboXa.SelectedValue == null) return baoLoi(cboXa, "Chưa chọn xã/phường.");
            if (txtTenDuong.Text.Trim() == "") return baoLoi(txtTenDuong, "Chưa nhập tên đường hoặc ấp.");

            if (txtNamTN.Text.Trim() != "" && docNamTN() == null)
                return baoLoi(txtNamTN, "Năm tốt nghiệp THPT phải là năm từ 1990 đến nay.");
            if (txtDiemXT.Text.Trim() != "" && docDiemXT() == null)
                return baoLoi(txtDiemXT, "Điểm xét tuyển phải là số từ 0 đến 40, ví dụ 24.5.");

            if (dangThem && sinhVien.tonTaiMaSV(maSV))
                return baoLoi(txtMaSV, "Mã sinh viên này đã có rồi.");
            if (sinhVien.tonTaiCCCD(txtSoCCCD.Text, dangThem ? "" : maSV))
                return baoLoi(txtSoCCCD, "Số CCCD này đã thuộc về một sinh viên khác.");
            return true;
        }

        bool emailHopLe(string email)
        {
            email = email.Trim();
            return email == "" || Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        short? docNamTN()
        {
            if (short.TryParse(txtNamTN.Text.Trim(), out short nam) && nam >= 1990 && nam <= DateTime.Today.Year)
                return nam;
            return null;
        }

        decimal? docDiemXT()
        {
            string s = txtDiemXT.Text.Trim().Replace(',', '.');
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal d)
                && d >= 0 && d <= 40)
                return Math.Round(d, 2);
            return null;
        }

        
        string? rong(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }

        
        Dictionary<string, object?> layDuLieu()
        {
            return new Dictionary<string, object?>
            {
                ["MASV"] = txtMaSV.Text.Trim(),
                ["MAXA"] = cboXa.SelectedValue?.ToString(),
                ["MANGANH"] = cboNganh.SelectedValue?.ToString(),
                ["MAKHOAHOC"] = cboKhoaHoc.SelectedValue?.ToString(),
                ["HOLOT"] = txtHoLot.Text.Trim(),
                ["TEN"] = txtTen.Text.Trim(),
                ["NGAYSINH"] = dtpNgaySinh.Value.Date,
                ["GIOITINH"] = cboGioiTinh.Text,
                ["SODIENTHOAI"] = rong(txtSDT.Text),
                ["EMAIL"] = rong(txtEmail.Text),
                ["NGAYNHAPHOC"] = dtpNgayNhapHoc.Value.Date,
                ["TINHTRANG"] = cboTinhTrang.Text,
                ["SONHA"] = rong(txtSoNha.Text),
                ["TENDUONG"] = txtTenDuong.Text.Trim(),
                ["SOCCCD"] = txtSoCCCD.Text.Trim(),
                ["DANTOC"] = txtDanToc.Text.Trim(),
                ["TONGIAO"] = rong(txtTonGiao.Text),
                ["NOISINH"] = rong(txtNoiSinh.Text),
                ["QUOCTICH"] = txtQuocTich.Text.Trim(),
                ["EMAILPHU"] = rong(txtEmailPhu.Text),
                ["ANHTHE"] = rong(anhThe),
                ["MALOP"] = txtMaLop.Text.Trim(),
                ["HEDAOTAO"] = cboHeDaoTao.Text,
                ["NGAYCAPCCCD"] = dtpNgayCap.Checked ? (object?)dtpNgayCap.Value.Date : null,
                ["QUEQUAN"] = rong(txtQueQuan.Text),
                ["HOTENCHA"] = rong(txtHoTenCha.Text),
                ["HOTENME"] = rong(txtHoTenMe.Text),
                ["TRUONGTHPT"] = rong(txtTruongTHPT.Text),
                ["NAMTNTHPT"] = docNamTN(),
                ["PHUONGTHUCXETTUYEN"] = rong(cboPhuongThuc.Text),
                ["TOHOPXETTUYEN"] = rong(txtToHop.Text.ToUpper()),
                ["DIEMXETTUYEN"] = docDiemXT(),
                ["DOITUONGUUTIEN"] = rong(txtDoiTuong.Text),
                ["KHUVUCUUTIEN"] = rong(cboKhuVuc.Text)
            };
        }

      

        List<string> giayToDaChon()
        {
            return clbGiayTo.CheckedItems.Cast<MucGiayTo>().Select(g => g.Ma).ToList();
        }

        void capNhatGiayToThieu()
        {
            List<string> thieu = new List<string>();
            for (int i = 0; i < clbGiayTo.Items.Count; i++)
            {
                MucGiayTo g = (MucGiayTo)clbGiayTo.Items[i];
                if (g.BatBuoc && !clbGiayTo.GetItemChecked(i)) thieu.Add(g.Ten);
            }
            if (thieu.Count == 0)
            {
                lblGiayToThieu.ForeColor = Color.Green;
                lblGiayToThieu.Text = "Đã nộp đủ giấy tờ bắt buộc.";
            }
            else
            {
                lblGiayToThieu.ForeColor = Color.Firebrick;
                lblGiayToThieu.Text = "Còn thiếu " + thieu.Count + " giấy tờ bắt buộc:\n- " + string.Join("\n- ", thieu);
            }
        }

        

        void btnChonAnh_Click(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (maSV == "")
            {
                baoLoi(txtMaSV, "Nhập mã sinh viên trước rồi mới chọn ảnh, vì ảnh được lưu theo mã sinh viên.");
                return;
            }
            using OpenFileDialog hop = new OpenFileDialog();
            hop.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (hop.ShowDialog() != DialogResult.OK) return;
            try
            {
                
                string thuMuc = Path.Combine(Application.StartupPath, "AnhThe");
                Directory.CreateDirectory(thuMuc);
                string tenFile = maSV + Path.GetExtension(hop.FileName).ToLower();
                string dich = Path.Combine(thuMuc, tenFile);
                if (!string.Equals(Path.GetFullPath(hop.FileName), Path.GetFullPath(dich),
                                   StringComparison.OrdinalIgnoreCase))
                    File.Copy(hop.FileName, dich, true);
                anhThe = Path.Combine("AnhThe", tenFile);
                hienAnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không chép được ảnh: " + ex.Message, "Lỗi");
            }
        }

        void hienAnh()
        {
            picAnhThe.Image?.Dispose();
            picAnhThe.Image = null;
            if (anhThe == "") return;
            string duongDan = Path.Combine(Application.StartupPath, anhThe);
            if (!File.Exists(duongDan)) return;
            
            using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
            using (Image goc = Image.FromStream(fs))
                picAnhThe.Image = new Bitmap(goc);
        }

        

        void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!duLieuHopLe(true)) return;
                string maSV = txtMaSV.Text.Trim();
                sinhVien.themSinhVien(layDuLieu());
                sinhVien.capNhatGiayTo(maSV, giayToDaChon());
                napLuoi();
                lamMoi();
                MessageBox.Show("Đã thêm sinh viên " + maSV + ".", "Thông báo");
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
                sinhVien.suaSinhVien(layDuLieu());
                sinhVien.capNhatGiayTo(txtMaSV.Text.Trim(), giayToDaChon());
                napLuoi();
                lamMoi();
                MessageBox.Show("Đã cập nhật hồ sơ.", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }

        void btnXoa_Click(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            try
            {
                int soDangKy = sinhVien.demDangKyHoc(maSV);
                if (soDangKy > 0)
                {
                    MessageBox.Show("Sinh viên này đã có " + soDangKy + " lượt đăng ký học nên không xóa được. " +
                                    "Nếu sinh viên nghỉ học, hãy đổi tình trạng thành \"Thôi học\".", "Không thể xóa");
                    return;
                }
                if (sinhVien.coTaiKhoan(maSV))
                {
                    MessageBox.Show("Sinh viên này đang có tài khoản đăng nhập. Xóa tài khoản trước rồi mới xóa hồ sơ.",
                                    "Không thể xóa");
                    return;
                }
                DialogResult traLoi = MessageBox.Show("Xóa hồ sơ sinh viên " + maSV + " - " + txtHoLot.Text + " " +
                                                      txtTen.Text + "?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi != DialogResult.Yes) return;

                sinhVien.xoaSinhVien(maSV);
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
                txtTimKiem.Clear();
                napDanhMuc();    
                napLuoi();
                lamMoi();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi");
            }
        }
    }

    
    class MucGiayTo
    {
        public string Ma = "";
        public string Ten = "";
        public bool BatBuoc;

        public override string ToString()
        {
            return BatBuoc ? Ten + " (bắt buộc)" : Ten;
        }
    }
}
