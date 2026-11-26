using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QLHSSV
{
    // Form xem trước bản in. Thanh công cụ của ReportViewer có sẵn nút In, Xuất PDF/Word/Excel.
    public partial class frmXemIn : Form
    {
        ReportViewer viewer;

        public frmXemIn(string tieuDe, string mauIn, string tenFile, Dictionary<string, DataTable> nguonDuLieu)
        {
            InitializeComponent();
            Text = tieuDe;

            // Tạo ReportViewer bằng code để trình thiết kế form của Visual Studio không bị lỗi khi mở form này
            viewer = new ReportViewer();
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);

            // Mẫu in .rdlc được nhúng vào chương trình (EmbeddedResource trong QLHSSV.csproj)
            using (Stream? luong = Assembly.GetExecutingAssembly().GetManifestResourceStream(mauIn))
            {
                if (luong == null)
                    throw new FileNotFoundException("Không tìm thấy mẫu in " + mauIn + ".");
                viewer.LocalReport.LoadReportDefinition(luong);
            }
            viewer.LocalReport.DisplayName = tenFile;
            foreach (var nguon in nguonDuLieu)
                viewer.LocalReport.DataSources.Add(new ReportDataSource(nguon.Key, nguon.Value));

            DateTime homNay = DateTime.Today;
            viewer.LocalReport.SetParameters(new ReportParameter("NgayIn",
                "Trà Vinh, ngày " + homNay.Day.ToString("00") + " tháng " + homNay.Month.ToString("00") + " năm " + homNay.Year));

            Load += (s, e) =>
            {
                viewer.SetDisplayMode(DisplayMode.PrintLayout);
                viewer.ZoomMode = ZoomMode.PageWidth;
                viewer.RefreshReport();
            };
        }

        // ---------- Hai hàm gọi nhanh dùng ở frmSinhVien và frmBangDiem ----------

        public static void inHoSo(string maSV)
        {
            try
            {
                InAn inAn = new InAn();
                DataTable hoSo = inAn.getHoSo(maSV);
                if (hoSo.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên " + maSV + ".", "Thông báo");
                    return;
                }
                var nguon = new Dictionary<string, DataTable>
                {
                    ["HoSo"] = hoSo,
                    ["GiayTo"] = inAn.getGiayTo(maSV)
                };
                using frmXemIn f = new frmXemIn("In hồ sơ sinh viên " + maSV, "HoSoSinhVien.rdlc", "HoSo_" + maSV, nguon);
                f.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được bản in: " + ex.Message, "Lỗi");
            }
        }

        public static void inBangDiem(string maSV)
        {
            try
            {
                InAn inAn = new InAn();
                DangKyHoc dangKyHoc = new DangKyHoc();
                DataTable thongTin = inAn.getThongTinBangDiem(maSV);
                if (thongTin.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên " + maSV + ".", "Thông báo");
                    return;
                }
                var nguon = new Dictionary<string, DataTable>
                {
                    ["SinhVien"] = thongTin,
                    ["Diem"] = dangKyHoc.getBangDiem(maSV),
                    ["TongKet"] = dangKyHoc.getTongKetHocKy(maSV)
                };
                using frmXemIn f = new frmXemIn("In bảng điểm " + maSV, "BangDiem.rdlc", "BangDiem_" + maSV, nguon);
                f.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + DangKyHoc.loiSQL(ex), "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được bản in: " + ex.Message, "Lỗi");
            }
        }
    }
}
