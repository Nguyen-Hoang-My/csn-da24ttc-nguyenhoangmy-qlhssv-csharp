using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP XỬ LÝ cho chức năng thống kê. Dữ liệu lấy từ view vw_SinhVienTongHop (08_ThongKe.sql).
    // Mỗi kiểu thống kê trả về bảng có cột MANHOM (khóa để lọc danh sách, ẩn trên lưới),
    // NHOM (tên nhóm), TONG (số sinh viên, dùng vẽ biểu đồ) và TILE (% trên tổng).
    class ThongKe
    {
        ThaotacCSDL db;

        public ThongKe()
        {
            db = new ThaotacCSDL();
        }

        public static readonly string[] KieuThongKe =
        {
            "Khoa", "Ngành", "Khóa học", "Xếp loại học lực (tích lũy)", "Tình trạng nộp giấy tờ"
        };

        // Điều kiện lọc chung theo khóa học và ngành ('' = tất cả)
        const string DieuKienLoc = "(@khoa = '' OR v.MAKHOAHOC = @khoa) AND (@nganh = '' OR v.MANGANH = @nganh)";

        const string CotTinhTrang =
            "SUM(CASE WHEN v.GIOITINH = N'Nữ' THEN 1 ELSE 0 END) AS NU, " +
            "SUM(CASE WHEN v.TINHTRANG = N'Đang học' THEN 1 ELSE 0 END) AS DANGHOC, " +
            "SUM(CASE WHEN v.TINHTRANG = N'Bảo lưu' THEN 1 ELSE 0 END) AS BAOLUU, " +
            "SUM(CASE WHEN v.TINHTRANG = N'Thôi học' THEN 1 ELSE 0 END) AS THOIHOC, " +
            "SUM(CASE WHEN v.TINHTRANG = N'Đã tốt nghiệp' THEN 1 ELSE 0 END) AS TOTNGHIEP, ";

        const string CotTiLe = "CAST(ROUND(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER (), 2) AS decimal(5,2)) AS TILE";

        public DataTable thongKe(int kieu, string maKhoaHoc, string maNganh)
        {
            string sql;
            switch (kieu)
            {
                case 0: // theo khoa
                    sql = "SELECT v.MAKHOA AS MANHOM, v.TENKHOA AS NHOM, COUNT(*) AS TONG, " + CotTinhTrang + CotTiLe +
                          " FROM vw_SinhVienTongHop v WHERE " + DieuKienLoc +
                          " GROUP BY v.MAKHOA, v.TENKHOA ORDER BY v.TENKHOA";
                    break;
                case 1: // theo ngành
                    sql = "SELECT v.MANGANH AS MANHOM, v.TENNGANH AS NHOM, COUNT(*) AS TONG, " + CotTinhTrang + CotTiLe +
                          " FROM vw_SinhVienTongHop v WHERE " + DieuKienLoc +
                          " GROUP BY v.MANGANH, v.TENNGANH ORDER BY v.TENNGANH";
                    break;
                case 2: // theo khóa học
                    sql = "SELECT v.MAKHOAHOC AS MANHOM, v.TENKHOAHOC AS NHOM, COUNT(*) AS TONG, " + CotTinhTrang + CotTiLe +
                          " FROM vw_SinhVienTongHop v WHERE " + DieuKienLoc +
                          " GROUP BY v.MAKHOAHOC, v.TENKHOAHOC, v.NAMBATDAU ORDER BY v.NAMBATDAU DESC";
                    break;
                case 3: // theo xếp loại: hiện đủ các mức kể cả mức không có sinh viên nào
                    sql = "SELECT m.TEN AS MANHOM, m.TEN AS NHOM, COUNT(v.MASV) AS TONG, " +
                          "CAST(ROUND(COUNT(v.MASV) * 100.0 / NULLIF(SUM(COUNT(v.MASV)) OVER (), 0), 2) AS decimal(5,2)) AS TILE " +
                          "FROM (VALUES (1, N'Xuất sắc'), (2, N'Giỏi'), (3, N'Khá'), (4, N'Trung bình'), " +
                          "(5, N'Yếu'), (6, N'Kém'), (7, N'Chưa xếp loại')) m(THUTU, TEN) " +
                          "LEFT JOIN vw_SinhVienTongHop v ON v.XEPLOAI = m.TEN AND " + DieuKienLoc +
                          " GROUP BY m.THUTU, m.TEN ORDER BY m.THUTU";
                    break;
                default: // tình trạng nộp giấy tờ bắt buộc, theo ngành
                    sql = "SELECT v.MANGANH AS MANHOM, v.TENNGANH AS NHOM, COUNT(*) AS TONG, " +
                          "SUM(CASE WHEN v.SOGIAYTOTHIEU = 0 THEN 1 ELSE 0 END) AS DUGIAYTO, " +
                          "SUM(CASE WHEN v.SOGIAYTOTHIEU > 0 THEN 1 ELSE 0 END) AS THIEUGIAYTO, " + CotTiLe +
                          " FROM vw_SinhVienTongHop v WHERE " + DieuKienLoc +
                          " GROUP BY v.MANGANH, v.TENNGANH ORDER BY v.TENNGANH";
                    break;
            }
            return db.execute(sql, new SqlParameter("@khoa", maKhoaHoc), new SqlParameter("@nganh", maNganh));
        }

        // Danh sách sinh viên của một nhóm (maNhom = '' thì lấy hết theo bộ lọc)
        public DataTable danhSach(int kieu, string maNhom, string maKhoaHoc, string maNganh)
        {
            // tên cột lấy từ danh sách cố định, không lấy từ người dùng nhập
            string[] cotNhom = { "MAKHOA", "MANGANH", "MAKHOAHOC", "XEPLOAI", "MANGANH" };
            string sql =
                "SELECT v.MASV, v.HOTEN, v.NGAYSINH, v.GIOITINH, v.MALOP, v.TENNGANH, v.TENKHOA, v.TENKHOAHOC, " +
                "v.TINHTRANG, v.TCTICHLUY, v.DTBTLHE10, v.DTBTLHE4, v.XEPLOAI, v.SOGIAYTOTHIEU " +
                "FROM vw_SinhVienTongHop v WHERE " + DieuKienLoc +
                " AND (@nhom = '' OR v." + cotNhom[kieu] + " = @nhom) ORDER BY v.MASV";
            return db.execute(sql, new SqlParameter("@khoa", maKhoaHoc), new SqlParameter("@nganh", maNganh),
                              new SqlParameter("@nhom", maNhom));
        }

        public DataTable getDanhSachKhoaHoc()
        {
            return db.execute("SELECT '' AS MAKHOAHOC, N'(Tất cả khóa)' AS TENKHOAHOC, 9999 AS NAM " +
                              "UNION ALL SELECT MAKHOAHOC, TENKHOAHOC, NAMBATDAU FROM KHOAHOC ORDER BY NAM DESC");
        }

        public DataTable getDanhSachNganh()
        {
            return db.execute("SELECT '' AS MANGANH, N'(Tất cả ngành)' AS TENNGANH, 0 AS THUTU " +
                              "UNION ALL SELECT MANGANH, TENNGANH, 1 FROM NGANH ORDER BY THUTU, TENNGANH");
        }
    }
}
