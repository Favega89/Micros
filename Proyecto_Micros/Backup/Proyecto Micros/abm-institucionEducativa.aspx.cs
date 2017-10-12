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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        C_InstitucionEducativa CInstEduc = new C_InstitucionEducativa();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }
        protected bool chequearCBL()
        {
            bool aux = false;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                    aux = true;
            }
            return aux;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text != "") && (chequearCBL()))
            {
                if (CInstEduc.comprobarDescripcion(TextBox1.Text))
                {
                    Response.Write("<script>alert('Nombre de Institucion existente');</script>");
                }
                else
                {
                    CInstEduc.Nuevo(TextBox1.Text, armarListaNivel());
                    CargarControles();
                    refresh();
                }
            }
            else
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text != "")
            {
                int i = GridView1.SelectedIndex;
                CInstEduc.EditarXpos(i, TextBox2.Text, armarListaNivel2());
                CargarControles();
                TextBox2.Visible = false;
                Button2.Visible = false;
                CheckBoxList2.Visible = false;
            }
            else
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
        }

        public List<int> armarListaNivel2()
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                if (CheckBoxList2.Items[i].Selected)
                    lista.Add(Convert.ToInt32(CheckBoxList2.Items[i].Value));
            }
            return lista;
        }

        public List<int> armarListaNivel()
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                    lista.Add(Convert.ToInt32(CheckBoxList1.Items[i].Value));
            }
            return lista;
        }

        private void refresh()
        {
            CheckBoxList1.ClearSelection();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox2.Visible = false;
            Button2.Visible = false;
            CheckBoxList2.Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //eliminamos la fila
            int i = e.RowIndex;
            CInstEduc.BorrarXpos(i);
            CargarControles();
            refresh();
        }

        private void CargarControles()
        {
            if (!IsPostBack)
            {
                CheckBoxList1.DataSource = CInstEduc.ctrlNivelEducativo.TraerTodos();
                CheckBoxList1.DataTextField = "Descripcion";
                CheckBoxList1.DataValueField = "Id";
                CheckBoxList1.DataBind();   
            }

            GridView1.DataSource = CInstEduc.TraerTodos();
            GridView1.DataBind();
        }
        private void cargarGrid2()
        {
            CheckBoxList2.DataSource = CInstEduc.ctrlNivelEducativo.TraerTodos();
            CheckBoxList2.DataTextField = "Descripcion";
            CheckBoxList2.DataValueField = "Id";
            CheckBoxList2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Button2.Visible = true;
            CheckBoxList2.Visible = true;
            cargarGrid2();
            InstitucionEducativa aux = new InstitucionEducativa();
            aux = CInstEduc.buscarXpos(Convert.ToInt32(GridView1.SelectedIndex));
            TextBox2.Text = aux.Descripcion;
            for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                for (int w = 0; w < aux.Lista_nivelEducativos.Count; w++)
                    if (Convert.ToInt32(CheckBoxList2.Items[i].Value) == aux.Lista_nivelEducativos[w].Id)
                        CheckBoxList2.Items[i].Selected=true;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            /*editamos la fila
            int i = GridView1.EditIndex = e.NewEditIndex;
            //CInstEduc.EditarXpos(i, descripcion);
            CargarControles();*/
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*GridViewRow fila = GridView1.Rows[e.RowIndex];
            
                CInstEduc.TraerTodos*/
        }

    }
}