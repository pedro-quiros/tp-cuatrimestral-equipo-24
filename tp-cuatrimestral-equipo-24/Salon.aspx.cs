using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Salon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Puedes agregar código de inicialización aquí si es necesario
        }

        protected void btnMesa_Click(object sender, EventArgs e)
        {
            Button btnMesa = sender as Button;
            if (btnMesa != null)
            {
                // Lógica adicional si es necesario
            }
        }
    }
}
