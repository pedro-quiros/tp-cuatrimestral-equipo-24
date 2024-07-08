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
            List<Reporte> listaReporte = new List<Reporte>();
            PedidoNegocio negocio = new PedidoNegocio();
            listaReporte = negocio.ListarParaReporte();
            int id = Convert.ToInt32(Request.QueryString["IdPedido"]);
            int cantidad = 0;
            Reporte r = new Reporte();

            DateTime fechaActual = DateTime.Now.Date;

            int nuevo;
            string Tipo = "";
            Tipo = Request.QueryString["Parametro"].ToString();

            List<Reporte> reportes = new List<Reporte>();

            if (!IsPostBack)
            {
                switch (Tipo)
                {
                    case "Hoy":
                        nuevo = 1;
                        foreach (var item in listaReporte)
                        {
                            r = new Reporte();
                            if (item.FechaHoraGenerado.Date == fechaActual)
                            {
                                r.CantidadPedidos = item.CantidadPedidos;
                                r.IdMesa = item.IdMesa;
                                r.IdMesero = item.IdMesero;
                                r.NumeroMesa = item.NumeroMesa;
                                r.Precio = item.Precio;
                                r.FechaHoraGenerado = item.FechaHoraGenerado;
                                r.Reseña = "hola";
                                r.PuntajeReseña = 1;
                                reportes.Add(r);
                            }
                        }
                    break;

                    case "Este mes":
                        nuevo = 2;
                        break;

                    case "Este año":
                        nuevo = 3;
                        break;
                }

                Session["Reportes"] = listaReporte;




                idRep.DataSource = reportes;
                idRep.DataBind();
            }
        }
    }
}
