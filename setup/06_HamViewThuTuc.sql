/*==============================================================*/
/* 06_HamViewThuTuc.sql - Rang buoc, ham, view, thu tuc, trigger*/
/* phuc vu dang ky hoc va tinh diem (theo QD 4363/QD-DHTV).     */
/* Chay SAU 01_TaoCSDL.sql. Chay lai nhieu lan duoc.            */
/*==============================================================*/
use QLHSSV
go

/*------------------------- Cot diem thi lan 2 ------------------*/
if col_length('DANGKYHOC', 'DIEMTHILAN2') is null
    alter table DANGKYHOC add DIEMTHILAN2 decimal(4,2) null
go

/*------------------------- Rang buoc CHECK ---------------------*/
alter table DANGKYHOC drop constraint if exists CK_DANGKYHOC_DIEMQT
alter table DANGKYHOC drop constraint if exists CK_DANGKYHOC_DIEMTHI
alter table DANGKYHOC drop constraint if exists CK_DANGKYHOC_DIEMTHI2
alter table DANGKYHOC drop constraint if exists CK_DANGKYHOC_THILAN2
alter table HOCPHAN   drop constraint if exists CK_HOCPHAN_SOTINCHI
alter table HOCPHAN   drop constraint if exists CK_HOCPHAN_TYLE
go
alter table DANGKYHOC add constraint CK_DANGKYHOC_DIEMQT  check (DIEMQUATRINH between 0 and 10)
alter table DANGKYHOC add constraint CK_DANGKYHOC_DIEMTHI check (DIEMTHI between 0 and 10)
alter table DANGKYHOC add constraint CK_DANGKYHOC_DIEMTHI2 check (DIEMTHILAN2 between 0 and 10)
alter table DANGKYHOC add constraint CK_DANGKYHOC_THILAN2 check (DIEMTHILAN2 is null or DIEMTHI is not null)
alter table HOCPHAN   add constraint CK_HOCPHAN_SOTINCHI  check (SOTINCHI between 1 and 10)
alter table HOCPHAN   add constraint CK_HOCPHAN_TYLE      check (TYLEQUATRINH between 0 and 1)
go

/*------------------------- Ham ---------------------------------*/
-- Diem hoc phan = lam tron(QT * tyle + Thi * (1 - tyle), 1). Chua co diem thi thi tra ve NULL.
-- Co diem thi lan 2 thi dung diem lan 2 thay diem lan 1, va diem hoc phan toi da 6,9.
create or alter function dbo.fn_DiemHocPhan(@qt decimal(4,2), @thi decimal(4,2), @thi2 decimal(4,2), @tyle decimal(3,2))
returns decimal(3,1)
as
begin
    declare @kq decimal(3,1)
    if @thi is null return null
    if @qt is null and @tyle > 0 return null
    set @kq = cast(round(isnull(@qt, 0) * @tyle + isnull(@thi2, @thi) * (1 - @tyle), 1) as decimal(3,1))
    if @thi2 is not null and @kq > 6.9 set @kq = 6.9
    return @kq
end
go

-- Quy doi diem hoc phan (thang 10) sang diem chu
create or alter function dbo.fn_DiemChu(@diem decimal(3,1))
returns varchar(2)
as
begin
    return case when @diem is null then null
                when @diem >= 9.0 then 'A'
                when @diem >= 8.0 then 'B+'
                when @diem >= 7.0 then 'B'
                when @diem >= 6.5 then 'C+'
                when @diem >= 5.5 then 'C'
                when @diem >= 5.0 then 'D+'
                when @diem >= 4.0 then 'D'
                else 'F' end
end
go

-- Quy doi diem hoc phan (thang 10) sang thang 4
create or alter function dbo.fn_DiemHe4(@diem decimal(3,1))
returns decimal(2,1)
as
begin
    return case when @diem is null then null
                when @diem >= 9.0 then 4.0
                when @diem >= 8.0 then 3.5
                when @diem >= 7.0 then 3.0
                when @diem >= 6.5 then 2.5
                when @diem >= 5.5 then 2.0
                when @diem >= 5.0 then 1.5
                when @diem >= 4.0 then 1.0
                else 0.0 end
end
go

-- Xep loai hoc luc theo diem trung binh thang 4
create or alter function dbo.fn_XepLoai(@dtbHe4 decimal(3,2))
returns nvarchar(20)
as
begin
    return case when @dtbHe4 is null then null
                when @dtbHe4 >= 3.6 then N'Xuất sắc'
                when @dtbHe4 >= 3.2 then N'Giỏi'
                when @dtbHe4 >= 2.5 then N'Khá'
                when @dtbHe4 >= 2.0 then N'Trung bình'
                when @dtbHe4 >= 1.0 then N'Yếu'
                else N'Kém' end
end
go

/*------------------------- View --------------------------------*/
-- Moi lan dang ky hoc kem diem hoc phan, diem chu, diem he 4 va dat/khong dat
create or alter view dbo.vw_DiemHocPhan
as
select x.*,
       dbo.fn_DiemChu(x.DIEMHP) as DIEMCHU,
       dbo.fn_DiemHe4(x.DIEMHP) as DIEMHE4,
       case when x.DIEMHP is null then null when x.DIEMHP >= 4.0 then 1 else 0 end as DAT
from (
    select d.MASV, d.MAHOCKY, k.TENHOCKY, k.NAMHOC, k.HOCKYSO, k.NGAYBATDAU,
           d.MAHP, h.TENHP, h.SOTINCHI, h.TYLEQUATRINH, d.NGAYDANGKY,
           d.DIEMQUATRINH, d.DIEMTHI, d.DIEMTHILAN2,
           dbo.fn_DiemHocPhan(d.DIEMQUATRINH, d.DIEMTHI, d.DIEMTHILAN2, h.TYLEQUATRINH) as DIEMHP
    from DANGKYHOC d
    join HOCPHAN h on d.MAHP = h.MAHP
    join HOCKY k on d.MAHOCKY = k.MAHOCKY
) x
go

/*------------------------- Thu tuc -----------------------------*/
-- Bang diem toan khoa cua mot sinh vien (moi lan hoc la mot dong, ke ca hoc lai)
create or alter procedure dbo.sp_BangDiemToanKhoa @MASV varchar(10)
as
begin
    set nocount on
    select MAHOCKY, TENHOCKY, MAHP, TENHP, SOTINCHI, DIEMQUATRINH, DIEMTHI, DIEMTHILAN2, DIEMHP, DIEMCHU, DIEMHE4,
           case when DAT is null then N'Chưa có điểm' when DAT = 1 then N'Đạt' else N'Không đạt' end as KETQUA
    from dbo.vw_DiemHocPhan
    where MASV = @MASV
    order by NGAYBATDAU, MAHP
end
go

-- Tong ket tung hoc ky: diem trung binh hoc ky (tat ca hoc phan co diem, ke ca F)
-- va diem trung binh tich luy den het hoc ky do (chi hoc phan dat, moi hoc phan lay lan hoc gan nhat)
create or alter procedure dbo.sp_TongKetHocKy @MASV varchar(10)
as
begin
    set nocount on
    select hk.MAHOCKY, hk.TENHOCKY,
           sum(v.SOTINCHI) as TCHOC,
           sum(case when v.DAT = 1 then v.SOTINCHI else 0 end) as TCDAT,
           cast(round(sum(v.DIEMHP * v.SOTINCHI) / sum(v.SOTINCHI), 2) as decimal(4,2)) as DTBHE10,
           cast(round(sum(v.DIEMHE4 * v.SOTINCHI) / sum(v.SOTINCHI), 2) as decimal(3,2)) as DTBHE4,
           tl.TCTICHLUY, tl.DTBTLHE10, tl.DTBTLHE4,
           dbo.fn_XepLoai(tl.DTBTLHE4) as XEPLOAI
    from dbo.vw_DiemHocPhan v
    join HOCKY hk on v.MAHOCKY = hk.MAHOCKY
    cross apply (
        select isnull(sum(t.SOTINCHI), 0) as TCTICHLUY,
               cast(round(sum(t.DIEMHP * t.SOTINCHI) / nullif(sum(t.SOTINCHI), 0), 2) as decimal(4,2)) as DTBTLHE10,
               cast(round(sum(t.DIEMHE4 * t.SOTINCHI) / nullif(sum(t.SOTINCHI), 0), 2) as decimal(3,2)) as DTBTLHE4
        from (
            select x.*, row_number() over (partition by x.MAHP order by x.NGAYBATDAU desc) as LAN
            from dbo.vw_DiemHocPhan x
            where x.MASV = @MASV and x.DIEMHP is not null and x.NGAYBATDAU <= hk.NGAYBATDAU
        ) t
        where t.LAN = 1 and t.DAT = 1
    ) tl
    where v.MASV = @MASV and v.DIEMHP is not null
    group by hk.MAHOCKY, hk.TENHOCKY, hk.NGAYBATDAU, tl.TCTICHLUY, tl.DTBTLHE10, tl.DTBTLHE4
    order by hk.NGAYBATDAU
end
go

/*------------------------- Trigger -----------------------------*/
-- Chi duoc dang ky hoc phan thuoc chuong trinh hoc cua nganh sinh vien,
-- va khong dang ky trung khi dang co mot lan hoc hoc phan do chua co diem.
create or alter trigger dbo.trg_DANGKYHOC_KiemTra on DANGKYHOC
after insert, update
as
begin
    set nocount on
    if exists (select 1 from inserted i
               join SINHVIEN s on i.MASV = s.MASV
               where not exists (select 1 from CHUONGTRINHHOC c
                                 where c.MANGANH = s.MANGANH and c.MAHP = i.MAHP))
    begin
        raiserror(N'Học phần không thuộc chương trình học của ngành sinh viên.', 16, 1)
        rollback transaction
        return
    end

    if not exists (select 1 from deleted)
       and exists (select 1 from inserted i
                   join DANGKYHOC d on d.MASV = i.MASV and d.MAHP = i.MAHP and d.MAHOCKY <> i.MAHOCKY
                   where d.DIEMTHI is null)
    begin
        raiserror(N'Sinh viên đang có một lần học học phần này chưa có điểm, không đăng ký trùng được.', 16, 1)
        rollback transaction
        return
    end
end
go

select name, type_desc from sys.objects
where name in ('fn_DiemHocPhan','fn_DiemChu','fn_DiemHe4','fn_XepLoai','vw_DiemHocPhan',
               'sp_BangDiemToanKhoa','sp_TongKetHocKy','trg_DANGKYHOC_KiemTra')
order by type_desc, name
go
