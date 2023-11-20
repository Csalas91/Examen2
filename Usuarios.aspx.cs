using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen2.Clases;
using System.Drawing;

namespace Examen2
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int resultado = Clases.Usuarios.Agregar(tnombre.Text, temail.Text, ttelefono.Text);
            if (resultado > 0)
            {
                alertas("Usuario ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                temail.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Usuario");

            }

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuarios.Borrar(int.Parse(tcodigo.Text));
            if (resultado > 0)
            {
                alertas("Usuario ha sido borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Codigo");

            }



        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string nombre = tnombre.Text;
            string email = temail.Text;
            string telefono = ttelefono.Text;

            int resultado = Clases.Usuarios.Modificar(codigo, nombre, email, telefono);
            if (resultado > 0)
            {
                alertas("Usuario ha sido actualizado con éxito");
                tcodigo.Text = string.Empty;
                tnombre.Text = string.Empty;
                temail.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar Usuario");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE ID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }

                }

            }

        }



    }

}
