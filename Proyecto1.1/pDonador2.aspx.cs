using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class pDonador2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null || Session["correo"] == null || Session["cCiudad"] == null)
            {
                Response.Redirect("pDonador1.aspx");
            }

            Label1.Text = Session["nombre"].ToString();

            String queryCat1, queryCat2;

            queryCat1 = "select cInsumo,nombre from Insumo";
            OdbcConnection con1 = new conexionBD().conexion;
            OdbcCommand com1 = new OdbcCommand(queryCat1, con1);
            OdbcDataReader leer1 = com1.ExecuteReader();

            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.DataSource = leer1;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "cInsumo";
                DropDownList1.DataBind();
            }

            queryCat2 = "select cCentro,nombre from CentroAcopio";
            OdbcConnection con2 = new conexionBD().conexion;
            OdbcCommand com2 = new OdbcCommand(queryCat2, con2);
            OdbcDataReader leer2 = com2.ExecuteReader();

            if (DropDownList2.Items.Count == 0)
            {
                DropDownList2.DataSource = leer2;
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataValueField = "cCentro";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("pDonador1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text != "" && TextBox2.Text != "" && int.Parse(TextBox1.Text)>0)
            {

                String cInsumo, cCentro, cPersona, q1, q2, q3, q4, q5, q6, q7;
                DateTime fecha;
                int cantidad;

                cInsumo = DropDownList1.SelectedValue;
                cCentro = DropDownList2.SelectedValue;
                cantidad = int.Parse(TextBox1.Text);
                fecha = DateTime.Parse(TextBox2.Text);

                q1 = "select Persona.cPersona from Persona where Persona.Nombre=? and Persona.Correo=? and Persona.cCiudad=?";
                OdbcConnection con1 = new conexionBD().conexion;
                OdbcCommand com1 = new OdbcCommand(q1, con1);

                com1.Parameters.AddWithValue("nombre", Session["nombre"].ToString());
                com1.Parameters.AddWithValue("correo", Session["correo"].ToString());
                com1.Parameters.AddWithValue("cCiudad", Session["cCiudad"].ToString());

                OdbcDataReader leer = com1.ExecuteReader();

                leer.Read();

                if (leer.HasRows)
                {
                    cPersona = leer.GetString(0);
                }

                else
                {
                    Label2.Text = "error de busqueda de persona";
                    return;
                }

                q2 = "insert into Donacion values(?,?)";
                OdbcConnection con2 = new conexionBD().conexion;
                OdbcCommand com2 = new OdbcCommand(q2, con2);

                com2.Parameters.AddWithValue("fecha", fecha);
                com2.Parameters.AddWithValue("cPersona", cPersona);

                try
                {
                    com2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label2.Text += ex.Message;
                    return;
                }

                q3 = "insert into TieneDonacion values((select MAX(Donacion.cDonacion) from Donacion),?,?)";
                OdbcConnection con3 = new conexionBD().conexion;
                OdbcCommand com3 = new OdbcCommand(q3, con3);

                com3.Parameters.AddWithValue("cInsumo", cInsumo);
                com3.Parameters.AddWithValue("cantidad", cantidad);

                try
                {
                    com3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label2.Text += ex.Message;
                    return;
                }

                q4 = "insert into Recibe values(?,(select MAX(Donacion.cDonacion) from Donacion))";
                OdbcConnection con4 = new conexionBD().conexion;
                OdbcCommand com4 = new OdbcCommand(q4, con4);

                com4.Parameters.AddWithValue("cCentro", cCentro);

                try
                {
                    com4.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label2.Text += ex.Message;
                    return;
                }

                q5 = "select TieneCentroAcopio.Inventario from TieneCentroAcopio where cCentro=? and cInsumo=?";
                OdbcConnection con5 = new conexionBD().conexion;
                OdbcCommand com5 = new OdbcCommand(q5, con5);

                com5.Parameters.AddWithValue("cCentro", cCentro);
                com5.Parameters.AddWithValue("cInsumo", cInsumo);

                OdbcDataReader leer1 = com5.ExecuteReader();

                leer1.Read();

                int cantidadAnt;
                if (leer1.HasRows)
                {
                    cantidadAnt = leer1.GetInt32(0);
                }

                else
                {
                    q7 = "insert into TieneCentroAcopio values (?,?,0)";
                    OdbcConnection con7 = new conexionBD().conexion;
                    OdbcCommand com7 = new OdbcCommand(q7, con7);

                    com7.Parameters.AddWithValue("cCentro", cCentro);
                    com7.Parameters.AddWithValue("cInsumo", cInsumo);

                    try
                    {
                        com7.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Label2.Text += ex.Message;
                        return;
                    }

                    cantidadAnt = 0;
                }

                cantidad = cantidad + cantidadAnt;

                String canti = cantidad.ToString();

                q6 = "update TieneCentroAcopio set Inventario=? where cCentro=? and cInsumo=?";
                OdbcConnection con6 = new conexionBD().conexion;
                OdbcCommand com6 = new OdbcCommand(q6, con6);

                com6.Parameters.AddWithValue("inventario", canti);
                com6.Parameters.AddWithValue("cCentro", cCentro);
                com6.Parameters.AddWithValue("cInsumo", cInsumo);

                try
                {
                    com6.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label2.Text += ex.Message;
                    return;
                }

                Label2.Text = "Donación exitosa, muchas gracias " + Session["nombre"].ToString();
            }

            else
            {
                Label2.Text = "Algún campo está vacío ó la cantidad de donación no es válida";
            }
        }
    }
}