using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Reportes1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlReportesFiltro.Text = "Mostrar todo";

                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> pedidos = negocio.Listar();


                Session["Pedido"] = pedidos;
                idRep.DataSource = pedidos;
                idRep.DataBind();
            }
        }

        protected void ddlReportesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Tipo = ddlReportesFiltro.Text;
            List<Pedido> lista = new List<Pedido>();
            DateTime fechaActual = DateTime.Now;
            int mesActual = DateTime.Now.Month;

            if (Session["Pedido"] != null)
            {
                lista = (List<Pedido>)Session["Pedido"];
            }
            List<Pedido> listaFiltrada = new List<Pedido>();

            switch (Tipo)
            {
                case "Hoy":
                    foreach (var item in lista)
                    {
                        if (item.FechaHoraGenerado.Date == fechaActual.Date)
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                break;

                case "Este mes":
                    foreach (var item in lista)
                    {
                        if (item.FechaHoraGenerado.Month == mesActual)
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                break;

                case "Este año":
                    foreach (var item in lista)
                    {
                        if (item.FechaHoraGenerado.Year == DateTime.Now.Year)
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                break;

                case "Mostrar todo":
                    listaFiltrada = lista;
                break;
            }

            idRep.DataSource = listaFiltrada;
            idRep.DataBind();
        }
    }
}