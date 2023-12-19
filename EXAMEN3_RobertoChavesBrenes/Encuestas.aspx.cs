using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXAMEN3_RobertoChavesBrenes
{
    public partial class Encuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarPartidos();
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
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Encuestas"))
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


        protected void LlenarPartidos()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT PartidoID, Nombre FROM PartidosPoliticos", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Crear un nuevo DataTable para agregar el elemento "Clic" al inicio
                            DataTable dtModified = new DataTable();
                            dtModified.Columns.Add("PartidoID");
                            dtModified.Columns.Add("Nombre");

                            // Agregar el elemento "Clic" manualmente al inicio del nuevo DataTable
                            dtModified.Rows.Add("", "Clic ");

                            // Copiar los datos de la consulta SQL al nuevo DataTable
                            foreach (DataRow row in dt.Rows)
                            {
                                dtModified.ImportRow(row);
                            }

                            // Enlazar el DropDownList con el nuevo DataTable modificado
                            DropPartido.DataSource = dtModified;
                            DropPartido.DataTextField = "Nombre";
                            DropPartido.DataValueField = "PartidoID";
                            DropPartido.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones si ocurre algún error al poblar el DropDownList
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Class.Encuestas.AgregarEncuesta(tnombre.Text, tedad.Text, tcorreo.Text, int.Parse(DropPartido.Text));

            if (resultado > 0)
            {
                alertas("Encuesta ha sido agregada con exito");
                tnombre.Text = string.Empty;
                tedad.Text = string.Empty;
                tcorreo.Text = string.Empty;
                DropPartido.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar encuesta");

            }
        }

        
    }
}