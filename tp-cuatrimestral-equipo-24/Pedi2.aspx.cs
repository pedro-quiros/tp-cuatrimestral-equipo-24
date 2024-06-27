using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el número de mesa desde la URL
                if (Request.QueryString["mesa"] != null)
                {
                    string numeroMesa = Request.QueryString["mesa"];
                    numeroMesaLabel.Text = numeroMesa; // Asignar el número de mesa al control correspondiente
                }

                // Instanciar el negocio de insumos y obtener la lista de insumos
                InsumosNegocio negocioInsumos = new InsumosNegocio();
                List<Insumo> listaInsumos = negocioInsumos.ListarConSp();

                // Mostrar los insumos en el GridView
                GridView1.DataSource = listaInsumos;
                GridView1.DataBind();
            }
        }
        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Insumo> ListaFiltrada = new List<Insumo>();

            if (Session["Listado"] != null && Session["Listado"] is List<Insumo>)
            {
                if (Filtro.Text == "")
                {
                    ListaFiltrada = (List<Insumo>)Session["Listado"];
                }
                else
                {
                    ListaFiltrada = ((List<Insumo>)Session["Listado"]).FindAll(X => X.Nombre.ToUpper().Contains(Filtro.Text.ToUpper()));
                }
            }
            else
            {
                InsumosNegocio insumo = new InsumosNegocio();
                ListaFiltrada = insumo.ListarConSp();
                Session["Listado"] = ListaFiltrada;
            }
            GridView1.DataSource = ListaFiltrada;
            GridView1.DataBind();
        }

        // Clase de ejemplo para productos
        public class Producto
        {
            public string Productox { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
        }
    }
}
