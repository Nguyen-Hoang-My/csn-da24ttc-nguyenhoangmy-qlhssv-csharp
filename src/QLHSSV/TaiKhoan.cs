using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace QLHSSV
{
    // LỚP XỬ LÝ cho bảng TAIKHOAN: đăng nhập, mã hóa mật khẩu
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
    }
}