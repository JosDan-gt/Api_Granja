using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Granja.Datos;
using WebApi_Granja.Models;

namespace WebApi_Granja.Controllers
{
    public class ControlVacunacionController : ApiController
    {
        //http://localhost:56138/api/ControlVacunacion
        public IHttpActionResult Post(ControlVacunacion controlVacunacion)
        {
            try
            {
                ConexionControlVacunacionSQL conEmp = new ConexionControlVacunacionSQL();
                bool res = conEmp.InserVac(controlVacunacion);
                if (res)
                    return Content(HttpStatusCode.OK, "Guardado Correctamente");
                else
                    return Content(HttpStatusCode.BadRequest, "Ocurrio un error");
            }
            catch (Exception exmsg)
            {
                return Content(HttpStatusCode.InternalServerError, "Error interno en el servidor:" + exmsg.Message);
            }
        }
        public IHttpActionResult Put(ControlVacunacion controlVacunacion)
        {
            try
            {
                ConexionControlVacunacionSQL conCli = new ConexionControlVacunacionSQL();
                bool res = conCli.UpdateVac(controlVacunacion);
                if (res)
                    return Content(HttpStatusCode.OK, "Modificado Correctamente");
                else
                    return Content(HttpStatusCode.BadRequest, "Ocurrio un error");
            }
            catch (Exception exmsg)
            {

                return Content(HttpStatusCode.InternalServerError, "Error interno en el servidor:" + exmsg.Message);
            }
        }
        public ControlVacunacion Get(int id)
        {
            return ConexionControlVacunacionSQL.obtenerVac(id);
        }
    }
}