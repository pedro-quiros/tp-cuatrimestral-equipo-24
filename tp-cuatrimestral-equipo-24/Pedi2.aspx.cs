using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        private PedidoNegocio pedidoNegocio = new PedidoNegocio();

        private List<Insumo> listaInsumos
        {
            get { return (List<Insumo>)Session["ListadoInsumos"]; }
            set { Session["ListadoInsumos"] = value; }
        }

        private List<ItemPedido> listaPedidos
        {
            get { return (List<ItemPedido>)Session["Pedidos"]; }
            set { Session["Pedidos"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idMesa;

                // Intenta obtener el ID de la mesa desde los parámetros de la URL
                if (Request.QueryString["IdMesa"] != null && int.TryParse(Request.QueryString["IdMesa"], out idMesa))
                {
                    Session["IdMesa"] = idMesa;
                }
                else if (Session["IdMesa"] != null)
                {
                    idMesa = (int)Session["IdMesa"];
                }
                else
                {
                    // Manejar el caso en que no se haya encontrado el ID de la mesa
                    Response.Redirect("Salon.aspx");
                    return;
                }

                // Utiliza idMesa según sea necesario
                CargarInsumos();
                CargarPedidos();
                numeroMesaLabel.Text = idMesa.ToString();
            }
        }

        private void CargarInsumos()
        {
            listaInsumos = pedidoNegocio.ListarInsumos();
            GridView1.DataSource = listaInsumos;
            GridView1.DataBind();
        }

        private void CargarPedidos()
        {
            if (Session["IdMesa"] != null)
            {
                int idMesa = (int)Session["IdMesa"];
                listaPedidos = pedidoNegocio.ObtenerItemsDePedido(idMesa);

                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Insumo> ListaFiltrada = new List<Insumo>();

            if (listaInsumos != null)
            {
                if (Filtro.Text == "")
                {
                    ListaFiltrada = listaInsumos;
                }
                else
                {
                    ListaFiltrada = listaInsumos.FindAll(X => X.Nombre.ToUpper().Contains(Filtro.Text.ToUpper()));
                }
            }
            else
            {
                CargarInsumos();
                ListaFiltrada = listaInsumos;
            }
            GridView1.DataSource = ListaFiltrada;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (listaInsumos == null || listaPedidos == null)
            {
                return;
            }

            if (e.CommandName == "Agregar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Insumo insumoSeleccionado = listaInsumos[index];

                ItemPedido pedidoExistente = listaPedidos.Find(p => p.Insumo.IdInsumo == insumoSeleccionado.IdInsumo);
                if (pedidoExistente != null)
                {
                    pedidoExistente.Cantidad++;
                }
                else
                {
                    ItemPedido nuevoPedido = new ItemPedido
                    {
                        Insumo = insumoSeleccionado,
                        Cantidad = 1,
                        Precio = insumoSeleccionado.Precio
                    };
                    listaPedidos.Add(nuevoPedido);
                }
                insumoSeleccionado.Stock--;

                GridView1.DataSource = listaInsumos;
                GridView1.DataBind();
                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
        }

        protected void GridViewPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (listaPedidos == null || listaInsumos == null)
            {
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            ItemPedido pedidoSeleccionado = listaPedidos[index];

            if (e.CommandName == "Aumentar")
            {
                Insumo insumo = listaInsumos.Find(i => i.IdInsumo == pedidoSeleccionado.Insumo.IdInsumo);
                if (insumo != null && insumo.Stock > 0)
                {
                    pedidoSeleccionado.Cantidad++;
                    insumo.Stock--;
                }
            }
            else if (e.CommandName == "Disminuir")
            {
                if (pedidoSeleccionado.Cantidad > 0)
                {
                    pedidoSeleccionado.Cantidad--;
                    Insumo insumo = listaInsumos.Find(i => i.IdInsumo == pedidoSeleccionado.Insumo.IdInsumo);
                    if (insumo != null)
                    {
                        insumo.Stock++;
                    }
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                // Eliminar el insumo del pedido y actualizar stock
                Insumo insumo = listaInsumos.Find(i => i.IdInsumo == pedidoSeleccionado.Insumo.IdInsumo);
                if (insumo != null)
                {
                    insumo.Stock += pedidoSeleccionado.Cantidad;
                }
                listaPedidos.RemoveAt(index);
            }

            GridView1.DataSource = listaInsumos;
            GridView1.DataBind();
            GridViewPedidos.DataSource = listaPedidos;
            GridViewPedidos.DataBind();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if (listaPedidos != null)
            {
                foreach (ItemPedido item in listaPedidos)
                {
                    total += item.Cantidad * item.Precio;
                }
            }
            TotalLabel.Text = $"Total: {total:C}";
        }

        protected void BtnCerrarPedido_Click(object sender, EventArgs e)
        {
            if (Session["IdMesa"] != null && listaPedidos != null)
            {
                int idMesa = (int)Session["IdMesa"];
                DateTime fechaHora = DateTime.Now;
                decimal total = 0;

                foreach (ItemPedido item in listaPedidos)
                {
                    total += item.Cantidad * item.Precio;
                }

                pedidoNegocio.InsertarPedido(fechaHora, total, idMesa);

                foreach (ItemPedido item in listaPedidos)
                {
                    Insumo insumo = listaInsumos.Find(i => i.IdInsumo == item.Insumo.IdInsumo);
                    if (insumo != null)
                    {
                        pedidoNegocio.AgregarItemPedido(idMesa, insumo.IdInsumo, item.Cantidad, item.Precio);
                        pedidoNegocio.ActualizarStockInsumo(insumo.IdInsumo, -item.Cantidad);
                    }
                }

                // Cerrar mesa y limpiar sesiones
                pedidoNegocio.AbrirCerrarMesa(idMesa);
                Session["ListadoInsumos"] = null;
                Session["Pedidos"] = null;
                Session["IdMesa"] = null;

                // Redirigir a una página de confirmación o reiniciar el proceso
                Response.Redirect("Salon.aspx");
            }
        }
    }
}
