using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class agregarCentro : System.Web.UI.Page
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
                String qc = "Select Ciudad.cCiudad, Ciudad.nombre from Ciudad";
                OdbcConnection conc = new conexionBD().conexion;
                OdbcCommand comc = new OdbcCommand(qc, conc);
                OdbcDataReader leerc = comc.ExecuteReader();

                DropDownList1.DataSource = leerc;
                DropDownList1.DataValueField = "cCiudad";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                conc.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text!="" && TextBox2.Text!="")
            {
                String q = "insert into CentroAcopio values(?,?,?)";
                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com = new OdbcCommand(q, con);
                com.Parameters.AddWithValue("nombre", TextBox1.Text);
                com.Parameters.AddWithValue("direccion", TextBox2.Text);
                com.Parameters.AddWithValue("cCiudad", DropDownList1.SelectedValue);

                try
                {
                    com.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }

                Label1.Text = "Agregación exitosa";
                con.Close();
            }

            else
            {
                Label1.Text = "Algún campo está vacío";
            }
        }
    }
}