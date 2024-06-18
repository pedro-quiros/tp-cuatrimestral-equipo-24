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

                if (Session["Listado"] != null)
                {
                    listaUsu = (List<Usuario>)Session["Listado"];
                }
                else
                {
                    // Cargar la lista de usuarios si no está en la sesión
                    listaUsu = usuarioGest.ListarConSpUsuario();
                    Session["Listado"] = listaUsu;
                }

                try
                {
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                        Usuario usu = listaUsu.Find(u => u.Id == id);

                        if (usu != null)
                        {
                            txtId.Text = usu.Id.ToString();
                            txtUsuario.Value = usu.NombreUsuario;
                        }
                        else
                        {
                            Response.Write("<script>alert('Usuario no encontrado.');</script>");
                        }
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
                int idUsuario = Convert.ToInt32(txtId.Text); // Obtener Id del usuario desde txtId
                UsuarioGestion usuario = new UsuarioGestion();

                // Crear un objeto Usuario con el Id
                Usuario usu = new Usuario();
                usu.Id = idUsuario;
                usuario.BajaLogica(usu); // Pasar el objeto Usuario al método BajaLogica
                
                    Response.Redirect("Home.aspx");
                

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

    }
}
