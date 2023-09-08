using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi_Granja.Models;

namespace WebApi_Granja.Datos
{
    public class ConexionPedidosClientesSQL
    {
        public bool InserPed(PedidosClientes pedidosClientes)
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "insert into PedidosClientes(Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono_Cliente, Tipo_Carton, Cantidad_Cartones, Fecha_Entrega, Encargado_Recibir, Nombre_Repartidor) values(@Nombre_Cliente, @Apellido_Cliente, @Direccion_Cliente, @Telefono_Cliente, @Tipo_Carton, @Cantidad_Cartones, @Fecha_Entrega, @Encargado_Recibir, @Nombre_Repartidor);";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre_Cliente", pedidosClientes.Nombre_Cliente);
                        cmd.Parameters.AddWithValue("@Apellido_Cliente", pedidosClientes.Apellido_Cliente);
                        cmd.Parameters.AddWithValue("@Direccion_Cliente", pedidosClientes.Direccion_Cliente);
                        cmd.Parameters.AddWithValue("@Telefono_Cliente", pedidosClientes.Telefono_Cliente);
                        cmd.Parameters.AddWithValue("@Tipo_Carton", pedidosClientes.Tipo_Carton);
                        cmd.Parameters.AddWithValue("@Cantidad_Cartones", pedidosClientes.Cantidad_Cartones);
                        cmd.Parameters.AddWithValue("@Fecha_Entrega", pedidosClientes.Fecha_Entrega);
                        cmd.Parameters.AddWithValue("@Encargado_Recibir", pedidosClientes.Encargado_Recibir);
                        cmd.Parameters.AddWithValue("@Nombre_Repartidor", pedidosClientes.Nombre_Repartidor);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool UpdatePed(PedidosClientes pedidosClientes)
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "update PedidosClientes SET Nombre_Cliente=@Nombre_Cliente, Apellido_Cliente=@Apellido_Cliente, Direccion_Cliente=@Direccion_Cliente, Telefono_Cliente=@Telefono_Cliente, Tipo_Carton=@Tipo_Carton, Cantidad_Cartones=@Cantidad_Cartones, Encargado_Recibir=@Encargado_Recibir, Nombre_Repartidor, WHERE Cliente_Numero=@Cliente_Numero;";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@DiaControl_Numero", pedidosClientes.Cliente_Numero);
                        cmd.Parameters.AddWithValue("@Nombre_Vacuna", pedidosClientes.Nombre_Cliente);
                        cmd.Parameters.AddWithValue("@Cantidad_Vacunas", pedidosClientes.Apellido_Cliente);
                        cmd.Parameters.AddWithValue("@Tipo_Vacuna", pedidosClientes.Direccion_Cliente);
                        cmd.Parameters.AddWithValue("@Tiempo_Aplicacion", pedidosClientes.Telefono_Cliente);
                        cmd.Parameters.AddWithValue("@CostoPor_Vacuna", pedidosClientes.Tipo_Carton);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", pedidosClientes.Cantidad_Cartones);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", pedidosClientes.Fecha_Entrega);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", pedidosClientes.Encargado_Recibir);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", pedidosClientes.Nombre_Repartidor);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static PedidosClientes obtenerPed(int Cliente_Numero)
        {
            PedidosClientes ocontrol = new PedidosClientes();

            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "select * from PedidosClientes where Cliente_Numero = @Cliente_Numero";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Cliente_Numero", Cliente_Numero);
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ocontrol = new PedidosClientes()
                                {
                                    Cliente_Numero = Convert.ToInt32(dr["Cliente_Numero"]),
                                    Nombre_Cliente = dr["Nombre_Cliente"].ToString(),
                                    Apellido_Cliente = dr["Apellido_Cliente"].ToString(),
                                    Direccion_Cliente = dr["Direccion_Cliente"].ToString(),
                                    Telefono_Cliente = dr["Telefono_Cliente"].ToString(),
                                    Tipo_Carton = Convert.ToInt32(dr["Tipo_Carton"]),
                                    Cantidad_Cartones = Convert.ToInt32(dr["Cantidad_Cartones"]),
                                    Fecha_Entrega = Convert.ToDateTime(dr["Fecha_Entrega"]),
                                    Encargado_Recibir = dr["Encargado_Recibir"].ToString(),
                                    Nombre_Repartidor = dr["Nombre_Repartidor"].ToString(),
                                    Total = Convert.ToInt32(dr["Total"]),
                                };
                            }
                        }
                    }
                }
                return ocontrol;
            }
            catch (Exception ex)
            {

                return ocontrol;
            }
        }

    }
}
 