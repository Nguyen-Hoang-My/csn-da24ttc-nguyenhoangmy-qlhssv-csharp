using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP XỬ LÝ cho bảng BOMON: chứa câu lệnh SQL và các kiểm tra dữ liệu.
    class BoMon
    {
        ThaotacCSDL db;

        public BoMon()
        {
            db = new ThaotacCSDL();
        }

        
        const string cauLay =
            "SELECT b.MABOMON, b.TENBOMON, b.MAKHOA, k.TENKHOA, b.TRUONGBOMON, b.EMAILBOMON, " +
            "b.SONOIBOBOMON, b.TRANGTHONGTINBOMON, b.MOTABOMON " +
            "FROM BOMON b JOIN KHOA k ON b.MAKHOA = k.MAKHOA ";

        public DataTable getAllBoMon()
        {
            return db.execute(cauLay + "ORDER BY b.MABOMON");
        }

        // Tìm theo mã bộ môn, tên bộ môn hoặc tên khoa
        public DataTable timBoMon(string tuKhoa)
        {
            string sql = cauLay + "WHERE b.MABOMON LIKE @tk OR b.TENBOMON LIKE @tk OR k.TENKHOA LIKE @tk " +
                         "ORDER BY b.MABOMON";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        // Danh sách khoa để đổ vào ComboBox chọn khoa
        public DataTable getDanhSachKhoa()
        {
            return db.execute("SELECT MAKHOA, TENKHOA FROM KHOA ORDER BY TENKHOA");
        }

        public bool tonTaiMaBoMon(string maBoMon)
        {
            string sql = "SELECT MABOMON FROM BOMON WHERE MABOMON = @ma";
            return db.execute(sql, new SqlParameter("@ma", maBoMon.Trim())).Rows.Count > 0;
        }

        // Bộ môn đang quản lý bao nhiêu ngành
        public int demNganh(string maBoMon)
        {
            string sql = "SELECT MANGANH FROM NGANH WHERE MABOMON = @ma";
            return db.execute(sql, new SqlParameter("@ma", maBoMon.Trim())).Rows.Count;
        }

        public int themBoMon(string ma, string maKhoa, string ten, string truongBoMon, string email,
                             string soNoiBo, string trangThongTin, string moTa)
        {
            string sql = "INSERT INTO BOMON (MABOMON, MAKHOA, TENBOMON, TRUONGBOMON, EMAILBOMON, " +
                         "SONOIBOBOMON, TRANGTHONGTINBOMON, MOTABOMON) " +
                         "VALUES (@ma, @maKhoa, @ten, @truong, @email, @noiBo, @trang, @moTa)";
            return db.executeNonQuery(sql, taoThamSo(ma, maKhoa, ten, truongBoMon, email,
                                                     soNoiBo, trangThongTin, moTa));
        }

        // Sửa theo mã bộ môn
        public int suaBoMon(string ma, string maKhoa, string ten, string truongBoMon, string email,
                            string soNoiBo, string trangThongTin, string moTa)
        {
            string sql = "UPDATE BOMON SET MAKHOA = @maKhoa, TENBOMON = @ten, TRUONGBOMON = @truong, " +
                         "EMAILBOMON = @email, SONOIBOBOMON = @noiBo, TRANGTHONGTINBOMON = @trang, " +
                         "MOTABOMON = @moTa WHERE MABOMON = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, maKhoa, ten, truongBoMon, email,
                                                     soNoiBo, trangThongTin, moTa));
        }

        public int xoaBoMon(string maBoMon)
        {
            string sql = "DELETE FROM BOMON WHERE MABOMON = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", maBoMon.Trim()));
        }

        SqlParameter[] taoThamSo(string ma, string maKhoa, string ten, string truongBoMon, string email,
                                 string soNoiBo, string trangThongTin, string moTa)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@maKhoa", maKhoa),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@truong", rongThiNull(truongBoMon)),
                new SqlParameter("@email", rongThiNull(email)),
                new SqlParameter("@noiBo", rongThiNull(soNoiBo)),
                new SqlParameter("@trang", rongThiNull(trangThongTin)),
                new SqlParameter("@moTa", rongThiNull(moTa))
            };
        }

        
        object rongThiNull(string giaTri)
        {
            if (string.IsNullOrWhiteSpace(giaTri)) return DBNull.Value;
            return giaTri.Trim();
        }
    }
}