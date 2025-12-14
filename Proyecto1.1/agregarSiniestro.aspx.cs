using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class agregarSiniestro : System.Web.UI.Page
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
                String qc1 = "select Ciudad.cCiudad, Ciudad.nombre from Ciudad";
                OdbcConnection conc1 = new conexionBD().conexion;
                OdbcCommand comc1 = new OdbcCommand(qc1, conc1);
                OdbcDataReader leerc1 = comc1.ExecuteReader();

                DropDownList1.DataSource = leerc1;
                DropDownList1.DataValueField = "cCiudad";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                conc1.Close();
            }

            if (DropDownList2.Items.Count == 0)
            {
                String qc2 = "select Desastre.cDesastre, Desastre.nombre from Desastre";
                OdbcConnection conc2 = new conexionBD().conexion;
                OdbcCommand comc2 = new OdbcCommand(qc2, conc2);
                OdbcDataReader leerc2 = comc2.ExecuteReader();

                DropDownList2.DataSource = leerc2;
                DropDownList2.DataValueField = "cDesastre";
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataBind();

                conc2.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                String q = "insert into Siniestro values(?,?,?)";
                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com = new OdbcCommand(q, con);
                com.Parameters.AddWithValue("nombre",TextBox1.Text);
                com.Parameters.AddWithValue("cCiudad", DropDownList1.SelectedValue);
                com.Parameters.AddWithValue("cDesastre", DropDownList2.SelectedValue);

                try
                {
                    com.ExecuteNonQuery();
                }

                catch(Exception ex)
                {
                    Label1.Text = ex.Message;
                }

                Label1.Text = "Agregación exitosa";
                con.Close();
            }

            else
            {
                Label1.Text = "Ingresa un nombre válido";
            }
        }
    }
}