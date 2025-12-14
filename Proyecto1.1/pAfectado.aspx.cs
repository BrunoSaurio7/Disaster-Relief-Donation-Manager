using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace Proyecto1._1
{
    public partial class pAfectado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String queryCat1, queryCat2;

            queryCat1 = "select cEstado,nombre from Estado";
            OdbcConnection con1 = new conexionBD().conexion;
            OdbcCommand com1 = new OdbcCommand(queryCat1,con1);
            OdbcDataReader leer1 = com1.ExecuteReader();

            if (DropDownList2.Items.Count == 0)
            {
                DropDownList2.DataSource = leer1;
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataValueField = "cEstado";
                DropDownList2.DataBind();
            }

            OdbcConnection con2 = new conexionBD().conexion;
            queryCat2 = "select cCiudad,nombre from Ciudad";
            OdbcCommand com2 = new OdbcCommand(queryCat2,con2);
            OdbcDataReader leer2 = com2.ExecuteReader();

            if (DropDownList3.Items.Count == 0)
            {

                DropDownList3.DataSource = leer2;
                DropDownList3.DataTextField = "nombre";
                DropDownList3.DataValueField = "cCiudad";
                DropDownList3.DataBind();
            }

            con1.Close();
            con2.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("p1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text != "" && TextBox2.Text != "")
            {

                String q1, q2;

                q1 = "select Persona.cPersona from Persona where Correo=? and cCiudad=? and Nombre=?";
                q2 = "insert into Persona values(?,?,?)";

                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com1 = (new OdbcCommand(q1, con));
                com1.Parameters.AddWithValue("correo", TextBox1.Text.ToString());
                com1.Parameters.AddWithValue("cCiudad", DropDownList3.SelectedValue.ToString());
                com1.Parameters.AddWithValue("nombre", TextBox2.Text.ToString());

                OdbcDataReader leer1 = com1.ExecuteReader();

                leer1.Read();

                if (!leer1.HasRows)
                {
                    OdbcCommand com2 = new OdbcCommand(q2, con);
                    com2.Parameters.AddWithValue("nombre", TextBox2.Text.ToString());
                    com2.Parameters.AddWithValue("cCiudad", DropDownList3.SelectedValue.ToString());
                    com2.Parameters.AddWithValue("correo", TextBox1.Text.ToString());

                    try
                    {
                        com2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                }

                Session.Timeout = 20;

                Session["nombre"] = TextBox2.Text.ToString();
                Session["correo"] = TextBox1.Text.ToString();
                Session["cCiudad"] = DropDownList3.SelectedValue.ToString();

                Response.Redirect("pAfectado1.aspx");
            }

            else
            {
                Label1.Text = "Hay algún campo vacío";
            }
        }
    }
}