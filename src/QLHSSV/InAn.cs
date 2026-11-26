using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP XỬ LÝ lấy dữ liệu cho các mẫu in (hồ sơ sinh viên, bảng điểm toàn khóa).
    // Ngày tháng được đổi sẵn sang chuỗi dd/MM/yyyy để mẫu in chỉ việc hiển thị.
    class InAn
    {
        ThaotacCSDL db;

        public InAn()
        {
            db = new ThaotacCSDL();
        }

        public DataTable getHoSo(string maSV)
        {
            string sql =
                "SELECT s.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, CONVERT(varchar(10), s.NGAYSINH, 103) AS NGAYSINH, " +
                "s.GIOITINH, s.SOCCCD, ISNULL(CONVERT(varchar(10), s.NGAYCAPCCCD, 103), '') AS NGAYCAPCCCD, " +
                "s.DANTOC, ISNULL(s.TONGIAO, N'') AS TONGIAO, s.QUOCTICH, ISNULL(s.NOISINH, N'') AS NOISINH, " +
                "ISNULL(s.QUEQUAN, N'') AS QUEQUAN, " +
                "ISNULL(s.SONHA + N' ', N'') + s.TENDUONG + N', ' + x.TENXA + N', ' + t.TENTINH AS DIACHI, " +
                "ISNULL(s.SODIENTHOAI, N'') AS SODIENTHOAI, ISNULL(s.EMAIL, '') AS EMAIL, ISNULL(s.EMAILPHU, '') AS EMAILPHU, " +
                "ISNULL(s.HOTENCHA, N'') AS HOTENCHA, ISNULL(s.HOTENME, N'') AS HOTENME, " +
                "n.TENNGANH, kh.TENKHOA, k.TENKHOAHOC, s.MALOP, s.HEDAOTAO, " +
                "CONVERT(varchar(10), s.NGAYNHAPHOC, 103) AS NGAYNHAPHOC, s.TINHTRANG, " +
                "ISNULL(s.TRUONGTHPT, N'') AS TRUONGTHPT, ISNULL(CONVERT(varchar(4), s.NAMTNTHPT), '') AS NAMTNTHPT, " +
                "ISNULL(s.PHUONGTHUCXETTUYEN, N'') AS PHUONGTHUCXETTUYEN, ISNULL(s.TOHOPXETTUYEN, '') AS TOHOPXETTUYEN, " +
                "ISNULL(CONVERT(varchar(10), s.DIEMXETTUYEN), '') AS DIEMXETTUYEN, " +
                "ISNULL(s.DOITUONGUUTIEN, '') AS DOITUONGUUTIEN, ISNULL(s.KHUVUCUUTIEN, '') AS KHUVUCUUTIEN, " +
                "ISNULL(s.ANHTHE, '') AS ANHTHE " +
                "FROM SINHVIEN s JOIN XAPHUONG x ON s.MAXA = x.MAXA JOIN TINHTHANH t ON x.MATINH = t.MATINH " +
                "JOIN NGANH n ON s.MANGANH = n.MANGANH JOIN BOMON b ON n.MABOMON = b.MABOMON " +
                "JOIN KHOA kh ON b.MAKHOA = kh.MAKHOA JOIN KHOAHOC k ON s.MAKHOAHOC = k.MAKHOAHOC " +
                "WHERE s.MASV = @sv";
            DataTable kq = db.execute(sql, new SqlParameter("@sv", maSV));

            // Ảnh thẻ lưu dạng đường dẫn tương đối (AnhThe\MASV.jpg) nên đọc file ra mảng byte cho mẫu in
            kq.Columns.Add("ANH", typeof(byte[]));
            kq.Columns.Add("ANHMIME", typeof(string));
            foreach (DataRow r in kq.Rows)
            {
                string duongDan = r["ANHTHE"].ToString() ?? "";
                if (duongDan == "") continue;
                string day = Path.Combine(Application.StartupPath, duongDan);
                if (!File.Exists(day)) continue;
                r["ANH"] = File.ReadAllBytes(day);
                string duoi = Path.GetExtension(day).ToLower();
                r["ANHMIME"] = duoi == ".png" ? "image/png" : duoi == ".bmp" ? "image/bmp" : "image/jpeg";
            }
            return kq;
        }

        // Liệt kê toàn bộ giấy tờ trong danh mục, đánh dấu cái nào sinh viên đã nộp
        public DataTable getGiayTo(string maSV)
        {
            string sql =
                "SELECT ROW_NUMBER() OVER (ORDER BY g.MAGIAYTO) AS STT, g.TENGIAYTO, " +
                "CASE WHEN g.BATBUOC = 1 THEN N'Có' ELSE N'Không' END AS BATBUOC, " +
                "CASE WHEN n.MASV IS NULL THEN N'Chưa nộp' ELSE N'Đã nộp' END AS TINHTRANG, " +
                "ISNULL(CONVERT(varchar(10), n.NGAYNOP, 103), '') AS NGAYNOP, ISNULL(n.HINHTHUC, N'') AS HINHTHUC " +
                "FROM GIAYTO g LEFT JOIN NOP n ON n.MAGIAYTO = g.MAGIAYTO AND n.MASV = @sv " +
                "ORDER BY g.MAGIAYTO";
            return db.execute(sql, new SqlParameter("@sv", maSV));
        }

        // Thông tin đầu trang của bảng điểm
        public DataTable getThongTinBangDiem(string maSV)
        {
            string sql =
                "SELECT s.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, CONVERT(varchar(10), s.NGAYSINH, 103) AS NGAYSINH, " +
                "n.TENNGANH, kh.TENKHOA, s.MALOP, k.TENKHOAHOC " +
                "FROM SINHVIEN s JOIN NGANH n ON s.MANGANH = n.MANGANH JOIN BOMON b ON n.MABOMON = b.MABOMON " +
                "JOIN KHOA kh ON b.MAKHOA = kh.MAKHOA JOIN KHOAHOC k ON s.MAKHOAHOC = k.MAKHOAHOC " +
                "WHERE s.MASV = @sv";
            return db.execute(sql, new SqlParameter("@sv", maSV));
        }
    }
}
