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
                        aux.NombreUsuario = datos.Lector["NombreUsuario"].ToString();
                        aux.Puesto = Convert.ToInt32(datos.Lector["Puesto"]);
                        aux.Activo = Convert.ToBoolean(datos.Lector["Activo"]);
                        aux.datos = new DatosPersonales
                        {
                            Legajo = Convert.ToInt32(datos.Lector["Legajo"]),
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Apellido = datos.Lector["Apellido"].ToString(),
                            Email = datos.Lector["Email"].ToString(),
                            Dni = datos.Lector["Dni"].ToString(),
                            Telefono = datos.Lector["Telefono"].ToString(),
                            Nacimiento = datos.Lector["FechaNacimiento"].ToString(),
                            Genero = datos.Lector["Genero"].ToString(),
                            Domicilio = datos.Lector["Domicilio"].ToString()
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
        public void AgregarUsuario(Usuario usuario)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearProcedimiento("AgregarUsuario");
                Datos.SeterParametros("@nombreusuario", usuario.NombreUsuario);
                Datos.SeterParametros("@clave", usuario.Clave);
                Datos.SeterParametros("@Puesto", usuario.Puesto);
                Datos.SeterParametros("@activo", usuario.Activo);

                usuario.datos = new DatosPersonales();
                {
                    Datos.SeterParametros("@Legajo", usuario.Legajo);
                    Datos.SeterParametros("@Dni", usuario.Dni);
                    Datos.SeterParametros("@Nombre", usuario.Nombre);
                    Datos.SeterParametros("@Apellido", usuario.Apellido);
                    Datos.SeterParametros("@Fechanacimiento", usuario.Nacimiento);
                    Datos.SeterParametros("@genero", usuario.Genero);
                    Datos.SeterParametros("@telefono", usuario.Telefono);
                    Datos.SeterParametros("@Email", usuario.Email);
                    Datos.SeterParametros("@domicilio", usuario.Domicilio);
                }

                     Datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Agregar el usuario: " + ex.Message, ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}