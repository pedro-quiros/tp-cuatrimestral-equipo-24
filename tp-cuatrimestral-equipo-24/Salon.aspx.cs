using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.UI;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Salon : System.Web.UI.Page
    {
        private MesaNegocio mesaNegocio = new MesaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGridView();
            }
        }

        protected void dgvMesas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMesas.PageIndex = e.NewPageIndex;
            CargarDatosGridView();
        }

        protected void dgvMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica para manejar la selección de una mesa si es necesario
        }

        protected void btnAbrirCerrar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idMesa = Convert.ToInt32(btn.CommandArgument);

            mesaNegocio.AbrirCerrarMesa(idMesa);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Estado de la mesa actualizado exitosamente');", true);

            CargarDatosGridView();
        }

        private void CargarDatosGridView()
        {
            List<Mesas> listaMesas = mesaNegocio.ListarConSpMesa();
            dgvMesas.DataSource = listaMesas;
            dgvMesas.DataBind();
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

    }


}
