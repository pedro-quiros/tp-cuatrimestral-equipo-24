using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo_24
{
    public partial class ModificarInsumo : System.Web.UI.Page
    {
        List<Insumo> listaInsumos;
        protected void Page_Load(object sender, EventArgs e)
        {
            InsumoNegocios negocio = new InsumoNegocios();
            List<Insumo> listaInsu = new List<Insumo>();
            Insumo insu = new Insumo();

            if (Session["Listado"] != null)
            {
                listaInsu = (List<Insumo>)Session["Listado"];
            }
            try
            {
                if (Request.QueryString["IdInsumo"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["IdInsumo"]);
                    foreach (Insumo item in listaInsu)
                    {
                        if (id == item.IdInsumo)
                        {
                            insu = item;
                        }
                    }

                    txtnombre.Text = insu.Nombre;
                    txtTipo.Text = insu.Tipo;
                    txtPrecio.Text = insu.Precio.ToString();
                    txtStock.Text = insu.Stock.ToString();
                    txtImagen.Text = insu.UrlImagen.ToString();
                    txtDescripcion.Text = insu.Descripcion;

                    //repDetalle.DataSource = insu.UrlImagen;
                    //repDetalle.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}