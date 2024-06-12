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
    public partial class Menu : System.Web.UI.Page
    {
        public List<Insumo> ListaInsumos = new List<Insumo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsumosNegocio insumo = new InsumosNegocio();
                ListaInsumos = insumo.ListarConSp();
                Session["Listado"] = ListaInsumos;
                idRep.DataSource = ListaInsumos;
                idRep.DataBind();
            }
        }
    }
}