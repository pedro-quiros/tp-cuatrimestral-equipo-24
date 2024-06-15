using Dominio;
using Negocio;
using System;
using System.Collections.Generic;


namespace tp_cuatrimestral_equipo_24
{
    public partial class UsuarioRegistro : System.Web.UI.Page
    {
        List<Usuario> listaUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioGestion usuarioGest = new UsuarioGestion();
                List<Usuario> listaUsu = new List<Usuario>();
                Usuario usu = new Usuario();

                if (Session["Listado"] != null)
                {
                    listaUsu = (List<Usuario>)Session["Listado"];
                }
                try
                {
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                        foreach (Usuario item in listaUsu)
                        {
                            if (id == item.Id)
                            {
                                usu = item;
                            }
                        }
                        // txtId.Value = usu.Id.ToString();
                        txtId.Value = usu.Id.ToString();
                        txtNombre.Value = usu.NombreUsuario;




                    }

                }


                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }

        }


        protected void btnInactivo_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioGestion usuario = new UsuarioGestion();
                //usuario.BajaLogica(int.Parse(txtId));
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}