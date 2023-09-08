using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Granja.Models
{
    public class ControlProduccion
    {

        public int DiaControl_Numero { get; set; }
        public int Huevos_PorDia { get; set; }
        public int CantidadCartones_Pequeño { get; set; }
        public int CantidadCartones_Mediano { get; set; }
        public int CantidadCartones_Grande { get; set; }
        public int CantidadCartones_Jumbo { get; set; }
        public int Cantidad_Gallinas { get; set; }
        public int Cantidad_Cajas { get; set; }
        public int Cantidad_Perdida { get; set; }
        public string Fecha_Control { get; set; }
    }
}