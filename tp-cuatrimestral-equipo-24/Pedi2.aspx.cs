using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        public List<Insumo> listaInsumos
        {
            get { return (List<Insumo>)Session["ListadoInsumos"]; }
            set { Session["ListadoInsumos"] = value; }
        }

        public List<Pedido> listaPedidos
        {
            get { return (List<Pedido>)Session["Pedidos"]; }
            set { Session["Pedidos"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["mesa"] != null)
                {
                    string numeroMesa = Request.QueryString["mesa"];
                    numeroMesaLabel.Text = numeroMesa;
                }

                InsumosNegocio negocioInsumos = new InsumosNegocio();
                listaInsumos = negocioInsumos.ListarConSpInsumo();

                if (listaPedidos == null)
                {
                    listaPedidos = new List<Pedido>();
                }

                GridView1.DataSource = listaInsumos;
                GridView1.DataBind();
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
                InsumosNegocio insumo = new InsumosNegocio();
                ListaFiltrada = insumo.ListarConSpInsumo();
                listaInsumos = ListaFiltrada;
            }
            GridView1.DataSource = ListaFiltrada;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (listaInsumos == null || listaPedidos == null)
            {
                // Redirigir al usuario o manejar el caso cuando las listas son nulas
                return;
            }

            if (e.CommandName == "Agregar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Insumo insumoSeleccionado = listaInsumos[index];

                Pedido pedidoExistente = listaPedidos.Find(p => p.Nombre == insumoSeleccionado.Nombre);
                if (pedidoExistente != null)
                {
                    pedidoExistente.Cantidad++;
                }
                else
                {
                    Pedido nuevoPedido = new Pedido
                    {
                        Nombre = insumoSeleccionado.Nombre,
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
                // Redirigir al usuario o manejar el caso cuando las listas son nulas
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            Pedido pedidoSeleccionado = listaPedidos[index];

            if (e.CommandName == "Aumentar")
            {
                Insumo insumo = listaInsumos.Find(i => i.Nombre == pedidoSeleccionado.Nombre);
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
                    Insumo insumo = listaInsumos.Find(i => i.Nombre == pedidoSeleccionado.Nombre);
                    if (insumo != null)
                    {
                        insumo.Stock++;
                    }
                }
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
                foreach (var pedido in listaPedidos)
                {
                    total += pedido.Cantidad * pedido.Precio;
                }
            }
            lblTotal.Text = total.ToString("C");
        }

        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {

            // Guardar los pedidos en la base de datos
            // Limpiar pedidos
            listaPedidos.Clear();
            GridViewPedidos.DataSource = listaPedidos;
            GridViewPedidos.DataBind();
            

            /*
            if (Request.QueryString["mesa"] != null)
            {
                int idMesa;
                if (int.TryParse(Request.QueryString["mesa"], out idMesa))
                {
                    MesaNegocio negocioMesa = new MesaNegocio();
                    negocioMesa.AbrirCerrarMesa(idMesa);

                    // Limpiar pedidos
                    listaPedidos.Clear();
                    GridViewPedidos.DataSource = listaPedidos;
                    GridViewPedidos.DataBind();

                    // Actualizar el estado de la mesa en la interfaz
                    numeroMesaLabel.Text = string.Empty;
                    lblTotal.Text = string.Empty;
                }
                else
                {
                    // Manejar el caso en que el ID de la mesa no es válido
                }
            }
            */
        }

        public class Pedido
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
        }
    }
}


