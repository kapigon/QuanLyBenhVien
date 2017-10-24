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