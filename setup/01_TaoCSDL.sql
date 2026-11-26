/*==============================================================*/
/* 01_TaoCSDL.sql - Tao CSDL QLHSSV va 14 bang                  */
/* DBMS:  Microsoft SQL Server                                  */
/* Nguon: sinh tu PDM PowerDesigner (16/11/2026), da chinh sua  */
/*        - Tu tao va chon dung CSDL QLHSSV truoc khi tao bang  */
/*        - Bo cot SINHVIEN.TENDANGNHAP (khoa ngoai vong)       */
/*        - Doi cac cot ngay tu datetime sang date              */
/*        - Them DANGKYHOC.DIEMTHILAN2 (thi lai, QD 4363)       */
/* File nay chay lai nhieu lan duoc: moi lan chay se XOA het    */
/* bang cu trong QLHSSV roi tao lai tu dau.                     */
/*==============================================================*/

/*==============================================================*/
/* 1. Tao CSDL (neu chua co) va chuyen sang CSDL do             */
/*==============================================================*/
if db_id('QLHSSV') is null
   create database QLHSSV
go

use QLHSSV
go

-- Chot an toan: neu vi ly do nao do chua dung o QLHSSV thi dung lai,
-- khong tao bang nham vao master hay CSDL khac.
if db_name() <> 'QLHSSV'
begin
   raiserror('Chua chuyen duoc sang CSDL QLHSSV. Dung lai, khong tao bang.', 16, 1)
   set noexec on
end
go

/*==============================================================*/
/* 2. Xoa khoa ngoai va bang cu (neu co)                        */
/*==============================================================*/
declare @sql nvarchar(max) = N''
select @sql = @sql + N'alter table ' + quotename(object_name(parent_object_id))
            + N' drop constraint ' + quotename(name) + N';'
from sys.foreign_keys
exec sp_executesql @sql
go

if object_id('NOP', 'U')            is not null drop table NOP
if object_id('DANGKYHOC', 'U')      is not null drop table DANGKYHOC
if object_id('CHUONGTRINHHOC', 'U') is not null drop table CHUONGTRINHHOC
if object_id('TAIKHOAN', 'U')       is not null drop table TAIKHOAN
if object_id('SINHVIEN', 'U')       is not null drop table SINHVIEN
if object_id('GIAYTO', 'U')         is not null drop table GIAYTO
if object_id('HOCKY', 'U')          is not null drop table HOCKY
if object_id('HOCPHAN', 'U')        is not null drop table HOCPHAN
if object_id('KHOAHOC', 'U')        is not null drop table KHOAHOC
if object_id('NGANH', 'U')          is not null drop table NGANH
if object_id('BOMON', 'U')          is not null drop table BOMON
if object_id('KHOA', 'U')           is not null drop table KHOA
if object_id('XAPHUONG', 'U')       is not null drop table XAPHUONG
if object_id('TINHTHANH', 'U')      is not null drop table TINHTHANH
go

/*==============================================================*/
/* 3. Tao bang                                                  */
/*==============================================================*/

/*==============================================================*/
/* Table: KHOA                                                  */
/*==============================================================*/
create table KHOA (
   MAKHOA               varchar(10)          not null,
   TENKHOA              nvarchar(100)        not null,
   TENTIENGANH          varchar(100)         null,
   TENVIETTAT           varchar(10)          null,
   LOAIDONVI            nvarchar(20)         not null,
   TRUONGDONVI          nvarchar(100)        null,
   SDTKHOA              nvarchar(15)         null,
   SONOIBOKHOA          varchar(5)           null,
   EMAILKHOA            varchar(100)         null,
   WEBSITEKHOA          varchar(100)         null,
   DIACHIKHOA           nvarchar(200)        null,
   MOTAKHOA             nvarchar(1000)       null,
   constraint PK_KHOA primary key nonclustered (MAKHOA)
)
go

/*==============================================================*/
/* Table: BOMON                                                 */
/*==============================================================*/
create table BOMON (
   MABOMON              varchar(10)          not null,
   MAKHOA               varchar(10)          not null,
   TENBOMON             nvarchar(100)        not null,
   TRUONGBOMON          nvarchar(100)        null,
   EMAILBOMON           varchar(100)         null,
   SONOIBOBOMON         varchar(5)           null,
   TRANGTHONGTINBOMON   varchar(200)         null,
   MOTABOMON            nvarchar(1000)       null,
   constraint PK_BOMON primary key nonclustered (MABOMON)
)
go

create index GOM_FK on BOMON (MAKHOA ASC)
go

/*==============================================================*/
/* Table: NGANH                                                 */
/*==============================================================*/
create table NGANH (
   MANGANH              varchar(10)          not null,
   MABOMON              varchar(10)          not null,
   TENNGANH             nvarchar(100)        not null,
   THOIGIANDAOTAO       decimal(3,1)         not null,
   MOTANGANHHOC         nvarchar(1000)       null,
   constraint PK_NGANH primary key nonclustered (MANGANH)
)
go

create index QUAN_LY_FK on NGANH (MABOMON ASC)
go

/*==============================================================*/
/* Table: KHOAHOC                                               */
/*==============================================================*/
create table KHOAHOC (
   MAKHOAHOC            varchar(10)          not null,
   TENKHOAHOC           nvarchar(50)         not null,
   NAMBATDAU            smallint             not null,
   NAMKETTHUC           smallint             not null,
   constraint PK_KHOAHOC primary key nonclustered (MAKHOAHOC)
)
go

/*==============================================================*/
/* Table: TINHTHANH                                             */
/*==============================================================*/
create table TINHTHANH (
   MATINH               varchar(5)           not null,
   TENTINH              nvarchar(50)         not null,
   constraint PK_TINHTHANH primary key nonclustered (MATINH)
)
go

/*==============================================================*/
/* Table: XAPHUONG                                              */
/*==============================================================*/
create table XAPHUONG (
   MAXA                 varchar(10)          not null,
   MATINH               varchar(5)           not null,
   TENXA                nvarchar(100)        not null,
   constraint PK_XAPHUONG primary key nonclustered (MAXA)
)
go

create index CO_FK on XAPHUONG (MATINH ASC)
go

/*==============================================================*/
/* Table: HOCPHAN                                               */
/*==============================================================*/
create table HOCPHAN (
   MAHP                 varchar(10)          not null,
   TENHP                nvarchar(100)        not null,
   SOTINCHI             tinyint              not null,
   TYLEQUATRINH         decimal(3,2)         not null,
   constraint PK_HOCPHAN primary key nonclustered (MAHP)
)
go

/*==============================================================*/
/* Table: HOCKY                                                 */
/*==============================================================*/
create table HOCKY (
   MAHOCKY              varchar(10)          not null,
   TENHOCKY             nvarchar(50)         not null,
   NAMHOC               char(9)              not null,
   HOCKYSO              tinyint              not null,
   NGAYBATDAU           date                 not null,
   NGAYKETTHUC          date                 not null,
   constraint PK_HOCKY primary key nonclustered (MAHOCKY)
)
go

/*==============================================================*/
/* Table: GIAYTO                                                */
/*==============================================================*/
create table GIAYTO (
   MAGIAYTO             varchar(10)          not null,
   TENGIAYTO            nvarchar(100)        not null,
   BATBUOC              bit                  not null,
   constraint PK_GIAYTO primary key nonclustered (MAGIAYTO)
)
go

/*==============================================================*/
/* Table: SINHVIEN                                              */
/* (da bo cot TENDANGNHAP: quan he sinh vien - tai khoan chi    */
/*  luu mot chieu o TAIKHOAN.MASV)                              */
/*==============================================================*/
create table SINHVIEN (
   MASV                 varchar(10)          not null,
   MAXA                 varchar(10)          not null,
   MANGANH              varchar(10)          not null,
   MAKHOAHOC            varchar(10)          not null,
   HOLOT                nvarchar(50)         not null,
   TEN                  nvarchar(20)         not null,
   NGAYSINH             date                 not null,
   GIOITINH             nvarchar(3)          not null,
   SODIENTHOAI          nvarchar(10)         null,
   EMAIL                varchar(100)         null,
   NGAYNHAPHOC          date                 not null,
   TINHTRANG            nvarchar(20)         not null,
   SONHA                nvarchar(50)         null,
   TENDUONG             nvarchar(100)        not null,
   SOCCCD               varchar(12)          not null,
   DANTOC               nvarchar(30)         not null,
   TONGIAO              nvarchar(30)         null,
   NOISINH              nvarchar(100)        null,
   QUOCTICH             nvarchar(30)         not null,
   EMAILPHU             varchar(100)         null,
   ANHTHE               varchar(200)         null,
   MALOP                varchar(10)          not null,
   HEDAOTAO             nvarchar(30)         not null,
   NGAYCAPCCCD          date                 null,
   QUEQUAN              nvarchar(100)        null,
   HOTENCHA             nvarchar(100)        null,
   HOTENME              nvarchar(100)        null,
   TRUONGTHPT           nvarchar(100)        null,
   NAMTNTHPT            smallint             null,
   PHUONGTHUCXETTUYEN   nvarchar(50)         null,
   TOHOPXETTUYEN        varchar(5)           null,
   DIEMXETTUYEN         decimal(5,2)         null,
   DOITUONGUUTIEN       varchar(5)           null,
   KHUVUCUUTIEN         varchar(6)           null,
   constraint PK_SINHVIEN primary key nonclustered (MASV),
   constraint AK_IDENTIFIER_2_SINHVIEN unique (SOCCCD)
)
go

create index THEO_HOC_FK on SINHVIEN (MANGANH ASC)
go

create index THUOC_KHOA_FK on SINHVIEN (MAKHOAHOC ASC)
go

create index CU_TRU_FK on SINHVIEN (MAXA ASC)
go

/*==============================================================*/
/* Table: TAIKHOAN                                              */
/* MASV de trong (null) voi tai khoan quan tri, giao vu         */
/*==============================================================*/
create table TAIKHOAN (
   TENDANGNHAP          varchar(50)          not null,
   MASV                 varchar(10)          null,
   MATKHAUHASH          char(64)             not null,
   HOTEN                nvarchar(100)        not null,
   VAITRO               varchar(10)          not null,
   TRANGTHAI            bit                  not null,
   constraint PK_TAIKHOAN primary key nonclustered (TENDANGNHAP)
)
go

create index SO_HUU_FK on TAIKHOAN (MASV ASC)
go

/*==============================================================*/
/* Table: CHUONGTRINHHOC                                        */
/*==============================================================*/
create table CHUONGTRINHHOC (
   MANGANH              varchar(10)          not null,
   MAHP                 varchar(10)          not null,
   HOCKYDUKIEN          tinyint              not null,
   BATBUOC              bit                  not null,
   constraint PK_CHUONGTRINHHOC primary key (MANGANH, MAHP)
)
go

create index CHUONGTRINHHOC_FK on CHUONGTRINHHOC (MANGANH ASC)
go

create index CHUONGTRINHHOC2_FK on CHUONGTRINHHOC (MAHP ASC)
go

/*==============================================================*/
/* Table: DANGKYHOC                                             */
/*==============================================================*/
create table DANGKYHOC (
   MAHP                 varchar(10)          not null,
   MASV                 varchar(10)          not null,
   MAHOCKY              varchar(10)          not null,
   NGAYDANGKY           date                 not null,
   DIEMQUATRINH         decimal(4,2)         null,
   DIEMTHI              decimal(4,2)         null,
   DIEMTHILAN2          decimal(4,2)         null,
   constraint PK_DANGKYHOC primary key (MAHP, MASV, MAHOCKY)
)
go

create index DANGKYHOC_FK on DANGKYHOC (MAHP ASC)
go

create index DANGKYHOC2_FK on DANGKYHOC (MASV ASC)
go

create index DANGKYHOC3_FK on DANGKYHOC (MAHOCKY ASC)
go

/*==============================================================*/
/* Table: NOP                                                   */
/*==============================================================*/
create table NOP (
   MASV                 varchar(10)          not null,
   MAGIAYTO             varchar(10)          not null,
   NGAYNOP              date                 not null,
   HINHTHUC             nvarchar(30)         null,
   GHICHU               nvarchar(200)        null,
   constraint PK_NOP primary key (MASV, MAGIAYTO)
)
go

create index NOP_FK on NOP (MASV ASC)
go

create index NOP2_FK on NOP (MAGIAYTO ASC)
go

/*==============================================================*/
/* 4. Khoa ngoai                                                */
/*==============================================================*/
alter table BOMON
   add constraint FK_BOMON_GOM_KHOA foreign key (MAKHOA)
      references KHOA (MAKHOA)
go

alter table NGANH
   add constraint FK_NGANH_QUAN_LY_BOMON foreign key (MABOMON)
      references BOMON (MABOMON)
go

alter table XAPHUONG
   add constraint FK_XAPHUONG_CO_TINHTHAN foreign key (MATINH)
      references TINHTHANH (MATINH)
go

alter table SINHVIEN
   add constraint FK_SINHVIEN_CU_TRU_XAPHUONG foreign key (MAXA)
      references XAPHUONG (MAXA)
go

alter table SINHVIEN
   add constraint FK_SINHVIEN_THEO_HOC_NGANH foreign key (MANGANH)
      references NGANH (MANGANH)
go

alter table SINHVIEN
   add constraint FK_SINHVIEN_THUOC_KHO_KHOAHOC foreign key (MAKHOAHOC)
      references KHOAHOC (MAKHOAHOC)
go

alter table TAIKHOAN
   add constraint FK_TAIKHOAN_SO_HUU_SINHVIEN foreign key (MASV)
      references SINHVIEN (MASV)
go

alter table CHUONGTRINHHOC
   add constraint FK_CHUONGTR_CHUONGTRI_NGANH foreign key (MANGANH)
      references NGANH (MANGANH)
go

alter table CHUONGTRINHHOC
   add constraint FK_CHUONGTR_CHUONGTRI_HOCPHAN foreign key (MAHP)
      references HOCPHAN (MAHP)
go

alter table DANGKYHOC
   add constraint FK_DANGKYHO_DANGKYHOC_HOCPHAN foreign key (MAHP)
      references HOCPHAN (MAHP)
go

alter table DANGKYHOC
   add constraint FK_DANGKYHO_DANGKYHOC_SINHVIEN foreign key (MASV)
      references SINHVIEN (MASV)
go

alter table DANGKYHOC
   add constraint FK_DANGKYHO_DANGKYHOC_HOCKY foreign key (MAHOCKY)
      references HOCKY (MAHOCKY)
go

alter table NOP
   add constraint FK_NOP_NOP_SINHVIEN foreign key (MASV)
      references SINHVIEN (MASV)
go

alter table NOP
   add constraint FK_NOP_NOP2_GIAYTO foreign key (MAGIAYTO)
      references GIAYTO (MAGIAYTO)
go

/*==============================================================*/
/* 5. Kiem tra nhanh: danh sach bang vua tao (phai du 14 bang)  */
/*==============================================================*/
select name as TENBANG from sys.tables order by name
go

set noexec off
go
