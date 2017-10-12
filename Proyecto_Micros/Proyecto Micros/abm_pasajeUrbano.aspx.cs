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
    public partial class abm_pasajeUrbano : System.Web.UI.Page
    {
        C_PasajeUrbano cPasaje = new C_PasajeUrbano();
        protected void Page_Load(object sender, EventArgs e)
        {
            LBLFecha.Text = System.DateTime.Now.ToShortDateString();

            cargarBondis();
        }

        private void cargarBondis()
        {
            //ServicioWeb1.PruebaSoapClient servicio = new ServicioWeb1.PruebaSoapClient();
            //DropDownList1.DataSource = servicio.
            //DropDownList1.DataTextField = "Descripcion";
            //DropDownList1.DataValueField = "Id";
            //DropDownList1.DataBind();
        }

        public bool ComprobarEstudiante(int id)
        {
            ServicioWeb1.PruebaSoapClient servicio = new ServicioWeb1.PruebaSoapClient();
            if (servicio.ComprobarEstudiante(id))
                return true;
            else
                return false;
        }
        public bool CargarPasaje(int id, DateTime fecha, TransporteUrbano trans)      //llamo al web service para cargar el paasje
        {
            PasajeUrbano pas = new PasajeUrbano();
            
            return true;
        }

        protected void BTNacept_Click(object sender, EventArgs e)
        {
            if (TXTid.Text == "")
                Response.Write("<script>alert('Campos vacios');</script>");
            else
                if (ComprobarEstudiante(Convert.ToInt32(TXTid.Text)))   //existe hay q guardarlo como se que bondi es??
                {
                   // CargarPasaje(Convert.ToInt32(TXTid.Text),Convert.ToDateTime(LBLFecha.Text),);
                }
        }



    }
}