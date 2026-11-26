/*==============================================================*/
/* QLHSSV - View phuc vu thong ke (chay sau 06_HamViewThuTuc.sql) */
/*==============================================================*/
use QLHSSV
go

-- Tich luy cua tung sinh vien: chi tinh hoc phan dat, moi hoc phan lay lan hoc gan nhat
-- (cung cach tinh voi sp_TongKetHocKy o hoc ky cuoi cung)
create or alter view dbo.vw_TichLuySinhVien
as
select t.MASV,
       sum(t.SOTINCHI) as TCTICHLUY,
       cast(round(sum(t.DIEMHP * t.SOTINCHI) / nullif(sum(t.SOTINCHI), 0), 2) as decimal(4,2)) as DTBTLHE10,
       cast(round(sum(t.DIEMHE4 * t.SOTINCHI) / nullif(sum(t.SOTINCHI), 0), 2) as decimal(3,2)) as DTBTLHE4
from (
    select x.MASV, x.MAHP, x.SOTINCHI, x.DIEMHP, x.DIEMHE4, x.DAT,
           row_number() over (partition by x.MASV, x.MAHP order by x.NGAYBATDAU desc) as LAN
    from dbo.vw_DiemHocPhan x
    where x.DIEMHP is not null
) t
where t.LAN = 1 and t.DAT = 1
group by t.MASV
go

-- Moi sinh vien mot dong: thong tin hanh chinh, ket qua tich luy, so giay to bat buoc con thieu
create or alter view dbo.vw_SinhVienTongHop
as
select s.MASV, s.HOLOT + N' ' + s.TEN as HOTEN, s.NGAYSINH, s.GIOITINH, s.MALOP, s.TINHTRANG,
       s.MANGANH, n.TENNGANH, kh.MAKHOA, kh.TENKHOA, s.MAKHOAHOC, k.TENKHOAHOC, k.NAMBATDAU,
       isnull(tl.TCTICHLUY, 0) as TCTICHLUY, tl.DTBTLHE10, tl.DTBTLHE4,
       isnull(dbo.fn_XepLoai(tl.DTBTLHE4), N'Chưa xếp loại') as XEPLOAI,
       (select count(*) from GIAYTO g
        where g.BATBUOC = 1
          and not exists (select 1 from NOP p where p.MASV = s.MASV and p.MAGIAYTO = g.MAGIAYTO)) as SOGIAYTOTHIEU
from SINHVIEN s
join NGANH n on s.MANGANH = n.MANGANH
join BOMON b on n.MABOMON = b.MABOMON
join KHOA kh on b.MAKHOA = kh.MAKHOA
join KHOAHOC k on s.MAKHOAHOC = k.MAKHOAHOC
left join dbo.vw_TichLuySinhVien tl on tl.MASV = s.MASV
go

select MASV, HOTEN, TENKHOA, TCTICHLUY, DTBTLHE4, XEPLOAI, SOGIAYTOTHIEU from dbo.vw_SinhVienTongHop order by MASV
go
