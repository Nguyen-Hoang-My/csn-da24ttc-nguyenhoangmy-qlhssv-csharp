/*==============================================================*/
/* 04_TaiKhoanSinhVienMau.sql - Tai khoan cho 6 sinh vien mau   */
/* Chay SAU 03_SinhVienMau.sql.                                 */
/* Ten dang nhap = ma sinh vien, mat khau = ma sinh vien.       */
/* Vi du: 110124001 / 110124001                                 */
/*==============================================================*/
use QLHSSV
go

delete from TAIKHOAN where TENDANGNHAP in ('110123001','110124001','110124002','110124003','110125001','110125002')
go

insert into TAIKHOAN (TENDANGNHAP, MASV, MATKHAUHASH, HOTEN, VAITRO, TRANGTHAI)
select MASV, MASV,
       lower(convert(char(64), hashbytes('SHA2_256', MASV), 2)),
       HOLOT + N' ' + TEN, 'SINHVIEN', 1
from SINHVIEN
where MASV in ('110123001','110124001','110124002','110124003','110125001','110125002')
go

select TENDANGNHAP, MASV, HOTEN, VAITRO from TAIKHOAN order by VAITRO, TENDANGNHAP
go
