using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Deployment.Internal;

namespace Examen2.Clases
{
   
        public class Equipo
        {
            public static int ID { get; set; }
           
            public static int ID_Usuario { get; set; }

            public static String TipoEquipo { get; set; }

            public static String Modelo { get; set; }

            public Equipo (int iD,int Id , string tipoequipo, string modelo)
            {
            ID_Usuario = iD;
            ID = Id;
            TipoEquipo = tipoequipo;
                Modelo = modelo;
            }
           
            public Equipo(int iD)
            {  
            ID_Usuario=iD; 
            }   
            public Equipo()
            {

            }



            public static int Agregar(int iD, string tipoequipo , string modelo)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("AgregarEquipo", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                    cmd.Parameters.Add(new SqlParameter("@ID_Usuario", iD));
                    cmd.Parameters.Add(new SqlParameter("@tipo_Equipo", tipoequipo));
                        cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));

                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }

                return retorno;

            }
            public static int Borrar(int ID)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("BorrarEquipo", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", ID));


                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    Conn.Close();
                }

                return retorno;

            }

            public static int Modificar(int Id,int ID_Usuario, string tipoEquipo, string modelo)
            {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarEquipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo", Id));
                    cmd.Parameters.Add(new SqlParameter("@ID_Usuario", ID_Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Tipo_Equipo", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public void consultaFiltro()
        {


        }

            public static List<Usuarios> ObtenerUsuarios()
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                List<Usuarios> USUARIOS = new List<Usuarios>();
                try
                {

                    using (Conn = DBConn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("consultar", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        retorno = cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuarios Usuarios = new Usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  // instancia
                                USUARIOS.Add(Usuarios);

                            }

                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return USUARIOS;
                }
                finally
                {
                    Conn.Close();
                    Conn.Dispose();
                }

                return USUARIOS;
            }



        }


    
}