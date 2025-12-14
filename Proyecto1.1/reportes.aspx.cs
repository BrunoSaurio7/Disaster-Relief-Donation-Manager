using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class reportes : System.Web.UI.Page
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
                String qc1 = "select CentroAcopio.cCentro, CentroAcopio.nombre from CentroAcopio";
                OdbcConnection conc1 = new conexionBD().conexion;
                OdbcCommand comc1 = new OdbcCommand(qc1, conc1);
                OdbcDataReader leerc1 = comc1.ExecuteReader();

                DropDownList1.DataSource = leerc1;
                DropDownList1.DataValueField = "cCentro";
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataBind();

                conc1.Close();
            }

            String qg = "select Persona.Nombre as 'Persona', Ciudad.Nombre as 'Ciudad',Insumo.Nombre as 'Insumo', TieneDonacion.Cantidad as 'Cantidad', CentroAcopio.Nombre as 'Centro de acopio', Donacion.Fecha as 'Fecha'\r\n\tfrom Persona inner join Donacion on Persona.cPersona=Donacion.cPersona\r\n\t\tinner join TieneDonacion on Donacion.cDonacion=TieneDonacion.cDonacion\r\n\t\tinner join Insumo on TieneDonacion.cInsumo=Insumo.cInsumo\r\n\t\tinner join Ciudad on Persona.cCiudad=Ciudad.cCiudad\r\n\t\tinner join Recibe on Donacion.cDonacion=Recibe.cDonacion\r\n\t\tinner join CentroAcopio on Recibe.cCentroAcopio=CentroAcopio.cCentro";
            OdbcConnection cong = new conexionBD().conexion;
            OdbcCommand comg = new OdbcCommand(qg, cong);
            OdbcDataReader leerg = comg.ExecuteReader();

            GridView2.DataSource= leerg;
            GridView2.DataBind();

            cong.Close();

            if (DropDownList2.Items.Count == 0)
            {
                String qc2 = "select Persona.cPersona, Persona.nombre from Persona";
                OdbcConnection conc2 = new conexionBD().conexion;
                OdbcCommand comc2 = new OdbcCommand(qc2, conc2);
                OdbcDataReader leerc2 = comc2.ExecuteReader();

                DropDownList2.DataSource = leerc2;
                DropDownList2.DataValueField = "cPersona";
                DropDownList2.DataTextField = "nombre";
                DropDownList2.DataBind();

                conc2.Close();
            }

            if (DropDownList3.Items.Count == 0)
            {
                String qc3 = "select Ciudad.cCiudad, Ciudad.nombre from Ciudad";
                OdbcConnection conc3 = new conexionBD().conexion;
                OdbcCommand comc3 = new OdbcCommand(qc3, conc3);
                OdbcDataReader leerc3 = comc3.ExecuteReader();

                DropDownList3.DataSource = leerc3;
                DropDownList3.DataValueField = "cCiudad";
                DropDownList3.DataTextField = "nombre";
                DropDownList3.DataBind();

                conc3.Close();
            }

            if (DropDownList4.Items.Count == 0)
            {
                String qc4 = "select Insumo.cInsumo, Insumo.nombre from Insumo";
                OdbcConnection conc4 = new conexionBD().conexion;
                OdbcCommand comc4 = new OdbcCommand(qc4, conc4);
                OdbcDataReader leerc4 = comc4.ExecuteReader();

                DropDownList4.DataSource = leerc4;
                DropDownList4.DataValueField = "cInsumo";
                DropDownList4.DataTextField = "nombre";
                DropDownList4.DataBind();

                conc4.Close();
            }

            if (DropDownList5.Items.Count == 0)
            {
                String qc5 = "select CentroAcopio.cCentro, CentroAcopio.nombre from CentroAcopio";
                OdbcConnection conc5 = new conexionBD().conexion;
                OdbcCommand comc5 = new OdbcCommand(qc5, conc5);
                OdbcDataReader leerc5 = comc5.ExecuteReader();

                DropDownList5.DataSource = leerc5;
                DropDownList5.DataValueField = "cCentro";
                DropDownList5.DataTextField = "nombre";
                DropDownList5.DataBind();

                conc5.Close();
            }

            if (CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.Items.Add(new ListItem("Persona","Persona.nombre as 'Persona'"));
                CheckBoxList1.Items.Add(new ListItem("Ciudad", "Ciudad.nombre as 'Ciudad'"));
                CheckBoxList1.Items.Add(new ListItem("Insumo", "Insumo.nombre as 'Insumo'"));
                CheckBoxList1.Items.Add(new ListItem("Cantidad", "TieneDonacion.Cantidad as 'Cantidad'"));
                CheckBoxList1.Items.Add(new ListItem("Centro de acopio", "CentroAcopio.nombre as 'Centro de acopio'"));
                CheckBoxList1.Items.Add(new ListItem("Fecha", "Donacion.Fecha as 'Fecha'"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String q = "select Insumo.Nombre as 'Insumo', TieneCentroAcopio.Inventario as 'Cantidad de insumo'\r\n\tfrom Insumo inner join TieneCentroAcopio on Insumo.cInsumo=TieneCentroAcopio.cInsumo\r\n\t\tinner join CentroAcopio on TieneCentroAcopio.cCentro=CentroAcopio.cCentro\r\n\t where CentroAcopio.cCentro=?";
            OdbcConnection con = new conexionBD().conexion;
            OdbcCommand com = new OdbcCommand(q, con);

            com.Parameters.AddWithValue("cCentro", DropDownList1.SelectedValue);
            OdbcDataReader leer = com.ExecuteReader();

            GridView1.DataSource = leer;
            GridView1.DataBind();

            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String select, from, where;

            select = "select ";
            from = " from Persona inner join Donacion on Persona.cPersona=Donacion.cPersona\r\n\t\tinner join TieneDonacion on Donacion.cDonacion=TieneDonacion.cDonacion\r\n\t\tinner join Insumo on TieneDonacion.cInsumo=Insumo.cInsumo\r\n\t\tinner join Ciudad on Persona.cCiudad=Ciudad.cCiudad\r\n\t\tinner join Recibe on Donacion.cDonacion=Recibe.cDonacion\r\n\t\tinner join CentroAcopio on Recibe.cCentroAcopio=CentroAcopio.cCentro ";
            where = " where 1=1 ";

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    select = select + CheckBoxList1.Items[i].Value + ",";
                }
            }

            select=select.Trim(',');

            if(select=="select ")
            {
                Label2.Text = "No se seleccionaron columnas";
                GridView2.DataSource = null;
                GridView2.DataBind();
            }

            else
            {
                if(DropDownList2.SelectedItem != null)
                {
                    where = where + "and Persona.cPersona=" + DropDownList2.SelectedValue + " ";
                }

                if (DropDownList3.SelectedItem != null)
                {
                    where = where + "and Ciudad.cCiudad=" + DropDownList3.SelectedValue + " ";
                }

                if (DropDownList4.SelectedItem != null)
                {
                    where = where + "and Insumo.cInsumo=" + DropDownList4.SelectedValue + " ";
                }

                if (TextBox1.Text!="")
                {
                    where = where + "and TieneDonacion.Cantidad>" + TextBox1.Text + " ";
                }

                if (DropDownList5.SelectedItem != null)
                {
                    where = where + "and CentroAcopio.cCentro=" + DropDownList5.SelectedValue + " ";
                }

                if(TextBox2.Text!="" && TextBox3.Text != "")
                {
                    DateTime f1 = DateTime.Parse(TextBox2.Text);
                    DateTime f2 = DateTime.Parse(TextBox3.Text);

                    String ff1 = f1.Year.ToString() + "-" + f1.Month.ToString() + "-" + f1.Day.ToString() + " " + f1.Hour.ToString() + ":" + f1.Minute.ToString() + ":00";
                    String ff2 = f2.Year.ToString() + "-" + f2.Month.ToString() + "-" + f2.Day.ToString() + " " + f2.Hour.ToString() + ":" + f2.Minute.ToString() + ":00";

                    where = where + "and Donacion.Fecha between '" + ff1 + "' and '" + ff2 + "' ";
                }

                String q = select + from + where;

                OdbcConnection con = new conexionBD().conexion;
                OdbcCommand com = new OdbcCommand(q, con);
                OdbcDataReader leer = com.ExecuteReader();

                GridView2.DataSource = leer;
                GridView2.DataBind();
            }
        }
    }
}