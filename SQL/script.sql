USE [master]
GO
/****** Object:  Database [QuanLyHocSinh]    Script Date: 2/21/2022 12:10:14 AM ******/
CREATE DATABASE [QuanLyHocSinh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyHocSinh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLyHocSinh.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyHocSinh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QuanLyHocSinh_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyHocSinh] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyHocSinh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyHocSinh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyHocSinh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyHocSinh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyHocSinh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyHocSinh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyHocSinh] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyHocSinh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyHocSinh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyHocSinh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyHocSinh] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyHocSinh] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyHocSinh]
GO
/****** Object:  Table [dbo].[BangDiemDanh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiemDanh](
	[MaDangKy] [int] NOT NULL,
	[MaDiemDanh] [int] NOT NULL,
	[ThoiGianDiemDanh] [datetime] NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_BangDiemDanh] PRIMARY KEY CLUSTERED 
(
	[MaDangKy] ASC,
	[MaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietLuong]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietLuong](
	[MaChiTietLuong] [int] NOT NULL,
	[MaLuong] [int] NOT NULL,
	[Thang] [date] NULL,
	[SoTien] [int] NULL,
	[Loai] [int] NULL,
 CONSTRAINT [PK_ChiTietLuong] PRIMARY KEY CLUSTERED 
(
	[MaChiTietLuong] ASC,
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGiaovien] [int] IDENTITY(1,1) NOT NULL,
	[DanhXung] [nvarchar](5) NULL,
	[TenGiaoVien] [nvarchar](30) NULL,
	[SDTGiaoVien] [nvarchar](12) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGiaovien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GioHoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHoc](
	[MaGioHoc] [int] NOT NULL,
	[MaLopHoc] [int] NOT NULL,
	[Thu] [int] NULL,
	[Gio] [time](0) NULL,
 CONSTRAINT [PK_GioHoc] PRIMARY KEY CLUSTERED 
(
	[MaGioHoc] ASC,
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GioHocKhac]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHocKhac](
	[MaGioHocKhac] [int] IDENTITY(1,1) NOT NULL,
	[NgayNghi] [date] NULL,
	[ThoiGianBu] [datetime] NULL,
	[MaLopHoc] [int] NOT NULL,
 CONSTRAINT [PK_GioHocKhac] PRIMARY KEY CLUSTERED 
(
	[MaGioHocKhac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocPhi]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhi](
	[MaHocPhi] [int] IDENTITY(1,1) NOT NULL,
	[ThangDong] [date] NOT NULL,
	[GiaTien] [int] NOT NULL,
	[ThoiGianDong] [datetime] NOT NULL,
	[NguoiDong] [nvarchar](20) NULL,
	[NguoiThu] [nvarchar](20) NULL,
	[DongTai] [nvarchar](20) NULL,
	[SoBienLaiGiay] [nvarchar](10) NULL,
	[ThoiGianChinhSua] [datetime] NULL,
	[MaDangKy] [int] NOT NULL,
 CONSTRAINT [PK_HocPhi] PRIMARY KEY CLUSTERED 
(
	[MaHocPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocPhiNo]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhiNo](
	[MaNo] [int] IDENTITY(1,1) NOT NULL,
	[ThangNo] [date] NULL,
	[TienNo] [int] NULL,
	[MaDangKy] [int] NULL,
 CONSTRAINT [PK_HocPhiNo] PRIMARY KEY CLUSTERED 
(
	[MaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [int] IDENTITY(1,1) NOT NULL,
	[HoLot] [nvarchar](20) NOT NULL,
	[Ten] [nvarchar](10) NOT NULL,
	[SDTHocSinh] [nvarchar](12) NULL,
	[SDTPhuHuynh] [nvarchar](12) NULL,
	[Lop] [nvarchar](5) NULL,
	[XacNhanSDT] [bit] NULL,
	[NienKhoa] [nchar](10) NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLopHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenLopHoc] [nvarchar](8) NULL,
	[NienKhoa] [nchar](10) NOT NULL,
	[HocPhiLopHoc] [nvarchar](7) NULL,
	[MaGiaoVien] [int] NOT NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHocDangKy]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocDangKy](
	[MaDangky] [int] IDENTITY(1,1) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TinhTrang] [bit] NULL,
	[MaHocSinh] [int] NULL,
	[MaLopHoc] [int] NULL,
	[MienGiam] [nchar](30) NULL,
 CONSTRAINT [PK_LopHocDangKy] PRIMARY KEY CLUSTERED 
(
	[MaDangky] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LuongGiaoVien]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongGiaoVien](
	[MaLuong] [int] IDENTITY(1,1) NOT NULL,
	[ThangLuong] [int] NULL,
	[NgayGuiLuong] [date] NULL,
	[TongLuong] [int] NULL,
	[TienGuiLai] [int] NULL,
	[TienNhanThem] [int] NULL,
	[HeSo] [float] NULL,
	[MaGiaoVien] [int] NOT NULL,
 CONSTRAINT [PK_LuongGiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BangDiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_BangDiemDanh_LopHocDangKy] FOREIGN KEY([MaDangKy])
REFERENCES [dbo].[LopHocDangKy] ([MaDangky])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BangDiemDanh] CHECK CONSTRAINT [FK_BangDiemDanh_LopHocDangKy]
GO
ALTER TABLE [dbo].[ChiTietLuong]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLuong_LuongGiaoVien] FOREIGN KEY([MaLuong])
REFERENCES [dbo].[LuongGiaoVien] ([MaLuong])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietLuong] CHECK CONSTRAINT [FK_ChiTietLuong_LuongGiaoVien]
GO
ALTER TABLE [dbo].[GioHoc]  WITH CHECK ADD  CONSTRAINT [FK_GioHoc_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[GioHoc] CHECK CONSTRAINT [FK_GioHoc_LopHoc]
GO
ALTER TABLE [dbo].[GioHocKhac]  WITH CHECK ADD  CONSTRAINT [FK_GioHocKhac_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[GioHocKhac] CHECK CONSTRAINT [FK_GioHocKhac_LopHoc]
GO
ALTER TABLE [dbo].[HocPhi]  WITH CHECK ADD  CONSTRAINT [FK_HocPhi_LopHocDangKy] FOREIGN KEY([MaDangKy])
REFERENCES [dbo].[LopHocDangKy] ([MaDangky])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocPhi] CHECK CONSTRAINT [FK_HocPhi_LopHocDangKy]
GO
ALTER TABLE [dbo].[HocPhiNo]  WITH CHECK ADD  CONSTRAINT [FK_HocPhiNo_LopHocDangKy] FOREIGN KEY([MaDangKy])
REFERENCES [dbo].[LopHocDangKy] ([MaDangky])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocPhiNo] CHECK CONSTRAINT [FK_HocPhiNo_LopHocDangKy]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_GiaoVien] FOREIGN KEY([MaGiaoVien])
REFERENCES [dbo].[GiaoVien] ([MaGiaovien])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_GiaoVien]
GO
ALTER TABLE [dbo].[LopHocDangKy]  WITH CHECK ADD  CONSTRAINT [FK_LopHocDangKy_HocSinh] FOREIGN KEY([MaHocSinh])
REFERENCES [dbo].[HocSinh] ([MaHS])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LopHocDangKy] CHECK CONSTRAINT [FK_LopHocDangKy_HocSinh]
GO
ALTER TABLE [dbo].[LopHocDangKy]  WITH CHECK ADD  CONSTRAINT [FK_LopHocDangKy_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[LopHocDangKy] CHECK CONSTRAINT [FK_LopHocDangKy_LopHoc]
GO
ALTER TABLE [dbo].[LuongGiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_LuongGiaoVien_GiaoVien] FOREIGN KEY([MaGiaoVien])
REFERENCES [dbo].[GiaoVien] ([MaGiaovien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LuongGiaoVien] CHECK CONSTRAINT [FK_LuongGiaoVien_GiaoVien]
GO
/****** Object:  StoredProcedure [dbo].[usp_create_hocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_create_hocsinh] 
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

GO
/****** Object:  StoredProcedure [dbo].[usp_create_lhdk]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_create_lhdk]
	@ngaybd date,
	@ngaykt date,
	@tinhtrang bit,
	@mahs int,
	@malh int,
	@miengiam nchar(30)
as
	if not exists (select * from LopHoc where MaLopHoc = @malh)
	begin
		RAISERROR(N'Lớp học không tồn tại!',16,1)
		return
	end
	insert into LopHocDangKy(NgayBatDau, NgayKetThuc, TinhTrang, MaHocSinh, MaLopHoc, MienGiam)
	values (@ngaybd, @ngaykt, @tinhtrang, @mahs, @malh, @miengiam)

GO
/****** Object:  StoredProcedure [dbo].[usp_create_lophoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_create_lophoc]
	@tenlh nvarchar(8),
	@nienkhoa nchar(10),
	@hplh nvarchar(7),
	@magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	insert into LopHoc(TenLopHoc, NienKhoa, HocPhiLopHoc, MaGiaoVien)
	values (@tenlh, @nienkhoa, @hplh, @magv)

GO
/****** Object:  StoredProcedure [dbo].[usp_delete_hocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_delete_hocsinh] 
	@mahs int
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Học sinh này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	delete from HocSinh
	where MaHS = @mahs

GO
/****** Object:  StoredProcedure [dbo].[usp_delete_lhdk]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_delete_lhdk]
	@madk int
as
	if not exists (select * from LopHocDangKy where MaDangky = @madk)
	begin
		RAISERROR(N'Lớp học đăng ký này không tồn tại!',16,1)
		return
	end
	delete from LopHocDangKy
	where MaDangky = @madk

GO
/****** Object:  StoredProcedure [dbo].[usp_delete_lophoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_delete_lophoc]
	@malh int
as
	if not exists (select * from LopHoc where MaLopHoc = @malh)
	begin
		RAISERROR(N'Lớp học này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	delete from LopHoc
	where MaLopHoc = @malh

GO
/****** Object:  StoredProcedure [dbo].[usp_find_giaovien_by_id]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_find_giaovien_by_id] @magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	select * from GiaoVien where MaGiaoVien = @magv

GO
/****** Object:  StoredProcedure [dbo].[usp_find_lophoc_by_giaovien]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_find_lophoc_by_giaovien] @magv int
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	select * from LopHoc where MaGiaoVien = @magv

GO
/****** Object:  StoredProcedure [dbo].[usp_find_lophoc_by_giaovien_with_nienkhoa]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- find lophoc by id giaovien with nienkhoa
CREATE proc [dbo].[usp_find_lophoc_by_giaovien_with_nienkhoa] @magv int, @nienkhoa nchar(10)
as
	if not exists (select * from GiaoVien where MaGiaoVien = @magv)
	begin
		RAISERROR(N'Giáo viên của lớp học này không tồn tại!',16,1)
		return
	end
	select * from LopHoc where MaGiaoVien = @magv and NienKhoa = @nienkhoa

GO
/****** Object:  StoredProcedure [dbo].[usp_find_lophocdangky_by_idlophoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_find_lophocdangky_by_idlophoc] @malophoc int
as
	if not exists (select * from LopHoc where MaLopHoc = @malophoc)
	begin
		RAISERROR(N'Lớp học không tồn tại!',16,1)
		return
	end
	select * from LopHocDangKy 
	where MaLopHoc = @malophoc

GO
/****** Object:  StoredProcedure [dbo].[usp_get_lhdk_by_month_idlophoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_get_lhdk_by_month_idlophoc] @malophoc int, @thang date
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

GO
/****** Object:  StoredProcedure [dbo].[usp_get_lhdk_with_lophoc_by_idhocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_get_lhdk_with_lophoc_by_idhocsinh] @mahs int
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Học sinh không tồn tại!',16,1)
		return
	end
	select lhdk.*, lh.TenLopHoc, lh.NienKhoa, gv.DanhXung, gv.TenGiaoVien, hpn.SoTienNo
	from LopHocDangKy lhdk 
	join LopHoc lh on lhdk.MaLopHoc = lh.MaLopHoc
	join GiaoVien gv on lh.MaGiaoVien = gv.MaGiaovien
	left join (select MaDangKy, SUM(TienNo) as SoTienNo from HocPhiNo group by MaDangKy) hpn on lhdk.MaDangky = hpn.MaDangKy
	where lhdk.MaHocSinh = @mahs

GO
/****** Object:  StoredProcedure [dbo].[usp_get_nienkhoa]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get all nienkhoa in lophoc
CREATE proc [dbo].[usp_get_nienkhoa] @magv int
as
	select distinct NienKhoa from LopHoc where MaGiaoVien = @magv

GO
/****** Object:  StoredProcedure [dbo].[usp_load_giaovien]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_load_giaovien]
as
	select * from GiaoVien

GO
/****** Object:  StoredProcedure [dbo].[usp_search_hocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_search_hocsinh] @holot nvarchar(20), @ten nvarchar(10)
as
	if not exists (select * from HocSinh where HoLot like '%'+@holot+'%' and Ten like '%'+@ten+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where HoLot like '%'+@holot+'%' and Ten like '%'+@ten+'%'

GO
/****** Object:  StoredProcedure [dbo].[usp_search_hocsinh_by_id]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_search_hocsinh_by_id] @mahs int
as
	if not exists (select * from HocSinh where MaHS = @mahs)
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where MaHS = @mahs

GO
/****** Object:  StoredProcedure [dbo].[usp_search_hocsinh_exact]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_search_hocsinh_exact] @holot nvarchar(20), @ten nvarchar(10)
as
	if not exists (select * from HocSinh where HoLot like @holot and Ten like @ten)
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where HoLot like @holot and Ten like @ten

GO
/****** Object:  StoredProcedure [dbo].[usp_search_hocsinh_sdthocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[usp_search_hocsinh_sdthocsinh] @sdthocsinh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTHocSinh like '%'+@sdthocsinh+'%'

GO
/****** Object:  StoredProcedure [dbo].[usp_search_hocsinh_sdtphuhuynh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[usp_search_hocsinh_sdtphuhuynh] @sdtphuhuynh nvarchar(12)
as
	if not exists (select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%')
	begin
		RAISERROR(N'Không tìm thấy học sinh',16,1)
		return
	end
	select * from HocSinh where SDTPhuHuynh like '%'+@sdtphuhuynh+'%'

GO
/****** Object:  StoredProcedure [dbo].[usp_update_hocsinh]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_update_hocsinh] 
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

GO
/****** Object:  StoredProcedure [dbo].[usp_update_lhdk]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_update_lhdk]
	@madk int,
	@ngaybd date,
	@ngaykt date,
	@tinhtrang bit,
	@mahs int,
	@malh int,
	@miengiam nchar(30)
as
	if not exists (select * from LopHocDangKy where MaDangky = @madk)
	begin
		RAISERROR(N'Lớp học đăng ký này không tồn tại!',16,1)
		return
	end
	update LopHocDangKy
	set NgayBatDau=@ngaybd, NgayKetThuc=@ngaykt, TinhTrang=@tinhtrang, MaHocSinh=@mahs, MaLopHoc=@malh, MienGiam=@miengiam
	where MaDangky = @madk

GO
/****** Object:  StoredProcedure [dbo].[usp_update_lophoc]    Script Date: 2/21/2022 12:10:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_update_lophoc]
	@malh int,
	@tenlh nvarchar(8),
	@nienkhoa nchar(10),
	@hplh nvarchar(7),
	@magv int
as
	if not exists (select * from LopHoc where MaLopHoc = @malh)
	begin
		RAISERROR(N'Lớp học này không tồn tại trong cơ sở dữ liệu!',16,1)
		return
	end
	update LopHoc
	set TenLopHoc = @tenlh, NienKhoa = @nienkhoa, HocPhiLopHoc=@hplh, MaGiaoVien = @magv
	where MaLopHoc = @malh

GO
USE [master]
GO
ALTER DATABASE [QuanLyHocSinh] SET  READ_WRITE 
GO
