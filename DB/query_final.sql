USE [master]
GO
/****** Object:  Database [Pintucor]    Script Date: 07/11/2022 16:28:09 ******/
CREATE DATABASE [Pintucor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pintucor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pintucor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pintucor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Pintucor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pintucor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pintucor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pintucor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pintucor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pintucor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pintucor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pintucor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pintucor] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Pintucor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pintucor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pintucor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pintucor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pintucor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pintucor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pintucor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pintucor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pintucor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Pintucor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pintucor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pintucor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pintucor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pintucor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pintucor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pintucor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pintucor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pintucor] SET  MULTI_USER 
GO
ALTER DATABASE [Pintucor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pintucor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pintucor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pintucor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pintucor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pintucor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pintucor] SET QUERY_STORE = OFF
GO
USE [Pintucor]
GO
/****** Object:  Table [dbo].[barrio]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[barrio](
	[id_barrio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[id_localidad] [int] NULL,
 CONSTRAINT [pk_id_b] PRIMARY KEY CLUSTERED 
(
	[id_barrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
	[direccion] [varchar](20) NULL,
	[telefono] [numeric](10, 0) NULL,
	[dni] [int] NULL,
	[email] [varchar](10) NULL,
	[id_barrio] [int] NULL,
 CONSTRAINT [pk_id_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[color]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[color](
	[id_color] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [pk_color] PRIMARY KEY CLUSTERED 
(
	[id_color] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[nroFac] [int] NOT NULL,
	[codigo_producto] [int] NOT NULL,
	[cantidad] [int] NULL,
	[descripcion] [varchar](80) NULL,
	[precio_unitario] [float] NULL,
	[importe_bruto] [float] NULL,
	[descuento] [float] NULL,
	[impuesto] [float] NULL,
	[total] [float] NULL,
 CONSTRAINT [pk_nroF] PRIMARY KEY CLUSTERED 
(
	[nroFac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [varchar](30) NULL,
	[nombre] [varchar](30) NULL,
	[dni] [int] NULL,
	[cargo] [varchar](30) NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [pk_id_empleado] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[envio]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[envio](
	[id_envio] [int] IDENTITY(1,1) NOT NULL,
	[id_estado] [int] NULL,
	[direccion] [varchar](20) NULL,
	[id_cliente] [int] NULL,
	[codigo_producto] [int] NULL,
 CONSTRAINT [pk_id_envio] PRIMARY KEY CLUSTERED 
(
	[id_envio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
 CONSTRAINT [pk_id_estado] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estante]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estante](
	[id_estante] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
	[id_seccion] [int] NULL,
 CONSTRAINT [pk_id_e] PRIMARY KEY CLUSTERED 
(
	[id_estante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[forma_pago]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forma_pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
 CONSTRAINT [id_forma_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidad]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidad](
	[id_localidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[id_provincia] [int] NULL,
 CONSTRAINT [pk_id_l] PRIMARY KEY CLUSTERED 
(
	[id_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [pk_marca] PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_producto] [varchar](20) NULL,
	[descripcion] [varchar](80) NULL,
	[id_tipo_pintura] [int] NULL,
	[id_marca] [int] NULL,
	[id_color] [int] NULL,
	[acabado] [varchar](50) NULL,
	[tamano] [int] NULL,
	[precio] [float] NULL,
	[id_sector] [int] NULL,
 CONSTRAINT [pk_cod_p] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
 CONSTRAINT [pk_id] PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NULL,
 CONSTRAINT [pk_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seccion]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seccion](
	[id_seccion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
 CONSTRAINT [pk_id_s] PRIMARY KEY CLUSTERED 
(
	[id_seccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sector]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector](
	[id_sector] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
	[id_estante] [int] NULL,
 CONSTRAINT [pk_id_sector] PRIMARY KEY CLUSTERED 
(
	[id_sector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_pintura]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_pintura](
	[id_tipo] [int] IDENTITY(1,1) NOT NULL,
	[tipoPintura] [varchar](50) NULL,
 CONSTRAINT [pk_id_tipo] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](256) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[id_rol] [int] NULL,
 CONSTRAINT [pk_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 07/11/2022 16:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[nroFac] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_forma_pago] [int] NULL,
	[fecha_venta] [date] NULL,
	[id_empleado] [int] NULL,
	[id_envio] [int] NULL,
 CONSTRAINT [pk_nroFac] PRIMARY KEY CLUSTERED 
(
	[nroFac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[barrio]  WITH CHECK ADD  CONSTRAINT [fk_id_l] FOREIGN KEY([id_localidad])
REFERENCES [dbo].[localidad] ([id_localidad])
GO
ALTER TABLE [dbo].[barrio] CHECK CONSTRAINT [fk_id_l]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [fk_id_b] FOREIGN KEY([id_barrio])
REFERENCES [dbo].[barrio] ([id_barrio])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [fk_id_b]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [fk_cod] FOREIGN KEY([codigo_producto])
REFERENCES [dbo].[producto] ([codigo])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [fk_cod]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [fk_nroF] FOREIGN KEY([nroFac])
REFERENCES [dbo].[venta] ([nroFac])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [fk_nroF]
GO
ALTER TABLE [dbo].[empleado]  WITH CHECK ADD  CONSTRAINT [fk_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[empleado] CHECK CONSTRAINT [fk_usuario]
GO
ALTER TABLE [dbo].[envio]  WITH CHECK ADD  CONSTRAINT [fk_codigo_producto] FOREIGN KEY([codigo_producto])
REFERENCES [dbo].[producto] ([codigo])
GO
ALTER TABLE [dbo].[envio] CHECK CONSTRAINT [fk_codigo_producto]
GO
ALTER TABLE [dbo].[envio]  WITH CHECK ADD  CONSTRAINT [fk_id_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[envio] CHECK CONSTRAINT [fk_id_cliente]
GO
ALTER TABLE [dbo].[envio]  WITH CHECK ADD  CONSTRAINT [fk_id_estado] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estado] ([id_estado])
GO
ALTER TABLE [dbo].[envio] CHECK CONSTRAINT [fk_id_estado]
GO
ALTER TABLE [dbo].[estante]  WITH CHECK ADD  CONSTRAINT [fk_id_s] FOREIGN KEY([id_seccion])
REFERENCES [dbo].[seccion] ([id_seccion])
GO
ALTER TABLE [dbo].[estante] CHECK CONSTRAINT [fk_id_s]
GO
ALTER TABLE [dbo].[localidad]  WITH CHECK ADD  CONSTRAINT [fk_id_p] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincia] ([id_provincia])
GO
ALTER TABLE [dbo].[localidad] CHECK CONSTRAINT [fk_id_p]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [fk_color] FOREIGN KEY([id_color])
REFERENCES [dbo].[color] ([id_color])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [fk_color]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [fk_id_t] FOREIGN KEY([id_tipo_pintura])
REFERENCES [dbo].[tipo_pintura] ([id_tipo])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [fk_id_t]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [fk_marca] FOREIGN KEY([id_marca])
REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [fk_marca]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [fk_s] FOREIGN KEY([id_sector])
REFERENCES [dbo].[sector] ([id_sector])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [fk_s]
GO
ALTER TABLE [dbo].[sector]  WITH CHECK ADD  CONSTRAINT [fk_id_e] FOREIGN KEY([id_estante])
REFERENCES [dbo].[estante] ([id_estante])
GO
ALTER TABLE [dbo].[sector] CHECK CONSTRAINT [fk_id_e]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [fk_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id_rol])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [fk_rol]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [fk_id_c] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [fk_id_c]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [fk_id_empleado] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[empleado] ([id_empleado])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [fk_id_empleado]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [fk_id_env] FOREIGN KEY([id_envio])
REFERENCES [dbo].[envio] ([id_envio])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [fk_id_env]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [fk_id_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[forma_pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [fk_id_forma_pago]
GO
USE [master]
GO
ALTER DATABASE [Pintucor] SET  READ_WRITE 
GO
