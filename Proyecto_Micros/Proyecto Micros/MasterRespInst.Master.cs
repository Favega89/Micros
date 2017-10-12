using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Micros
{
    public partial class MasterRespInst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresoAlumnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("abm-estudiante.aspx");
        }
    }
}