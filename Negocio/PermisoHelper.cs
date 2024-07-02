using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Negocio
{
    public static class PermisoHelper
    {
        public static bool EsGerente(HttpSessionState session)
        {
            if (session["UsuarioSeleccionado"] != null)
            {
                Usuario usuario = (Usuario)session["UsuarioSeleccionado"];
                return usuario.tipoUsuario == TipoUsuario.GERENTE;
            }
            return false;
        }
        public static void VerificarPermisoGerente(HttpSessionState session)
        {
            if (!EsGerente(session))
            {
                HttpContext.Current.Response.Redirect("Error.aspx");
            }
        }

    }
}
