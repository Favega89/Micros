using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace WebApplication1
{
    public partial class alta_pasaje : System.Web.UI.Page
    {
        ServiceReference1.PruebaSoapClient servicio = new ServiceReference1.PruebaSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            LBLFecha.Text = System.DateTime.Now.ToShortDateString();

            cargarBondis();
        }

        private void cargarBondis()
        {
            DropDownList1.DataSource = servicio.TraerTodosMicros();
            DropDownList1.DataTextField = "Descripcion";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
        }

        public bool ComprobarEstudiante(int id)
        {
            if (servicio.ComprobarEstudiante(id))
                return true;
            else
                return false;
        }
        public bool CargarPasaje(int id, DateTime fecha, int trans)      //llamo al web service para cargar el paasje
        {
            try
            {
                servicio.CargarPasaje(id, fecha, trans);
                return true;
            }
            catch
            {
                return false;

            }
        }

        protected void BTNacept_Click(object sender, EventArgs e)
        {
            if (TXTid.Text == "")
                Response.Write("<script>alert('Campos vacios');</script>");
            else
                if (ComprobarEstudiante(Convert.ToInt32(TXTid.Text)))   
                {
                    int aux = Convert.ToInt32(DropDownList1.SelectedValue);
                    CargarPasaje(Convert.ToInt32(TXTid.Text),Convert.ToDateTime(LBLFecha.Text),aux);
                }
        }
    }
}