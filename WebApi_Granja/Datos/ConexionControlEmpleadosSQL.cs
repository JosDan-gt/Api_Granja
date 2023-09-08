using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi_Granja.Models;

namespace WebApi_Granja.Datos
{
    public class ConexionControlEmpleadosSQL
    {

        public bool InserEmp(ControlEmpleados controlEmpleados)
        {
            //string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";
            string conString = "Data Source=DESKTOP-HGGBRC3; Initial Catalog=GRANJA; User Id = sa; Password = Tebalan02";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "insert into ControlEmpleados(Nombre_Empleado, Apellido_Empleado, Direccion_Empleado, Puesto_Empleado, Edad_Empleado, Telefono_Empleado, Salario_Empleado, Solvencia_Salario) values(@Nombre_Empleado, @Apellido_Empleado, @Direccion_Empleado, @Puesto_Empleado, @Edad_Empleado, @Telefono_Empleado, @Salario_Empleado, @Solvencia_Salario);";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre_Empleado", controlEmpleados.Nombre_Empleado);
                        cmd.Parameters.AddWithValue("@Apellido_Empleado", controlEmpleados.Apellido_Empleado);
                        cmd.Parameters.AddWithValue("@Direccion_Empleado", controlEmpleados.Direccion_Empleado);
                        cmd.Parameters.AddWithValue("@Puesto_Empleado", controlEmpleados.Puesto_Empleado);
                        cmd.Parameters.AddWithValue("@Edad_Empleado", controlEmpleados.Edad_Empleado);
                        cmd.Parameters.AddWithValue("@Telefono_Empleado", controlEmpleados.Telefono_Empleado);
                        cmd.Parameters.AddWithValue("@Salario_Empleado", controlEmpleados.Salario_Empleado);
                        cmd.Parameters.AddWithValue("@Solvencia_Salario", controlEmpleados.Solvencia_Salario);

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

        public bool UpdateEmp(ControlEmpleados controlEmpleados)
        {
            //string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";
            string conString = "Data Source=DESKTOP-HGGBRC3; Initial Catalog=GRANJA; User Id = sa; Password = Tebalan02";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "update ControlEmpleados SET Nombre_Empleado=@Nombre_Empleado, Apellido_Empleado=@Apellido_Empleado, Direccion_Empleado=@Direccion_Empleado, Puesto_Empleado=@Puesto_Empleado, Edad_Empleado=@Edad_Empleado, Telefono_Empleado=@Telefono_Empleado, Salario_Empleado=@Salario_Empleado, Solvencia_Salario=@Solvencia_Salario WHERE Id_Empleado=@Id_Empleado;";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Empleado", controlEmpleados.Id_Empleado);
                        cmd.Parameters.AddWithValue("@Nombre_Empleado", controlEmpleados.Nombre_Empleado);
                        cmd.Parameters.AddWithValue("@Apellido_Empleado", controlEmpleados.Apellido_Empleado);
                        cmd.Parameters.AddWithValue("@Direccion_Empleado", controlEmpleados.Direccion_Empleado);
                        cmd.Parameters.AddWithValue("@Puesto_Empleado", controlEmpleados.Puesto_Empleado);
                        cmd.Parameters.AddWithValue("@Edad_Empleado", controlEmpleados.Edad_Empleado);
                        cmd.Parameters.AddWithValue("@Telefono_Empleado", controlEmpleados.Telefono_Empleado);
                        cmd.Parameters.AddWithValue("@Salario_Empleado", controlEmpleados.Salario_Empleado);
                        cmd.Parameters.AddWithValue("@Solvencia_Salario", controlEmpleados.Solvencia_Salario);

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

        public bool DeleteEmp(ControlEmpleados controlEmpleados)
        {
            //string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";
            string conString = "Data Source=DESKTOP-HGGBRC3; Initial Catalog=GRANJA; User Id = sa; Password = Tebalan02";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "update ControlEmpleados set Solvencia_Salario = @Solvencia_Salario where Id_Empleado = @Id_Empleado;";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Empleado", controlEmpleados.Id_Empleado);
                        cmd.Parameters.AddWithValue("@Solvencia_Salario", controlEmpleados.Solvencia_Salario);

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

        public static ControlEmpleados obtenerEmp(int Id_Empleado)
        {
            ControlEmpleados ocontrol = new ControlEmpleados();

            //string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";
            string conString = "Data Source=DESKTOP-HGGBRC3; Initial Catalog=GRANJA; User Id = sa; Password = Tebalan02";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "select * from ControlEmpleados where Id_Empleado = @Id_Empleado";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Empleado", Id_Empleado);
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ocontrol = new ControlEmpleados()
                                {
                                    Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]),
                                    Nombre_Empleado = dr["Nombre_Empleado"].ToString(),
                                    Apellido_Empleado = dr["Apellido_Empleado"].ToString(),
                                    Direccion_Empleado = dr["Direccion_Empleado"].ToString(),
                                    Puesto_Empleado = dr["Puesto_Empleado"].ToString(),
                                    Edad_Empleado = Convert.ToInt32(dr["Edad_Empleado"]),
                                    Telefono_Empleado = Convert.ToInt32(dr["Telefono_Empleado"]),
                                    Salario_Empleado = Convert.ToDouble(dr["Salario_Empleado"]),
                                    Solvencia_Salario = dr["Solvencia_Salario"].ToString(),
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

        public static List<ControlEmpleados> Listar()
        {
            List<ControlEmpleados> oListaRegistro = new List<ControlEmpleados>();

            //string conString = "Data Source=LAPTOP-ECOQDBI2; Initial Catalog=GranjaLosAres; Integrated Security=True;";
            string conString = "Data Source=DESKTOP-HGGBRC3; Initial Catalog=GRANJA; User Id = sa; Password = Tebalan02";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string Comando = "SELECT * From ControlEmpleados WHERE Solvencia_Salario = 1";

                    using (SqlCommand cmd = new SqlCommand(Comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        //if (con.State==ConnectionState.Open)

                          // con.Close();

                        //cmd.ExecuteNonQuery();


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oListaRegistro.Add(new ControlEmpleados()
                                {
                                    Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]),
                                    Nombre_Empleado = dr["Nombre_Empleado"].ToString(),
                                    Apellido_Empleado = dr["Apellido_Empleado"].ToString(),
                                    Direccion_Empleado = dr["Direccion_Empleado"].ToString(),
                                    Puesto_Empleado = dr["Puesto_Empleado"].ToString(),
                                    Edad_Empleado = Convert.ToInt32(dr["Edad_Empleado"]),
                                    Telefono_Empleado = Convert.ToInt32(dr["Telefono_Empleado"]),
                                    Salario_Empleado = Convert.ToDouble(dr["Salario_Empleado"]),
                                    Solvencia_Salario = dr["Solvencia_Salario"].ToString(),
                                });
                            }
                        }
                    }
                }
                return oListaRegistro;
            }
            catch (Exception ex)
            {
                return oListaRegistro;
            }
        }

    }
}