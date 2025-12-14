using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class borrarSiniestro : System.Web.UI.Page
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
                String qc = "select Siniestro.cSiniestro, Siniestro.nombre from Siniestro";
                OdbcConnection conc = new conexionBD().conexion;
                OdbcCommand comc = new OdbcCommand(qc, conc);
                OdbcDataReader leerc = comc.ExecuteReader();

                DropDownList1.DataSource = leerc;
                DropDownList1.DataValueField = "cSiniestro";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String q = "delete from Afecta where cSiniestro=?\r\ndelete from Siniestro where cSiniestro=?";
            OdbcConnection con = new conexionBD().conexion;
            OdbcCommand com = new OdbcCommand(q, con);
            com.Parameters.AddWithValue("cSiniestro1",DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("cSiniestro2", DropDownList1.SelectedValue);

            try
            {
                com.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Label1.Text=ex.Message;
            }

            String qc = "select Siniestro.cSiniestro, Siniestro.nombre from Siniestro";
            OdbcConnection conc = new conexionBD().conexion;
            OdbcCommand comc = new OdbcCommand(qc, conc);
            OdbcDataReader leerc = comc.ExecuteReader();

            DropDownList1.DataSource = leerc;
            DropDownList1.DataValueField = "cSiniestro";
            DropDownList1.DataTextField = "nombre";
            DropDownList1.DataBind();

            Label1.Text = "Eliminación exitosa";

            con.Close();
            conc.Close();
        }
    }
}