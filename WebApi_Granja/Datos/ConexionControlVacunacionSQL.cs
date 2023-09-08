using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi_Granja.Models;

namespace WebApi_Granja.Datos
{
    public class ConexionControlVacunacionSQL
    {
        public bool InserVac(ControlVacunacion controlVacunacion)
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "insert into ControlVacunacion(Nombre_Vacuna, Cantidad_Vacunas, Tipo_Vacuna, Tiempo_Aplicacion, CostoPor_Vacuna, Fecha_Colocacion) values(@Nombre_Vacuna, @Cantidad_Vacunas, @Tipo_Vacuna, @Tiempo_Aplicacion, @CostoPor_Vacuna, @Fecha_Colocacion);";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre_Vacuna", controlVacunacion.Nombre_Vacuna);
                        cmd.Parameters.AddWithValue("@Cantidad_Vacunas", controlVacunacion.Cantidad_Vacunas);
                        cmd.Parameters.AddWithValue("@Tipo_Vacuna", controlVacunacion.Tipo_Vacuna);
                        cmd.Parameters.AddWithValue("@Tiempo_Aplicacion", controlVacunacion.Tiempo_Aplicacion);
                        cmd.Parameters.AddWithValue("@CostoPor_Vacuna", controlVacunacion.CostoPor_Vacuna);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", controlVacunacion.Fecha_Colocacion);

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
        public bool UpdateVac(ControlVacunacion controlVacunacion)
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "update ControlVacunacion SET Nombre_Vacuna=@Nombre_Vacuna, Cantidad_Vacunas=@Cantidad_Vacunas, Tipo_Vacuna=@Tipo_Vacuna, Tiempo_Aplicacion=@Tiempo_Aplicacion, CostoPor_Vacuna=@CostoPor_Vacuna WHERE DiaControl_Numero=@DiaControl_Numero;";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@DiaControl_Numero", controlVacunacion.DiaControl_Numero);
                        cmd.Parameters.AddWithValue("@Nombre_Vacuna", controlVacunacion.Nombre_Vacuna);
                        cmd.Parameters.AddWithValue("@Cantidad_Vacunas", controlVacunacion.Cantidad_Vacunas);
                        cmd.Parameters.AddWithValue("@Tipo_Vacuna", controlVacunacion.Tipo_Vacuna);
                        cmd.Parameters.AddWithValue("@Tiempo_Aplicacion", controlVacunacion.Tiempo_Aplicacion);
                        cmd.Parameters.AddWithValue("@CostoPor_Vacuna", controlVacunacion.CostoPor_Vacuna);
                        cmd.Parameters.AddWithValue("@Fecha_Colocacion", controlVacunacion.Fecha_Colocacion);

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
        public static ControlVacunacion obtenerVac(int DiaControl_Numero)
        {
            ControlVacunacion ocontrol = new ControlVacunacion();

            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "select * from ControlVacunacion where DiaControl_Numero = @DiaControl_Numero";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@DiaControl_Numero", DiaControl_Numero);
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ocontrol = new ControlVacunacion()
                                {
                                    DiaControl_Numero = Convert.ToInt32(dr["DiaControl_Numero"]),
                                    Nombre_Vacuna = dr["Nombre_Vacuna"].ToString(),
                                    Cantidad_Vacunas = Convert.ToInt32(dr["Cantidad_Vacunas"]),
                                    Tipo_Vacuna = dr["Tipo_Vacuna"].ToString(),
                                    Tiempo_Aplicacion = dr["Tiempo_Aplicacion"].ToString(),
                                    CostoPor_Vacuna = Convert.ToInt32(dr["CostoPor_Vacuna"]),
                                    Fecha_Colocacion = dr["Fecha_Colocacion"].ToString(),
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