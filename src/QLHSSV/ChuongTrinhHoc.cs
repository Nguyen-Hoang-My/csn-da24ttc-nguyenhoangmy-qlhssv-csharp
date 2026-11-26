using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    class ChuongTrinhHoc
    {
        ThaotacCSDL db;

        public ChuongTrinhHoc()
        {
            db = new ThaotacCSDL();
        }

        public DataTable getDanhSachNganh()
        {
            return db.execute("SELECT MANGANH, TENNGANH, THOIGIANDAOTAO FROM NGANH ORDER BY TENNGANH");
        }

        public DataTable getDanhSachHocPhan()
        {
            return db.execute("SELECT MAHP, MAHP + N' - ' + TENHP + N' (' + CAST(SOTINCHI AS varchar(2)) + N' TC)' AS HIENTHI " +
                              "FROM HOCPHAN ORDER BY MAHP");
        }

        public DataTable getChuongTrinh(string maNganh)
        {
            string sql = "SELECT c.MAHP, h.TENHP, h.SOTINCHI, c.HOCKYDUKIEN, " +
                         "CASE WHEN c.BATBUOC = 1 THEN N'Bắt buộc' ELSE N'Tự chọn' END AS LOAI, c.BATBUOC " +
                         "FROM CHUONGTRINHHOC c JOIN HOCPHAN h ON c.MAHP = h.MAHP " +
                         "WHERE c.MANGANH = @nganh ORDER BY c.HOCKYDUKIEN, c.MAHP";
            return db.execute(sql, new SqlParameter("@nganh", maNganh));
        }

        public bool daCoTrongChuongTrinh(string maNganh, string maHP)
        {
            string sql = "SELECT MAHP FROM CHUONGTRINHHOC WHERE MANGANH = @nganh AND MAHP = @hp";
            return db.execute(sql, new SqlParameter("@nganh", maNganh), new SqlParameter("@hp", maHP)).Rows.Count > 0;
        }

        public int demDangKy(string maNganh, string maHP)
        {
            string sql = "SELECT d.MASV FROM DANGKYHOC d JOIN SINHVIEN s ON d.MASV = s.MASV " +
                         "WHERE s.MANGANH = @nganh AND d.MAHP = @hp";
            return db.execute(sql, new SqlParameter("@nganh", maNganh), new SqlParameter("@hp", maHP)).Rows.Count;
        }

        public int themVaoChuongTrinh(string maNganh, string maHP, int hocKyDuKien, bool batBuoc)
        {
            string sql = "INSERT INTO CHUONGTRINHHOC (MANGANH, MAHP, HOCKYDUKIEN, BATBUOC) VALUES (@nganh, @hp, @hk, @bb)";
            return db.executeNonQuery(sql, taoThamSo(maNganh, maHP, hocKyDuKien, batBuoc));
        }

        public int suaChuongTrinh(string maNganh, string maHP, int hocKyDuKien, bool batBuoc)
        {
            string sql = "UPDATE CHUONGTRINHHOC SET HOCKYDUKIEN = @hk, BATBUOC = @bb WHERE MANGANH = @nganh AND MAHP = @hp";
            return db.executeNonQuery(sql, taoThamSo(maNganh, maHP, hocKyDuKien, batBuoc));
        }

        public int xoaKhoiChuongTrinh(string maNganh, string maHP)
        {
            string sql = "DELETE FROM CHUONGTRINHHOC WHERE MANGANH = @nganh AND MAHP = @hp";
            return db.executeNonQuery(sql, new SqlParameter("@nganh", maNganh), new SqlParameter("@hp", maHP));
        }

        SqlParameter[] taoThamSo(string maNganh, string maHP, int hocKyDuKien, bool batBuoc)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@nganh", maNganh),
                new SqlParameter("@hp", maHP),
                new SqlParameter("@hk", (byte)hocKyDuKien),
                new SqlParameter("@bb", batBuoc)
            };
        }
    }
}
