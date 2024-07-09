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
                ddlReportesFiltro.Text = "-";

                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> pedidos = negocio.Listar();


                Session["Pedido"] = pedidos;
                //idRep.DataSource = pedidos;
                //idRep.DataBind();
            }
        }

        protected void ddlReportesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Tipo = ddlReportesFiltro.Text;
            List<Pedido> lista = new List<Pedido>();
            DateTime fechaActual = DateTime.Now;
            int mesActual = DateTime.Now.Month;

            string Parametro;
            if (Session["Pedido"] != null)
            {
                lista = (List<Pedido>)Session["Pedido"];
            }
            List<Pedido> listaFiltrada = new List<Pedido>();

            switch (Tipo)
            {
                case "Hoy":
                    Parametro = "Hoy";
                    Response.Redirect("DetalleReporte.aspx?Parametro=" + Parametro, false);
                break;

                case "Este mes":
                    Parametro = "Este mes";
                    Response.Redirect("DetalleReporte.aspx?Parametro=" + Parametro, false);
                break;

                case "Este año":
                    Parametro = "Este año";
                    Response.Redirect("DetalleReporte.aspx?Parametro=" + Parametro, false);
                break;
            }

        }

        protected void txtReseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detalle_Reseñas.aspx");
        }
    }
}