using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioGestion
    {
        public List<Usuario> ListarConSpUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select U.IdUsuario,U.Nombre,U.Puesto,U.Activo from Usuarios U";

                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["Nombre"];
                    aux.Puesto = (int)datos.Lector["Puesto"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaLogica(Usuario Usuario)
        {
            AccesoDatos Accesodatos = new AccesoDatos();
            try
            {

                Accesodatos.setearProcedimiento("BajaLogicaUsuario");
                Accesodatos.SeterParametros("@Id", Usuario.Id);
                Accesodatos.EjecutarConsulta();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Accesodatos.CerrarConexion();
            }
        }

        public void AltaLogica(Usuario Usuario)
        {
            AccesoDatos Accesodatos = new AccesoDatos();
            try
            {

                Accesodatos.setearProcedimiento("AltaLogicaUsuario");
                Accesodatos.SeterParametros("@Id", Usuario.Id);
                Accesodatos.EjecutarConsulta();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Accesodatos.CerrarConexion();
            }
        }

    }
}