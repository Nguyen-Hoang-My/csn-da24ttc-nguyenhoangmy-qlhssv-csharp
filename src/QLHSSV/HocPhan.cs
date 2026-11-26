using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    class HocPhan
    {
        ThaotacCSDL db;

        public HocPhan()
        {
            db = new ThaotacCSDL();
        }

        const string cauLay = "SELECT MAHP, TENHP, SOTINCHI, TYLEQUATRINH FROM HOCPHAN ";

        public DataTable getAllHocPhan()
        {
            return db.execute(cauLay + "ORDER BY MAHP");
        }

        public DataTable timHocPhan(string tuKhoa)
        {
            string sql = cauLay + "WHERE MAHP LIKE @tk OR TENHP LIKE @tk ORDER BY MAHP";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        public bool tonTaiMaHP(string maHP)
        {
            string sql = "SELECT MAHP FROM HOCPHAN WHERE MAHP = @ma";
            return db.execute(sql, new SqlParameter("@ma", maHP.Trim())).Rows.Count > 0;
        }

        public int demChuongTrinh(string maHP)
        {
            string sql = "SELECT MANGANH FROM CHUONGTRINHHOC WHERE MAHP = @ma";
            return db.execute(sql, new SqlParameter("@ma", maHP.Trim())).Rows.Count;
        }

        public int demDangKy(string maHP)
        {
            string sql = "SELECT MASV FROM DANGKYHOC WHERE MAHP = @ma";
            return db.execute(sql, new SqlParameter("@ma", maHP.Trim())).Rows.Count;
        }

        public int themHocPhan(string ma, string ten, int soTinChi, decimal tyLe)
        {
            string sql = "INSERT INTO HOCPHAN (MAHP, TENHP, SOTINCHI, TYLEQUATRINH) VALUES (@ma, @ten, @tc, @tl)";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, soTinChi, tyLe));
        }

        public int suaHocPhan(string ma, string ten, int soTinChi, decimal tyLe)
        {
            string sql = "UPDATE HOCPHAN SET TENHP = @ten, SOTINCHI = @tc, TYLEQUATRINH = @tl WHERE MAHP = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, soTinChi, tyLe));
        }

        public int xoaHocPhan(string maHP)
        {
            string sql = "DELETE FROM HOCPHAN WHERE MAHP = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", maHP.Trim()));
        }

        SqlParameter[] taoThamSo(string ma, string ten, int soTinChi, decimal tyLe)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@tc", (byte)soTinChi),
                new SqlParameter("@tl", tyLe)
            };
        }
    }
}
