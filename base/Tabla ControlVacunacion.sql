CREATE TABLE ControlVacunacion(
	Vacuna_Numero integer identity(1,1),
	Nombre_Vacuna varchar (30),
	Cantidad_Vacunas int,
	Tipo_Vacuna varchar (10),
	Tiempo_Aplicacion varchar(30),
	CostoPor_Vacuna int,
	Fecha_Colocacion datetime
	primary key(Vacuna_Numero)
)
SELECT * FROM ControlVacunacion