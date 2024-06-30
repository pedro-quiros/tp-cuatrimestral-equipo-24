using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        private PedidoNegocio pedidoNegocio = new PedidoNegocio();
        private InsumosNegocio insumoNegocio = new InsumosNegocio(); // Añadido

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
                if (Session["IdMesa"] != null)
                {
                    int idMesa = (int)Session["IdMesa"];
                    numeroMesaLabel.Text = idMesa.ToString();

                    // Obtener la lista de insumos y de pedidos
                    try
                    {
                        CargarInsumos();  // Llamar al método para cargar los insumos
                        CargarPedidos(); // Llamar al método para cargar los pedidos
                        CalcularTotal(); // Llamar al método para calcular el total
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores, como registrar el error o mostrar un mensaje
                        ErrorMessage.Text = "Ocurrió un error al cargar los datos: " + ex.Message;
                    }
                }
                else
                {
                    Response.Redirect("Salon.aspx");
                }
            }
        }
        private void CargarInsumos()
        {
            try
            {
                listaInsumos = insumoNegocio.ListarConSpInsumo();  // Cambiado a ListarConSpInsumo
                GridView1.DataSource = listaInsumos;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores, como registrar el error o mostrar un mensaje
                ErrorMessage.Text = "Ocurrió un error al cargar los insumos: " + ex.Message;
            }
        }

        private void CargarPedidos()
        {
            if (listaPedidos == null)
            {
                listaPedidos = new List<ItemPedido>();
            }
            GridViewPedidos.DataSource = listaPedidos;
            GridViewPedidos.DataBind();
        }

        private void CalcularTotal()
        {
            if (listaPedidos != null)
            {
                decimal total = listaPedidos.Sum(p => p.Cantidad * p.Precio);
                TotalLabel.Text = total.ToString("C");
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            var textoFiltro = Filtro.Text.ToLower();
            GridView1.DataSource = listaInsumos.Where(i => i.Nombre.ToLower().Contains(textoFiltro) || i.Tipo.ToLower().Contains(textoFiltro)).ToList();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var insumoSeleccionado = listaInsumos[index];

                var itemPedido = new ItemPedido
                {
                    Insumo = insumoSeleccionado,
                    Cantidad = 1,  // Asumimos una cantidad inicial de 1
                    Precio = insumoSeleccionado.Precio
                };

                if (listaPedidos == null)
                {
                    listaPedidos = new List<ItemPedido>();
                }

                // Verificar si el ítem ya está en la lista
                var itemExistente = listaPedidos.FirstOrDefault(i => i.Insumo.IdInsumo == insumoSeleccionado.IdInsumo);
                if (itemExistente != null)
                {
                    itemExistente.Cantidad++;
                }
                else
                {
                    listaPedidos.Add(itemPedido);
                }

                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
        }

        protected void GridViewPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aumentar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                listaPedidos[index].Cantidad++;
                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
            else if (e.CommandName == "Disminuir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (listaPedidos[index].Cantidad > 1)
                {
                    listaPedidos[index].Cantidad--;
                }
                else
                {
                    listaPedidos.RemoveAt(index);
                }
                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
            else if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                listaPedidos.RemoveAt(index);
                GridViewPedidos.DataSource = listaPedidos;
                GridViewPedidos.DataBind();
                CalcularTotal();
            }
        }
        protected void BtnCerrarPedido_Click(object sender, EventArgs e)
        {
            if (Session["IdMesa"] != null && listaPedidos != null && listaPedidos.Count > 0)
            {
                try
                {
                    int idMesa = (int)Session["IdMesa"];

                    // Crear un nuevo pedido y obtener su ID
                    var fechaHora = DateTime.Now;
                    var totalPedido = listaPedidos.Sum(p => p.Cantidad * p.Precio);

                    // Llamar al método CrearPedido y verificar el ID del nuevo pedido
                    int idPedido = pedidoNegocio.CrearPedido(fechaHora, totalPedido, idMesa);
                    if (idPedido <= 0)
                    {
                        throw new Exception("No se pudo crear el pedido.");
                    }

                    // Agregar los ítems al pedido
                    foreach (var item in listaPedidos)
                    {
                        pedidoNegocio.AgregarItemPedido(idPedido, item.Insumo.IdInsumo, item.Cantidad, item.Precio);
                    }

                    // Actualizar el stock de los insumos
                    foreach (var item in listaPedidos)
                    {
                        pedidoNegocio.ActualizarStockInsumo(item.Insumo.IdInsumo, -item.Cantidad);  // Restar la cantidad del stock
                    }

                    // Cerrar el pedido
                    pedidoNegocio.CerrarPedido(idPedido);

                    // Limpiar sesión
                    Session.Remove("IdMesa");
                    Session.Remove("Pedidos");
                    Session.Remove("ListadoInsumos");

                    // Redirigir a la página de salón
                    Response.Redirect("Salon.aspx");
                }
                catch (Exception ex)
                {
                    // Manejo de errores, como registrar el error o mostrar un mensaje
                    ErrorMessage.Text = "Ocurrió un error al cerrar el pedido: " + ex.Message;
                }
            }
            else
            {
                // Mostrar un mensaje de error si no hay pedidos
                ErrorMessage.Text = "No hay pedidos para cerrar.";
            }
        }
    }
}
