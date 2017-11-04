select thuoc.MaThuoc, thuoc.TenThuoc,
		ct_nhap.TonKho + ct_xuat.SoLuong - ct_xuat_tungay.SoLuong  as TonKhoDauKy,
		ct_xuat.CT_Thuoc_PhieuNhap_ID, --ct_xuat.SoLuong, 
		 ct_nhap.SoLuong, ct_nhap.TonKho, --ct_xuat_trongky.SoLuong,
		ct_nhap.TonKho + ct_xuat.SoLuong - ct_xuat_trongky.SoLuong as TonKhoCuoiKy
from
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03'))--and ct_xuat.NgayBan <= convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat

JOIN
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03')and ct_xuat.NgayBan <= convert(date, '2017/11/04'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat_trongky
on ct_xuat_trongky.CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID

JOIN
(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan = convert(date, '2017/11/03'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat_tungay
on ct_xuat_tungay.CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID

JOIN (SELECT Thuoc_ID, ID, SoLuong, TonKho
FROM CT_Thuoc_PhieuNhap as ct_nhap) as ct_nhap
on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
JOIN 
(SELECT ID, MaThuoc, TenThuoc from Thuoc as thuoc) as thuoc
on thuoc.ID = ct_nhap.Thuoc_ID


JOIN
(SELECT Thuoc_ID, ID, SoLuong, TonKho
FROM CT_Thuoc_PhieuNhap as ct_nhap
where ct_nhap.NgayNhap = convert(date, '2017/11/01')) as ct_nhap
on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID




select *From CT_Thuoc_PhieuNhap where NgayNhap < convert(date, '2017/11/02')
select *From CT_Thuoc_PhieuXuat where NgayBan < convert(date, '2017/11/02')

select ct_nhap.SoLuong as Nhap, ct_xuat.SoLuong as Xuat,
		ct_nhap.SoLuong  - ct_xuat.SoLuong  as TonKho
from CT_Thuoc_PhieuNhap as ct_nhap
join CT_Thuoc_PhieuXuat as ct_xuat on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
where ct_nhap.NgayNhap < convert(date, '2017/11/02') and ct_xuat.NgayBan < convert(date, '2017/11/02')


select ct_nhap.SoLuong as Nhap, ct_xuat.SoLuong as Xuat,
		ct_nhap.SoLuong  - ct_xuat.SoLuong  as TonKho
from CT_Thuoc_PhieuNhap as ct_nhap
join CT_Thuoc_PhieuXuat as ct_xuat on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
where ct_nhap.NgayNhap < convert(date, '2017/11/04') and ct_xuat.NgayBan < convert(date, '2017/11/04')
select *From NCC_KH


select ID, SoLuong from CT_Thuoc_PhieuNhap
where NgayNhap < convert(date, '2017/11/02')

select ID, SUM(SoLuong) from CT_Thuoc_PhieuXuat
where NgayBan < convert(date, '2017/11/02')
group by CT_Thuoc_PhieuNhap_ID


select ID, SoLuong from CT_Thuoc_PhieuNhap
where NgayNhap <= convert(date, '2017/11/04')

select CT_Thuoc_PhieuNhap_ID, SUM(SoLuong) from CT_Thuoc_PhieuXuat
where NgayBan <= convert(date, '2017/11/04')
group by CT_Thuoc_PhieuNhap_ID

SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
FROM CT_Thuoc_PhieuXuat as ct_xuat
WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03')and ct_xuat.NgayBan <= convert(date, '2017/11/04'))
GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID







select thuoc.MaThuoc, thuoc.TenThuoc, ct_nhap.ID,
		CASE
			WHEN nhap_truoc.soLuong IS NOT NULL THEN nhap_truoc.soLuong
			ELSE 0
		END as NhapTruoc,
		CASE
			WHEN xuat_truoc.soLuong IS NOT NULL THEN xuat_truoc.soLuong
			ELSE 0
		END as XuatTruoc,
		CASE
			WHEN nhap_sau.soLuong IS NOT NULL THEN nhap_sau.soLuong
			ELSE 0
		END as NhapSau,
		CASE
			WHEN xuat_sau.soLuong IS NOT NULL THEN xuat_sau.soLuong
			ELSE 0
		END as XuatSau,
		CASE
			WHEN ct_xuat.SoLuong IS NOT NULL THEN ct_xuat.SoLuong
			ELSE 0
		END as SoLuongXuatTrongKy,
		CASE
			WHEN ct_xuat.GiaBan IS NOT NULL THEN ct_xuat.GiaBan
			ELSE 0
		END as GiaBanTrongKy
from CT_Thuoc_PhieuNhap as ct_nhap								--(1)

LEFT JOIN 
(SELECT  ID, SoLuong FROM CT_Thuoc_PhieuNhap
WHERE NgayNhap < convert(date, '2017/11/02')) as nhap_truoc		--(2)
ON nhap_truoc.ID = ct_nhap.ID

LEFT JOIN 
(SELECT CT_Thuoc_PhieuNhap_ID, SUM(SoLuong) as SoLuong			--(3)
	FROM CT_Thuoc_PhieuXuat
	WHERE NgayBan < convert(date, '2017/11/02')
	GROUP BY CT_Thuoc_PhieuNhap_ID) as xuat_truoc
ON xuat_truoc.CT_Thuoc_PhieuNhap_ID = ct_nhap.ID

LEFT JOIN 
(SELECT  ID, SoLuong FROM CT_Thuoc_PhieuNhap
WHERE NgayNhap <= convert(date, '2017/11/04')) as nhap_sau		--(4)
ON nhap_sau.ID = ct_nhap.ID

LEFT JOIN 
(SELECT CT_Thuoc_PhieuNhap_ID, SUM(SoLuong) as SoLuong			--(5)
	FROM CT_Thuoc_PhieuXuat
	WHERE NgayBan <= convert(date, '2017/11/04')
	GROUP BY CT_Thuoc_PhieuNhap_ID) as xuat_sau
ON xuat_sau.CT_Thuoc_PhieuNhap_ID = ct_nhap.ID

LEFT JOIN
	(SELECT ct_xuat.CT_Thuoc_PhieuNhap_ID,						--(6)
		SUM(ct_xuat.SoLuong) as SoLuong, 
		SUM(ct_xuat.GiaBan) as GiaBan
	FROM CT_Thuoc_PhieuXuat as ct_xuat
	WHERE (ct_xuat.NgayBan >= convert(date, '2017/11/03') and ct_xuat.NgayBan <= convert(date, '2017/11/04'))
	GROUP BY ct_xuat.CT_Thuoc_PhieuNhap_ID) as ct_xuat
ON ct_xuat.CT_Thuoc_PhieuNhap_ID = ct_nhap.ID

LEFT JOIN
	(SELECT ct_nhap.ID,											--(7)
		SUM(ct_nhap.SoLuong) as SoLuong 
	FROM CT_Thuoc_PhieuNhap as ct_nhap
	WHERE (ct_nhap.NgayNhap >= convert(date, '2017/11/03') and ct_nhap.NgayNhap <= convert(date, '2017/11/04'))
	GROUP BY ct_nhap.ID) as ct_nhap_trongky
ON ct_nhap_trongky.ID = ct_nhap.ID

LEFT JOIN 
	Thuoc as thuoc												--(8)
ON thuoc.ID = ct_nhap.Thuoc_ID

LEFT JOIN 
	DonViTinh as dvt
ON dvt.ID = ct_nhap.DVT_Theo_DVT_Thuoc_ID						--(9)