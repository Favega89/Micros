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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        C_NivelEducativo CNivel = new C_NivelEducativo();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarControles();
        }

        private void cargarControles()
        {
            GridView1.DataSource = CNivel.TraerTodos();
            GridView1.DataBind();

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                if (CNivel.comprobarDescripcion(TextBox1.Text))
                {
                    Response.Write("<script>alert('Nivel Educativo en uso');</script>");
                }
                else
                {
                    CNivel.Nuevo(TextBox1.Text);
                    refresh();
                }
            }
            else
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");

            cargarControles();
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM_institucionEducativa.aspx");
        }
        public void refresh()
        {
            TextBox2.Visible = false;
            Button3.Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //eliminamos la fila
            int i = e.RowIndex;
            CNivel.borrarXPos(i);
            //refresh();
            cargarControles();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int i = GridView1.SelectedIndex;
            CNivel.editarXPos(i, TextBox2.Text);
            //refresh();
            cargarControles();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Button3.Visible = true;
            NivelEducativo aux = new NivelEducativo();
            aux = CNivel.buscarXpos(Convert.ToInt32(GridView1.SelectedIndex));
            TextBox2.Text = aux.Descripcion;
        }

        /*protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
        editamos la fila
        int i = e.NewEditIndex;
        int index = GridView1.EditIndex;
        GridViewRow row = GridView1.Rows[index];

        CNivel.editarXPos(i,);
        refresh();
        cargarControles();
        }*/

    }
}