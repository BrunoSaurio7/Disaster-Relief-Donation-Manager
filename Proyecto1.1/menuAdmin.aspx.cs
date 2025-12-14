using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1._1
{
    public partial class menuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["cAdmin"]==null || Session["nombre"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginAdmin.aspx");
            }

            Label1.Text = Session["nombre"].ToString();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarDesastre.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("loginAdmin.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrarDesastre.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarSiniestro.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrarSiniestro.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarSiniestro.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarInsumo.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrarInsumo.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarCentro.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrarCentro.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportes.aspx");
        }
    }
}