USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[tblChitietHDBan]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChitietHDBan](
	[MaHDBan] [nvarchar](50) NOT NULL,
	[Mahang] [nvarchar](50) NOT NULL,
	[Soluong] [float] NOT NULL,
	[Dongia] [float] NOT NULL,
	[Giamgia] [float] NOT NULL,
	[Thanhtien] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHangHoa]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHangHoa](
	[Mahang] [nvarchar](50) NOT NULL,
	[Tenhang] [nvarchar](50) NOT NULL,
	[Maloai] [nvarchar](50) NOT NULL,
	[Soluong] [float] NOT NULL,
	[Dongianhap] [float] NOT NULL,
	[Dongiaban] [float] NOT NULL,
	[Anh] [nvarchar](500) NOT NULL,
	[Ghichu] [nvarchar](250) NULL,
 CONSTRAINT [PK_tblHang] PRIMARY KEY CLUSTERED 
(
	[Mahang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHDBan]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHDBan](
	[MaHDBan] [nvarchar](50) NOT NULL,
	[Manhanvien] [nvarchar](10) NOT NULL,
	[Ngayban] [datetime] NOT NULL,
	[Makhach] [nvarchar](10) NOT NULL,
	[Tongtien] [float] NOT NULL,
	[Ghichu] [nvarchar](250) NULL,
 CONSTRAINT [PK_tblHDBan] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[Makhach] [nvarchar](10) NOT NULL,
	[Tenkhach] [nvarchar](50) NOT NULL,
	[Diachi] [nvarchar](50) NOT NULL,
	[Dienthoai] [nchar](15) NOT NULL,
	[Email] [varchar](50) NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblKhach] PRIMARY KEY CLUSTERED 
(
	[Makhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLoai]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoai](
	[Maloai] [nvarchar](50) NOT NULL,
	[Tenloai] [nvarchar](50) NOT NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblLoai] PRIMARY KEY CLUSTERED 
(
	[Maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanvien]    Script Date: 12/26/2018 10:05:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanvien](
	[Manhanvien] [nvarchar](10) NOT NULL,
	[Tennhanvien] [nvarchar](30) NOT NULL,
	[Gioitinh] [nvarchar](10) NOT NULL,
	[Diachi] [nvarchar](50) NOT NULL,
	[Dienthoai] [nvarchar](15) NOT NULL,
	[Ngaysinh] [datetime] NOT NULL,
	[Tendangnhap] [nvarchar](20) NULL,
	[Matkhau] [nvarchar](20) NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblNhanvien] PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblChitietHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblChitietHDBan_tblHangHoa] FOREIGN KEY([Mahang])
REFERENCES [dbo].[tblHangHoa] ([Mahang])
GO
ALTER TABLE [dbo].[tblChitietHDBan] CHECK CONSTRAINT [FK_tblChitietHDBan_tblHangHoa]
GO
ALTER TABLE [dbo].[tblChitietHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblChitietHDBan_tblHDBan] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[tblHDBan] ([MaHDBan])
GO
ALTER TABLE [dbo].[tblChitietHDBan] CHECK CONSTRAINT [FK_tblChitietHDBan_tblHDBan]
GO
ALTER TABLE [dbo].[tblHangHoa]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblLoai] FOREIGN KEY([Maloai])
REFERENCES [dbo].[tblLoai] ([Maloai])
GO
ALTER TABLE [dbo].[tblHangHoa] CHECK CONSTRAINT [FK_tblHang_tblLoai]
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHDBan_tblKhach] FOREIGN KEY([Makhach])
REFERENCES [dbo].[tblKhachHang] ([Makhach])
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK_tblHDBan_tblKhach]
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHDBan_tblNhanvien] FOREIGN KEY([Manhanvien])
REFERENCES [dbo].[tblNhanvien] ([Manhanvien])
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK_tblHDBan_tblNhanvien]
GO
