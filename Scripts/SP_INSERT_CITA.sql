CREATE OR ALTER PROC SP_INSERT_CITA
@idCliente int, @idDoctor int, @fechaCita date, @diagnostico varchar(500) 
AS
BEGIN
   Insert into Cita(IdCliente, IdDoctor, FechaCita, Diagnostico) values (@idCliente, @idDoctor, @fechaCita, @diagnostico);
END

CREATE OR ALTER PROC SP_ADD_DIAGNOSTICO_CITA
@idCita int, @diagnostico varchar(500) 
AS
BEGIN
   update Cita set Diagnostico = @diagnostico where IdCita = @idCita
END

CREATE OR ALTER PROC SP_SELECT_CITAS 
AS
BEGIN
   select * from Cita
END

CREATE OR ALTER PROC SP_SELECT_CITAS_BY_CITAID
@citaId int
AS
BEGIN
   select * from Cita where IdCita = @citaId
END

CREATE OR ALTER PROC SP_SELECT_CITAS_BY_DOCTORID
@doctorId int
AS
BEGIN
   select * from Cita where IdDoctor = @doctorId
END

CREATE OR ALTER PROC SP_SELECT_CITAS_BY_CLIENTEID
@clienteId int
AS
BEGIN
   select * from Cita where IdCliente = @clienteId
END