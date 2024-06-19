using System;
using System.Collections.Generic;
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
                    try
                    {
                        aux.Id = (int)datos.Lector["IdUsuario"];
                        aux.NombreUsuario = datos.Lector["Nombre"].ToString();
                        aux.Puesto = Convert.ToInt32(datos.Lector["Puesto"]);
                        aux.Activo = Convert.ToBoolean(datos.Lector["Activo"]);
                        aux.datos = new DatosPersonales
                        {
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString(),
                            Email = datos.Lector["Email"].ToString(),
                         //   Dni = Convert.ToInt32(datos.Lector["Dni"]),



                        };
                    }
                    catch (InvalidCastException ex)
                    {
                        // Manejar excepciones específicas para conversiones no válidas
                        Console.WriteLine("Error de conversión: " + ex.Message);
                        throw new Exception($"Error de conversión: {ex.Message}", ex);
                    }
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los usuarios: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void BajaLogica(Usuario usuario, bool activo = false)
        {
            AccesoDatos Accesodatos = new AccesoDatos();
            try
            {
                Accesodatos.setearProcedimiento("BajaLogicaUsuario");
                Accesodatos.SeterParametros("@IdUsuario", usuario.Id);
                Accesodatos.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inactivar el usuario: " + ex.Message, ex);
            }
            finally
            {
                Accesodatos.CerrarConexion();
            }
        }

        public void AltaLogica(Usuario usuario, bool activo = true)
        {
            AccesoDatos Accesodatos = new AccesoDatos();
            try
            {
                Accesodatos.setearProcedimiento("AltaLogicaUsuario");
                Accesodatos.SeterParametros("@IdUsuario", usuario.Id);
                Accesodatos.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar el usuario: " + ex.Message, ex);
            }
            finally
            {
                Accesodatos.CerrarConexion();
            }
        }
    }
}