using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Granja.Models
{
    public class ControlVacunacion
    {
        public int DiaControl_Numero { get; set; }
        public string Nombre_Vacuna { get; set; }
        public int Cantidad_Vacunas { get; set; }
        public string Tipo_Vacuna { get; set; }
        public string Tiempo_Aplicacion { get; set; }
        public int CostoPor_Vacuna { get; set; }
        public string Fecha_Colocacion { get; set; }
    }
}