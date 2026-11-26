/*==============================================================*/
/* 02_DuLieuMau.sql - Du lieu mau cho CSDL QLHSSV               */
/* Chay SAU file 01_TaoCSDL.sql.                                */
/* Du lieu de thu chuong trinh, sua lai theo khao sat thuc te.  */
/* Chay lai nhieu lan duoc: moi lan chay xoa du lieu danh muc   */
/* cu roi them lai (khi chua co sinh vien nao trong CSDL).      */
/*==============================================================*/
use QLHSSV
go

if db_name() <> 'QLHSSV'
begin
   raiserror('Chua co CSDL QLHSSV. Chay file 01_TaoCSDL.sql truoc.', 16, 1)
   set noexec on
end
go

/*==============================================================*/
/* 1. Xoa du lieu cu (bang con truoc, bang cha sau)             */
/*==============================================================*/
delete from TAIKHOAN
delete from GIAYTO
delete from XAPHUONG
delete from TINHTHANH
delete from KHOAHOC
delete from NGANH
delete from BOMON
delete from KHOA
go

/*==============================================================*/
/* 2. Them du lieu mau                                          */
/*==============================================================*/
insert into KHOA (MAKHOA, TENKHOA, TENTIENGANH, TENVIETTAT, LOAIDONVI) values
   ('CNTT', N'Khoa Công nghệ thông tin', 'Faculty of Information Technology', 'CNTT', N'Khoa'),
   ('KT',   N'Khoa Kinh tế',             'Faculty of Economics',              'KT',   N'Khoa'),
   ('NN',   N'Khoa Ngoại ngữ',           'Faculty of Foreign Languages',      'NN',   N'Khoa')
go

insert into BOMON (MABOMON, MAKHOA, TENBOMON) values
   ('BMCNTT', 'CNTT', N'Bộ môn Công nghệ thông tin'),
   ('BMCNPM', 'CNTT', N'Bộ môn Công nghệ phần mềm'),
   ('BMKETOAN', 'KT', N'Bộ môn Kế toán'),
   ('BMTA',   'NN',   N'Bộ môn Tiếng Anh')
go

insert into NGANH (MANGANH, MABOMON, TENNGANH, THOIGIANDAOTAO) values
   ('7480201', 'BMCNTT',   N'Công nghệ thông tin', 4.0),
   ('7480103', 'BMCNPM',   N'Kỹ thuật phần mềm',   4.0),
   ('7340301', 'BMKETOAN', N'Kế toán',             4.0),
   ('7220201', 'BMTA',     N'Ngôn ngữ Anh',        4.0)
go

insert into KHOAHOC (MAKHOAHOC, TENKHOAHOC, NAMBATDAU, NAMKETTHUC) values
   ('K2023', N'Khóa 2023', 2023, 2027),
   ('K2024', N'Khóa 2024', 2024, 2028),
   ('K2025', N'Khóa 2025', 2025, 2029),
   ('K2026', N'Khóa 2026', 2026, 2030)
go

insert into TINHTHANH (MATINH, TENTINH) values
   ('86', N'Tỉnh Vĩnh Long'),
   ('92', N'Thành phố Cần Thơ'),
   ('79', N'Thành phố Hồ Chí Minh')
go

-- Ma xa/phuong ben duoi la ma tu dat de thu, chua phai ma hanh chinh chinh thuc
insert into XAPHUONG (MAXA, MATINH, TENXA) values
   ('86001', '86', N'Phường Trà Vinh'),
   ('86002', '86', N'Phường Long Đức'),
   ('86003', '86', N'Phường Long Châu'),
   ('92001', '92', N'Phường Ninh Kiều'),
   ('79001', '79', N'Phường Sài Gòn')
go

insert into GIAYTO (MAGIAYTO, TENGIAYTO, BATBUOC) values
   ('GT01', N'Giấy báo trúng tuyển',                 1),
   ('GT02', N'Bản sao học bạ THPT',                  1),
   ('GT03', N'Bản sao giấy khai sinh',               1),
   ('GT04', N'Bản sao căn cước công dân',            1),
   ('GT05', N'Giấy chứng nhận tốt nghiệp tạm thời',  1),
   ('GT06', N'Giấy chứng nhận đối tượng ưu tiên',    0)
go

-- Mat khau luu dang ma bam SHA-256 (64 ky tu hex, chu thuong)
--   admin  / Admin@123
--   giaovu / Giaovu@123
insert into TAIKHOAN (TENDANGNHAP, MASV, MATKHAUHASH, HOTEN, VAITRO, TRANGTHAI) values
   ('admin',  null, lower(convert(char(64), hashbytes('SHA2_256', 'Admin@123'), 2)),  N'Quản trị hệ thống', 'ADMIN',  1),
   ('giaovu', null, lower(convert(char(64), hashbytes('SHA2_256', 'Giaovu@123'), 2)), N'Cán bộ giáo vụ',    'GIAOVU', 1)
go

/*==============================================================*/
/* 3. Kiem tra nhanh: so dong cua tung bang danh muc            */
/*==============================================================*/
select 'KHOA' as BANG, count(*) as SODONG from KHOA
union all select 'BOMON', count(*) from BOMON
union all select 'NGANH', count(*) from NGANH
union all select 'KHOAHOC', count(*) from KHOAHOC
union all select 'TINHTHANH', count(*) from TINHTHANH
union all select 'XAPHUONG', count(*) from XAPHUONG
union all select 'GIAYTO', count(*) from GIAYTO
union all select 'TAIKHOAN', count(*) from TAIKHOAN
go

set noexec off
go
