/* lấy ra tên thuốc trong ThoiGianCanhBaoHetHan  */

select  t.Tenthuoc, GETDATE(), DATEADD(DAY, 30, ct_t.HSD), t.ThoiGianCanhBaoHetHan from CT_Thuoc_PhieuNhap as ct_t
join thuoc as t on t.ID = ct_t.Thuoc_ID
where GETDATE() >= DATEADD(DAY, -t.ThoiGianCanhBaoHetHan, ct_t.HSD)

/*-----------------------------------------------*/

select *from Thuoc
where id = 21

update thuoc
set ThoiGianCanhBaoHetHan = 9
where id = 21

select *from CT_Thuoc_PhieuXuat

select *from PhieuXuatThuoc

SELECT pdc.CT_Thuoc_PhieuNhap_ID, SUM(pdc.SoLuongTang) as SLT, SUM(pdc.SoLuongGiam) as SLG from PHIEUDIEUCHINH as pdc
GROUP BY pdc.CT_Thuoc_PhieuNhap_ID


/*Tinhs so luong sau khi dieu chinh*/
SELECT ct_phieu.ID, ct_phieu.TonKho + tinhtong.SLT - tinhtong.SLG
FROM CT_Thuoc_PhieuNhap as ct_phieu
JOIN (SELECT pdc.CT_Thuoc_PhieuNhap_ID as ID, SUM(pdc.SoLuongTang) as SLT, SUM(pdc.SoLuongGiam) as SLG from PHIEUDIEUCHINH as pdc
GROUP BY pdc.CT_Thuoc_PhieuNhap_ID) as tinhtong on tinhtong.ID = ct_phieu.ID

/*
join tinhtong in
(from pdc in db.PhieuDieuChinh
 group pdc by pdc.CT_Thuoc_PhieuNhap_ID into gr_ID
select new {
	CT_Thuoc_PhieuNhap_ID = gr_ID.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
	SoLuongTang = gr_ID.Sum(p => p.SoLuongTang),
	SoLuongGiam = gr_ID.Sum(p => p.SoLuongGiam)
}) on ct_thuoc_nhap.ID equals tinhtong.CT_Thuoc_PhieuNhap_ID*/



SELECT 
	--ct_xuat.SoLuong, ct_xuat.NgayBan,
	ct_xuat.CT_Thuoc_PhieuNhap_ID,
	SUM(ct_xuat.SoLuong) as 'Số lượng bán'
FROM CT_Thuoc_PhieuXuat as ct_xuat
JOIN CT_Thuoc_PhieuNhap as ct_nhap on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30') and ct_xuat.NgayBan <= convert(date, '2017/10/30')
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID

/* LẤY RA SỐ LƯỢNG BÁN HÀNG THEO CT_Thuoc_PhieuNhap_ID 		(1)*/
SELECT 
	ct_xuat.CT_Thuoc_PhieuNhap_ID,
	SUM(ct_xuat.SoLuong) as 'Số lượng bán'
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30') and ct_xuat.NgayBan <= convert(date, '2017/10/30')
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID

/* LẤY RA SỐ LƯỢNG ĐÃ BÁN TỪ THỜI ĐIỂM MUỐN KIỂM KÊ			(2)*/
SELECT 
	ct_xuat.CT_Thuoc_PhieuNhap_ID,
	SUM(ct_xuat.SoLuong) as 'Số lượng bán'
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30')
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID

/* LẤY RA SỐ LƯỢNG NHẬP TỪ TRONG KỲ 						(3)*/
SELECT 
	ct_nhap.Thuoc_ID,
	SUM(ct_nhap.SoLuong) as 'Số lượng nhập'
FROM CT_Thuoc_PhieuNhap as ct_nhap
WHERE ct_nhap.NgayNhap >= convert(date, '2017/10/30') and ct_nhap.NgayNhap <= convert(date, '2017/10/30')
GROUP BY ct_nhap.Thuoc_ID

/* (1) + (2) + (3)*/
SELECT
	t.ID,
	--t.MaThuoc, t.TenThuoc,
	Sum(ct_nhap.TonKho) + (SELECT 
							SUM(ct_xuat.SoLuong) as 'Số lượng bán'
							FROM CT_Thuoc_PhieuXuat as ct_xuat
							JOIN CT_Thuoc_PhieuNhap as ct_nhap on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
							WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30') and ct_nhap.Thuoc_ID = 1157
							GROUP BY ct_nhap.Thuoc_ID) 
	--ct_xuat.SoLuong,
	--ct_xuat.NgayBan
	--ct_xuat.SoLuong, ct_xuat.NgayBan
	--COUNT(ct_xuat.SoLuong) as 'Số lượng bán'
FROM CT_Thuoc_PhieuNhap as ct_nhap 
JOIN Thuoc as t on t.ID = ct_nhap.Thuoc_ID
WHERE t.ID = 1157
GROUP BY t.ID


JOIN CT_Thuoc_PhieuXuat as ct_xuat on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID

select *from CT_Thuoc_PhieuXuat
--JOIN (SELECT 
--		ct_nhap.Thuoc_ID,
--		SUM(ct_nhap.SoLuong) as 'Số lượng nhập'
--		FROM CT_Thuoc_PhieuNhap as ct_nhap
--		WHERE ct_nhap.NgayNhap >= convert(date, '2017/10/30') and ct_nhap.NgayNhap <= convert(date, '2017/10/30')
--		GROUP BY ct_nhap.Thuoc_ID) as ct_nhap on t.ID = ct_nhap.Thuoc_ID
--JOIN (SELECT 
--		ct_xuat.CT_Thuoc_PhieuNhap_ID,
--		SUM(ct_xuat.SoLuong) as 'Số lượng bán'
--		FROM CT_Thuoc_PhieuXuat as ct_xuat
--		WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30')
--		GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID


select *From CT_Thuoc_PhieuNhap
select ct_xuat.CT_Thuoc_PhieuNhap_ID, ct_xuat.SoLuong From CT_Thuoc_PhieuXuat as ct_xuat
WHERE ct_xuat.NgayBan >= convert(date, '2017/10/30') and ct_xuat.NgayBan <= convert(date, '2017/10/31')


SELECT thuoc.ID, thuoc.TenThuoc FROM Thuoc as thuoc


---------------
select t.ID, t.MaThuoc, t.TenThuoc, groupNhom.Ton as 'TonDauKy', groupNhom.SoLuongNhap as 'NhapTrongKy', groupNhom.soluongxuat as 'XuatTrongKy', groupNhom.giaban as 'ThanhTien', groupNhom.SoLuongNhap - groupNhom.soluongxuat as 'TonCuoiKy'
FROM
(Select TonKho.ID,(TonKho.tonkho + SoLuongXuat.soluongxuat - SoLuongNhap.soluongnhap) as Ton, SoLuongNhap, SoLuongXuat, giaban
FROM
	(SELECT 
		ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as soluongxuat,
		Sum(ct_xuat.GiaBan) as giaban
		FROM CT_Thuoc_PhieuXuat as ct_xuat
		JOIN CT_Thuoc_PhieuNhap as ct_nhap on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
		GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID)  as SoLuongXuat
JOIN 
	(SELECT ct_nhap.ID,
		Sum(ct_nhap.TonKho) as tonkho
	FROM CT_Thuoc_PhieuNhap as ct_nhap 
	GROUP BY ct_nhap.Thuoc_ID) as TonKho
ON TonKho.ID = SoLuongXuat.Thuoc_ID

JOIN 
	(SELECT 
		ct_nhap.Thuoc_ID,
		SUM(ct_nhap.SoLuong) as soluongnhap
		FROM CT_Thuoc_PhieuNhap as ct_nhap
		GROUP BY ct_nhap.Thuoc_ID) as SoLuongNhap
ON TonKho.ID = SoLuongNhap.Thuoc_ID) AS groupNHOM 
JOIN Thuoc as t on t.ID = groupNHOM.ID

select *from CT_Thuoc_PhieuNhap where Thuoc_ID = 1157
select *From CT_Thuoc_PhieuXuat
where Thuoc_ID = 1157




select	ct_nhap.ID, ct_nhap.TonKho, ct_nhap.Soluong as SoLuongNhap, 
		ct_xuat.SoLuong as SoLuongXuat, ct_xuat.GiaBan,
		ct_nhap.TonKho + ct_xuat.SoLuong  as TonDauKy,
		ct_nhap.Soluong - ct_xuat.SoLuong as TonKhoCuoiKy

from CT_Thuoc_PhieuNhap as ct_nhap	
	
LEFT JOIN 
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/01'))--and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat
on ct_xuat.CT_Thuoc_PhieuNhap_ID = ct_nhap.ID

LEFT JOIN
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03'))-- and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuatTuNgayDenHien
on ct_xuatTuNgayDenHien.CT_Thuoc_PhieuNhap_ID = ct_nhap.ID


select ct_xuat.CT_Thuoc_PhieuNhap_ID, ct_xuat.SoLuong, ct_xuatTuNgayDenHien.SoLuong, ct_nhap.SoLuong, ct_nhap.TonKho, ct_xuat_trongky.SoLuong,
		ct_nhap.TonKho + ct_xuat.SoLuong - ct_nhap.SoLuong  as TonKhoDauKy,
		ct_nhap.TonKho + ct_xuat.SoLuong - ct_xuat_trongky.SoLuong as TonKhoCuoiKy
from
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/01'))--and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat

LEFT JOIN
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03'))-- and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuatTuNgayDenHien
on ct_xuatTuNgayDenHien.CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID

LEFT JOIN
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/01')and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat_trongky
on ct_xuat_trongky.CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID

LEFT JOIN CT_Thuoc_PhieuNhap as ct_nhap
on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
where ct_nhap.NgayNhap = convert(date, '2017/11/01')



select *from CT_Thuoc_phieuXuat
select *from CT_Thuoc_phieuNhap
select *from PhieuNhapThuoc

Select *from Thuoc where ID = 1157