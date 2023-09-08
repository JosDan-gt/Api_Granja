CREATE TABLE ControlProduccion(
	DiaControl_Numero integer identity(1,1),
	Huevos_PorDia int,
	CantidadCartones_Pequeno int,
	CantidadCartones_Mediano int,
	CantidadCartones_Grande int,
	CantidadCartones_Jumbo int,
	Cantidad_Gallinas int,
	Cantidad_Cajas int,
	Cantidad_Perdida int,
	Fecha_Control datetime
	primary key(DiaControl_Numero)
)
SELECT * FROM ControlProduccion