use QuanLyHocSinh
-- search hocsinh
create proc usp_search_hocsinh @holot nvarchar(20), @ten nvarchar(10)
as
	if not exists (select * from HocSinh where HoLot like '%'+@holot+'%' and Ten like '%'+@ten+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where HoLot like '%'+@holot+'%' and Ten like '%'+@ten+'%'
go

create proc usp_search_hocsinh_exact @holot nvarchar(20), @ten nvarchar(10)
as
	if not exists (select * from HocSinh where HoLot like @holot and Ten like @ten)
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where HoLot like @holot and Ten like @ten
go

create proc usp_search_hocsinh_sdtphuhuynh @sdtphuhuynh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%'
go

create proc usp_search_hocsinh_sdthocsinh @sdthocsinh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%'
go

create proc usp_search_hocsinh_by_id @mahs int
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where MaHS = @mahs
go

exec usp_search_hocsinh_sdtphuhuynh N'0938'
-- create hocsinh
create proc usp_create_hocsinh 
	@holot nvarchar(20),
	@ten nvarchar(10),
	@sdthocsinh nvarchar(12),
	@sdtphuhuynh nvarchar(12),
	@lop nvarchar(5),
	@xacnhansdt bit,
	@nienkhoa nchar(10)
as
	if exists (select * from HocSinh where HoLot like @holot and Ten like @ten and SDTPhuHuynh like @sdtphuhuynh)
	begin
		RAISERROR(N'Học sinh này đã tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	insert into HocSinh(HoLot, Ten, SDTHocSinh, SDTPhuHuynh, Lop, XacNhanSDT, NienKhoa)
	values (@holot, @ten, @sdthocsinh, @sdtphuhuynh, @lop, @xacnhansdt, @nienkhoa)
go
-- update hocsinh
create proc usp_update_hocsinh 
	@mahs int,
	@holot nvarchar(20),
	@ten nvarchar(10),
	@sdthocsinh nvarchar(12),
	@sdtphuhuynh nvarchar(12),
	@lop nvarchar(5),
	@xacnhansdt bit,
	@nienkhoa nchar(10)
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Học sinh này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	update HocSinh
	set HoLot = @holot, Ten = @ten, SDTHocSinh = @sdthocsinh, SDTPhuHuynh = @sdtphuhuynh, Lop = @lop, XacNhanSDT = @xacnhansdt, NienKhoa = @nienkhoa
	where MaHS = @mahs
go
-- delete hocsinh
create proc usp_delete_hocsinh 
	@mahs int
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Học sinh này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	delete from HocSinh
	where MaHS = @mahs
go
-- giaovien
-- load all giaovien
create proc usp_load_giaovien
as
	select * from GiaoVien
go
-- find giaovien by id
create proc usp_find_giaovien_by_id @magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	select * from GiaoVien where MaGiaoVien = @magv
go
-- lophoc
-- create lophoc
create proc usp_create_lophoc
	@tenlh nvarchar(8),
	@nienkhoa nchar(10),
	@magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	insert into LopHoc(TenLopHoc, NienKhoa, MaGiaoVien)
	values (@tenlh, @nienkhoa, @magv)
go
-- update lophoc
create proc usp_update_lophoc
	@malh int,
	@tenlh nvarchar(8),
	@nienkhoa nchar(10),
	@magv int
as
	if not exists (select * from LopHoc where MaLopHoc = @malh)
	begin
		RAISERROR(N'Lớp học này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	update LopHoc
	set TenLopHoc = @tenlh, NienKhoa = @nienkhoa, MaGiaoVien = @magv
	where MaLopHoc = @malh
go
-- delete lophoc
create proc usp_delete_lophoc
	@malh int
as
	if not exists (select * from LopHoc where MaLopHoc = @malh)
	begin
		RAISERROR(N'Lớp học này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	delete from LopHoc
	where MaLopHoc = @malh
go
-- find lophoc by id giaovien
create proc usp_find_lophoc_by_giaovien @magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	select * from LopHoc where MaGiaoVien = @magv
go
-- find lophoc by id giaovien with nienkhoa
create proc usp_find_lophoc_by_giaovien_with_nienkhoa @magv int, @nienkhoa nchar(10)
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên của lớp học này không tồn tại!',16,1)
		return
	end
	select * from LopHoc where MaGiaoVien = @magv and NienKhoa = @nienkhoa
go
-- get all nienkhoa in lophoc
create proc usp_get_nienkhoa @magv int
as
	select distinct NienKhoa from LopHoc where MaGiaoVien = @magv
go

-- lophocdangky
-- get lophocdangky by idlophoc
create proc usp_find_lophocdangky_by_idlophoc @malophoc int
as
	if not exists (select * from LopHoc where MaLopHoc = @malophoc)
	begin
		RAISERROR(N'Lớp học không tồn tại!',16,1)
		return
	end
	select * from LopHocDangKy 
	where MaLopHoc = @malophoc
go

-- exec usp_find_lophocdangky_by_idlophoc '1'

-- get lophocdangky by idlophoc, month
create proc usp_get_lhdk_by_month_idlophoc @malophoc int, @thang date
as
if not exists (select * from LopHoc where MaLopHoc = @malophoc)
	begin
		RAISERROR(N'Lớp học không tồn tại!',16,1)
		return
	end
	select lhdk.*, hs.HoLot, hs.Ten, hpn.SoTienNo, hp.SoTienDong
	from LopHocDangKy lhdk 
	join HocSinh hs on lhdk.MaHocSinh = hs.MaHS
	left join (select MaDangKy, SUM(TienNo) as SoTienNo from HocPhiNo group by MaDangKy) hpn on lhdk.MaDangky = hpn.MaDangKy
	left join (select MaDangKy, SUM(GiaTien) as SoTienDong from HocPhi where ThangDong = @thang group by MaDangKy) hp on lhdk.MaDangky = hp.MaDangKy
	where lhdk.MaLopHoc = @malophoc and DATEDIFF(month, lhdk.NgayBatDau, @thang) >= 0 and (lhdk.TinhTrang = 1 or DATEDIFF(month, lhdk.NgayKetThuc, @thang) = 0)
go
