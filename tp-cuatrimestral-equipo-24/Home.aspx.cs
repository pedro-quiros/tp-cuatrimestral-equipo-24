using Negocio;
using System.Web.UI.WebControls;
using System;
using Dominio;
using System.Collections.Generic;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PermisoHelper.VerificarPermisoGerente(Session);
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
            List<Usuario> ListaUsuarios = UsuarioG.ListarConSpUsuario();
            Session["Listado"] = ListaUsuarios;
            dgvUsuario.DataSource = ListaUsuarios;
            dgvUsuario.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {

            List<Usuario> ListaFiltrada = new List<Usuario>();

            if (Session["ListadoUsuarios"] != null && Session["ListadoUsuarios"] is List<Usuario>)
            {
                if (Filtro.Text == "")
                {
                    ListaFiltrada = (List<Usuario>)Session["ListadoUsuarios"];
                }
                else
                {
                    ListaFiltrada = ((List<Usuario>)Session["ListadoUsuarios"]).FindAll(X => X.NombreUsuario.ToUpper().Contains(Filtro.Text.ToUpper()));
                }
            }
            else
            {
                UsuarioGestion usuarioG = new UsuarioGestion();
                ListaFiltrada = usuarioG.ListarConSpUsuario();
                Session["ListadoUsuarios"] = ListaFiltrada;
            }
            dgvUsuario.DataSource = ListaFiltrada;
            dgvUsuario.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioRegistro.aspx");
        }
    }

}
