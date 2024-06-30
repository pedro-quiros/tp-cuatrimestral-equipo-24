CREATE DATABASE TPC_equipo24_BD
GO
USE [TPC_equipo24_BD]
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

CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) PRIMARY KEY,
	[NombreUsuario] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[Puesto] [int] NULL,
	[Activo] [bit] NULL,
	[DNI] [int] NULL,
	[Nombre] [varchar](200) NULL,
	[Apellido] [varchar](200) NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](200) NULL,
	[Domicilio] [varchar](200) NULL
	)

--- PROCEDIMIENTOS ALMACENADOS
GO
create Procedure [dbo].[AltaLogicaUsuario]
@IdUsuario int
as 
update Usuarios set Activo = 1 where IdUsuario = @IdUsuario
GO


create Procedure [dbo].[BajaLogicaUsuario]
@IdUsuario int 
as 
update Usuarios set Activo = 0 where IdUsuario = @IdUsuario
GO


CREATE proc [dbo].[MostrarUsuario] 
as
select IdUsuario,NombreUsuario,Puesto,Activo,Nombre,Apellido,Dni,FechaNacimiento,Genero,
Telefono,Email,Domicilio
from Usuarios
GO

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
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = @NombreUsuario)
        BEGIN
            RAISERROR('Ya existe un usuario con este nombre de usuario', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO Usuarios (NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
        VALUES (@NombreUsuario, @Clave, @Puesto, @Activo, @DNI, @Nombre, @Apellido, @FechaNacimiento, @Genero, @Telefono, @Email, @Domicilio);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

--- INSERT Datos Usuarios + Ejemplo con Procedimiento Almacenado:
-- Insert 1
INSERT INTO Usuarios (NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES ('usuario1', 'clave123', 1, 1, 12345678, 'Juan', 'Pérez', '1990-05-15', 'Masculino', '123456789', 'juan.perez@example.com', 'Calle 123');

-- Insert 2
INSERT INTO Usuarios (NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES ('usuario2', 'clave456', 2, 1, 23456789, 'María', 'Gómez', '1985-08-20', 'Femenino', '987654321', 'maria.gomez@example.com', 'Av. Principal 456');

-- Insert 3
INSERT INTO Usuarios (NombreUsuario, Clave, Puesto, Activo, DNI, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio)
VALUES ('usuario3', 'clave789', 3, 0, 34567890, 'Pedro', 'López', '1982-03-10', 'Masculino', '555123456', 'pedro.lopez@example.com', 'Ruta 101 Km 20');

EXEC InsertarUsuario 
    @NombreUsuario = 'jdoe', 
    @Clave = 'securepassword', 
    @Puesto = 1, 
    @Activo = 1, 
    @DNI = 12345678, 
    @Nombre = 'John', 
    @Apellido = 'Doe', 
    @FechaNacimiento = '1990-01-01', 
    @Genero = 'Masculino', 
    @Telefono = '123456789', 
    @Email = 'jdoe@example.com', 
    @Domicilio = '123 Main St'
go

--- INSERT Datos INSUMO
INSERT INTO Insumo (Nombre, Tipo, Precio, Stock, UrlImagen, Descripcion) VALUES
('Asado', 'Plato', 1000, 50,'https://www.infocampo.com.ar/wp-content/uploads/2018/10/asado.jpg', 'Delicioso asado a la parrilla.'),
('Milanesa', 'Plato', 500, 50,'https://www.ilolay.com.ar/uploads/recetas/1690929642-MilanesasSinPack.png', 'Milanesa de ternera crujiente.'),
('Coca-Cola', 'Bebida', 1500, 200,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fcomputerhoy.com%2Freportajes%2Flife%2Fcuriosidades-sobre-coca-cola-586931&psig=AOvVaw2vqqc7Xvg9YifhsK-xVaPW&ust=1718234668255000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKDzlY7Z1IYDFQAAAAAdAAAAABAE', 'Refrescante Coca-Cola.'),
('Pizza', 'Plato', 800, 30,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTI2hdQeNVlyu20ReOpJcNwdgW0ER5hwxnauQ&s', 'Pizza con queso y pepperoni.'),
('Empanada', 'Plato', 300, 100,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.knorr.com%2Fuy%2Fr%2Fempanadas-de-carne.html%2F237001&psig=AOvVaw0V2uGVFZxxqzq_11JvPxJk&ust=1718234737792000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKDNmK3Z1IYDFQAAAAAdAAAAABAE', 'Empanadas caseras variadas.'),
('Agua Mineral', 'Bebida', 1000, 150,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.infobae.com%2Fmexico%2F2024%2F01%2F28%2Fcuales-son-los-beneficios-de-tomar-agua-mineral-todos-los-dias%2F&psig=AOvVaw27Wm931wqQx1wPWAle4WkE&ust=1718234771991000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNi5l8DZ1IYDFQAAAAAdAAAAABAE', 'Agua mineral pura y refrescante.'),
('Ensalada', 'Plato', 700, 40,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVFwPCF6CmL42k8stku8w4wTTlL6Oa2-4a0w&s', 'Ensalada fresca con aderezo.'),
('Fanta', 'Bebida', 1400, 180,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB8PI1p4EYpqirpQa_i9STibb41CPPN8Rcow&s', 'Refrescante Fanta de naranja.');
GO


exec MostrarUsuario


----------

exec SP_ListarInsumos
CREATE PROCEDURE SP_ListarInsumos
AS
BEGIN
    SELECT IdInsumo, Nombre, Tipo, Precio, Stock, UrlImagen, Descripcion
    FROM Insumo
END

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

CREATE PROCEDURE SP_EliminarInsumo
    @IdInsumo INT
AS
BEGIN
    DELETE FROM Insumo
    WHERE IdInsumo = @IdInsumo
END



CREATE TABLE Mesa(
	IdMesa INT PRIMARY KEY IDENTITY(1,1),
	Estado BIT NULL DEFAULT 0,
	Numero INT,
	)
drop table Mesa
	/*
CREATE TABLE [dbo].[Mesa](
	[IdMesa] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[IdMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
*/
GO

-- Insertar una mesa con estado abierto y sin factura asociada
INSERT INTO Mesa (Numero)
VALUES (3),
(4),
(5),
(6),
(7);

select * from mesa

exec SP_ListarMesas
ALTER PROCEDURE SP_ListarMesas
AS
BEGIN
    SELECT IdMesa, Numero, Estado 
    FROM Mesa
END

---
ALTER PROCEDURE SP_AbrirCerrarMesa
    @IdMesa INT
AS
BEGIN
    DECLARE @EstadoActual BIT;

    SELECT @EstadoActual = Estado
    FROM Mesa
    WHERE IdMesa = @IdMesa;

    IF @EstadoActual = 1
    BEGIN
        UPDATE Mesa
        SET Estado = 0
        WHERE IdMesa = @IdMesa;
    END
    ELSE
    BEGIN
        UPDATE Mesa
        SET Estado = 1
        WHERE IdMesa = @IdMesa;
    END
END;

-- Cambiar el estado de la mesa con IdMesa = 1
EXEC SP_AbrirCerrarMesa @IdMesa = 1;

-- Verificar el cambio
SELECT * FROM Mesa WHERE IdMesa = 1;







---