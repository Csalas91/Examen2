﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
    public class login
    {
        private static string correo;
        private static string clave;
        private static string nombre;

        // constructor -- inicializar los atributos 
        public login(string Correo, string Clave, string Nombre)
        {
            correo = Correo;
            clave = Clave;
            nombre = Nombre;
        }

        public login(string Correo, string Clave)
        {
            correo = Correo;
            clave = Clave;

        }
        public login()
        {

        }

        // Getter = funcion (return) mostrar los valores de atributos
        // setter =  metodo (void) asignar valores a los atributos

        public static string Getcorreo()
        {
            return correo;
        }

        public static string Getnombre()
        {
            return nombre;
        }
        public static string Getclave()
        {
            return clave;
        }

        public void Setcorreo(string email)
        {
            correo = email;
        }

        public void Setclave(string contrasena)
        {
            clave = contrasena;
        }


        public static int validarUsuario()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("validarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));

                    retorno = cmd.ExecuteNonQuery();
                    // reader = lector = lectura = rdr
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            nombre = lectura[2].ToString();
                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

    }
}