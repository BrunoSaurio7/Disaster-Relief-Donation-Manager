using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class borrarInsumo : System.Web.UI.Page
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
                String q = "select Insumo.cInsumo, Insumo.nombre from Insumo";
                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com = new OdbcCommand(q, con);

                OdbcDataReader leer = com.ExecuteReader();

                DropDownList1.DataSource = leer;
                DropDownList1.DataValueField = "cInsumo";
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
            String q = "delete from Insumo where cInsumo=?\r\ndelete from TieneCentroAcopio where cInsumo=?\r\ndelete from TieneDonacion where cInsumo=?";
            OdbcConnection con = new conexionBD().conexion;
            OdbcCommand com = new OdbcCommand(q, con);
            com.Parameters.AddWithValue("cInsumo1", DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("cInsumo2", DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("cInsumo3", DropDownList1.SelectedValue);

            try
            {
                com.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                return;
            }

            String qc = "select Insumo.cInsumo, Insumo.nombre from Insumo";
            OdbcConnection conc = new conexionBD().conexion;
            OdbcCommand comc = new OdbcCommand(qc, conc);

            OdbcDataReader leer = comc.ExecuteReader();

            DropDownList1.DataSource = leer;
            DropDownList1.DataValueField = "cInsumo";
            DropDownList1.DataTextField = "nombre";
            DropDownList1.DataBind();

            con.Close();
            conc.Close();

            Label1.Text = "Eliminación exitosa";
        }
    }
}