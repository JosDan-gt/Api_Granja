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
    public class ControlProduccionController : ApiController
    {
        //http://localhost:56138/api/ControlProduccion
        public IHttpActionResult Post(ControlProduccion controlProduccion)
        {
            try
            {
                ConexionControlProduccionSQL conEmp = new ConexionControlProduccionSQL();
                bool res = conEmp.InserPro(controlProduccion);
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

        public IHttpActionResult Put(ControlProduccion controlProduccion)
        {
            try
            {
                ConexionControlProduccionSQL conCli = new ConexionControlProduccionSQL();
                bool res = conCli.UpdatePro(controlProduccion);
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

        public ControlProduccion Get(int id)
        {
            return ConexionControlProduccionSQL.obtenerProd(id);
        }

        public List<ControlProduccion> GET()
        {
            return ConexionControlProduccionSQL.listar2();
        }
    }
}
