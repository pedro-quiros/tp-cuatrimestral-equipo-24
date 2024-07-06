using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            List<Pedido> listaPedido = new List<Pedido>();
            PedidoNegocio negocio = new PedidoNegocio();
            listaPedido = negocio.ListarParaReporte();
            int id = Convert.ToInt32(Request.QueryString["IdItemPedido"]);
            int cantidad = 0;
            Reporte r = new Reporte();


            List<Reporte> reportes = new List<Reporte>();

            if (!IsPostBack)
            {
                Session["Reportes"] = listaPedido;

                foreach (var item in listaPedido)
                {
                    foreach (var item2 in item.ItemsPedido)
                    {
                        if (item2.IdPedido == id)
                        {
                            r.CantidadPedidos = negocio.CantidadPedidos(item.Mesa.IdMesa);
                            r.IdMesa = item.Mesa.Numero;
                            r.IdMesero = item.Mesa.IdMesero;
                            r.Precio = negocio.TotalPedidos(item.Mesa.IdMesa);
                            r.FechaHoraGenerado = item.FechaHoraGenerado;
                            r.Reseña = "hola";
                            r.PuntajeReseña = 1;
                            reportes.Add(r);
                        }
                    }
                }



                idRep.DataSource = reportes;
                idRep.DataBind();


            }
        }
    }
}