using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Salon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesas();
            }
        }

        private void CargarMesas()
        {
            MesaNegocio negocio = new MesaNegocio();
            List<Mesas> mesas = negocio.ListarConSpMesa();

            foreach (Mesas mesa in mesas)
            {
                Button btnMesa = FindControl($"btnMesa{mesa.Id}") as Button;
                if (btnMesa != null)
                {
                    if (mesa.Estado)
                    {
                        btnMesa.CssClass = "mesa-btn clicked";
                    }
                    else
                    {
                        btnMesa.CssClass = "mesa-btn";
                    }
                }
            }
        }
    }
}
