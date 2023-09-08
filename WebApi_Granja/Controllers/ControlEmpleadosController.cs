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
    public class ControlEmpleadosController : ApiController
    {
        //http://localhost:56138/api/ControlEmpleados
        public IHttpActionResult Post(ControlEmpleados controlEmpleados )
        {
            try
            {
                ConexionControlEmpleadosSQL conEmp = new ConexionControlEmpleadosSQL();
                bool res = conEmp.InserEmp(controlEmpleados);
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

        public IHttpActionResult Put(ControlEmpleados controlEmpleados)
        {
            try
            {
                ConexionControlEmpleadosSQL conCli = new ConexionControlEmpleadosSQL();
                bool res = conCli.UpdateEmp(controlEmpleados);
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

        public IHttpActionResult Delete(ControlEmpleados controlEmpleados)
        {
            try
            {
                ConexionControlEmpleadosSQL conCli = new ConexionControlEmpleadosSQL();
                bool res = conCli.DeleteEmp(controlEmpleados);
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

        public ControlEmpleados Get(int id)
        {
            return ConexionControlEmpleadosSQL.obtenerEmp(id);
        }

        public List<ControlEmpleados> Get()
        {
            return ConexionControlEmpleadosSQL.Listar();
        }
    }
}
