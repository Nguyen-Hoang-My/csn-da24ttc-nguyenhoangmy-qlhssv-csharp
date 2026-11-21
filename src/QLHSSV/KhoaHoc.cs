using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    
    class KhoaHoc
    {
        ThaotacCSDL db;

        public KhoaHoc()
        {
            db = new ThaotacCSDL();
        }

        const string cauLay = "SELECT MAKHOAHOC, TENKHOAHOC, NAMBATDAU, NAMKETTHUC FROM KHOAHOC ";

        public DataTable getAllKhoaHoc()
        {
            return db.execute(cauLay + "ORDER BY NAMBATDAU DESC");   
        }

        public DataTable timKhoaHoc(string tuKhoa)
        {
            string sql = cauLay + "WHERE MAKHOAHOC LIKE @tk OR TENKHOAHOC LIKE @tk ORDER BY NAMBATDAU DESC";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        public bool tonTaiMaKhoaHoc(string ma)
        {
            string sql = "SELECT MAKHOAHOC FROM KHOAHOC WHERE MAKHOAHOC = @ma";
            return db.execute(sql, new SqlParameter("@ma", ma.Trim())).Rows.Count > 0;
        }

        
        public int demSinhVien(string ma)
        {
            string sql = "SELECT MASV FROM SINHVIEN WHERE MAKHOAHOC = @ma";
            return db.execute(sql, new SqlParameter("@ma", ma.Trim())).Rows.Count;
        }

        public int themKhoaHoc(string ma, string ten, int namBatDau, int namKetThuc)
        {
            string sql = "INSERT INTO KHOAHOC (MAKHOAHOC, TENKHOAHOC, NAMBATDAU, NAMKETTHUC) " +
                         "VALUES (@ma, @ten, @bd, @kt)";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, namBatDau, namKetThuc));
        }

        public int suaKhoaHoc(string ma, string ten, int namBatDau, int namKetThuc)
        {
            string sql = "UPDATE KHOAHOC SET TENKHOAHOC = @ten, NAMBATDAU = @bd, NAMKETTHUC = @kt " +
                         "WHERE MAKHOAHOC = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, namBatDau, namKetThuc));
        }

        public int xoaKhoaHoc(string ma)
        {
            string sql = "DELETE FROM KHOAHOC WHERE MAKHOAHOC = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", ma.Trim()));
        }

        SqlParameter[] taoThamSo(string ma, string ten, int namBatDau, int namKetThuc)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@bd", (short)namBatDau),
                new SqlParameter("@kt", (short)namKetThuc)
            };
        }
    }
}