using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class borrarDesastre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAdmin"] == null || Session["nombre"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginAdmin.aspx");
            }

            if (DropDownList1.Items.Count == 0)
            {
                String q = "select Desastre.cDesastre, Desastre.nombre from Desastre";
                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com = new OdbcCommand(q, con);

                OdbcDataReader leer = com.ExecuteReader();

                DropDownList1.DataSource = leer;
                DropDownList1.DataValueField = "cDesastre";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String q = "delete from Afecta where Afecta.cSiniestro in (select Siniestro.cSiniestro from (Desastre inner join Siniestro on Desastre.cDesastre=Siniestro.cSiniestro) where Desastre.cDesastre=?)\r\ndelete from Siniestro where Siniestro.cDesastre=?\r\ndelete from Desastre where Desastre.cDesastre=?";
            OdbcConnection con = new conexionBD().conexion;
            OdbcCommand com = new OdbcCommand(q, con);
            com.Parameters.AddWithValue("cDesastre1", DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("cDesastre2", DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("cDesastre3", DropDownList1.SelectedValue);

            try
            {
                com.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                return;
            }

            String qc = "select Desastre.cDesastre, Desastre.nombre from Desastre";
            OdbcConnection conc = new conexionBD().conexion;
            OdbcCommand comc = new OdbcCommand(qc, conc);

            OdbcDataReader leerc = comc.ExecuteReader();

            DropDownList1.DataSource = leerc;
            DropDownList1.DataValueField = "cDesastre";
            DropDownList1.DataTextField = "nombre";
            DropDownList1.DataBind();

            con.Close();
            conc.Close();

            Label1.Text = "Eliminación exitosa";
        }
    }
}