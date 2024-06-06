using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using Dominio;
using Negocio;

namespace TP2_WinForm.Negocio
{
    public class ArticulosNegocio
    {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
        public ArticulosNegocio()
        {
            conexion= new SqlConnection("server= .\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando= new SqlCommand("");
        }
        public List<Articulos> ListarArticulos()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN IMAGENES I ON A.Id = I.IdArticulo");
               
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];


                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marcas.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marcas.Descripcion = "";
                    }

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categorias.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categorias.Descripcion = "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542";
                    }


                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    }
                    else
                    {

                    }

                    lista.Add(aux);
                }
                return lista;
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

        public List<Articulos> ListarArticulosConProcedimiento()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //  datos.SetearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.setearProcedimiento("storedListarArticulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];


                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marcas.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marcas.Descripcion = "";
                    }

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categorias.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categorias.Descripcion = "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542";
                    }


                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    }
                    else
                    {

                    }

                    lista.Add(aux);
                }
                return lista;
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

        public void AgregarArticulo(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
                                        
                datos.SeterParametros("@Codigo", nuevo.CodArticulo);
                datos.SeterParametros("@Nombre", nuevo.Nombre);
                datos.SeterParametros("@Descripcion", nuevo.Descripcion);
                datos.SeterParametros("@IdMarca", nuevo.Marcas.IdMarca);
                datos.SeterParametros("@IdCategoria", nuevo.Categorias.IdCategoria);
                datos.SeterParametros("@Precio", nuevo.Precio);

                conexion.Close();
                datos.EjecutarAccion();
                    
             
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public void ModificarArticulo(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Update ARTICULOS set Codigo = @codarticulo, Nombre = @nombre, Descripcion = @descripcion, Precio = @precio Where Id = @id");
               
                datos.SeterParametros("@codarticulo", articulo.CodArticulo);
                datos.SeterParametros("@nombre", articulo.Nombre);
                datos.SeterParametros("@descripcion", articulo.Descripcion);
          
                datos.SeterParametros("@precio", articulo.Precio);
                datos.SeterParametros("@id", articulo.IdArticulo);
                
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

        public void ModificarCategoria (Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.SetearConsulta("Update ARTICULOS set IdCategoria = @idcategoria Where Id = @IdArticulo");

                datos.SeterParametros("@IdArticulo", articulo.IdArticulo);
                datos.SeterParametros("@idcategoria", articulo.Categorias.IdCategoria);

                datos.EjecutarAccion ();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion ();
            }
        }

        public void ModificarMarca (Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Update ARTICULOS set IdMarca = @idmarca Where Id = @IdArticulo");

                datos.SeterParametros("@idmarca", articulo.Marcas.IdMarca);
                datos.SeterParametros("@IdArticulo", articulo.IdArticulo);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion ();
            }
        }

        public void ModificarImagen (Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @Imagenurl WHERE Id = (SELECT TOP 1 Id FROM IMAGENES WHERE IdArticulo = @Idarticulo)");

                datos.SeterParametros("@Imagenurl", articulo.Imagen);
                datos.SeterParametros("@Idarticulo", articulo.IdArticulo);

                datos.EjecutarAccion ();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos .CerrarConexion ();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS  where id = @id");
                datos.SeterParametros("@id", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool verificadorDeCodigos(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            { 
                datos.SetearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @codArt");
                datos.SeterParametros("@codArt", codigo);
                datos.EjecutarConsulta();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex ;
            }
        

        }
        public void AgregarImagen(Articulos nuevoArticulo)
        {
            Articulos articulo = new Articulos();
            AccesoDatos datos = new AccesoDatos();
            articulo = ListarArticulos().Last();

            try
            {

                int idArticulo = articulo.IdArticulo;
                datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.SeterParametros("@IdArticulo", idArticulo);
                datos.SeterParametros("@ImagenUrl", nuevoArticulo.Imagen);

                conexion.Close();
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public List<Articulos> listaParaImagenes()
        {
            List<Articulos> listaArticulos = ListarArticulos();

            if (listaArticulos != null && listaArticulos.Count > 0)
            {
                Dictionary<string, Articulos> diccionarioArticulos = new Dictionary<string, Articulos>();

                foreach (var articulo in listaArticulos)
                {
                    if (!diccionarioArticulos.ContainsKey(articulo.CodArticulo))
                    {
                        diccionarioArticulos.Add(articulo.CodArticulo, articulo);
                        articulo.Imagenes = new List<string>();
                    }
                    diccionarioArticulos[articulo.CodArticulo].Imagenes.Add(articulo.Imagen);
                }

                List<Articulos> listaParaDgv = diccionarioArticulos.Values.ToList();
                return listaParaDgv;
            }
            else
            {
                return new List<Articulos>();
            }
        }
    }
}