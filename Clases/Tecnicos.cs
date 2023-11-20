using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
    public class Tecnicos
    {
        public static int ID { get; set; }
        public static String Nombre { get; set; }

        public static String Especialidad { get; set; }

        public Tecnicos(int iD, string nombre, string especialidad)
        {
            Nombre = nombre;
            ID = iD;
            Especialidad = especialidad;
        }
        public Tecnicos(string nombre)
        {
            Nombre = nombre;
        }
        public Tecnicos()
        {

        }
        public static int Agregar(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));
                    

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
                    SqlCommand cmd = new SqlCommand("BorrarTecnico", Conn)
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
        public static int Modificar(int iD, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo", iD));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", especialidad));

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

        public static List<Usuarios> consultaFiltro(int ID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTRO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", ID));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios usuarios1 = new Usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  // instancia
                            usuarios.Add(usuarios1);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
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