using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Granja.Models
{
    public class PedidosClientes
    {
        public int Cliente_Numero { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellido_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Telefono_Cliente { get; set; }
        public int Tipo_Carton { get; set; }
        public int Cantidad_Cartones { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Encargado_Recibir { get; set; }
        public string Nombre_Repartidor { get; set; }
        public int Total { get; set; }
    }
}