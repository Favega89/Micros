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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        C_Usuario cUser = new C_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLroles.DataSource = cUser.ctrlRol.TraerTodos();
                DDLroles.DataTextField = "Descripcion";
                DDLroles.DataValueField = "Id";
                DDLroles.DataBind();
                cargarControles();
            }
            Label1.Visible = false;
            Usuario user = new Usuario();
            user = (Usuario)Session["user"];
            if (user.MiRol.Id == 2)     //entra como responsable de institucion educativa
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Button4.Visible = true;


                DDLroles.Visible = false;

                

                if (Session["dni"] != null)
                {
                    TextBox2.Text = Convert.ToString(Session["dni"]);
                    TextBox3.Text = Convert.ToString(Session["nombre"]);
                    TextBox2.ReadOnly = true;
                    TextBox3.ReadOnly = true;

                    Session.Remove("dni");
                    Session.Remove("nombre");
                }
                else
                {
                    TextBox2.ReadOnly = false;
                    TextBox3.ReadOnly = false;
                }
            }
            else
            {                       //entra como administrador
                Button1.Visible = true;
                Button2.Visible = true;
                Button4.Visible = false;
                DDLroles.Visible = true;
            }
        }

        private void cargarControles()
        {
            GridView1.DataSource = cUser.TraerTodos();
            
            //GridView1.Columns.RemoveAt(0);
            //GridView1.Columns.RemoveAt(1);
            GridView1.DataBind();
        }

        private static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int aux;
            if (DDLroles.SelectedValue == "2")
                aux = Convert.ToInt32(DropDownList1.SelectedValue);
            else
            {
                aux = 0;
            }
            if ((TextBox2.Text != "") && (TextBox3.Text != "") && (TextBox4.Text != "") && (TextBox5.Text != "") && (TextBox6.Text != "") && (DDLroles.SelectedItem != null) && (DropDownList1.SelectedItem != null))
            {
                if (ComprobarFormatoEmail(TextBox4.Text))
                {
                    cUser.nuevo(TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, Convert.ToInt32(DDLroles.SelectedValue), aux);
                }
                else
                {
                    Response.Write("<script>alert('EL FORMATO DE E-MAIL NO ES VALIDO');</script>");
                }
                //refresh();
            }
            else
            {
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("abm-roles.aspx");
        }

        private void refresh()
        {
            Label1.Visible = false;
            label2.Visible = false;
            DropDownList1.Visible = false;
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)//   NO LO TOMA(no entra al envento text changed cuando escribo en el text box)!!!!
        {
            if (TextBox5.Text != TextBox6.Text)
            {
                Label1.Visible = true;
                Label1.Text = "Contraseñas distintas";
            }
            else
            {
                Label1.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {   //le tengo que mandar el rol de estudiante!!!!! 
            cUser.nuevo(TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, 3, 0);
            Response.Redirect("abm-usuario.aspx");
        }

        protected void DDLroles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLroles.SelectedValue == "2") || (DDLroles.SelectedIndex == 1))
            {
                DropDownList1.Visible = true;
                label2.Visible = true;
                DropDownList1.DataSource = cUser.ctrlInst.TraerTodos();
                DropDownList1.DataTextField = "Descripcion";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
            }
            else
            {
                DropDownList1.Visible = false;
                label2.Visible = false;
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int pos = (int)GridView1.DataKeys[e.RowIndex].Value;
            TextBox dni = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdni");
            TextBox nombre = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnombre");
            TextBox mail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtmail");
            cUser.Modificar(pos, dni.Text, nombre.Text, mail.Text);
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
            cUser.Remover(i);
            cargarControles();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            cargarControles();
        }
    }
}