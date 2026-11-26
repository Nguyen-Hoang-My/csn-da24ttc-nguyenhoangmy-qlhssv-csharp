using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    class TaiKhoan
    {
        ThaotacCSDL db;

        public TaiKhoan()
        {
            db = new ThaotacCSDL();
        }

        public static string bamMatKhau(string matKhau)
        {
            byte[] kq = SHA256.HashData(Encoding.UTF8.GetBytes(matKhau));
            return Convert.ToHexString(kq).ToLower();
        }

        public DataRow? dangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT TENDANGNHAP, HOTEN, VAITRO, TRANGTHAI FROM TAIKHOAN " +
                         "WHERE TENDANGNHAP = @ten AND MATKHAUHASH = @mk";
            DataTable kq = db.execute(sql,
                new SqlParameter("@ten", tenDangNhap.Trim()),
                new SqlParameter("@mk", bamMatKhau(matKhau)));
            if (kq.Rows.Count == 0) return null;
            return kq.Rows[0];
        }

        public string layMaSV(string tenDangNhap)
        {
            DataTable kq = db.execute("SELECT MASV FROM TAIKHOAN WHERE TENDANGNHAP = @ten",
                                      new SqlParameter("@ten", tenDangNhap));
            if (kq.Rows.Count == 0 || kq.Rows[0]["MASV"] == DBNull.Value) return "";
            return kq.Rows[0]["MASV"].ToString() ?? "";
        }

        public DataTable locTaiKhoan(string vaiTro, string tuKhoa)
        {
            string sql = "SELECT TENDANGNHAP, HOTEN, VAITRO, " +
                         "CASE VAITRO WHEN 'ADMIN' THEN N'Quản trị' WHEN 'GIAOVU' THEN N'Giáo vụ' " +
                         "WHEN 'SINHVIEN' THEN N'Sinh viên' ELSE VAITRO END AS TENVAITRO, MASV, TRANGTHAI, " +
                         "CASE WHEN TRANGTHAI = 1 THEN N'Hoạt động' ELSE N'Đã khóa' END AS TENTRANGTHAI " +
                         "FROM TAIKHOAN WHERE (@vt = '' OR VAITRO = @vt) " +
                         "AND (@tk = '' OR TENDANGNHAP LIKE @tkLike OR HOTEN LIKE @tkLike) " +
                         "ORDER BY VAITRO, TENDANGNHAP";
            return db.execute(sql, new SqlParameter("@vt", vaiTro), new SqlParameter("@tk", tuKhoa.Trim()),
                              new SqlParameter("@tkLike", "%" + tuKhoa.Trim() + "%"));
        }

        public DataTable getSinhVienChuaCoTaiKhoan(string maSVGiuLai)
        {
            string sql = "SELECT s.MASV, s.MASV + N' - ' + s.HOLOT + N' ' + s.TEN AS HIENTHI, s.HOLOT + N' ' + s.TEN AS HOTEN " +
                         "FROM SINHVIEN s WHERE s.MASV = @giu OR NOT EXISTS " +
                         "(SELECT 1 FROM TAIKHOAN t WHERE t.MASV = s.MASV) ORDER BY s.MASV";
            return db.execute(sql, new SqlParameter("@giu", maSVGiuLai));
        }

        public bool tonTaiTenDangNhap(string tenDangNhap)
        {
            string sql = "SELECT TENDANGNHAP FROM TAIKHOAN WHERE TENDANGNHAP = @ten";
            return db.execute(sql, new SqlParameter("@ten", tenDangNhap.Trim())).Rows.Count > 0;
        }

        public bool sinhVienDaCoTaiKhoan(string maSV, string tenDangNhapBoQua)
        {
            string sql = "SELECT TENDANGNHAP FROM TAIKHOAN WHERE MASV = @sv AND TENDANGNHAP <> @ten";
            return db.execute(sql, new SqlParameter("@sv", maSV), new SqlParameter("@ten", tenDangNhapBoQua)).Rows.Count > 0;
        }

        public int demQuanTriHoatDongKhac(string tenDangNhap)
        {
            string sql = "SELECT TENDANGNHAP FROM TAIKHOAN WHERE VAITRO = 'ADMIN' AND TRANGTHAI = 1 AND TENDANGNHAP <> @ten";
            return db.execute(sql, new SqlParameter("@ten", tenDangNhap)).Rows.Count;
        }

        public int themTaiKhoan(string ten, string hoTen, string vaiTro, string maSV, bool hoatDong, string matKhau)
        {
            string sql = "INSERT INTO TAIKHOAN (TENDANGNHAP, MASV, MATKHAUHASH, HOTEN, VAITRO, TRANGTHAI) " +
                         "VALUES (@ten, @sv, @mk, @hoten, @vt, @tt)";
            return db.executeNonQuery(sql,
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@sv", maSV == "" ? (object)DBNull.Value : maSV),
                new SqlParameter("@mk", bamMatKhau(matKhau)),
                new SqlParameter("@hoten", hoTen.Trim()),
                new SqlParameter("@vt", vaiTro),
                new SqlParameter("@tt", hoatDong));
        }

        public int suaTaiKhoan(string ten, string hoTen, string vaiTro, string maSV, bool hoatDong)
        {
            string sql = "UPDATE TAIKHOAN SET HOTEN = @hoten, VAITRO = @vt, MASV = @sv, TRANGTHAI = @tt " +
                         "WHERE TENDANGNHAP = @ten";
            return db.executeNonQuery(sql,
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@sv", maSV == "" ? (object)DBNull.Value : maSV),
                new SqlParameter("@hoten", hoTen.Trim()),
                new SqlParameter("@vt", vaiTro),
                new SqlParameter("@tt", hoatDong));
        }

        public int doiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string sql = "UPDATE TAIKHOAN SET MATKHAUHASH = @mk WHERE TENDANGNHAP = @ten";
            return db.executeNonQuery(sql, new SqlParameter("@mk", bamMatKhau(matKhauMoi)),
                                      new SqlParameter("@ten", tenDangNhap));
        }

        public int xoaTaiKhoan(string tenDangNhap)
        {
            string sql = "DELETE FROM TAIKHOAN WHERE TENDANGNHAP = @ten";
            return db.executeNonQuery(sql, new SqlParameter("@ten", tenDangNhap));
        }

        public int taoTaiKhoanChoSinhVienChuaCo()
        {
            string sql = "INSERT INTO TAIKHOAN (TENDANGNHAP, MASV, MATKHAUHASH, HOTEN, VAITRO, TRANGTHAI) " +
                         "SELECT s.MASV, s.MASV, LOWER(CONVERT(char(64), HASHBYTES('SHA2_256', s.MASV), 2)), " +
                         "s.HOLOT + N' ' + s.TEN, 'SINHVIEN', 1 FROM SINHVIEN s " +
                         "WHERE NOT EXISTS (SELECT 1 FROM TAIKHOAN t WHERE t.MASV = s.MASV OR t.TENDANGNHAP = s.MASV)";
            return db.executeNonQuery(sql);
        }
    }
}
