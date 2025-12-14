using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class pAfectado1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["nombre"]==null || Session["correo"]==null || Session["cCiudad"] == null)
            {
                Response.Redirect("pAfectado.aspx");
            }

            Label2.Text = Session["nombre"].ToString();

            String queryCat1, queryCat2, queryCat3;

            queryCat1 = "select cDesastre,Nombre from Desastre";
            OdbcConnection con1 = new conexionBD().conexion;
            OdbcCommand com1 = new OdbcCommand(queryCat1, con1);
            OdbcDataReader leer1 = com1.ExecuteReader();

            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.DataSource = leer1;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "cDesastre";
                DropDownList1.DataBind();
            }

            queryCat2 = "select cSiniestro,Nombre from Siniestro";
            OdbcConnection con2 = new conexionBD().conexion;
            OdbcCommand com2 = new OdbcCommand(queryCat2, con2);
            OdbcDataReader leer2 = com2.ExecuteReader();

            if (DropDownList2.Items.Count == 0)
            {
                DropDownList2.DataSource = leer2;
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataValueField = "cSiniestro";
                DropDownList2.DataBind();
            }

            queryCat3 = "select cInsumo,Nombre from Insumo";
            OdbcConnection con3 = new conexionBD().conexion;
            OdbcCommand com3 = new OdbcCommand(queryCat3, con3);
            OdbcDataReader leer3 = com3.ExecuteReader();

            if (CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.DataSource = leer3;
                CheckBoxList1.DataTextField = "nombre";
                CheckBoxList1.DataValueField = "cInsumo";
                CheckBoxList1.DataBind();
            }

            con1.Close();
            con2.Close();
            con3.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("p1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String siniestro,desastre,q1,q2,q3,cPersona;
            DateTime fecha;

            if (TextBox1.Text != "")
            {

                siniestro = DropDownList2.SelectedValue.ToString();
                desastre = DropDownList1.SelectedItem.ToString();
                fecha = DateTime.Parse(TextBox1.Text);

                List<string> valoresSeleccionados = new List<string>();

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        valoresSeleccionados.Add(item.Value);
                    }
                }

                string[] insumos = valoresSeleccionados.ToArray();

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
                    Label1.Text = "error de busqueda de persona";
                    return;
                }

                q2 = "insert into Afecta values(?,?,?)";
                OdbcConnection con2 = new conexionBD().conexion;
                OdbcCommand com2 = new OdbcCommand(q2, con2);

                com2.Parameters.AddWithValue("cPersona", cPersona);
                com2.Parameters.AddWithValue("cSiniestro", siniestro);
                com2.Parameters.AddWithValue("fecha", fecha);

                try
                {
                    com2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label1.Text += ex.Message;
                }

                if (insumos.Length > 0)
                {
                    String ins = "(?";
                    for (int i = 0; i < insumos.Length - 1; i++)
                    {
                        ins = ins + ",?";
                    }
                    ins = ins + ")";

                    q3 = "select CentroAcopio.Nombre as 'Centro de acopio',CentroAcopio.Direccion as 'Dirección', Insumo.Nombre as 'Insumo', TieneCentroAcopio.Inventario as 'Cantidad disponible'\r\n from (CentroAcopio inner join TieneCentroAcopio on CentroAcopio.cCentro=TieneCentroAcopio.cCentro)\r\n\t\t inner join Insumo on TieneCentroAcopio.cInsumo=Insumo.cInsumo where cCiudad=? and Insumo.cInsumo in " + ins + " \torder by CentroAcopio.Nombre asc, Insumo.Nombre asc";
                    OdbcConnection con3 = new conexionBD().conexion;
                    OdbcCommand com3 = new OdbcCommand(q3, con3);

                    com3.Parameters.AddWithValue("cCiudad", Session["cCiudad"].ToString());

                    String param = "insumo ";
                    for (int i = 0; i < insumos.Length; i++)
                    {
                        com3.Parameters.AddWithValue(param + i, insumos[i]);
                    }

                    OdbcDataReader leer1 = com3.ExecuteReader();

                    GridView1.DataSource = leer1;
                    GridView1.DataBind();
                }

                else
                {
                    Label1.Text = "Ningún insumo seleccionado";
                }
            }

            else
            {
                Label1.Text = "Hay algún campo vacío";
            }
        }
    }
}