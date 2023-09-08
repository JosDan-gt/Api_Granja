using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Granja.Models
{
    public class ControlEmpleados
    {
        public int Id_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido_Empleado { get; set; }
        public string Direccion_Empleado { get; set; }
        public string Puesto_Empleado { get; set; }
        public int Edad_Empleado { get; set; }
        public int Telefono_Empleado { get; set; }
        public double Salario_Empleado { get; set; }
        public string Solvencia_Salario { get; set; }


    }
}