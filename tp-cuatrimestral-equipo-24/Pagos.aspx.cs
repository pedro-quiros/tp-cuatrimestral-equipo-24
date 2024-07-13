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
            // Asignar valores a los controles
            txtMesa.InnerText = "5"; // Ejemplo
            txtMesero.InnerText = "Juan Perez"; // Ejemplo
            Txtfecha.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            txtTotal.InnerText = "$50.00"; // Ejemplo
            txtTipo.InnerText = ddlPagos.SelectedItem.Text;
            txtConsumicion.InnerText = "Pizza, Refresco"; // Ejemplo

            // Mostrar los controles con los valores asignados
            lblMesa.Visible = true;
            txtMesa.Visible = true;
            lblmesero.Visible = true;
            txtMesero.Visible = true;
            lblFecha.Visible = true;
            Txtfecha.Visible = true;
            lbltotal.Visible = true;
            txtTotal.Visible = true;
            lblTipo.Visible = true;
            txtTipo.Visible = true;
            lblconsumicion.Visible = true;
            txtConsumicion.Visible = true;
            htext.Visible = true;
            divtext.Visible = true;
        }
    }
}