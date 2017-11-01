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


Select TonKho.ID, TonKho.MaThuoc, TonKho.TenThuoc, TonKho.tonkho + SoLuongBan.soluongban - SoLuongNhap.soluongnhap
FROM
	(SELECT
		t.ID,
		t.MaThuoc,
		t.TenThuoc,
		Sum(ct_nhap.TonKho) as tonkho
	FROM CT_Thuoc_PhieuNhap as ct_nhap 
	JOIN Thuoc as t on t.ID = ct_nhap.Thuoc_ID
	GROUP BY t.ID) as TonKho

JOIN 
	(SELECT 
		ct_nhap.Thuoc_ID,
		SUM(ct_xuat.SoLuong) as soluongban
		FROM CT_Thuoc_PhieuXuat as ct_xuat
		JOIN CT_Thuoc_PhieuNhap as ct_nhap on ct_nhap.ID = ct_xuat.CT_Thuoc_PhieuNhap_ID
		GROUP BY ct_nhap.Thuoc_ID)  as SoLuongBan
ON TonKho.ID = SoLuongBan.Thuoc_ID

JOIN 
	(SELECT 
		ct_nhap.Thuoc_ID,
		SUM(ct_nhap.SoLuong) as soluongnhap
		FROM CT_Thuoc_PhieuNhap as ct_nhap
		GROUP BY ct_nhap.Thuoc_ID) as SoLuongNhap
ON TonKho.ID = SoLuongNhap.Thuoc_ID

	
