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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        C_Estudiante cEst = new C_Estudiante();
        public C_NivelEducativo ctrlNivelEducativo = new C_NivelEducativo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login_usuario.aspx");
            Usuario user = (Usuario)Session["user"];

            //cuando la institucion hace el log in, sacamos de ahi el id de la institucion y los niveles educativos de esa institucipon
            DDLnivelEducativo.DataSource = user.MiInstitucion.Lista_nivelEducativos;
            DDLnivelEducativo.DataTextField = "Descripcion";
            DDLnivelEducativo.DataValueField = "Id";
            DDLnivelEducativo.DataBind();

        }

        private void refresh()
        {
            TextBox1.Text = "Dni";
            TextBox2.Text = "Nombre";
            TextBox3.Text = "Apellido";
            TextBox4.Text = "Telefono";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text == "") || (TextBox2.Text == "") || (TextBox3.Text == "") || (TextBox4.Text == "") || (DDLdia.SelectedItem.Text == "DIA") || (DDLmes.SelectedItem.Text == "MES"))
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
            else
            {
                if (cEst.ComprobarDni(TextBox1.Text))
                {
                    Response.Write("<script>alert('DNI en uso');</script>");
                }
                else
                {
                    Usuario user = (Usuario)Session["user"];
                    cEst.Nuevo(TextBox1.Text, TextBox2.Text, TextBox3.Text, new DateTime(Convert.ToInt32(TXTaño.Text), Convert.ToInt32(DDLmes.SelectedValue), Convert.ToInt32(DDLdia.Text)), TextBox4.Text, Convert.ToInt32(DDLnivelEducativo.SelectedValue), user.MiInstitucion);
                    Session["dni"] = TextBox1.Text;
                    Session["nombre"] = TextBox3.Text + ", " + TextBox2.Text;
                    //refresh();
                    Response.Redirect("abm-usuario.aspx");
                }
            }
        }
    }
}