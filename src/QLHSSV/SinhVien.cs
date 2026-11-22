using System.Data;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP XỬ LÝ cho bảng SINHVIEN và NOP (giấy tờ sinh viên đã nộp)
    class SinhVien
    {
        ThaotacCSDL db;

        public SinhVien()
        {
            db = new ThaotacCSDL();
        }

        
        public DataTable locSinhVien(string maNganh, string maKhoaHoc, string tuKhoa)
        {
            string sql =
                "SELECT s.MASV, s.HOLOT + N' ' + s.TEN AS HOTEN, s.NGAYSINH, s.GIOITINH, " +
                "n.TENNGANH, k.TENKHOAHOC, s.MALOP, s.TINHTRANG " +
                "FROM SINHVIEN s JOIN NGANH n ON s.MANGANH = n.MANGANH " +
                "JOIN KHOAHOC k ON s.MAKHOAHOC = k.MAKHOAHOC " +
                "WHERE (@nganh = '' OR s.MANGANH = @nganh) " +
                "AND (@khoa = '' OR s.MAKHOAHOC = @khoa) " +
                "AND (@tk = '' OR s.MASV LIKE @tkLike OR s.HOLOT + N' ' + s.TEN LIKE @tkLike OR s.SOCCCD LIKE @tkLike) " +
                "ORDER BY s.MASV";
            return db.execute(sql,
                new SqlParameter("@nganh", maNganh),
                new SqlParameter("@khoa", maKhoaHoc),
                new SqlParameter("@tk", tuKhoa.Trim()),
                new SqlParameter("@tkLike", "%" + tuKhoa.Trim() + "%"));
        }

        
        public DataRow? getSinhVien(string maSV)
        {
            string sql = "SELECT s.*, x.MATINH FROM SINHVIEN s JOIN XAPHUONG x ON s.MAXA = x.MAXA " +
                         "WHERE s.MASV = @ma";
            DataTable kq = db.execute(sql, new SqlParameter("@ma", maSV));
            if (kq.Rows.Count == 0) return null;
            return kq.Rows[0];
        }

        
        public DataTable getDanhSachNganh()
        {
            return db.execute("SELECT MANGANH, TENNGANH FROM NGANH ORDER BY TENNGANH");
        }

        public DataTable getDanhSachKhoaHoc()
        {
            return db.execute("SELECT MAKHOAHOC, TENKHOAHOC FROM KHOAHOC ORDER BY NAMBATDAU DESC");
        }

        public DataTable getDanhSachTinh()
        {
            return db.execute("SELECT MATINH, TENTINH FROM TINHTHANH ORDER BY TENTINH");
        }

        public DataTable getDanhSachXa(string maTinh)
        {
            string sql = "SELECT MAXA, TENXA FROM XAPHUONG WHERE MATINH = @tinh ORDER BY TENXA";
            return db.execute(sql, new SqlParameter("@tinh", maTinh));
        }

        public DataTable getDanhSachGiayTo()
        {
            return db.execute("SELECT MAGIAYTO, TENGIAYTO, BATBUOC FROM GIAYTO ORDER BY MAGIAYTO");
        }

        public DataTable getGiayToDaNop(string maSV)
        {
            string sql = "SELECT MAGIAYTO, NGAYNOP FROM NOP WHERE MASV = @ma";
            return db.execute(sql, new SqlParameter("@ma", maSV));
        }

        
        public bool tonTaiMaSV(string maSV)
        {
            string sql = "SELECT MASV FROM SINHVIEN WHERE MASV = @ma";
            return db.execute(sql, new SqlParameter("@ma", maSV.Trim())).Rows.Count > 0;
        }

        
        public bool tonTaiCCCD(string soCCCD, string maSVBoQua)
        {
            string sql = "SELECT MASV FROM SINHVIEN WHERE SOCCCD = @cccd AND MASV <> @ma";
            return db.execute(sql, new SqlParameter("@cccd", soCCCD.Trim()),
                                   new SqlParameter("@ma", maSVBoQua.Trim())).Rows.Count > 0;
        }

        public int demDangKyHoc(string maSV)
        {
            string sql = "SELECT MAHP FROM DANGKYHOC WHERE MASV = @ma";
            return db.execute(sql, new SqlParameter("@ma", maSV)).Rows.Count;
        }

        public bool coTaiKhoan(string maSV)
        {
            string sql = "SELECT TENDANGNHAP FROM TAIKHOAN WHERE MASV = @ma";
            return db.execute(sql, new SqlParameter("@ma", maSV)).Rows.Count > 0;
        }

        
        public int themSinhVien(Dictionary<string, object?> duLieu)
        {
            string cot = string.Join(", ", duLieu.Keys);
            string thamSo = string.Join(", ", duLieu.Keys.Select(k => "@" + k));
            string sql = "INSERT INTO SINHVIEN (" + cot + ") VALUES (" + thamSo + ")";
            return db.executeNonQuery(sql, taoThamSo(duLieu));
        }

        public int suaSinhVien(Dictionary<string, object?> duLieu)
        {
            string gan = string.Join(", ", duLieu.Keys.Where(k => k != "MASV").Select(k => k + " = @" + k));
            string sql = "UPDATE SINHVIEN SET " + gan + " WHERE MASV = @MASV";
            return db.executeNonQuery(sql, taoThamSo(duLieu));
        }

        public int xoaSinhVien(string maSV)
        {
            
            db.executeNonQuery("DELETE FROM NOP WHERE MASV = @ma", new SqlParameter("@ma", maSV));
            return db.executeNonQuery("DELETE FROM SINHVIEN WHERE MASV = @ma", new SqlParameter("@ma", maSV));
        }

       
        public void capNhatGiayTo(string maSV, List<string> giayToDaNop)
        {
            HashSet<string> daCo = new HashSet<string>();
            foreach (DataRow r in getGiayToDaNop(maSV).Rows)
                daCo.Add(r["MAGIAYTO"].ToString() ?? "");

            foreach (string ma in giayToDaNop)
            {
                if (!daCo.Contains(ma))
                    db.executeNonQuery("INSERT INTO NOP (MASV, MAGIAYTO, NGAYNOP) VALUES (@sv, @gt, @ngay)",
                        new SqlParameter("@sv", maSV), new SqlParameter("@gt", ma),
                        new SqlParameter("@ngay", DateTime.Today));
            }
            foreach (string ma in daCo)
            {
                if (!giayToDaNop.Contains(ma))
                    db.executeNonQuery("DELETE FROM NOP WHERE MASV = @sv AND MAGIAYTO = @gt",
                        new SqlParameter("@sv", maSV), new SqlParameter("@gt", ma));
            }
        }

        SqlParameter[] taoThamSo(Dictionary<string, object?> duLieu)
        {
            
            return duLieu.Select(kv => new SqlParameter("@" + kv.Key, kv.Value ?? DBNull.Value)).ToArray();
        }
    }
}