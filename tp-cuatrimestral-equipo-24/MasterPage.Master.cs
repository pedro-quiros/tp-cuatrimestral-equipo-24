using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioSeleccionado"] == null)
            {
                Session.Add("Error","Debes loguearte para ingresar");
                Response.Redirect("Error.aspx",false);
            }
        } 
    }
}