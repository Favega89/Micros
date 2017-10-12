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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        C_TransporteUrbano cTransporte = new C_TransporteUrbano();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarControles();
            }

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if ((TXTdescripcion.Text != "") && (TXTlinea.Text != ""))
            {
                cTransporte.Nuevo(TXTdescripcion.Text, Convert.ToInt32(TXTlinea.Text));
                //refresh();
                cargarControles();
            }
            else
            {
                Response.Write("<script>alert('CAMPOS VACIOS');</script>");
            }

        }

        private void refresh()
        {
            TXTdescripcion.Text = "Descripcion";
            TXTlinea.Text = "Linea";
        }

        private void cargarControles()
        {
            GridView1.DataSource = cTransporte.TraerTodos();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //eliminamos la fila
            int i = e.RowIndex;
            cTransporte.borrarXPos(i);
            //refresh();
            cargarControles();
        }
    }
}