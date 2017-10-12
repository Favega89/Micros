using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controladora;

namespace Proyecto_Micros
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        C_Rol cRol = new C_Rol();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void refresh()
        {
            TextBox2.Text = "Descripcion";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
            else
                if (cRol.comprobarDescripcion(TextBox2.Text))
                {
                    Response.Write("<script>alert('Rol existente');</script>");
                }
                else
                    cRol.nuevo(TextBox2.Text);
            //refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM_usuario.aspx");
        }
    }
}