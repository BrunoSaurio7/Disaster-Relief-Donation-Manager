using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class loginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String correo, contra;

            correo = TextBox1.Text;
            contra = TextBox2.Text;

            String q = "select Administrador.cAdmin,Administrador.Nombre from Administrador where Correo=? and Contraseña=?";
            OdbcConnection con = new conexionBD().conexion;
            OdbcCommand com = new OdbcCommand(q, con);

            com.Parameters.AddWithValue("correo", correo);
            com.Parameters.AddWithValue("contraseña",contra);

            OdbcDataReader leer = com.ExecuteReader();

            leer.Read();
            if (leer.HasRows)
            {
                Session.Timeout = 100;
                Session["cAdmin"] = leer.GetString(0);
                Session["nombre"] = leer.GetString(1);

                Response.Redirect("menuAdmin.aspx");
            }

            else
            {
                Label1.Text = "Error al iniciar sesión (comprueba tus datos)";
            }
        }
    }
}