using Negocio;
using System.Web.UI.WebControls;
using System;


namespace tp_cuatrimestral_equipo_24
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarDatosGridView();
            }
        }

        protected void dgvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuario.PageIndex = e.NewPageIndex;
            CargarDatosGridView();
        }

        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvUsuario.SelectedDataKey.Value.ToString();
            Response.Redirect("UsuarioRegistro.aspx?IdUsuario=" + id);
        }

        private void CargarDatosGridView()
        {
            UsuarioGestion UsuarioG = new UsuarioGestion();
            dgvUsuario.DataSource = UsuarioG.ListarConSpUsuario();
            dgvUsuario.DataBind();
        }
    }
}
