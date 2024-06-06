create Database TPC_equipo24_BD
go
USE TPC_equipo24_BD;
GO

CREATE TABLE Usuarios(
    ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Clave VARCHAR(20) NOT NULL,
    Puesto INT NOT NULL,
    CONSTRAINT CHK_Clave CHECK (LEN(Clave) >= 8)
);
GO

CREATE TABLE Datos_Personales(
    IdDatosPersonales BIGINT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Usuarios(ID),
    Legajo BIGINT NOT NULL UNIQUE,
    Dni VARCHAR(20) NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Genero CHAR(1) NULL,
    Telefono VARCHAR(15) NULL,
    Email VARCHAR(140) NULL,
    Domicilio VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Gerente(
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Estado BIT NOT NULL
);
GO

CREATE TABLE Mesero(
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Estado BIT NOT NULL
);
GO

CREATE TABLE Mesa(
    Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Id_Factura INT,
    Estado BIT NOT NULL
);
GO

CREATE TABLE Pedido(
    IdPedido BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Estado BIT NOT NULL,
    FechaHoraCreado DATETIME
);
GO

CREATE TABLE ItemPedido(
    IdItemPedido BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Cantidad INT NOT NULL CHECK(Cantidad > 0),
    PrecioUnitario MONEY NOT NULL CHECK(PrecioUnitario > 0)
);
GO

CREATE TABLE Factura(
    IdFactura BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Id_Mesa BIGINT NOT NULL,
    Id_Pedido BIGINT NOT NULL,
    Id_FormaDePago INT NOT NULL, 
    TipoFactura CHAR(1),
    Cantidad INT NOT NULL,
    PrecioTotal MONEY NOT NULL CHECK(PrecioTotal > 0),
    FechaCreacion DATETIME
);
GO

CREATE TABLE FormaDePago(
    Id SMALLINT NOT NULL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Resenias(
    IdInscripcion BIGINT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Mesero(Id),
    Fecha DATE NOT NULL DEFAULT(GETDATE()),
    Observaciones VARCHAR(MAX) NOT NULL,
    Puntaje DECIMAL(3, 1) NOT NULL,
    Inapropiada BIT NOT NULL DEFAULT(0)
);
GO

CREATE TABLE Insumo(
    IdInsumo BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Precio MONEY NOT NULL CHECK(Precio > 0),
    Cantidad INT NOT NULL
);

--datos para usuarios y datos personales
go 
INSERT INTO Usuarios (Nombre, Clave, Puesto) VALUES
('PedroQui', 'claveSegura123', 1),
('facuPii', 'claveSegura234', 2),
('Ismaores', 'claveSegura345', 3)
GO
INSERT INTO Datos_Personales (IdDatosPersonales, Legajo, Dni, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio) VALUES
((SELECT ID FROM Usuarios WHERE Nombre = 'PedroQui'), 1001, '12345678A', 'Pedro', 'Quiros', '1990-01-01', 'M', '1234567890', 'Pedro.quieros@example.com', 'Calle Falsa 123'),
((SELECT ID FROM Usuarios WHERE Nombre = 'facuPii'), 1002, '23456789B', 'facundo', 'Pino', '1985-02-02', 'M', '2345678901', 'facu.pino@example.com', 'Avenida Siempreviva 742'),
((SELECT ID FROM Usuarios WHERE Nombre = 'Ismaores'), 1003, '23456789B', 'Ismael', 'oreste', '1985-02-02', 'M', '2345678901', 'isma.ores@example.com', 'Avenida Siemprenoviva 747')