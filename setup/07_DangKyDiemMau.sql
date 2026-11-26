/*==============================================================*/
/* 07_DangKyDiemMau.sql - Dang ky hoc va diem mau               */
/* Chay SAU 03_SinhVienMau.sql, 05_HocPhanHocKyMau.sql va       */
/* 06_HamViewThuTuc.sql. Chay lai nhieu lan duoc.               */
/*                                                              */
/* Sinh vien 110124001 tai hien dung vi du Bang 2.3 cua bao cao:*/
/*  - HK 20241: 4 hoc phan, DTB hoc ky 2,25 (he 4), 6,68 (he 10)*/
/*    tich luy 9 tin chi, 3,00 (he 4), xep loai Kha             */
/*  - HK 20242: hoc lai CB1002 duoc 6,8 (C+), tich luy 12 TC,   */
/*    2,88 (he 4), van xep loai Kha                             */
/* HK 20261: 3 sinh vien dang ky IT2002, chua co diem, de thu   */
/* chuc nang nhap diem.                                         */
/*==============================================================*/
use QLHSSV
go

delete from DANGKYHOC where MASV in ('110123001','110124001','110124002')
go

insert into DANGKYHOC (MAHP, MASV, MAHOCKY, NGAYDANGKY, DIEMQUATRINH, DIEMTHI) values
   ('IT1001', '110124001', '20241', '2024-08-20', 8.0, 7.5),
   ('CB1004', '110124001', '20241', '2024-08-20', 6.0, 5.0),
   ('IT2001', '110124001', '20241', '2024-08-20', 9.0, 8.5),
   ('CB1002', '110124001', '20241', '2024-08-20', 5.0, 2.0)
go

insert into DANGKYHOC (MAHP, MASV, MAHOCKY, NGAYDANGKY, DIEMQUATRINH, DIEMTHI) values
   ('CB1002', '110124001', '20242', '2025-01-10', 7.0, 6.5)
go

insert into DANGKYHOC (MAHP, MASV, MAHOCKY, NGAYDANGKY, DIEMQUATRINH, DIEMTHI) values
   ('IT2002', '110124001', '20261', '2026-08-25', null, null),
   ('IT2002', '110124002', '20261', '2026-08-25', null, null),
   ('IT2002', '110123001', '20261', '2026-08-25', null, null)
go

exec dbo.sp_TongKetHocKy @MASV = '110124001'
go
