using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    
    class Khoa
    {
        ThaotacCSDL db;

        public Khoa()
        {
            db = new ThaotacCSDL();
        }

        
        public DataTable getAllKhoa()
        {
            string sql = "SELECT MAKHOA, TENKHOA, TENTIENGANH, TENVIETTAT, LOAIDONVI, TRUONGDONVI, " +
                         "SDTKHOA, SONOIBOKHOA, EMAILKHOA, WEBSITEKHOA, DIACHIKHOA, MOTAKHOA " +
                         "FROM KHOA ORDER BY MAKHOA";
            return db.execute(sql);
        }

        
        public DataTable timKhoa(string tuKhoa)
        {
            string sql = "SELECT MAKHOA, TENKHOA, TENTIENGANH, TENVIETTAT, LOAIDONVI, TRUONGDONVI, " +
                         "SDTKHOA, SONOIBOKHOA, EMAILKHOA, WEBSITEKHOA, DIACHIKHOA, MOTAKHOA " +
                         "FROM KHOA WHERE MAKHOA LIKE @tk OR TENKHOA LIKE @tk ORDER BY MAKHOA";
            return db.execute(sql, new SqlParameter("@tk", "%" + tuKhoa.Trim() + "%"));
        }

        
        public bool tonTaiMaKhoa(string maKhoa)
        {
            string sql = "SELECT MAKHOA FROM KHOA WHERE MAKHOA = @ma";
            return db.execute(sql, new SqlParameter("@ma", maKhoa.Trim())).Rows.Count > 0;
        }

        
        public int demBoMon(string maKhoa)
        {
            string sql = "SELECT MABOMON FROM BOMON WHERE MAKHOA = @ma";
            return db.execute(sql, new SqlParameter("@ma", maKhoa.Trim())).Rows.Count;
        }

        public int themKhoa(string ma, string ten, string tenTiengAnh, string tenVietTat,
                            string loaiDonVi, string truongDonVi, string sdt, string soNoiBo,
                            string email, string website, string diaChi, string moTa)
        {
            string sql = "INSERT INTO KHOA (MAKHOA, TENKHOA, TENTIENGANH, TENVIETTAT, LOAIDONVI, TRUONGDONVI, " +
                         "SDTKHOA, SONOIBOKHOA, EMAILKHOA, WEBSITEKHOA, DIACHIKHOA, MOTAKHOA) " +
                         "VALUES (@ma, @ten, @tenTA, @vietTat, @loai, @truong, " +
                         "@sdt, @noiBo, @email, @web, @diaChi, @moTa)";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, tenTiengAnh, tenVietTat, loaiDonVi,
                                                     truongDonVi, sdt, soNoiBo, email, website, diaChi, moTa));
        }

        
        public int suaKhoa(string ma, string ten, string tenTiengAnh, string tenVietTat,
                           string loaiDonVi, string truongDonVi, string sdt, string soNoiBo,
                           string email, string website, string diaChi, string moTa)
        {
            string sql = "UPDATE KHOA SET TENKHOA = @ten, TENTIENGANH = @tenTA, TENVIETTAT = @vietTat, " +
                         "LOAIDONVI = @loai, TRUONGDONVI = @truong, SDTKHOA = @sdt, SONOIBOKHOA = @noiBo, " +
                         "EMAILKHOA = @email, WEBSITEKHOA = @web, DIACHIKHOA = @diaChi, MOTAKHOA = @moTa " +
                         "WHERE MAKHOA = @ma";
            return db.executeNonQuery(sql, taoThamSo(ma, ten, tenTiengAnh, tenVietTat, loaiDonVi,
                                                     truongDonVi, sdt, soNoiBo, email, website, diaChi, moTa));
        }

        public int xoaKhoa(string maKhoa)
        {
            string sql = "DELETE FROM KHOA WHERE MAKHOA = @ma";
            return db.executeNonQuery(sql, new SqlParameter("@ma", maKhoa.Trim()));
        }

        
        SqlParameter[] taoThamSo(string ma, string ten, string tenTiengAnh, string tenVietTat,
                                 string loaiDonVi, string truongDonVi, string sdt, string soNoiBo,
                                 string email, string website, string diaChi, string moTa)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ma", ma.Trim()),
                new SqlParameter("@ten", ten.Trim()),
                new SqlParameter("@tenTA", rongThiNull(tenTiengAnh)),
                new SqlParameter("@vietTat", rongThiNull(tenVietTat)),
                new SqlParameter("@loai", loaiDonVi.Trim()),
                new SqlParameter("@truong", rongThiNull(truongDonVi)),
                new SqlParameter("@sdt", rongThiNull(sdt)),
                new SqlParameter("@noiBo", rongThiNull(soNoiBo)),
                new SqlParameter("@email", rongThiNull(email)),
                new SqlParameter("@web", rongThiNull(website)),
                new SqlParameter("@diaChi", rongThiNull(diaChi)),
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