CREATE TABLE PedidosClientes(
	Cliente_Numero integer identity(1,1),
	Nombre_Cliente varchar(50),
	Apellido_Cliente varchar(50),
	Direccion_Cliente varchar(100),
	Telefono_Cliente int,
	Tipo_Carton char(1),
	Fecha_Entrega datetime,
	Hora_Entrega varchar(10),
	Encargado_Recibir varchar(50),
	Nombre_Repartidor varchar(50),
	Precio_Envio int,
	Total int
	primary key(Cliente_Numero)
)
SELECT * FROM PedidosClientes