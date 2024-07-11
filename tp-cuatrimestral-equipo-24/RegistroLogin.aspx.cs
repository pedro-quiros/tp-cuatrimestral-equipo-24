using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace tp_cuatrimestral_equipo_24
{
    public partial class RegistroLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    Response.Write("<script>alert('Por favor, complete el Email del usuario.');</script>");
                }
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del usuario.');</script>");
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Response.Write("<script>alert('Por favor, Introduzca una contraseña.');</script>");
                }

                usuario.Email = txtEmail.Text;
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Clave = txtPassword.Text;
                switch (ddlPuesto.Text)
                {
                    case "Empleado":
                        usuario.Puesto = 1;
                        break;
                    case "Gerente":
                        usuario.Puesto = 2;
                        break;
                }
                usuario.Activo = true;
                usuario.Dni = int.Parse(txtdni.Text);
                usuario.Nombre= txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Nacimiento = DateTime.Parse((txtnacimiento.Text));
                usuario.Genero = ddlGenero.Text;
                usuario.Telefono = int.Parse(txttelefono.Text);
                usuario.Domicilio = txtdomicilio.Text;                            

                

                UsuarioGestion gestionUsuario = new UsuarioGestion();

                gestionUsuario.AgregarUsuarioLogin(usuario);
                Response.Redirect("Home.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }

        }
    }
}


