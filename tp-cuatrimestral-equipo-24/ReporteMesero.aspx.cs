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
    public partial class ReporteMesero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Reporte> listaReporte = new List<Reporte>();
            ReporteNegocio negocio = new ReporteNegocio();
            listaReporte = negocio.ListarPorMesero();
            Reporte r = new Reporte();

            DateTime fechaActual = DateTime.Now.Date;

            string Tipo = "";
            Tipo = Request.QueryString["Parametro"].ToString();

            List<Reporte> reportes = new List<Reporte>();

            if (!IsPostBack)
            {
                switch (Tipo)
                {
                    case "Hoy":
                        foreach (var item in listaReporte)
                        {
                            r = new Reporte();
                            if (item.FechaHoraGenerado.Date == fechaActual)
                            {
                                r.NombreApellidoMesero = item.NombreApellidoMesero;
                                r.IdMesero = item.IdMesero;
                                r.NumeroMesaParaMesero = item.NumeroMesaParaMesero;
                                r.FechaHoraGenerado = item.FechaHoraGenerado;
                                r.Precio = item.Precio;
                                r.CantidadPedidos = item.CantidadPedidos;
                                reportes.Add(r);
                            }
                        }
                    break;

                    case "Este mes":
                        foreach (var item in listaReporte)
                        {
                            r = new Reporte();
                            if (item.FechaHoraGenerado.Month == DateTime.Now.Month)
                            {
                                r.NombreApellidoMesero = item.NombreApellidoMesero;
                                r.IdMesero = item.IdMesero;
                                r.NumeroMesaParaMesero = item.NumeroMesaParaMesero;
                                r.FechaHoraGenerado = item.FechaHoraGenerado;
                                r.Precio = item.Precio;
                                r.CantidadPedidos = item.CantidadPedidos;
                                reportes.Add(r);
                            }
                        }
                    break;

                    case "Este año":
                        foreach (var item in listaReporte)
                        {
                            r = new Reporte();
                            if (item.FechaHoraGenerado.Year == DateTime.Now.Year)
                            {
                                r.NombreApellidoMesero = item.NombreApellidoMesero;
                                r.IdMesero = item.IdMesero;
                                r.NumeroMesaParaMesero = item.NumeroMesaParaMesero;
                                r.FechaHoraGenerado = item.FechaHoraGenerado;
                                r.Precio = item.Precio;
                                r.CantidadPedidos = item.CantidadPedidos;
                                reportes.Add(r);
                            }
                        }
                    break;
                }

                Session["ReportesMesero"] = listaReporte;

                idRep.DataSource = reportes;
                idRep.DataBind();
            }
        }
    }
}