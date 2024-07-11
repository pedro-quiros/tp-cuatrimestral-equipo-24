using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
                        aux.Id = datos.Lector["IdUsuario"] != DBNull.Value ? (int)datos.Lector["IdUsuario"] : 0;
                        aux.NombreUsuario = datos.Lector["NombreUsuario"] != DBNull.Value ? datos.Lector["NombreUsuario"].ToString() : string.Empty;
                        aux.Puesto = datos.Lector["Puesto"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Puesto"]) : 1;
                        aux.Activo = datos.Lector["Activo"] != DBNull.Value ? Convert.ToBoolean(datos.Lector["Activo"]) : true;
                        aux.Legajo = datos.Lector["Legajo"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Legajo"]) : 0;
                        aux.Nombre = datos.Lector["Nombre"] != DBNull.Value ? datos.Lector["Nombre"].ToString() : string.Empty;
                        aux.Apellido = datos.Lector["Apellido"] != DBNull.Value ? datos.Lector["Apellido"].ToString() : string.Empty;
                        aux.Email = datos.Lector["Email"] != DBNull.Value ? datos.Lector["Email"].ToString() : string.Empty;
                        aux.Dni = datos.Lector["Dni"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Dni"]) : 0;
                        aux.Telefono = datos.Lector["Telefono"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Telefono"]) : 0;

                        if (!(datos.Lector["FechaNacimiento"] is DBNull))
                            aux.Nacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                        aux.Genero = datos.Lector["Genero"] != DBNull.Value ? datos.Lector["Genero"].ToString() : string.Empty;
                        aux.Domicilio = datos.Lector["Domicilio"] != DBNull.Value ? datos.Lector["Domicilio"].ToString() : string.Empty;

                        //aux.Id = (int)datos.Lector["IdUsuario"];
                        //aux.NombreUsuario = datos.Lector["NombreUsuario"].ToString();
                        //aux.Puesto = Convert.ToInt32(datos.Lector["Puesto"]);
                        //aux.Activo = Convert.ToBoolean(datos.Lector["Activo"]);


                        //aux.Legajo = Convert.ToInt32(datos.Lector["Legajo"]);
                        //aux.Nombre = datos.Lector["Nombre"].ToString();
                        //aux.Apellido = datos.Lector["Apellido"].ToString();
                        //aux.Email = datos.Lector["Email"].ToString();
                        //aux.Dni = Convert.ToInt32(datos.Lector["Dni"]);
                        //aux.Telefono = Convert.ToInt32(datos.Lector["Telefono"]);

                        //if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        //aux.Nacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());

                        //aux.Genero = datos.Lector["Genero"].ToString();
                        //aux.Domicilio = datos.Lector["Domicilio"].ToString(); 

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
                Datos.setearProcedimiento("InsertarUsuario");
                Datos.SeterParametros("@NombreUsuario", usuario.NombreUsuario);
                Datos.SeterParametros("@Clave", usuario.Clave);
                Datos.SeterParametros("@Puesto", usuario.Puesto);
                Datos.SeterParametros("@Activo", usuario.Activo);
                Datos.SeterParametros("@Legajo", usuario.Legajo);
                Datos.SeterParametros("@DNI", usuario.Dni);
                Datos.SeterParametros("@Nombre", usuario.Nombre);
                Datos.SeterParametros("@Apellido", usuario.Apellido);
                Datos.SeterParametros("@Nacimiento", usuario.Nacimiento);
                Datos.SeterParametros("@Genero", usuario.Genero);
                Datos.SeterParametros("@Telefono", usuario.Telefono);
                Datos.SeterParametros("@Email", usuario.Email);
                Datos.SeterParametros("@Domicilio", usuario.Domicilio);

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
        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {

                Datos.SetearConsulta("Update Usuario2 set NombreUsuario = @NombreUsuario,Clave = @password,Puesto=@Puesto,Legajo=@Legajo,DNI=@DNI,Nombre=@Nombre ,Apellido = @Apellido,FechaNacimiento=@Nacimiento,genero=@genero,telefono=@Telefono,Email=@Email,domicilio=@domicilio WHERE IdUsuario = @IdUsuario");

                Datos.SeterParametros("@IdUsuario", usuario.Id);
                Datos.SeterParametros("@NombreUsuario", usuario.NombreUsuario);
                Datos.SeterParametros("@password", usuario.Clave);
                Datos.SeterParametros("@Puesto", usuario.Puesto);
                Datos.SeterParametros("@Legajo", usuario.Legajo);
                Datos.SeterParametros("@DNI", usuario.Dni);
                Datos.SeterParametros("@Nombre", usuario.Nombre);
                Datos.SeterParametros("@Apellido", usuario.Apellido);
                Datos.SeterParametros("@Nacimiento", usuario.Nacimiento);
                Datos.SeterParametros("@Genero", usuario.Genero);
                Datos.SeterParametros("@Telefono", usuario.Telefono);
                Datos.SeterParametros("@Email", usuario.Email);
                Datos.SeterParametros("@Domicilio", usuario.Domicilio);

                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar al Personal: " + ex.Message, ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select IdUsuario,Puesto from Usuario2 where NombreUsuario = @Nombreusuario and Clave = @clave");
                datos.SeterParametros("@Nombreusuario", usuario.NombreUsuario);
                datos.SeterParametros("@clave", usuario.Clave);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["IdUsuario"];
                    usuario.tipoUsuario = (int)(datos.Lector["Puesto"]) == 2 ? TipoUsuario.GERENTE : TipoUsuario.EMPLEADO;
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        public void AgregarUsuarioLogin(Usuario usuario)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearProcedimiento("InsertarusuarioLogin");
                Datos.SeterParametros("@Email", usuario.Email);
                Datos.SeterParametros("@NombreUsuario", usuario.NombreUsuario);
                Datos.SeterParametros("@Clave", usuario.Clave);

                Datos.SeterParametros("@Puesto", usuario.Puesto);
                Datos.SeterParametros("@Activo", usuario.Activo);
                Datos.SeterParametros("@Legajo", usuario.Legajo);
                Datos.SeterParametros("@DNI", usuario.Dni);
                Datos.SeterParametros("@Nombre", usuario.Nombre);
                Datos.SeterParametros("@Apellido", usuario.Apellido);
                Datos.SeterParametros("@Nacimiento", usuario.Nacimiento);
                Datos.SeterParametros("@Genero", usuario.Genero);
                Datos.SeterParametros("@Telefono", usuario.Telefono);
                Datos.SeterParametros("@Email", usuario.Email);
                Datos.SeterParametros("@Domicilio", usuario.Domicilio);

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