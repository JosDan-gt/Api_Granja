CREATE TABLE ControlEmpleados(
	Id_Empleado integer identity(1,1),
	Nombre_Empleado varchar(50),
	Apellido_Empleado varchar (50),
	Direccion_Empleado varchar (50),
	Puesto_Empleado varchar(30),
	Edad_Empleado int,
	Telefono_Empleado int,
	Salario_Empleado int,
	Solvencia_Salario char(1)
	primary key(Id_Empleado)
)
SELECT * FROM ControlEmpleados