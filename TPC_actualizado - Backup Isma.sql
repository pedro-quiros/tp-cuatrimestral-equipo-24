USE [TPC_equipo24_BD]
GO
/****** Object:  Table [dbo].[Datos_Personales]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Datos_Personales](
	[IdDatosPersonales] [int] NOT NULL,
	[Legajo] [int] NOT NULL,
	[Dni] [varchar](20) NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [char](1) NULL,
	[Telefono] [varchar](15) NULL,
	[Email] [varchar](140) NULL,
	[Domicilio] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDatosPersonales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdMesa] [int] NULL,
	[IdPedido] [int] NULL,
	[IdFormatoPago] [int] NULL,
	[TipoFactura] [char](1) NULL,
	[Cantidad] [int] NULL,
	[precioTotal] [money] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormatoPago]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormatoPago](
	[IdFormatopago] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_FormatoPago] PRIMARY KEY CLUSTERED 
(
	[IdFormatopago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gerente]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gerente](
	[IdGerente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Gerente] PRIMARY KEY CLUSTERED 
(
	[IdGerente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[IdInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Precio] [money] NULL,
	[Stock] [int] NULL,
	[UrlImagen] [varchar](max) NULL,
	[Descripcion] [varchar](500) NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemPedido]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPedido](
	[IdItemPedido] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NULL,
	[PrecioUnitario] [money] NULL,
 CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED 
(
	[IdItemPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[IdMesa] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[IdMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesero]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesero](
	[IdMesero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](10) NULL,
	[Apellido] [nchar](10) NULL,
	[Estado] [nchar](10) NULL,
 CONSTRAINT [PK_Mesero] PRIMARY KEY CLUSTERED 
(
	[IdMesero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [bit] NULL,
	[FechaHoraCreado] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reseña]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reseña](
	[IdReseña] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[observacion] [varchar](max) NULL,
	[puntaje] [int] NULL,
 CONSTRAINT [PK_Reseña] PRIMARY KEY CLUSTERED 
(
	[IdReseña] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario2]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario2](
	[IdUsuario] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[Puesto] [int] NULL,
	[Activo] [bit] NULL,
	[Legajo] [int] IDENTITY(1000,1) NOT NULL,
	[DNI] [int] NULL,
	[Nombre] [varchar](200) NULL,
	[Apellido] [varchar](200) NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Domicilio] [varchar](200) NULL,
 CONSTRAINT [PK_Usuario2] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Clave] [varchar](20) NOT NULL,
	[Puesto] [int] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Datos_Personales]  WITH CHECK ADD FOREIGN KEY([IdDatosPersonales])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[AltaLogicaUsuario]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter Procedure [dbo].[AltaLogicaUsuario]
@IdUsuario int
as 
update Usuario2 set Activo = 1 where IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[BajaLogicaUsuario]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter Procedure [dbo].[BajaLogicaUsuario]
@IdUsuario int 
as 
update Usuario2 set Activo = 0 where IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[MostrarUsuario]    Script Date: 20/6/2024 19:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[MostrarUsuario] 
as
select U.IdUsuario,U.NombreUsuario,U.Puesto,U.Activo,DP.Legajo,DP.Nombre,DP.Apellido,DP.Dni,DP.FechaNacimiento,DP.Genero,
DP.Telefono,DP.Email,DP.Domicilio
from Usuarios U
inner join Datos_Personales DP on DP.IdDatosPersonales = U.IdUsuario
GO


--- Avance
CREATE proc MostrarUsuario2
as
select IdUsuario,NombreUsuario,Puesto,Activo,Legajo,Nombre,Apellido,Dni,FechaNacimiento,Genero,
Telefono,Email,Domicilio from Usuario2


exec MostrarUsuario2
-- Insert 1
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (1, 'usuario1', 'clave123', 1, 1, 12345678, 'Juan', 'Pérez', '1990-05-15', 'Masculino', '123456789', 'juan.perez@example.com', 'Calle 123');

-- Insert 2
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (2, 'usuario2', 'clave456', 2, 1, 23456789, 'María', 'Gómez', '1985-08-20', 'Femenino', '987654321', 'maria.gomez@example.com', 'Av. Principal 456');

-- Insert 3
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (3, 'usuario3', 'clave789', 3, 0, 34567890, 'Pedro', 'López', '1982-03-10', 'Masculino', '555123456', 'pedro.lopez@example.com', 'Ruta 101 Km 20');

-- Insert 4
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (4, 'usuario4', 'claveabc', 1, 1, 45678901, 'Ana', 'Martínez', '1995-12-25', 'Femenino', '1122334455', 'ana.martinez@example.com', 'Plaza Central 789');

-- Insert 5
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (5, 'usuario5', 'clavexyz', 2, 0, 56789012, 'Carlos', 'Gutiérrez', '1988-07-03', 'Masculino', '999888777', 'carlos.gutierrez@example.com', 'Calle 7 Bis');

-- Insert 6
INSERT INTO Usuario2 (IdUsuario, NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES (6, 'usuario6', 'clave123xyz', 3, 1, 67890123, 'Laura', 'Rodríguez', '1993-09-18', 'Femenino', '333444555', 'laura.rodriguez@example.com', 'Avenida Sur 123');

go
---
create PROCEDURE InsertarUsuario
    @NombreUsuario VARCHAR(50),
    @Clave VARCHAR(50),
    @Puesto INT,
    @Activo BIT = 1,
    @DNI INT,
    @Nombre VARCHAR(200),
    @Apellido VARCHAR(200),
    @FechaNacimiento DATE,
    @Genero VARCHAR(50),
    @Telefono VARCHAR(50),
    @Email VARCHAR(200),
    @Domicilio VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Usuario2 WHERE NombreUsuario = @NombreUsuario)
    BEGIN
        RAISERROR('Ya existe un usuario con estos datos', 16, 1);
        RETURN;
    END

    INSERT INTO Usuario2 (NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
    VALUES (@NombreUsuario, @Clave, @Puesto, ISNULL(@Activo, 1), @DNI, @Nombre, @Apellido, @FechaNacimiento, @Genero, @Telefono, @Email, @Domicilio);
END


