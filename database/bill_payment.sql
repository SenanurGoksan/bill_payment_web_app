USE [master]
GO
/****** Object:  Database [BillApp]    Script Date: 30.06.2025 13:51:09 ******/
CREATE DATABASE [BillApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BillApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BillApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BillApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BillApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BillApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BillApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BillApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BillApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BillApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BillApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BillApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BillApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BillApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BillApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BillApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BillApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BillApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BillApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BillApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BillApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BillApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BillApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BillApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BillApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BillApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BillApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BillApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BillApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BillApp] SET RECOVERY FULL 
GO
ALTER DATABASE [BillApp] SET  MULTI_USER 
GO
ALTER DATABASE [BillApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BillApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BillApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BillApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BillApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BillApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BillApp', N'ON'
GO
ALTER DATABASE [BillApp] SET QUERY_STORE = OFF
GO
USE [BillApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30.06.2025 13:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bireysel]    Script Date: 30.06.2025 13:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bireysel](
	[idNum] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](max) NOT NULL,
	[lastName] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[parola] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_Bireysel] PRIMARY KEY CLUSTERED 
(
	[idNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fatura]    Script Date: 30.06.2025 13:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fatura](
	[faturaNo] [int] IDENTITY(1,1) NOT NULL,
	[tutar] [decimal](18, 2) NOT NULL,
	[sonOdemeTarihi] [datetime2](7) NOT NULL,
	[userId] [int] NOT NULL,
	[kurumId] [int] NOT NULL,
 CONSTRAINT [PK_Fatura] PRIMARY KEY CLUSTERED 
(
	[faturaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurumsal]    Script Date: 30.06.2025 13:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurumsal](
	[kurumId] [int] IDENTITY(1,1) NOT NULL,
	[kurumAdi] [nvarchar](max) NOT NULL,
	[adminMail] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kurumsal] PRIMARY KEY CLUSTERED 
(
	[kurumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdenmisFatura]    Script Date: 30.06.2025 13:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdenmisFatura](
	[odemeId] [int] IDENTITY(1,1) NOT NULL,
	[faturaNo] [int] NULL,
	[idNum] [int] NOT NULL,
	[odenmeTarihi] [datetime2](7) NOT NULL,
	[odenenMiktari] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OdenmisFatura] PRIMARY KEY CLUSTERED 
(
	[odemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230824131152_bill', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230824131637_bill1', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230826145419_bill2', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230903122215_bill3', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230906121828_bill4', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230908063400_bill5', N'6.0.21')
GO
SET IDENTITY_INSERT [dbo].[Bireysel] ON 

INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (8, N'ali', N'duyar', N'ali@gmail.com', N'ali', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (9, N'azra', N'kaya', N'azra@gmail.com', N'azra', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (10, N'sena', N'gok', N'sena4@gmail.com', N'sena', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (11, N'omer', N'gok', N'omer@gmail.com', N'omer', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (12, N'Sena', N'GÖKŞAN', N'senanur@gmail.com', N'sena', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (13, N'batu', N'han', N'batu@gmail.com', N'batu', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (14, N'Fatma', N'Gündüz', N'fatma@gmail.com', N'fatma', N'User', N'')
INSERT [dbo].[Bireysel] ([idNum], [firstName], [lastName], [email], [parola], [Role], [Token]) VALUES (15, N'Ebru', N'Can', N'ebru@gmail.com', N'ebru', N'User', N'')
SET IDENTITY_INSERT [dbo].[Bireysel] OFF
GO
SET IDENTITY_INSERT [dbo].[Fatura] ON 

INSERT [dbo].[Fatura] ([faturaNo], [tutar], [sonOdemeTarihi], [userId], [kurumId]) VALUES (10, CAST(534.00 AS Decimal(18, 2)), CAST(N'2023-09-06T19:37:13.1910000' AS DateTime2), 11, 3)
INSERT [dbo].[Fatura] ([faturaNo], [tutar], [sonOdemeTarihi], [userId], [kurumId]) VALUES (15, CAST(456.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 10, 4)
SET IDENTITY_INSERT [dbo].[Fatura] OFF
GO
SET IDENTITY_INSERT [dbo].[Kurumsal] ON 

INSERT [dbo].[Kurumsal] ([kurumId], [kurumAdi], [adminMail], [password], [Role], [Token]) VALUES (3, N'Bedaş', N'bedas@gmail.com', N'bedas', N'Admin', N'')
INSERT [dbo].[Kurumsal] ([kurumId], [kurumAdi], [adminMail], [password], [Role], [Token]) VALUES (4, N'İski', N'iski@gmail.com', N'iski', N'Admin', N'')
INSERT [dbo].[Kurumsal] ([kurumId], [kurumAdi], [adminMail], [password], [Role], [Token]) VALUES (5, N'İgdaş', N'igdas@gmail.com', N'igdas', N'Admin', N'')
SET IDENTITY_INSERT [dbo].[Kurumsal] OFF
GO
/****** Object:  Index [IX_Fatura_kurumId]    Script Date: 30.06.2025 13:51:09 ******/
CREATE NONCLUSTERED INDEX [IX_Fatura_kurumId] ON [dbo].[Fatura]
(
	[kurumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Fatura_userId]    Script Date: 30.06.2025 13:51:09 ******/
CREATE NONCLUSTERED INDEX [IX_Fatura_userId] ON [dbo].[Fatura]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OdenmisFatura_faturaNo]    Script Date: 30.06.2025 13:51:09 ******/
CREATE NONCLUSTERED INDEX [IX_OdenmisFatura_faturaNo] ON [dbo].[OdenmisFatura]
(
	[faturaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OdenmisFatura_idNum]    Script Date: 30.06.2025 13:51:09 ******/
CREATE NONCLUSTERED INDEX [IX_OdenmisFatura_idNum] ON [dbo].[OdenmisFatura]
(
	[idNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fatura]  WITH CHECK ADD  CONSTRAINT [FK_Fatura_Bireysel_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[Bireysel] ([idNum])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fatura] CHECK CONSTRAINT [FK_Fatura_Bireysel_userId]
GO
ALTER TABLE [dbo].[Fatura]  WITH CHECK ADD  CONSTRAINT [FK_Fatura_Kurumsal_kurumId] FOREIGN KEY([kurumId])
REFERENCES [dbo].[Kurumsal] ([kurumId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fatura] CHECK CONSTRAINT [FK_Fatura_Kurumsal_kurumId]
GO
ALTER TABLE [dbo].[OdenmisFatura]  WITH CHECK ADD  CONSTRAINT [FK_OdenmisFatura_Bireysel_idNum] FOREIGN KEY([idNum])
REFERENCES [dbo].[Bireysel] ([idNum])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OdenmisFatura] CHECK CONSTRAINT [FK_OdenmisFatura_Bireysel_idNum]
GO
ALTER TABLE [dbo].[OdenmisFatura]  WITH CHECK ADD  CONSTRAINT [FK_OdenmisFatura_Fatura_faturaNo] FOREIGN KEY([faturaNo])
REFERENCES [dbo].[Fatura] ([faturaNo])
GO
ALTER TABLE [dbo].[OdenmisFatura] CHECK CONSTRAINT [FK_OdenmisFatura_Fatura_faturaNo]
GO
USE [master]
GO
ALTER DATABASE [BillApp] SET  READ_WRITE 
GO
