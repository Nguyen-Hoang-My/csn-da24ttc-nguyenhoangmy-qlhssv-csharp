/*==============================================================*/
/* 03_SinhVienMau.sql - Sinh vien mau de thu form ho so         */
/* Chay SAU 01_TaoCSDL.sql va 02_DuLieuMau.sql.                 */
/* Ten, so CCCD deu la du lieu gia de thu chuong trinh.         */
/* Chay lai nhieu lan duoc: xoa 6 sinh vien mau roi them lai.   */
/*==============================================================*/
use QLHSSV
go

delete from DANGKYHOC where MASV in ('110123001','110124001','110124002','110124003','110125001','110125002')
delete from NOP       where MASV in ('110123001','110124001','110124002','110124003','110125001','110125002')
delete from TAIKHOAN  where MASV in ('110123001','110124001','110124002','110124003','110125001','110125002')
delete from SINHVIEN  where MASV in ('110123001','110124001','110124002','110124003','110125001','110125002')
go

insert into SINHVIEN (MASV, MAXA, MANGANH, MAKHOAHOC, HOLOT, TEN, NGAYSINH, GIOITINH, SODIENTHOAI, EMAIL,
                      NGAYNHAPHOC, TINHTRANG, SONHA, TENDUONG, SOCCCD, DANTOC, QUOCTICH, MALOP, HEDAOTAO,
                      TRUONGTHPT, NAMTNTHPT, PHUONGTHUCXETTUYEN, TOHOPXETTUYEN, DIEMXETTUYEN, KHUVUCUUTIEN)
values
 ('110123001','86001','7480201','K2023',N'Trần Minh',     N'Khang','2005-03-12',N'Nam','0901000001','khang@gmail.com',
  '2023-09-05',N'Đang học',N'12',N'Nguyễn Đáng','084205000001',N'Kinh',N'Việt Nam','DA23TTA',N'Chính quy',
  N'THPT Phạm Thái Bường',2023,N'Điểm thi tốt nghiệp THPT','A00',23.50,'KV2'),
 ('110124001','86002','7480201','K2024',N'Nguyễn Thị Ngọc',N'Anh', '2006-07-21',N'Nữ', '0901000002','ngocanh@gmail.com',
  '2024-09-04',N'Đang học',null, N'Ấp Long Bình','084306000002',N'Kinh',N'Việt Nam','DA24TTA',N'Chính quy',
  N'THPT Long Đức',2024,N'Học bạ THPT','A01',25.00,'KV2-NT'),
 ('110124002','86003','7480103','K2024',N'Thạch',         N'Sóc',  '2006-11-02',N'Nam','0901000003',null,
  '2024-09-04',N'Đang học',N'45',N'Điện Biên Phủ','084206000003',N'Khmer',N'Việt Nam','DA24KTP',N'Chính quy',
  N'THPT Dân tộc nội trú',2024,N'Điểm thi tốt nghiệp THPT','D01',21.75,'KV1'),
 ('110124003','92001','7340301','K2024',N'Lê Hoàng',      N'Yến',  '2006-01-30',N'Nữ', null,'yenle@gmail.com',
  '2024-09-04',N'Bảo lưu',N'8A',N'Trần Hưng Đạo','092306000004',N'Kinh',N'Việt Nam','DA24KTA',N'Chính quy',
  null,2024,null,null,null,'KV3'),
 ('110125001','86001','7220201','K2025',N'Phạm Gia',      N'Bảo',  '2007-05-17',N'Nam','0901000005','giabao@gmail.com',
  '2025-09-03',N'Đang học',null, N'Lê Lợi','084207000005',N'Kinh',N'Việt Nam','DA25NNA',N'Chính quy',
  N'THPT Trà Vinh',2025,N'Đánh giá năng lực','D01',null,'KV2'),
 ('110125002','79001','7480201','K2025',N'Võ Thanh',      N'Trúc', '2007-09-09',N'Nữ', '0901000006',null,
  '2025-09-03',N'Đang học',N'200',N'Nguyễn Huệ','079307000006',N'Kinh',N'Việt Nam','DA25TTA',N'Chính quy',
  null,2025,N'Học bạ THPT','A00',26.25,'KV3')
go

-- Giay to da nop: sinh vien 110124001 nop du, 110124002 con thieu
insert into NOP (MASV, MAGIAYTO, NGAYNOP) values
 ('110124001','GT01','2024-09-04'), ('110124001','GT02','2024-09-04'), ('110124001','GT03','2024-09-04'),
 ('110124001','GT04','2024-09-04'), ('110124001','GT05','2024-09-04'),
 ('110124002','GT01','2024-09-04'), ('110124002','GT04','2024-09-04'), ('110124002','GT06','2024-09-04')
go

select MASV, HOLOT + N' ' + TEN as HOTEN, MANGANH, MAKHOAHOC, TINHTRANG from SINHVIEN order by MASV
go
