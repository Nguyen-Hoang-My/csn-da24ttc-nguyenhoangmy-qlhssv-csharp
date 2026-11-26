using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    class DangKyHoc
    {
        ThaotacCSDL db;

        public DangKyHoc()
        {
            db = new ThaotacCSDL();
        }

        public DataTable getDanhSachHocKy()
        {
            return db.execute("SELECT MAHOCKY, TENHOCKY, NGAYBATDAU, NGAYKETTHUC FROM HOCKY ORDER BY NGAYBATDAU DESC");
        }

        public DataTable timSinhVien(string tuKhoa)
        {
            string sql = "SELECT s.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, n.TENNGANH, s.MALOP, s.TINHTRANG " +
                         "FROM SINHVIEN s JOIN NGANH n ON s.MANGANH = n.MANGANH " +
                         "WHERE @tk = '' OR s.MASV LIKE @tkLike OR s.HOLOT + N' ' + s.TEN LIKE @tkLike " +
                         "ORDER BY s.MASV";
            return db.execute(sql, new SqlParameter("@tk", tuKhoa.Trim()),
                              new SqlParameter("@tkLike", "%" + tuKhoa.Trim() + "%"));
        }

        public DataRow? getThongTinSinhVien(string maSV)
        {
            string sql = "SELECT s.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, n.TENNGANH, s.MALOP, k.TENKHOAHOC, s.TINHTRANG " +
                         "FROM SINHVIEN s JOIN NGANH n ON s.MANGANH = n.MANGANH " +
                         "JOIN KHOAHOC k ON s.MAKHOAHOC = k.MAKHOAHOC WHERE s.MASV = @sv";
            DataTable kq = db.execute(sql, new SqlParameter("@sv", maSV.Trim()));
            if (kq.Rows.Count == 0) return null;
            return kq.Rows[0];
        }

        public DataTable getHocPhanCoTheDangKy(string maSV, string maHocKy)
        {
            string sql =
                "SELECT c.MAHP, h.TENHP, h.SOTINCHI, c.HOCKYDUKIEN, " +
                "CASE WHEN c.BATBUOC = 1 THEN N'Bắt buộc' ELSE N'Tự chọn' END AS LOAI, " +
                "ISNULL(kq.MOTA, N'') AS DAHOC " +
                "FROM SINHVIEN s JOIN CHUONGTRINHHOC c ON c.MANGANH = s.MANGANH " +
                "JOIN HOCPHAN h ON h.MAHP = c.MAHP " +
                "OUTER APPLY (SELECT TOP 1 CASE WHEN v.DIEMHP IS NULL THEN N'Đang học (' + v.MAHOCKY + N')' " +
                "             ELSE N'Đã học: ' + v.DIEMCHU + N' (' + v.MAHOCKY + N')' END AS MOTA " +
                "             FROM dbo.vw_DiemHocPhan v WHERE v.MASV = s.MASV AND v.MAHP = c.MAHP " +
                "             ORDER BY v.NGAYBATDAU DESC) kq " +
                "WHERE s.MASV = @sv AND NOT EXISTS (SELECT 1 FROM DANGKYHOC d " +
                "      WHERE d.MASV = s.MASV AND d.MAHP = c.MAHP AND d.MAHOCKY = @hk) " +
                "ORDER BY c.HOCKYDUKIEN, c.MAHP";
            return db.execute(sql, new SqlParameter("@sv", maSV), new SqlParameter("@hk", maHocKy));
        }

        public DataTable getHocPhanDaDangKy(string maSV, string maHocKy)
        {
            string sql = "SELECT MAHP, TENHP, SOTINCHI, NGAYDANGKY, DIEMQUATRINH, DIEMTHI, DIEMTHILAN2, DIEMHP, DIEMCHU " +
                         "FROM dbo.vw_DiemHocPhan WHERE MASV = @sv AND MAHOCKY = @hk ORDER BY MAHP";
            return db.execute(sql, new SqlParameter("@sv", maSV), new SqlParameter("@hk", maHocKy));
        }

        public int dangKy(string maSV, string maHP, string maHocKy)
        {
            string sql = "INSERT INTO DANGKYHOC (MAHP, MASV, MAHOCKY, NGAYDANGKY) VALUES (@hp, @sv, @hk, @ngay)";
            return db.executeNonQuery(sql, new SqlParameter("@hp", maHP), new SqlParameter("@sv", maSV),
                                      new SqlParameter("@hk", maHocKy), new SqlParameter("@ngay", DateTime.Today));
        }

        public int huyDangKy(string maSV, string maHP, string maHocKy)
        {
            string sql = "DELETE FROM DANGKYHOC WHERE MASV = @sv AND MAHP = @hp AND MAHOCKY = @hk " +
                         "AND DIEMQUATRINH IS NULL AND DIEMTHI IS NULL";
            return db.executeNonQuery(sql, new SqlParameter("@sv", maSV), new SqlParameter("@hp", maHP),
                                      new SqlParameter("@hk", maHocKy));
        }

        public DataTable getHocPhanCoDangKy(string maHocKy)
        {
            string sql = "SELECT d.MAHP, d.MAHP + N' - ' + h.TENHP + N' (' + CAST(COUNT(*) AS varchar(5)) + N' sinh viên)' AS HIENTHI, " +
                         "h.TYLEQUATRINH FROM DANGKYHOC d JOIN HOCPHAN h ON d.MAHP = h.MAHP " +
                         "WHERE d.MAHOCKY = @hk GROUP BY d.MAHP, h.TENHP, h.TYLEQUATRINH ORDER BY d.MAHP";
            return db.execute(sql, new SqlParameter("@hk", maHocKy));
        }

        public DataTable getDanhSachNhapDiem(string maHocKy, string maHP)
        {
            string sql = "SELECT v.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, s.MALOP, v.DIEMQUATRINH, v.DIEMTHI, " +
                         "v.DIEMTHILAN2, v.DIEMHP, v.DIEMCHU FROM dbo.vw_DiemHocPhan v JOIN SINHVIEN s ON v.MASV = s.MASV " +
                         "WHERE v.MAHOCKY = @hk AND v.MAHP = @hp ORDER BY s.TEN, s.HOLOT";
            return db.execute(sql, new SqlParameter("@hk", maHocKy), new SqlParameter("@hp", maHP));
        }

        public int capNhatDiem(string maSV, string maHP, string maHocKy, object diemQuaTrinh, object diemThi, object diemThiLan2)
        {
            string sql = "UPDATE DANGKYHOC SET DIEMQUATRINH = @qt, DIEMTHI = @thi, DIEMTHILAN2 = @thi2 " +
                         "WHERE MASV = @sv AND MAHP = @hp AND MAHOCKY = @hk";
            return db.executeNonQuery(sql,
                new SqlParameter("@qt", SqlDbType.Decimal) { Precision = 4, Scale = 2, Value = diemQuaTrinh },
                new SqlParameter("@thi", SqlDbType.Decimal) { Precision = 4, Scale = 2, Value = diemThi },
                new SqlParameter("@thi2", SqlDbType.Decimal) { Precision = 4, Scale = 2, Value = diemThiLan2 },
                new SqlParameter("@sv", maSV), new SqlParameter("@hp", maHP), new SqlParameter("@hk", maHocKy));
        }

        public DataTable getBangDiem(string maSV)
        {
            return db.execute("EXEC dbo.sp_BangDiemToanKhoa @MASV = @sv", new SqlParameter("@sv", maSV));
        }

        public DataTable getTongKetHocKy(string maSV)
        {
            return db.execute("EXEC dbo.sp_TongKetHocKy @MASV = @sv", new SqlParameter("@sv", maSV));
        }

        public static string loiSQL(SqlException ex)
        {
            return ex.Errors.Count > 0 ? ex.Errors[0].Message : ex.Message;
        }
    }
}
