using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controladora;
using System.Text.RegularExpressions;

namespace Proyecto_Micros
{
    public partial class Login_usuario : System.Web.UI.Page
    {
        C_Usuario cUser = new C_Usuario();
        C_Rol crol = new C_Rol();
        Usuario user = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {            
            Refresh();
        }

        private void Refresh()
        {
            //TextBox1.Text = "";
            //TextBox2.Text = "";
            Label1.Visible=false;
            Session["user"] = null;           
        }        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cUser.comprobar(TextBox1.Text, TextBox2.Text) == true)       //  EL USER QUE LLEGA ACA LLEGA CON EL OBJETO MIROL ADENTRO COMO NULL!!!!!!!!!!
            {
                Session["user"] = cUser.buscarXemail(TextBox1.Text);
                user = (Usuario)Session["user"];
                if (user != null)
                {
                    if (user.MiRol.Id == 1)//el user tiene rol de Administrador 
                        Response.Redirect("abm-usuario.aspx");
                    else
                        if (user.MiRol.Id == 2)//el user tiene rol de respondable de institucion academica
                            Response.Redirect("abm-estudiante.aspx");
                    //else
                    //if (user.MiRol.Id == 3)//el user tiene rol de estudiante
                }
                else
                    Label1.Visible = true;
            }            
        }           
    }
}