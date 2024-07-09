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
    public partial class Detalle_Reseñas : System.Web.UI.Page
    {
        public List<Reseña> ListaRese = new List<Reseña>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientesGestion client = new ClientesGestion();
                ListaRese = client.ListarParaReseña();
                Session["Listado"] = ListaRese;
                idRep.DataSource = ListaRese;
                idRep.DataBind();

                var (Positivo, Negativo) = client.ContadorReseña();
                lblPositivas.Text = Positivo.ToString();
                lblNegativas.Text = Negativo.ToString();
            }

        }
    }
}