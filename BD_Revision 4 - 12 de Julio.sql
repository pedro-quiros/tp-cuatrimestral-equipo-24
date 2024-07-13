CREATE DATABASE TPC_equipo24_BD
GO
USE [TPC_equipo24_BD]

GO
---  TABLA DATOS PERSONALES
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

--- TABLA FACTURA
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

--- TABLA FORMATO PAGO
GO
CREATE TABLE [dbo].[FormatoPago](
	[IdFormatopago] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_FormatoPago] PRIMARY KEY CLUSTERED 
(
	[IdFormatopago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--- TABLA GERENTE
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


--- TABLA INSUMO
CREATE TABLE [dbo].[Insumo](
	[IdInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Precio] [money] NULL,
	[Stock] [int] NULL,
	[UrlImagen] [varchar](max) NULL,
	[Descripcion] [varchar](500) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--- TABLA MESERO
GO
CREATE TABLE [dbo].[Mesero](
	[IdMesero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](10) NULL,
	[Apellido] [nchar](10) NULL,
	[Estado] [nchar](10) NULL,
	[IdMesa] [int] NOT NULL,

 CONSTRAINT [PK_Mesero] PRIMARY KEY CLUSTERED 
(
	[IdMesero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--- TABLA MESA
GO
CREATE TABLE Mesa (
    IdMesa INT PRIMARY KEY IDENTITY(1,1),
    IdFactura INT NULL,
    Estado BIT NULL DEFAULT 0,
    Numero INT,
    IdMesero INT,
    CONSTRAINT FK_Mesa_Meseroo FOREIGN KEY (IdMesero) REFERENCES Mesero(IdMesero)
);

--- TABLA Reseña
GO
CREATE TABLE [dbo].[Reseña](
	[IdReseña] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Email] [varchar](200) NULL,
	[Fecha] [date] NULL,
	[Puntaje] [int] NULL,
	[mensaje] [varchar](max) NULL,
 CONSTRAINT [PK_Reseña] PRIMARY KEY CLUSTERED 
(
	[IdReseña] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--- TABLA USUARIOS X
GO
CREATE TABLE [dbo].[Usuario2](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[Puesto] [int] NULL,
	[Activo] [bit] NULL,
	[Legajo] [int] NULL,
	[DNI] [int] NULL,
	[Nombre] [varchar](200) NULL,
	[Apellido] [varchar](200) NULL,
	[FechaNacimiento] [date] NULL,
	[genero] [varchar](50) NULL,
	[Telefono] [int] NULL,
	[Email] [varchar](200) NULL,
	[domicilio] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
--- TABLA PEDIDO
GO
--CREATE TABLE [dbo].[Pedido](
--    [IdPedido] [int] IDENTITY(1,1) NOT NULL,
--	--[IdItemPedido] [int] NULL,   
--	----[IdInsumo] [int] NOT NULL,   
--	[IdMesa] [int] NOT NULL,
--	[IdMesero] [int] NOT NULL,
--    [FechaHoraGenerado] [datetime] NOT NULL,
--    [Estado] [bit] NOT NULL,
--	[Total] [money] NOT NULL,
	
--    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([IdPedido] ASC),
--	CONSTRAINT FK_MESERO_PEDIDO foreign key (IdMesero) references Mesero(IdMesero),
--    CONSTRAINT [FK_Pedido_Mesa] FOREIGN KEY ([IdMesa]) REFERENCES [dbo].[Mesa] ([IdMesa]),
--	----CONSTRAINT [Fk_Pedido_Insumo] FOREIGN KEY([IdInsumo]) REFERENCES [dbo].[Insumo] ([IdInsumo]) --- ver
--) ON [PRIMARY]

CREATE TABLE [dbo].[Pedido](
    [IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdMesa] [int] NOT NULL,
	[IdMesero] [int] NOT NULL,
    [FechaHoraGenerado] [datetime] NOT NULL,
    [Estado] [bit] NOT NULL,
	[Total] [money] NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([IdPedido] ASC),
	CONSTRAINT FK_MESERO_PEDIDO FOREIGN KEY (IdMesero) REFERENCES Mesero(IdMesero),
    CONSTRAINT [FK_Pedido_Mesa] FOREIGN KEY ([IdMesa]) REFERENCES [dbo].[Mesa] ([IdMesa])
) ON [PRIMARY]
--- TABLA ITEMPEDIDO
GO
--CREATE TABLE [dbo].[ItemPedido](
--    [IdItemPedido] [int] IDENTITY(1,1) NOT NULL,
--    [IdPedido] [int] NOT NULL,
--    [IdInsumo] [int] NOT NULL,
--    [Cantidad] [int] NOT NULL,
--    [PrecioUnitario] [money] NOT NULL,
--    CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED ([IdItemPedido] ASC),
--    --CONSTRAINT [FK_ItemPedido_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido]([IdPedido]),
--    CONSTRAINT [FK_ItemPedido_Insumo] FOREIGN KEY ([IdInsumo]) REFERENCES [dbo].[Insumo]([IdInsumo])
--) ON [PRIMARY]

CREATE TABLE [dbo].[ItemPedido](
    [IdItemPedido] [int] IDENTITY(1,1) NOT NULL,
    [IdPedido] [int] NOT NULL,
    [IdInsumo] [int] NOT NULL,
    [Cantidad] [int] NOT NULL,
    [PrecioUnitario] [money] NOT NULL,
    CONSTRAINT [PK_ItemPedido] PRIMARY KEY CLUSTERED ([IdItemPedido] ASC),
    CONSTRAINT [FK_ItemPedido_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido]([IdPedido]),
    CONSTRAINT [FK_ItemPedido_Insumo] FOREIGN KEY ([IdInsumo]) REFERENCES [dbo].[Insumo]([IdInsumo])
) ON [PRIMARY]


----- TABLA USUARIO 2
--GO
--create TABLE [dbo].[Usuario2](
--	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
--	[NombreUsuario] [varchar](50) NULL,
--	[Clave] [varchar](50) NULL,
--	[Puesto] [int] NULL,
--	[Activo] [bit] NULL,
--	[Legajo] [int] NULL,
--	[DNI] [int] NULL,
--	[Nombre] [varchar](200) NULL,
--	[Apellido] [varchar](200) NULL,
--	[FechaNacimiento] [date] NULL,
--	[genero] [varchar](50) NULL,
--	[Telefono] [int] NULL,
--	[Email] [varchar](200) NULL,
--	[domicilio] [varchar](200) NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[IdUsuario] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]


--- ALTERS

ALTER TABLE [dbo].[Datos_Personales]  WITH CHECK ADD FOREIGN KEY([IdDatosPersonales])
REFERENCES [dbo].[Usuario2] ([IdUsuario])
GO


--ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [Fk_Pedido] FOREIGN KEY([IdItemPedido])
--REFERENCES [dbo].[ItemPedido] ([IdItemPedido])

--GO
--ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [Fk_Pedido]

GO
------------ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [Fk_Pedido_Insumo]
GO
--ALTER TABLE [dbo].[Reseña]  WITH CHECK ADD  CONSTRAINT [CHK_Puntaje_mesa] CHECK  (([Puntaje]>=(1) AND [Puntaje]<=(10)))
GO
--ALTER TABLE [dbo].[Reseña] CHECK CONSTRAINT [CHK_Puntaje_mesa]

--GO

--- PROCEDIMIENTOS ALMACENADOS USUARIO
GO
create proc InsertarusuarioLogin
    @Email VARCHAR(200),
	@NombreUsuario VARCHAR(50),
    @Clave VARCHAR(50),
    @Puesto INT,
    @Activo BIT,
    @DNI INT,
    @Nombre VARCHAR(200),
    @Apellido VARCHAR(200),
    @Nacimiento DATE,
    @genero VARCHAR(50),
    @Telefono INT,
    @domicilio VARCHAR(200)
as
IF EXISTS(SELECT 1 FROM Usuario2 WHERE Email = @Email)
RAISERROR('Ya existe un Usuario con ese Email, POR FAVOR INGRESE DE NUEVO',16,1)
ELSE
INSERT INTO Usuario2
        (NombreUsuario, Clave, Email,Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, genero, Telefono,domicilio)
        VALUES
        (@NombreUsuario, @Clave, @Email,@Puesto, @Activo, @DNI, @Nombre, @Apellido, @Nacimiento, @genero, @Telefono,@domicilio)
		
GO
create Procedure [dbo].[AltaLogicaUsuario]
@IdUsuario int
as 
update Usuario2 set Activo = 1 where IdUsuario = @IdUsuario

GO
create Procedure [dbo].[BajaLogicaUsuario]
@IdUsuario int 
as 
update Usuario2 set Activo = 0 where IdUsuario = @IdUsuario

GO
CREATE proc [dbo].[MostrarUsuario] 
as
select U.IdUsuario,U.NombreUsuario,U.Puesto,U.Activo,U.Legajo,U.Nombre,U.Apellido,U.DNI,U.FechaNacimiento,u.Genero,
U.Telefono,U.Email,U.Domicilio
from Usuario2 U
GO

CREATE proc [dbo].[editar_Personal]
	@IdUsuario int,
	@NombreUsuario VARCHAR(50),
	@password VARCHAR(50),
    @Puesto INT,
    @Legajo INT,
    @DNI INT,
    @Nombre VARCHAR(200),
    @Apellido VARCHAR(200),
    @Nacimiento DATE,
    @genero VARCHAR(50),
    @Telefono INT,
    @Email VARCHAR(200),
    @domicilio VARCHAR(200)
as
if EXISTS (SELECT IdUsuario FROM Usuario2 where DNI   = @DNI)
RAISERROR ('Nº de documento en Uso, usa otro Nº de documento por favor', 16,1)
else 
update Usuario2 set NombreUsuario  =@NombreUsuario,Clave = @password,Puesto=@Puesto,Legajo=@Legajo,DNI=@DNI,Nombre=@Nombre ,Apellido = @Apellido,   
FechaNacimiento=@Nacimiento,genero=@genero,telefono=@Telefono,Email=@Email,domicilio=@domicilio
WHERE @IdUsuario = IdUsuario
GO

---------------------------------------------------------------------------------------------------
CREATE proc [dbo].[Insertarusuario]
@NombreUsuario VARCHAR(50),
    @Clave VARCHAR(50),
    @Puesto INT,
    @Activo BIT,
    @Legajo INT,
    @DNI INT,
    @Nombre VARCHAR(200),
    @Apellido VARCHAR(200),
    @Nacimiento DATE,
    @genero VARCHAR(50),
    @Telefono INT,
    @Email VARCHAR(200),
    @domicilio VARCHAR(200)
as
IF EXISTS(SELECT 1 FROM Usuario2 WHERE DNI = @DNI)
RAISERROR('Ya existe un Usuario con ese Numero de Documento, POR FAVOR INGRESE DE NUEVO',16,1)
ELSE
INSERT INTO Usuario2
        (NombreUsuario, Clave, Puesto, Activo, Legajo, DNI, Nombre, Apellido, FechaNacimiento, genero, Telefono, Email, domicilio)
        VALUES
        (@NombreUsuario, @Clave, @Puesto, @Activo, @Legajo, @DNI, @Nombre, @Apellido, @Nacimiento, @genero, @Telefono, @Email, @domicilio)
GO


--- INSERT Datos Usuarios + Ejemplo con Procedimiento Almacenado:

insert into Usuario2 (NombreUsuario, Clave, Puesto, Activo, Legajo, DNI, Nombre, Apellido, FechaNacimiento, genero, Telefono, Email, domicilio)
VALUES
('FacuPino', 'river912', 1, 1, 123456789, 123456789, 'Facundo', 'Pino', '01/03/2004', 'M', 123456789, 'facupino@gmail.com', 'yVaElTercero 912'),
('Mailomono', 'ElBichoSiu', 1, 1, 987654321, 987654321, 'Isma', 'Oreste', '06/26/2004', 'M', 987654321, 'ismaores@gmail.com', 'Messi 1812'),
('Pedrito', 'VanPersie', 1, 1, 012345678, 012345678, 'Pedro', 'Quiros', '12/09/2001', 'M', 012345678, 'pedrito@gmail.com', 'LaNaranjaMecanica 1978'),
('a', 'a', 1, 2, 012345678, 012345678, 'Pedro', 'Quiros', '12/09/2001', 'H', 012345678, 'pedrito2@gmail.com', 'LaNaranjaMecanica 1978')

--- INSERT Datos INSUMO
GO
INSERT INTO Insumo (Nombre, Tipo, Precio, Stock, UrlImagen, Descripcion) VALUES
('Asado', 'Plato', 1000, 50,'https://www.infocampo.com.ar/wp-content/uploads/2018/10/asado.jpg', 'Delicioso asado a la parrilla.'),
('Milanesa', 'Plato', 500, 50,'https://www.ilolay.com.ar/uploads/recetas/1690929642-MilanesasSinPack.png', 'Milanesa de ternera crujiente.'),
('Coca-Cola', 'Bebida', 1500, 200,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fcomputerhoy.com%2Freportajes%2Flife%2Fcuriosidades-sobre-coca-cola-586931&psig=AOvVaw2vqqc7Xvg9YifhsK-xVaPW&ust=1718234668255000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKDzlY7Z1IYDFQAAAAAdAAAAABAE', 'Refrescante Coca-Cola.'),
('Pizza', 'Plato', 800, 30,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTI2hdQeNVlyu20ReOpJcNwdgW0ER5hwxnauQ&s', 'Pizza con queso y pepperoni.'),
('Empanada', 'Plato', 300, 100,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.knorr.com%2Fuy%2Fr%2Fempanadas-de-carne.html%2F237001&psig=AOvVaw0V2uGVFZxxqzq_11JvPxJk&ust=1718234737792000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKDNmK3Z1IYDFQAAAAAdAAAAABAE', 'Empanadas caseras variadas.'),
('Agua Mineral', 'Bebida', 1000, 150,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.infobae.com%2Fmexico%2F2024%2F01%2F28%2Fcuales-son-los-beneficios-de-tomar-agua-mineral-todos-los-dias%2F&psig=AOvVaw27Wm931wqQx1wPWAle4WkE&ust=1718234771991000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNi5l8DZ1IYDFQAAAAAdAAAAABAE', 'Agua mineral pura y refrescante.'),
('Ensalada', 'Plato', 700, 40,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVFwPCF6CmL42k8stku8w4wTTlL6Oa2-4a0w&s', 'Ensalada fresca con aderezo.'),
('Fanta', 'Bebida', 1400, 180,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB8PI1p4EYpqirpQa_i9STibb41CPPN8Rcow&s', 'Refrescante Fanta de naranja.');

-- INSERT Datos MESAS
GO
INSERT INTO Mesa (Numero, Estado)
VALUES (1,0),
(2,0),
(3,0),
(4,0),
(5,1);


--- PROCEDIMIENTOS ALMACENADOS INSUMOS
GO
CREATE PROCEDURE SP_ListarInsumos
AS
BEGIN
    SELECT IdInsumo, Nombre, Tipo, Precio, Stock, UrlImagen, Descripcion
    FROM Insumo
END

GO
CREATE PROCEDURE SP_ModificarInsumo
    @IdInsumo INT,
    @Nombre VARCHAR(50),
    @Tipo VARCHAR(50),
    @Precio MONEY,
    @Stock INT,
    @UrlImagen VARCHAR(max),
    @Descripcion VARCHAR(500)
AS
BEGIN
    UPDATE Insumo
    SET Nombre = @Nombre, Tipo = @Tipo, Precio = @Precio, Stock = @Stock, UrlImagen = @UrlImagen, Descripcion = @Descripcion
    WHERE IdInsumo = @IdInsumo
END

GO
CREATE PROCEDURE SP_EliminarInsumo
    @IdInsumo INT
AS
BEGIN
    DELETE FROM Insumo
    WHERE IdInsumo = @IdInsumo
END


--- PROCEDIMIENTOS MESAS

GO

CREATE PROCEDURE SP_ListarMesas
AS
BEGIN
    SELECT IdMesa, Numero, Estado 
    FROM Mesa
END

---
--CREATE PROCEDURE [dbo].[SP_AbrirCerrarMesa]
--    @IdMesa INT,
--    @Estado BIT  -- 1 para abrir, 0 para cerrar
--AS
--BEGIN
--    UPDATE Mesas
--    SET Estado = @Estado
--    WHERE IdMesa = @IdMesa;
--END


GO
CREATE PROCEDURE SP_ActualizarStockInsumo
    @IdInsumo INT,
    @Cantidad INT
AS
BEGIN
    UPDATE Insumo
    SET Stock = Stock + @Cantidad
    WHERE IdInsumo = @IdInsumo;
END;


--GO
--CREATE PROCEDURE SP_CrearPedido
--    @IdInsumo INT,
--    @IdMesa INT,
--    @IdMesero INT,
--    @FechaHoraGenerado DATETIME,
--    @Estado BIT,
--    @Total MONEY
--AS
--BEGIN
--    -- Verificar si el IdInsumo es válido
--    IF NOT EXISTS (SELECT 1 FROM Insumo WHERE IdInsumo = @IdInsumo)
--    BEGIN
--        RAISERROR('El IdInsumo proporcionado no existe.', 16, 1);
--        RETURN;
--    END

--    -- Insertar el pedido
--    INSERT INTO Pedido (IdInsumo, IdMesa, IdMesero, FechaHoraGenerado, Estado, Total)
--    VALUES (@IdInsumo, @IdMesa, @IdMesero, @FechaHoraGenerado, @Estado, @Total);

--    -- Retornar el Id del pedido recién creado
--    SELECT SCOPE_IDENTITY() AS IdPedido;
--END
-------------------------------------------------------------
GO
CREATE PROCEDURE SP_CrearPedido
    @IdMesa INT,
    @IdMesero INT,
    @FechaHoraGenerado DATETIME,
    @Estado BIT,
    @Total MONEY,
    @ItemsPedido TABLE (IdInsumo INT, Cantidad INT, PrecioUnitario MONEY)
AS
BEGIN
    -- Iniciar una transacción
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insertar en la tabla Pedido
        INSERT INTO [dbo].[Pedido] (IdMesa, IdMesero, FechaHoraGenerado, Estado, Total)
        VALUES (@IdMesa, @IdMesero, @FechaHoraGenerado, @Estado, @Total);

        -- Obtener el IdPedido recién creado
        DECLARE @IdPedido INT;
        SET @IdPedido = SCOPE_IDENTITY();

        -- Insertar los items del pedido
        INSERT INTO [dbo].[ItemPedido] (IdPedido, IdInsumo, Cantidad, PrecioUnitario)
        SELECT @IdPedido, IdInsumo, Cantidad, PrecioUnitario
        FROM @ItemsPedido;

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, deshacer la transacción
        ROLLBACK TRANSACTION;

        -- Propagar el error
        THROW;
    END CATCH;
END;

GO
--CREATE PROCEDURE SP_CrearPedidoOK1957
--    @IdMesa INT,
--    @FechaHoraGenerado DATETIME,
--    @Estado BIT,
--    @Total MONEY
--AS
--BEGIN
--    INSERT INTO Pedido (IdMesa, FechaHoraGenerado, Estado, Total)
--    VALUES (@IdMesa, @FechaHoraGenerado, @Estado, @Total);

--    SELECT SCOPE_IDENTITY() AS IdPedido;
--END;

-----
--GO
--CREATE PROCEDURE SP_CerrarPedido
--    @IdPedido INT
--AS
--BEGIN
--    UPDATE Pedido
--    SET Estado = 1  -- Estado 1 representa "Cerrado"
--    WHERE IdPedido = @IdPedido;
--END;

--CREATE PROCEDURE [dbo].[SP_AgregarItemPedido] ---ok
--    @IdPedido INT,
--    @IdInsumo INT,
--    @Cantidad INT,
--    @PrecioUnitario DECIMAL(18,2)
--AS
--BEGIN
--    BEGIN TRANSACTION;

--    -- Agregar un ítem al pedido
--    INSERT INTO ItemPedido (IdPedido, IdInsumo, Cantidad, PrecioUnitario)
--    VALUES (@IdPedido, @IdInsumo, @Cantidad, @PrecioUnitario);

--    COMMIT TRANSACTION;
--END

GO
CREATE PROCEDURE [dbo].[SP_ObtenerPedidoPorId] ---ok
    @IdPedido INT
AS
BEGIN
    SELECT IdPedido, IdMesa, FechaHoraGenerado, Estado, Total
    FROM Pedidos
    WHERE IdPedido = @IdPedido;
END

GO
CREATE PROCEDURE [dbo].[SP_ActualizarPedido] ---ok
    @IdPedido INT,
    @Total DECIMAL(18,2)
AS
BEGIN
    UPDATE Pedido
    SET Total = @Total
    WHERE IdPedido = @IdPedido;
END

GO
CREATE PROCEDURE SP_CerrarPedidoYGenerarFactura
    @IdPedido INT,
    @IdFormatoPago INT,
    @TipoFactura CHAR(1)
AS
BEGIN
    DECLARE @IdMesa INT;
    DECLARE @Cantidad INT;
    DECLARE @PrecioTotal MONEY;
    DECLARE @FechaCreacion DATETIME = GETDATE();

    SELECT @IdMesa = IdMesa, @PrecioTotal = Total
    FROM Pedido
    WHERE IdPedido = @IdPedido;

    UPDATE Pedido
    SET Estado = 0
    WHERE IdPedido = @IdPedido;

    SELECT @Cantidad = COUNT(*) 
    FROM ItemPedido 
    WHERE IdPedido = @IdPedido;

    INSERT INTO Factura (IdMesa, IdPedido, IdFormatoPago, TipoFactura, Cantidad, precioTotal, FechaCreacion)
    VALUES (@IdMesa, @IdPedido, @IdFormatoPago, @TipoFactura, @Cantidad, @PrecioTotal, @FechaCreacion);
END;

-----------------------------
GO
CREATE proc [dbo].[Insertarreseña] 
@nombre varchar(100),
@email varchar(100),
@fecha date ,
@puntaje int,
@msj varchar(max)
as
INSERT INTO Reseña
        (Nombre, Email, Fecha, Puntaje, mensaje)
        VALUES
        (@Nombre, @email, @fecha, @puntaje, @msj)
GO


---------------------------------------------

create or alter Procedure SP_ContReseñas 
as 
begin 
	select COUNT(Puntaje) as POSITIVOS 
	from Reseña 
	where Puntaje BETWEEN  6 and 10 

	SELECT COUNT(Puntaje) AS Negativos 
    FROM Reseña 
    WHERE Puntaje BETWEEN 1 AND 5
END

GO
INSERT INTO MESERO (Nombre, Apellido, Estado, IdMesa) VALUES
('Andres', 'Cuccitini', 1, 2),
('Julian', 'Araña', 1, 4),
('Lauta', 'Toro', 1, 2),
('Dibu', 'Martinez', 1, 2), 
('Cuti', 'Romero', 1, 1), 
('Licha', 'Carnicero', 1, 3)

GO
INSERT INTO Mesa (Estado, Numero) VALUES
(1, 1), 
(1, 2), 
(1, 3), 
(1, 4), 
(1, 5), 
(1, 6)

-------------------------------------------------
GO
CREATE PROCEDURE [dbo].[SP_AbrirMesaYCrearPedido] --OK
    @IdMesa INT,
    @FechaHoraGenerado DATETIME,
    @IdPedido INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;

    -- Abrir la mesa

    UPDATE Mesa
    SET Estado = 1  -- 1 para abierto
    WHERE IdMesa = @IdMesa;

    -- Crear el pedido
    INSERT INTO Pedido (IdMesa, FechaHoraGenerado, Estado, Total)
    VALUES (@IdMesa, @FechaHoraGenerado, 1, 0);  -- 1 para estado activo, Total inicial es 0

    -- Obtener el IdPedido del nuevo pedido
    SET @IdPedido = SCOPE_IDENTITY();

    COMMIT TRANSACTION;
END

---
GO
CREATE PROCEDURE [dbo].[SP_CerrarMesaYPedido] --OK
    @IdMesa INT,
    @IdPedido INT
AS
BEGIN
    BEGIN TRANSACTION;

    -- Cerrar el pedido
    UPDATE Pedido
    SET Estado = 0  -- 0 para cerrado
    WHERE IdPedido = @IdPedido;

    -- Actualizar el total del pedido
    DECLARE @Total DECIMAL(18,2);
    SELECT @Total = SUM(Cantidad * PrecioUnitario)
    FROM ItemPedido
    WHERE IdPedido = @IdPedido;

    UPDATE Pedido
    SET Total = @Total
    WHERE IdPedido = @IdPedido;

    -- Cerrar la mesa
    UPDATE Mesa
    SET Estado = 0  -- 0 para cerrado
    WHERE IdMesa = @IdMesa;

    COMMIT TRANSACTION;
END

---
GO
CREATE PROCEDURE SP_ObtenerPedidoPorMesa
    @IdMesa INT
AS
BEGIN
    SELECT IdPedido, Estado, FechaHoraGenerado, Total
    FROM Pedido
    WHERE IdMesa = @IdMesa AND Estado = 1 
END
---

GO
CREATE PROCEDURE InsertarItemPedido
    @IdPedido INT,
    @IdInsumo INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(18,2)
AS
BEGIN
    INSERT INTO ItemPedido (IdPedido, IdInsumo, Cantidad, PrecioUnitario)
    VALUES (@IdPedido, @IdInsumo, @Cantidad, @PrecioUnitario)
END


------------------------------------

alter table pedido 
drop FK_MESERO_PEDIDO
drop column IdMesero
alter table Mesa
drop FK_Mesa_Meseroo
drop column IdMesero
drop table Mesero
drop table Gerente



alter table Pedido
add IdUsuario INT
add CONSTRAINT FK_PEDIDO_USUARIO foreign key (IdUsuario) references Usuario2(IdUsuario)
alter table Mesa
add IdUsuario INT
add CONSTRAINT FK_MESA_USUARIO foreign key (IdUsuario) references Usuario2(IdUsuario)



update Mesa SET IdUsuario = 1  where IdMesa =  1
update Mesa SET IdUsuario = 1  where IdMesa =  2
update Mesa SET IdUsuario = 1  where IdMesa =  3
update Mesa SET IdUsuario = 2  where IdMesa =  4
update Mesa SET IdUsuario = 2  where IdMesa =  5
update Mesa SET IdUsuario = 2  where IdMesa =  6
update Mesa SET IdUsuario = 2  where IdMesa =  7
update Mesa SET IdUsuario = 3  where IdMesa =  8
update Mesa SET IdUsuario = 3  where IdMesa =  9
update Mesa SET IdUsuario = 3  where IdMesa =  10
update Mesa SET IdUsuario = 3  where IdMesa =  11

