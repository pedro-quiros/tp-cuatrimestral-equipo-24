using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

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
            MesaNegocio mesaNegocio = new MesaNegocio();
            List<Mesas> ListaMesas = mesaNegocio.ListarConSpMesa();
            Session["ListadoMesas"] = ListaMesas;
            dgvMesas.DataSource = ListaMesas;
            dgvMesas.DataBind();
        }

        protected void dgvMesas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMesas.PageIndex = e.NewPageIndex;
            CargarMesas();
        }

        protected void dgvMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvMesas.SelectedDataKey.Value.ToString();
            Response.Redirect("Pedi2.aspx?IdMesa=" + id);
        }

        [WebMethod]
        public static void ConfirmarAbrirCerrarMesa(int idMesa)
        {
            Salon salonPage = new Salon();
            salonPage.AbrirCerrarMesa(idMesa);
        }

        private void AbrirCerrarMesa(int idMesa)
        {
            MesaNegocio mesaNegocio = new MesaNegocio();
            mesaNegocio.AbrirCerrarMesa(idMesa);
            CargarMesas();
            // No es necesario redireccionar aquí, ya que se maneja desde JavaScript
        }

        protected void btnAbrirCerrar_Click(object sender, EventArgs e)
        {
            // Este método no necesita una implementación directa aquí
        }
    }
}
