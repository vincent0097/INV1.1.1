USE [master]
GO

/****** Object:  Database [INV1.1.1]    Script Date: 11/6/2022 10:27:42 AM ******/
CREATE DATABASE [INV1.1.1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INV1.1.1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\INV1.1.1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INV1.1.1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\INV1.1.1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INV1.1.1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [INV1.1.1] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [INV1.1.1] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [INV1.1.1] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [INV1.1.1] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [INV1.1.1] SET ARITHABORT OFF 
GO

ALTER DATABASE [INV1.1.1] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [INV1.1.1] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [INV1.1.1] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [INV1.1.1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [INV1.1.1] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [INV1.1.1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [INV1.1.1] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [INV1.1.1] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [INV1.1.1] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [INV1.1.1] SET  DISABLE_BROKER 
GO

ALTER DATABASE [INV1.1.1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [INV1.1.1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [INV1.1.1] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [INV1.1.1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [INV1.1.1] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [INV1.1.1] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [INV1.1.1] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [INV1.1.1] SET RECOVERY FULL 
GO

ALTER DATABASE [INV1.1.1] SET  MULTI_USER 
GO

ALTER DATABASE [INV1.1.1] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [INV1.1.1] SET DB_CHAINING OFF 
GO

ALTER DATABASE [INV1.1.1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [INV1.1.1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [INV1.1.1] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [INV1.1.1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [INV1.1.1] SET QUERY_STORE = OFF
GO

ALTER DATABASE [INV1.1.1] SET  READ_WRITE 
GO

