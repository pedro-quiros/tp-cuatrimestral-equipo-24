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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioGestion UsuGesti = new UsuarioGestion();
            try
            {
                usuario = new Usuario(txtnombre.Text, txtpassword.Text, false);
                if (UsuGesti.Loguear(usuario))
                {
                    Session.Add("UsuarioSeleccionado", usuario);
                    Response.Redirect("Home.aspx",false);
                }
                else 
                {
                    Session.Add("Error", "User o pass Incorrecto");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception Ex)
            {
                Session.Add("Error",Ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnRecuperarPass_Click(object sender, EventArgs e)
        {

            Response.Redirect("Soporte.aspx");
        }
    }
}