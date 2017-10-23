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