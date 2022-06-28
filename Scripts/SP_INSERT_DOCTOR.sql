CREATE OR ALTER PROC SP_INSERT_DOCTOR
@nombre varchar(250)
AS
BEGIN
   Insert into Doctor(Nombre) values (@nombre);
END

CREATE OR ALTER PROC SP_SELECT_DOCTORES
AS
BEGIN
   Select * from Doctor
END