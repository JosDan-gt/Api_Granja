using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi_Granja.Models;

namespace WebApi_Granja.Datos
{
    public class ConexionControlProduccionSQL
    {

        public bool InserPro(ControlProduccion controlProduccion )
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "insert into ControlProduccion(Huevos_PorDia, CantidadCartones_Pequeño, CantidadCartones_Mediano, CantidadCartones_Grande, CantidadCartones_Jumbo, Cantidad_Gallinas, Cantidad_Cajas, Cantidad_Perdida, Fecha_Control) values(@Huevos_PorDia, @CantidadCartones_Pequeño, @CantidadCartones_Mediano, @CantidadCartones_Grande, @CantidadCartones_Jumbo, @Cantidad_Gallinas, @Cantidad_Cajas, @Cantidad_Perdida, @Fecha_Control);";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Huevos_PorDia", controlProduccion.Huevos_PorDia);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Pequeño", controlProduccion.CantidadCartones_Pequeño);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Mediano", controlProduccion.CantidadCartones_Mediano);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Grande", controlProduccion.CantidadCartones_Grande);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Jumbo", controlProduccion.CantidadCartones_Jumbo);
                        cmd.Parameters.AddWithValue("@Cantidad_Gallinas", controlProduccion.Cantidad_Gallinas);
                        cmd.Parameters.AddWithValue("@Cantidad_Cajas", controlProduccion.Cantidad_Cajas);
                        cmd.Parameters.AddWithValue("@Cantidad_Perdida", controlProduccion.Cantidad_Perdida);
                        cmd.Parameters.AddWithValue("@Fecha_Control", controlProduccion.Fecha_Control);

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

        public bool UpdatePro(ControlProduccion controlProduccion)
        {
            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "update ControlProduccion SET Huevos_PorDia=@Huevos_PorDia, CantidadCartones_Pequeño=@CantidadCartones_Pequeño, CantidadCartones_Mediano=@CantidadCartones_Mediano, CantidadCartones_Grande=@CantidadCartones_Grande, CantidadCartones_Jumbo=@CantidadCartones_Jumbo, Cantidad_Gallinas=@Cantidad_Gallinas, Cantidad_Cajas=@Cantidad_Cajas, Cantidad_Perdida=@Cantidad_Perdida WHERE DiaControl_Numero=@DiaControl_Numero;";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@DiaControl_Numero", controlProduccion.DiaControl_Numero);
                        cmd.Parameters.AddWithValue("@Huevos_PorDia", controlProduccion.Huevos_PorDia);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Pequeño", controlProduccion.CantidadCartones_Pequeño);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Mediano", controlProduccion.CantidadCartones_Mediano);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Grande", controlProduccion.CantidadCartones_Grande);
                        cmd.Parameters.AddWithValue("@CantidadCartones_Jumbo", controlProduccion.CantidadCartones_Jumbo);
                        cmd.Parameters.AddWithValue("@Cantidad_Gallinas", controlProduccion.Cantidad_Gallinas);
                        cmd.Parameters.AddWithValue("@Cantidad_Cajas", controlProduccion.Cantidad_Cajas);
                        cmd.Parameters.AddWithValue("@Cantidad_Perdida", controlProduccion.Cantidad_Perdida);
                        cmd.Parameters.AddWithValue("@Fecha_Control", controlProduccion.Fecha_Control);

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

        public static ControlProduccion obtenerProd(int DiaControl_Numero)
        {
            ControlProduccion ocontrolPro = new ControlProduccion();

            string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "select * from controlProduccion where DiaControl_Numero = @DiaControl_Numero";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@DiaControl_Numero", DiaControl_Numero);
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ocontrolPro = new ControlProduccion()
                                {
                                    DiaControl_Numero = Convert.ToInt32(dr["DiaControl_Numero"]),
                                    Fecha_Control = dr["Fecha_Control"].ToString(),
                                    Cantidad_Cajas = Convert.ToInt32(dr["Cantidad_Cajas"]),
                                    Huevos_PorDia = Convert.ToInt32(dr["Huevos_PorDia"]),
                                    Cantidad_Perdida = Convert.ToInt32(dr["Cantidad_Perdida"]),
                                    Cantidad_Gallinas = Convert.ToInt32(dr["Cantidad_Gallinas"]),
                                    CantidadCartones_Pequeño = Convert.ToInt32(dr["CantidadCartones_Pequeño"]),
                                    CantidadCartones_Mediano = Convert.ToInt32(dr["CantidadCartones_Mediano"]),
                                    CantidadCartones_Grande = Convert.ToInt32(dr["CantidadCartones_Grande"]),
                                    CantidadCartones_Jumbo = Convert.ToInt32(dr["CantidadCartones_Jumbo"]),
                                };
                            }
                        }
                    }
                }
                return ocontrolPro;
            }
            catch (Exception ex)
            {

                return ocontrolPro;
            }
        }
    }

}