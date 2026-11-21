using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    
    class Nganh
    {
        ThaotacCSDL db;

        public Nganh()
        {
            db = new ThaotacCSDL();
        }

        
        const string cauLay =
            "SELECT n.MANGANH, n.TENNGANH, n.MABOMON, b.TENBOMON, k.TENKHOA, n.THOIGIANDAOTAO, n.MOTANGANHHOC " +
            "FROM NGANH n JOIN BOMON b ON n.MABOMON = b.MABOMON " +
            "JOIN KHOA k ON b.MAKHOA = k.MAKHOA ";

        public DataTable getAllNganh()
        {
            return db.execute(cauLay + "ORDER BY n.MANGANH");
        }

        public DataTable timNganh(string tuKhoa)
        {
            string sql = cauLay + "WHERE n.MANGANH LIKE @tk OR n.TENNGANH LIKE @tk OR b.TENBOMON LIKE @tk " +
                         "ORDER BY n.MANGANH";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        
        public DataTable getDanhSachBoMon()
        {
            return db.execute("SELECT MABOMON, TENBOMON FROM BOMON ORDER BY TENBOMON");
        }

        public bool tonTaiMaNganh(string maNganh)
        {
            string sql = "SELECT MANGANH FROM NGANH WHERE MANGANH = @ma";
            return db.execute(sql, new SqlParameter("@ma", maNganh.Trim())).Rows.Count > 0;
        }

        
        public int demSinhVien(string maNganh)
        {
            string sql = "SELECT MASV FROM SINHVIEN WHERE MANGANH = @ma";
            return db.execute(sql, new SqlParameter("@ma", maNganh.Trim())).Rows.Count;
        }

        public int demHocPhanTrongChuongTrinh(string maNganh)
        {
            string sql = "SELECT MAHP FROM CHUONGTRINHHOC WHERE MANGANH = @ma";
            return db.execute(sql, new SqlParameter("@ma", maNganh.Trim())).Rows.Count;
        }

        public int themNganh(string ma, string maBoMon, string ten, decimal thoiGian, string moTa)
        {
            string sql = "INSERT INTO NGANH (MANGANH, MABOMON, TENNGANH, THOIGIANDAOTAO, MOTANGANHHOC) " +
                         "VALUES (@ma, @maBoMon, @ten, @thoiGian, @moTa)";
            return db.executeNonQuery(sql, taoThamSo(ma, maBoMon, ten, thoiGian, moTa));
        }

        public int suaNganh(string ma, string maBoMon, string ten, decimal thoiGian, string moTa)
        {
            string sql = "UPDATE NGANH SET MABOMON = @maBoMon, TENNGANH = @ten, THOIGIANDAOTAO = @thoiGian, " +
                         "MOTANGANHHOC = @moTa WHERE MANGANH = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, maBoMon, ten, thoiGian, moTa));
        }

        public int xoaNganh(string maNganh)
        {
            string sql = "DELETE FROM NGANH WHERE MANGANH = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", maNganh.Trim()));
        }

        SqlParameter[] taoThamSo(string ma, string maBoMon, string ten, decimal thoiGian, string moTa)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@maBoMon", maBoMon),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@thoiGian", thoiGian),
                new SqlParameter("@moTa", string.IsNullOrWhiteSpace(moTa) ? (object)DBNull.Value : moTa.Trim())
            };
        }
    }
}