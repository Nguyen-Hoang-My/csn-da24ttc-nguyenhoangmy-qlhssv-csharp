using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    class HocKy
    {
        ThaotacCSDL db;

        public HocKy()
        {
            db = new ThaotacCSDL();
        }

        const string cauLay = "SELECT MAHOCKY, TENHOCKY, NAMHOC, HOCKYSO, NGAYBATDAU, NGAYKETTHUC FROM HOCKY ";

        public DataTable getAllHocKy()
        {
            return db.execute(cauLay + "ORDER BY NAMHOC DESC, HOCKYSO DESC");
        }

        public DataTable timHocKy(string tuKhoa)
        {
            string sql = cauLay + "WHERE MAHOCKY LIKE @tk OR TENHOCKY LIKE @tk OR NAMHOC LIKE @tk " +
                         "ORDER BY NAMHOC DESC, HOCKYSO DESC";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        public bool tonTaiMaHocKy(string maHocKy)
        {
            string sql = "SELECT MAHOCKY FROM HOCKY WHERE MAHOCKY = @ma";
            return db.execute(sql, new SqlParameter("@ma", maHocKy.Trim())).Rows.Count > 0;
        }

        public bool trungHocKy(string namHoc, int hocKySo, string maBoQua)
        {
            string sql = "SELECT MAHOCKY FROM HOCKY WHERE NAMHOC = @nh AND HOCKYSO = @so AND MAHOCKY <> @ma";
            return db.execute(sql, new SqlParameter("@nh", namHoc), new SqlParameter("@so", (byte)hocKySo),
                              new SqlParameter("@ma", maBoQua.Trim())).Rows.Count > 0;
        }

        public int demDangKy(string maHocKy)
        {
            string sql = "SELECT MASV FROM DANGKYHOC WHERE MAHOCKY = @ma";
            return db.execute(sql, new SqlParameter("@ma", maHocKy.Trim())).Rows.Count;
        }

        public int themHocKy(string ma, string ten, string namHoc, int hocKySo, DateTime batDau, DateTime ketThuc)
        {
            string sql = "INSERT INTO HOCKY (MAHOCKY, TENHOCKY, NAMHOC, HOCKYSO, NGAYBATDAU, NGAYKETTHUC) " +
                         "VALUES (@ma, @ten, @nh, @so, @bd, @kt)";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, namHoc, hocKySo, batDau, ketThuc));
        }

        public int suaHocKy(string ma, string ten, string namHoc, int hocKySo, DateTime batDau, DateTime ketThuc)
        {
            string sql = "UPDATE HOCKY SET TENHOCKY = @ten, NAMHOC = @nh, HOCKYSO = @so, NGAYBATDAU = @bd, " +
                         "NGAYKETTHUC = @kt WHERE MAHOCKY = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, namHoc, hocKySo, batDau, ketThuc));
        }

        public int xoaHocKy(string maHocKy)
        {
            string sql = "DELETE FROM HOCKY WHERE MAHOCKY = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", maHocKy.Trim()));
        }

        SqlParameter[] taoThamSo(string ma, string ten, string namHoc, int hocKySo, DateTime batDau, DateTime ketThuc)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@nh", namHoc.Trim()),
                new SqlParameter("@so", (byte)hocKySo),
                new SqlParameter("@bd", batDau.Date),
                new SqlParameter("@kt", ketThuc.Date)
            };
        }
    }
}
