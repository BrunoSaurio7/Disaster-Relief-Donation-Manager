using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class agregarInsumo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAdmin"] == null || Session["nombre"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginAdmin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            String inN, q1, q2;
            inN = TextBox1.Text;

            q1 = "select Insumo.Nombre from Insumo where Insumo.Nombre like '?'";
            OdbcConnection con1 = new conexionBD().conexion;
            OdbcCommand com1 = new OdbcCommand(q1, con1);
            com1.Parameters.AddWithValue("insumo", inN);

            OdbcDataReader leer1 = com1.ExecuteReader();
            leer1.Read();

            if (leer1.HasRows)
            {
                Label1.Text = "EL Insumo está repetido, agrega un nuevo insumo";
                con1.Close();
                return;
            }

            else
            {
                q2 = "insert into Insumo values (?)";
                OdbcConnection con2 = new conexionBD().conexion;
                OdbcCommand com2 = new OdbcCommand(q2, con2);
                com2.Parameters.AddWithValue("insumo", inN);

                try
                {
                    com2.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                    return;
                }

                Label1.Text = "Insumo agregado exitosamente";
                con2.Close();
            }
        }
    }
}