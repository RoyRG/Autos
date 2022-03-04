USE [master]
GO
/****** Object:  Database [Autos]    Script Date: 04/03/2022 04:10:47 p. m. ******/
CREATE DATABASE [Autos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Autos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Autos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Autos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Autos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Autos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Autos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Autos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Autos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Autos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Autos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Autos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Autos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Autos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Autos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Autos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Autos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Autos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Autos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Autos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Autos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Autos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Autos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Autos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Autos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Autos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Autos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Autos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Autos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Autos] SET RECOVERY FULL 
GO
ALTER DATABASE [Autos] SET  MULTI_USER 
GO
ALTER DATABASE [Autos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Autos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Autos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Autos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Autos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Autos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Autos', N'ON'
GO
ALTER DATABASE [Autos] SET QUERY_STORE = OFF
GO
USE [Autos]
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 04/03/2022 04:10:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[Id_Auto] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Id_Modelo] [uniqueidentifier] NOT NULL,
	[Año] [date] NOT NULL,
	[Fecha_Ingreso] [date] NOT NULL,
	[Id_Estado] [uniqueidentifier] NOT NULL,
	[Id_Lote] [uniqueidentifier] NOT NULL,
	[Fecha_Movimiento] [date] NULL,
	[Usuario] [nchar](50) NULL,
	[Fecha_Actualizacion] [date] NULL,
	[Usuario_Activo] [nchar](30) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[Id_Auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 04/03/2022 04:10:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id_Estado] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Fecha_Movimiento] [date] NULL,
	[Usuario] [nchar](50) NULL,
	[Fecha_Actualizacion] [date] NULL,
	[Usuario_Activo] [nchar](30) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lote]    Script Date: 04/03/2022 04:10:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lote](
	[Id_Lote] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Fecha_Movimiento] [date] NULL,
	[Usuario] [nchar](50) NULL,
	[Fecha_Actualizacion] [date] NULL,
	[Usuario_Activo] [nchar](30) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Lote] PRIMARY KEY CLUSTERED 
(
	[Id_Lote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 04/03/2022 04:10:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id_Marca] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Fecha_Movimiento] [date] NULL,
	[Usuario] [nchar](50) NULL,
	[Fecha_Actualizacion] [date] NULL,
	[Usuario_Activo] [nchar](30) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Marcas_1] PRIMARY KEY CLUSTERED 
(
	[Id_Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelos]    Script Date: 04/03/2022 04:10:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelos](
	[Id_Modelo] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Id_Marca] [uniqueidentifier] NOT NULL,
	[Fecha_Movimiento] [date] NULL,
	[Usuario] [nchar](50) NULL,
	[Fecha_Actualizacion] [date] NULL,
	[Usuario_Activo] [nchar](30) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED 
(
	[Id_Modelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Autos] ADD  CONSTRAINT [DF_Table_1_IdAuto]  DEFAULT (newid()) FOR [Id_Auto]
GO
ALTER TABLE [dbo].[Estado] ADD  CONSTRAINT [DF_Estado_Id_Estado]  DEFAULT (newid()) FOR [Id_Estado]
GO
ALTER TABLE [dbo].[Lote] ADD  CONSTRAINT [DF_Lote_Id_Lote]  DEFAULT (newid()) FOR [Id_Lote]
GO
ALTER TABLE [dbo].[Marcas] ADD  CONSTRAINT [DF_Marcas_Id_Marca]  DEFAULT (newid()) FOR [Id_Marca]
GO
ALTER TABLE [dbo].[Modelos] ADD  CONSTRAINT [DF_Modelos_Id_Modelo]  DEFAULT (newid()) FOR [Id_Modelo]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Estado] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Estado]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Lote] FOREIGN KEY([Id_Lote])
REFERENCES [dbo].[Lote] ([Id_Lote])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Lote]
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD  CONSTRAINT [FK_Autos_Modelos] FOREIGN KEY([Id_Modelo])
REFERENCES [dbo].[Modelos] ([Id_Modelo])
GO
ALTER TABLE [dbo].[Autos] CHECK CONSTRAINT [FK_Autos_Modelos]
GO
ALTER TABLE [dbo].[Modelos]  WITH CHECK ADD  CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY([Id_Marca])
REFERENCES [dbo].[Marcas] ([Id_Marca])
GO
ALTER TABLE [dbo].[Modelos] CHECK CONSTRAINT [FK_Modelos_Marcas]
GO
USE [master]
GO
ALTER DATABASE [Autos] SET  READ_WRITE 
GO
