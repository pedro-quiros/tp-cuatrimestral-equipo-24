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

            if(!IsPostBack)
            {
                Session["Reportes"] = listaPedido;


                
            }
        }
    }
}