using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Examen2
{
    public partial class Equipo1 : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipo"))
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
            int resultado = Clases.Equipo.Agregar(int.Parse(tId.Text),tequipo.Text,tmodelo.Text);
            if (resultado > 0)
            {
                alertas("Equipo ha sido ingresado con exito");
                tId.Text = string.Empty;
                tequipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Equipo");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Equipo.Borrar(int.Parse(tId.Text));
            if (resultado > 0)
            {
                alertas("Equipo ha sido borrado con exito");
                tId.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Equipo");

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(tcodigo.Text);
            int ID_Usuario = int.Parse(tId.Text);
            string tipoEquipo = tequipo.Text;
            string modelo = tmodelo.Text;

            int resultado = Clases.Equipo.Modificar(Id, ID_Usuario, tipoEquipo, modelo);
            if (resultado > 0)
            {
                alertas("Equipo ha sido actualizado con éxito");
                tcodigo.Text = string.Empty;
                tId.Text = string.Empty;
                tequipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar Equipo");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipo WHERE Codigo_Equipo ='" + codigo + "'"))


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