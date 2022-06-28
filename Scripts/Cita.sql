create table Cita(
	IdCita int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IdCliente int NOT NULL,
	IdDoctor int NOT NULL,
	FechaCita date NOT NULL,
	Diagnostico varchar(500),
	CONSTRAINT fk_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente) ON DELETE CASCADE,
	CONSTRAINT fk_Doctor FOREIGN KEY (IdDoctor) REFERENCES Doctor(IdDoctor) ON DELETE CASCADE,
)