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
    public class PedidosClientesController : ApiController
    {
        //http://localhost:56138/api/PedidosClientes
        public IHttpActionResult Post(PedidosClientes pedidosClientes)
        {
            try
            {
                ConexionPedidosClientesSQL conEmp = new ConexionPedidosClientesSQL();
                bool res = conEmp.InserPed(pedidosClientes);
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
        public IHttpActionResult Put(PedidosClientes pedidosClientes)
        {
            try
            {
                ConexionPedidosClientesSQL conCli = new ConexionPedidosClientesSQL();
                bool res = conCli.UpdatePed(pedidosClientes);
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
        public PedidosClientes Get(int id)
        {
            return ConexionPedidosClientesSQL.obtenerPed(id);
        }

    }
}