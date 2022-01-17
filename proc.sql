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

alter proc usp_search_hocsinh_sdtphuhuynh @sdtphuhuynh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%'
go

alter proc usp_search_hocsinh_sdthocsinh @sdthocsinh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%'
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