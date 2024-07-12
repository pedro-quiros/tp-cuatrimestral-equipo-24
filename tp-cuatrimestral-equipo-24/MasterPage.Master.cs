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
            if (!IsPostBack)
            {
                int P = Convert.ToInt32(Session["Puesto"]);
                if (P == 1)
                {
                    aReportes.Attributes["href"] = "#";
                    aReportes.Attributes["onclick"] = "alert('No tiene autorizacion'); return false;"; 
                    //aHome.Attributes["href"] = "#";
                    //aHome.Attributes["onclick"] = "alert('No tiene autorizacion'); return false;";
                }

            }
        }
    }
}
