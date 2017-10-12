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
    public partial class Estudiantes_institucion : System.Web.UI.Page
    {
        C_Estudiante cEst = new C_Estudiante();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                cargarControles();
        }
        private void cargarControles()
        {
            Usuario user =(Usuario) Session["user"];
            GridView1.DataSource = cEst.TraerPorInstitucion(user.MiInstitucion); 
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int pos = (int)GridView1.DataKeys[e.RowIndex].Value;
            TextBox nombre = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnombre");
            TextBox apellido = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtapellido");
            TextBox dni = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdni");
            TextBox telefono = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txttel");
            cEst.Modificar(pos, nombre.Text, apellido.Text, dni.Text, telefono.Text);
            GridView1.EditIndex = -1;
            cargarControles();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            cargarControles();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = (int)GridView1.DataKeys[e.RowIndex].Value;
            cEst.Remover(i);
            cargarControles();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            cargarControles();
        }
    }
}