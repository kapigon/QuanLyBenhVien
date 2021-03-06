USE [master]
GO
/****** Object:  Database [mHospital]    Script Date: 13/09/2017 3:30:34 PM ******/
CREATE DATABASE [mHospital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mHospital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\mHospital.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'mHospital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\mHospital_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [mHospital] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mHospital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mHospital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mHospital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mHospital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mHospital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mHospital] SET ARITHABORT OFF 
GO
ALTER DATABASE [mHospital] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mHospital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mHospital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mHospital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mHospital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mHospital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mHospital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mHospital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mHospital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mHospital] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mHospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mHospital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mHospital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mHospital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mHospital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mHospital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mHospital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mHospital] SET RECOVERY FULL 
GO
ALTER DATABASE [mHospital] SET  MULTI_USER 
GO
ALTER DATABASE [mHospital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mHospital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mHospital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mHospital] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [mHospital] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'mHospital', N'ON'
GO
USE [mHospital]
GO
/****** Object:  Table [dbo].[ChiTietPhanQuyen]    Script Date: 13/09/2017 3:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhanQuyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhanQuyenID] [numeric](3, 0) NOT NULL,
	[ChucNangQuanLyID] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_RoleDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChucNangQuanLy]    Script Date: 13/09/2017 3:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucNangQuanLy](
	[ID] [numeric](3, 0) IDENTITY(100,1) NOT NULL,
	[TenChucNangQuanLy] [nvarchar](100) NULL,
	[Nut] [nvarchar](50) NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [PK_RoleFunctions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 13/09/2017 3:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[ID] [numeric](3, 0) IDENTITY(100,1) NOT NULL,
	[TenKhoa] [nvarchar](100) NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 13/09/2017 3:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [numeric](6, 0) IDENTITY(100000,1) NOT NULL,
	[KhoaID] [numeric](3, 0) NULL,
	[PhanQuyenID] [numeric](3, 0) NULL,
	[HoVaTen] [nvarchar](100) NULL,
	[TaiKhoan] [varchar](100) NULL,
	[MatKhau] [varchar](150) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](250) NULL,
	[CMT] [varchar](12) NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 13/09/2017 3:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[ID] [numeric](3, 0) IDENTITY(100,1) NOT NULL,
	[TenPhanQuyen] [nvarchar](100) NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChucNangQuanLy] ON 

INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(100 AS Numeric(3, 0)), N'Quản Lý Thuốc', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(101 AS Numeric(3, 0)), N'Quản Lý Kho', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(102 AS Numeric(3, 0)), N'Quản Lý Thiếu Bị', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(103 AS Numeric(3, 0)), N'Quản Lý Hóa đơn', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(104 AS Numeric(3, 0)), N'Quản Lý Tổng Hợp Bác Cáo', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(105 AS Numeric(3, 0)), N'Quản Lý Toa Thuốc', NULL, 1)
INSERT [dbo].[ChucNangQuanLy] ([ID], [TenChucNangQuanLy], [Nut], [KichHoat]) VALUES (CAST(106 AS Numeric(3, 0)), N'Quản Lý Dịch Vụ', NULL, 1)
SET IDENTITY_INSERT [dbo].[ChucNangQuanLy] OFF
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(101 AS Numeric(3, 0)), N'Khoa phẩu thuật', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(102 AS Numeric(3, 0)), N'Khoa nội', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(103 AS Numeric(3, 0)), N'Khoa ngoại', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(104 AS Numeric(3, 0)), N'Khoa sản', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(105 AS Numeric(3, 0)), N'Khoan kiểm soát nhiểm khuẩn', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(106 AS Numeric(3, 0)), N'Khoa dược', 1)
INSERT [dbo].[Khoa] ([ID], [TenKhoa], [KichHoat]) VALUES (CAST(107 AS Numeric(3, 0)), N'Khoa chuẩn đoán hình ảnh', 1)
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [KhoaID], [PhanQuyenID], [HoVaTen], [TaiKhoan], [MatKhau], [GioiTinh], [NgaySinh], [DiaChi], [CMT], [KichHoat]) VALUES (CAST(100000 AS Numeric(6, 0)), NULL, CAST(100 AS Numeric(3, 0)), N'Administrator', N'administrator', N'123456', 1, CAST(N'1988-08-29' AS Date), N'Hà Nội', N'123456789', 1)
INSERT [dbo].[NhanVien] ([ID], [KhoaID], [PhanQuyenID], [HoVaTen], [TaiKhoan], [MatKhau], [GioiTinh], [NgaySinh], [DiaChi], [CMT], [KichHoat]) VALUES (CAST(100001 AS Numeric(6, 0)), NULL, CAST(101 AS Numeric(3, 0)), N'admin', N'admin', N'123456', 1, CAST(N'1988-08-29' AS Date), N'Hà Nội', N'123456789', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([ID], [TenPhanQuyen], [KichHoat]) VALUES (CAST(100 AS Numeric(3, 0)), N'Administrator', 1)
INSERT [dbo].[PhanQuyen] ([ID], [TenPhanQuyen], [KichHoat]) VALUES (CAST(101 AS Numeric(3, 0)), N'Quản trị hệ thống', 1)
INSERT [dbo].[PhanQuyen] ([ID], [TenPhanQuyen], [KichHoat]) VALUES (CAST(102 AS Numeric(3, 0)), N'Quản lý vật tư', 1)
INSERT [dbo].[PhanQuyen] ([ID], [TenPhanQuyen], [KichHoat]) VALUES (CAST(103 AS Numeric(3, 0)), N'Bác sĩ', 1)
INSERT [dbo].[PhanQuyen] ([ID], [TenPhanQuyen], [KichHoat]) VALUES (CAST(104 AS Numeric(3, 0)), N'Quản lý nhân sự', 1)
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
USE [master]
GO
ALTER DATABASE [mHospital] SET  READ_WRITE 
GO
