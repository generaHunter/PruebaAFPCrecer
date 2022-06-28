CREATE OR ALTER PROC SP_INSERT_CLIENTE
@nombre varchar(250)
AS
BEGIN
   Insert into Cliente(Nombre) values (@nombre);
END

CREATE OR ALTER PROC SP_SELECT_CLIENTES
AS
BEGIN
   Select * from Cliente
END



