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
        private PedidoNegocio pedidoNegocio = new PedidoNegocio();

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
            Response.Redirect($"Pedidos.aspx?IdMesa={idMesa}");
        }

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si el IdMesa está en la sesión
                if (string.IsNullOrEmpty(hdfIdMesa.Value))
                {
                    throw new Exception("El IdMesa no está disponible en el modal.");
                }

                int idMesa = Convert.ToInt32(hdfIdMesa.Value);

                // Verifica si el usuario está en la sesión
                if (Session["UsuarioSeleccionado"] == null)
                {
                    throw new Exception("El UsuarioSeleccionado no está en la sesión.");
                }

                Usuario usuario = (Usuario)Session["UsuarioSeleccionado"];
                int idUsuario = usuario.Id; // Asegúrate de que la propiedad Id esté definida en la clase Usuario

                // Abrir la mesa
                mesaNegocio.AbrirMesa(idMesa);

                // Crear un nuevo pedido relacionado con la mesa
                var fechaHora = DateTime.Now;
                var totalPedido = 0.0m;  // El total del pedido es inicialmente 0
                int idPedido = pedidoNegocio.CrearPedido(fechaHora, totalPedido, idMesa, idUsuario);

                // Verificar que el pedido se creó exitosamente
                if (idPedido <= 0)
                {
                    throw new Exception("No se pudo crear el pedido.");
                }

                // Asignar el IdPedido a la sesión para poder usarlo en la página
                Session["IdPedido"] = idPedido;

                // Actualizar la vista de la mesa en el GridView
                CargarDatosGridView();

                // Ocultar el modal después de aceptar
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OcultarModal", "$('#modalConfirmar').modal('hide');", true);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                // Muestra un mensaje de error en la interfaz de usuario
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarError", $"alert('Ocurrió un error al abrir la mesa y crear el pedido. Detalles: {ex.Message}');", true);
            }
            finally
            {
                // Vuelve a cargar el GridView después de ocultar el modal
                CargarDatosGridView();
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
