using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace Proyecto_Micros
{
    public partial class PaginaMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["User"] == null)          //esto lo usamos para chequar que este logeado bien
            {
                Response.Redirect("Login_usuario.aspx");
            }
            Usuario user = new Usuario();
            user = (Usuario)Session["user"];
            if (user.MiRol.Id == 2)
            {
                //aca tengo q ocultar la barra 
                aaa.Visible = false;
            }
            else
                aaa.Visible = true;
        }

        protected void btnNivelEduc_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM_nivelEducativo.aspx");
        }

        protected void btnInstEduc_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM_institucionEducativa.aspx");
        }
        /*
        protected void BTNlogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
        }
        */
        protected void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM_usuario.aspx");
        }
    }
}