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
    public partial class Usuario : System.Web.UI.Page
    {
        List<Usuario> listaUsuario = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioGestion usuarioGest = new UsuarioGestion();
                Usuario usu = new Usuario();

                if (Session["Listado"] != null)
                {
                    listaUsuario = (List<Usuario>)Session["Listado"];
                }
                try
                {
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["IdUsuario"]);
                        foreach (Usuario item in listaUsuario)
                        {
                            if (id == item.Id)
                            {
                                usu = item;
                            }
                        }

                        txtNombre.Value = usu.;
                        txtTipo.Value = insu.Tipo;
                        txtPrecio.Value = insu.Precio.ToString();
                        txtStock.Value = insu.Stock.ToString();
                        txtImagen.Value = insu.UrlImagen.ToString();
                        txtDescripcion.Value = insu.Descripcion;
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