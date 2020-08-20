USE [master]
GO
/****** Object:  Database [ProductosDB]    Script Date: Aug/19/2020 9:45:00 PM ******/
CREATE DATABASE [ProductosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProductosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProductosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProductosDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductosDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductosDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductosDB] SET QUERY_STORE = OFF
GO
USE [ProductosDB]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: Aug/19/2020 9:45:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Precio] [float] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Codigo], [Descripcion], [Precio]) VALUES (1, N'Television 50', 30000)
INSERT [dbo].[Productos] ([Codigo], [Descripcion], [Precio]) VALUES (2, N'Television 60', 41000)
SET IDENTITY_INSERT [dbo].[Productos] OFF
USE [master]
GO
ALTER DATABASE [ProductosDB] SET  READ_WRITE 
GO
