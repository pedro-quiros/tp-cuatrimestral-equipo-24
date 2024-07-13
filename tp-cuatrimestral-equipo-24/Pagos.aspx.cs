using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            divtext.Visible = true;
            htext.Visible  = true;
            lblMesa.Visible = true;
            lblmesero.Visible = true;
            lblFecha.Visible = true;
            lbltotal.Visible = true;
            lblTipo.Visible = true;
            lblconsumicion.Visible = true;
            
            txtMesa.Visible = true; 
            txtMesero.Visible = true; 
            Txtfecha.Visible = true; 
            txtTotal.Visible = true; 
            txtTipo.Visible = true; 
            txtConsumicion.Visible = true; 
        }
    }
}