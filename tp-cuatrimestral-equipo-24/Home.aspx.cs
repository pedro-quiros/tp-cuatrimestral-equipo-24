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
                Usuario usuario = new Usuario();
                string nombreCompleto;
                int p = 0;
                if (Session["UsuarioSeleccionado"] != null)
                {
                    usuario = (Usuario)Session["UsuarioSeleccionado"];
                    nombreCompleto = string.Concat("Bienvenido ", usuario.NombreUsuario, "!");
                    lblMensaje.Text = nombreCompleto;
                    if (Session["Puesto"] != null)
                    {
                        p = Convert.ToInt32(Session["Puesto"]);
                        switch (p)
                        {
                            case 1:
                                lblPuesto.Text = "Usted ingreso como Empleado";
                            break;

                            case 2:
                                lblPuesto.Text = "Usted ingreso como Gerente";
                            break;
                        }
                    }
                }
            }
        }
    }

}
