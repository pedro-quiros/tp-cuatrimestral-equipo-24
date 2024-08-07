﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class ListadoUsuarios : System.Web.UI.Page
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

        protected void Filtro_TextChanged(object sender, EventArgs e)
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
            string Parametro = "Parametro";

            Response.Redirect("UsuarioRegistro.aspx?Parametro=" + Parametro, false);
        }
    }
}