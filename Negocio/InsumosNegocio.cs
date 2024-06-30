using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class InsumosNegocio
    {

        public List<Insumo> ListarConSpInsumo()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarInsumos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo aux = new Insumo();

                    aux.IdInsumo = Convert.ToInt32(datos.Lector["IdInsumo"]);
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Tipo = datos.Lector["Tipo"].ToString();
                    aux.Stock = Convert.ToInt32(datos.Lector["Stock"]);
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.UrlImagen = datos.Lector["UrlImagen"].ToString();
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]);

                    lista.Add(aux); // Agregar el insumo a la lista dentro del bucle
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los insumos: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista; // Retornar la lista completa fuera del bucle
        }
        public void ModificarConSpInsumo(Insumo nuevoInsumo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificarInsumo");
                datos.SeterParametros("@IdInsumo", nuevoInsumo.IdInsumo);
                datos.SeterParametros("@Nombre", nuevoInsumo.Nombre);
                datos.SeterParametros("@Tipo", nuevoInsumo.Tipo);
                datos.SeterParametros("@Precio", nuevoInsumo.Precio);
                datos.SeterParametros("@Stock", nuevoInsumo.Stock);
                datos.SeterParametros("@UrlImagen", nuevoInsumo.UrlImagen);
                datos.SeterParametros("@Descripcion", nuevoInsumo.Descripcion);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el insumo: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Insumo> ListarConSp2()
        {
            List<Insumo> lista = new List<Insumo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT IdInsumo, Nombre, Tipo, Precio, Stock,descripcion,UrlImagen FROM Insumo";


                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Insumo aux = new Insumo();

                    aux.IdInsumo = (int)datos.Lector["IdInsumo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Tipo = (string)datos.Lector["Tipo"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];


                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Modificar2(Insumo nuevoInsumo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearConsulta("Update Insumo set Nombre = @nombre, Tipo = @tipo, Precio = @precio, Stock = @stock, UrlImagen = @urlImagen, Descripcion = @descripcion  where IdInsumo = @Id");
                datos.SeterParametros("@Id", nuevoInsumo.IdInsumo);
                datos.SeterParametros("@nombre", nuevoInsumo.Nombre);
                datos.SeterParametros("@tipo", nuevoInsumo.Tipo);
                datos.SeterParametros("@precio", nuevoInsumo.Precio);
                datos.SeterParametros("@stock", nuevoInsumo.Stock);
                datos.SeterParametros("@urlImagen", nuevoInsumo.UrlImagen);
                datos.SeterParametros("@descripcion", nuevoInsumo.Descripcion);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarArticulo(Insumo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Insumo (Nombre, Tipo, Precio, Stock, UrlImagen, Descripcion) VALUES (@nombre , @tipo, @precio, @stock, @urlImagen, @descripcion)");

                datos.SeterParametros("@nombre", nuevo.Nombre);
                datos.SeterParametros("@tipo", nuevo.Tipo);
                datos.SeterParametros("@precio", nuevo.Precio);
                datos.SeterParametros("@stock", nuevo.Stock);
                datos.SeterParametros("@urlImagen", nuevo.UrlImagen);
                datos.SeterParametros("@descripcion", nuevo.Descripcion);

                datos.EjecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from Insumo where IdInsumo = @id");
                datos.SeterParametros("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }




    }
    }
