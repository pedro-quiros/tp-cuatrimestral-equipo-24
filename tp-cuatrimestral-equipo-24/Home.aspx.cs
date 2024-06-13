using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioGestion UsuarioG = new UsuarioGestion();   
            dgvUsuario.DataSource = UsuarioG.ListarConSpUsuario();
            dgvUsuario.DataBind();  
        }

        protected void dgvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuario.PageIndex = e.NewPageIndex;
            dgvUsuario.DataBind();
        }
        protected void dgvUsuario_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            string id = dgvUsuario.SelectedDataKey.Value.ToString();
            Response.Redirect("UsuarioRegistro.aspx?id=" + id);
        }

    }
}