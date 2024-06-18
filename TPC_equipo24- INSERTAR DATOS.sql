use TPC_equipo24_BD
go 
INSERT INTO Usuarios (Nombre, Clave, Puesto, Activo) VALUES
('PedroQui', 'claveSegura123', 1 ,1),
('facuPii', 'claveSegura234', 2, 1),
('Ismaores', 'claveSegura345', 3, 1)
GO
INSERT INTO Datos_Personales (IdDatosPersonales, Legajo, Dni, Nombre, Apellido, FechaNacimiento, Genero, Telefono, Email, Domicilio) VALUES
((SELECT ID FROM Usuarios WHERE Nombre = 'PedroQui'), 1001, '12345678A', 'Pedro', 'Quiros', '1990-01-01', 'M', '1234567890', 'Pedro.quieros@example.com', 'Calle Falsa 123'),
((SELECT ID FROM Usuarios WHERE Nombre = 'facuPii'), 1002, '23456789B', 'facundo', 'Pino', '1985-02-02', 'M', '2345678901', 'facu.pino@example.com', 'Avenida Siempreviva 742'),
((SELECT ID FROM Usuarios WHERE Nombre = 'Ismaores'), 1003, '23456789B', 'Ismael', 'oreste', '1985-02-02', 'M', '2345678901', 'isma.ores@example.com', 'Avenida Siemprenoviva 747')
go

select * from Datos_Personales
INSERT INTO Gerente (Nombre, Apellido, Estado) VALUES
('Pedro', 'Quieros', 1),
('Facundo', 'Pino', 1)
GO
INSERT INTO Mesero (Nombre, Apellido, Estado) VALUES
('Ismael', 'Oreste', 1)
GO
INSERT INTO Mesa (Id_Factura, Estado) VALUES
(1, 1),
(2, 0)
GO
INSERT INTO Pedido (Estado, FechaHoraCreado) VALUES
(1, '2023-01-01 12:00:00'),
(0, '2023-01-02 13:00:00')
GO
INSERT INTO ItemPedido (Cantidad, PrecioUnitario) VALUES
(2, 15.00),
(1, 25.00)
GO
INSERT INTO Factura (Id_Mesa, Id_Pedido, Id_FormaDePago, TipoFactura, Cantidad, PrecioTotal, FechaCreacion) VALUES
(1, 1, 1, 'A', 2, 30.00, '2023-01-01 12:30:00'),
(2, 2, 2, 'B', 1, 25.00, '2023-01-02 13:30:00')
GO
INSERT INTO FormaDePago (Id, Nombre) VALUES
(1, 'Efectivo'),
(2, 'Tarjeta de Crédito'),
(3, 'Tarjeta de Débito'),
(4, 'Transferencia Bancaria'),
(5, 'PayPal');
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
GO

select * from Datos_Personales
select * from Usuarios

select U.IdUsuario,U.Nombre,U.Puesto from Usuarios U

SELECT IdInsumo, Nombre, Tipo, Precio, Stock,Descripcion,UrlImagen FROM Insumo


create proc MostrarUsuario
as
select U.IdUsuario,U.Nombre,U.Puesto,U.Activo,DP.Legajo,DP.Nombre,DP.Apellido,DP.Dni,DP.FechaNacimiento,DP.Genero,
DP.Telefono,DP.Email,DP.Domicilio 
from Usuarios U
inner join Datos_Personales DP on DP.IdDatosPersonales = U.IdUsuario