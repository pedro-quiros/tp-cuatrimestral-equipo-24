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
                
                datos.setearProcedimiento("MostrarUsuario");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["IdUsuario"];
                    aux.NombreUsuario = (string)datos.Lector["Nombre"];
                    aux.Puesto = (int)datos.Lector["Puesto"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    //aux.Legajo = (int)datos.Lector["Legajo"];
                    //aux.Nombre = (string)datos.Lector["Nombre"];
                    //aux.Apellido = (string)datos.Lector["Apellido"];
                    //aux.Dni = (int)datos.Lector["Dni"];
                    //aux.Nacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    //aux.Genero = (char)datos.Lector["Genero"];
                    //aux.Telefono = (int)datos.Lector["Telefono"];
                    //aux.Email = (string)datos.Lector["Email"];
                    //aux.Domicilio = (string)datos.Lector["Domicilio"];
                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaLogica(Usuario usuario, bool activo = false)
        {
            AccesoDatos Accesodatos = new AccesoDatos();
            try
            {
                //Accesodatos.AbrirConexion();
                Accesodatos.setearProcedimiento("BajaLogicaUsuario");
                Accesodatos.SeterParametros("@IdUsuario", usuario.Id);
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
                Accesodatos.SeterParametros("@IdUsuario", Usuario.Id);
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