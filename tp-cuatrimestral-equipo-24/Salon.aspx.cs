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

        protected void btnAbrirMesa_Click(object sender, EventArgs e)
        {
            int idMesa = ObtenerIdMesaDesdeBoton((Control)sender);

            // Mostrar el modal de confirmación
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", "$('#modalConfirmar').modal('show');", true);

            // Guardar el Id de la mesa que se está abriendo para poder usarlo al aceptar en el modal
            hdfIdMesa.Value = idMesa.ToString();
        }

        protected void btnCargarPedidos_Click(object sender, EventArgs e)
        {
            int idMesa = ObtenerIdMesaDesdeBoton((Control)sender);

            // Guardar el ID de la mesa en la sesión
            Session["IdMesa"] = idMesa;

            // Redirige a la página de pedidos con el ID de la mesa en la URL
            Response.Redirect($"Pedi2.aspx?IdMesa={idMesa}");
        }



        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdfIdMesa.Value))
            {
                int idMesa = Convert.ToInt32(hdfIdMesa.Value);

                // Llamar al método de negocio para abrir o cerrar la mesa
                mesaNegocio.AbrirCerrarMesa(idMesa);

                // Actualizar la vista de la mesa en el GridView
                CargarDatosGridView();

                // Ocultar el modal después de aceptar
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OcultarModal", "$('#modalConfirmar').modal('hide');", true);
            }
        }

        private void CargarDatosGridView()
        {
            List<Mesas> listaMesas = mesaNegocio.ListarConSpMesa();
            dgvMesas.DataSource = listaMesas;
            dgvMesas.DataBind();
        }

        private int ObtenerIdMesaDesdeBoton(Control button)
        {
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int index = row.RowIndex;
            int idMesa = Convert.ToInt32(dgvMesas.DataKeys[index].Value);
            return idMesa;
        }
    }
}
