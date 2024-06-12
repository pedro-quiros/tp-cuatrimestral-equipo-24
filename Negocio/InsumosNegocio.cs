using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class InsumosNegocio
    {
        //public List<Insumo> Listar()
        //{
        //    List<Insumo> listaArticulo = new List<Insumo>();
        //    AccesoDatos AccesoDatos = new AccesoDatos();
        //    try
        //    {
        //        AccesoDatos.SetearConsulta("");
        //        AccesoDatos.ejecutarLectura();

        //        while (AccesoDatos.Lector.Read())
        //        {
        //            Insumo aux = new Insumo();

        //            aux.id = (int)AccesoDatos.Lector["Id"];
        //            aux.Codigo = (string)AccesoDatos.Lector["Codigo"];
        //            aux.Nombre = (string)AccesoDatos.Lector["Nombre"];
        //            aux.descripcion = (string)AccesoDatos.Lector["Descripcion"];
        //            aux.Precio = (decimal)AccesoDatos.Lector["Precio"];


        //            Creamos un aux marca para poder cargar las columnas

        //            aux.idMarca = new Marca();
        //            aux.idMarca.Id = (int)AccesoDatos.Lector["IdMarca"];
        //            aux.idMarca.Descripcion = (string)AccesoDatos.Lector["DescripcionMarca"];

        //            Creamos un aux categoria para poder cargar las columnas

        //            aux.idCategoria = new Categoria();
        //            if (AccesoDatos.Lector["DescripcionCate"] is DBNull && AccesoDatos.Lector["Idcategoria"] is DBNull)
        //            {
        //                aux.idCategoria.Descripcion = "Sin descripcion";
        //                aux.idCategoria.Id = 0;
        //            }
        //            else
        //            {

        //                aux.idCategoria.Id = (int)AccesoDatos.Lector["Idcategoria"];
        //                aux.idCategoria.Descripcion = (string)AccesoDatos.Lector["DescripcionCate"];
        //            }


        //            aux.IdImagenUrl = new Imagenes();
        //            if (AccesoDatos.Lector["ImagenURL"] is DBNull && AccesoDatos.Lector["IdImg"] is DBNull)
        //            {
        //                aux.IdImagenUrl.id = 0;
        //                aux.IdImagenUrl.ImagenURL = "";
        //            }
        //            else
        //            {

        //                aux.IdImagenUrl.id = (int)AccesoDatos.Lector["IdImg"];
        //                aux.IdImagenUrl.ImagenURL = (string)AccesoDatos.Lector["ImagenUrl"];
        //            }


        //            listaArticulo.Add(aux);

        //        }


        //        AccesoDatos.CerrarConexion();
        //        return listaArticulo;


        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}
        public List<Insumo> ListarConSp()
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



        public void Modificar(Insumo nuevoInsumo)
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






            //public void Agregar(Insumo nuevoarticulo)
            //{
            //    AccesoDatos Accesodatos = new AccesoDatos();
            //    try
            //    {

            //        Accesodatos.setearConsulta("Insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
            //        Accesodatos.setearParametros("@Codigo", nuevoarticulo.Codigo);
            //        Accesodatos.setearParametros("@Nombre", nuevoarticulo.Nombre);
            //        Accesodatos.setearParametros("@Descripcion", nuevoarticulo.descripcion);
            //        Accesodatos.setearParametros("@IdMarca", nuevoarticulo.idMarca.Id);
            //        Accesodatos.setearParametros("@IdCategoria", nuevoarticulo.idCategoria.Id);
            //        Accesodatos.setearParametros("@Precio", nuevoarticulo.Precio);
            //        Accesodatos.ejecutarAccion();

            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }
            //    finally
            //    {
            //        Accesodatos.CerrarConexion();


            //    }





            //}
            //public void Modificar(Insumo nuevoarticulo)
            //{
            //    AccesoDatos Accesodatos = new AccesoDatos();
            //    try
            //    {

            //        Accesodatos.setearConsulta("Update ARTICULOS set Codigo = @Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,Precio=@Precio where Id = @Id");
            //        Accesodatos.setearParametros("@Id", nuevoarticulo.id);
            //        Accesodatos.setearParametros("@Codigo", nuevoarticulo.Codigo);
            //        Accesodatos.setearParametros("@Nombre", nuevoarticulo.Nombre);
            //        Accesodatos.setearParametros("@Descripcion", nuevoarticulo.descripcion);
            //        Accesodatos.setearParametros("@IdMarca", nuevoarticulo.idMarca.Id);
            //        Accesodatos.setearParametros("@IdCategoria", nuevoarticulo.idCategoria.Id);
            //        Accesodatos.setearParametros("@Precio", nuevoarticulo.Precio);
            //        Accesodatos.ejecutarAccion();

            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }
            //    finally
            //    {
            //        Accesodatos.CerrarConexion();


            //    }





            //}
            //public void BajaLogica(Insumo nuevoarticulo)
            //{
            //    AccesoDatos Accesodatos = new AccesoDatos();
            //    try
            //    {

            //        Accesodatos.SetearConsulta("Update ARTICULOS set Precio= -1 where Id = @Id");
            //        Accesodatos.SeterParametros("@Id", nuevoarticulo.id);
            //        Accesodatos.EjecutarConsulta();

            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }
            //    finally
            //    {
            //        Accesodatos.CerrarConexion();
            //    }
            //}
            //public List<Insumo> FiltrarArticulos(string campo, string criterio, string filtro)
            //{
            //    List<Insumo> lista = new List<Insumo>();
            //    AccesoDatos datos = new AccesoDatos();

            //    try
            //    {
            //        string consulta = "select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left join CATEGORIAS C on C.Id = A.IdCategoria left join IMAGENES I on I.IdArticulo = A.Id where Precio > 0 and ";
            //        if (campo == "Precio.")
            //        {
            //            switch (criterio)
            //            {
            //                case "Mayor a..":
            //                    consulta += "Precio > @Precio";
            //                    break;
            //                case "Menor a..":
            //                    consulta += "Precio < @Precio";
            //                    break;
            //                default:
            //                    consulta += "Precio = @Precio";
            //                    break;
            //            }
            //            datos.SeterParametros("@Precio", Convert.ToDecimal(filtro));
            //        }
            //        else if (campo == "Nombre.")
            //        {
            //            switch (criterio)
            //            {
            //                case "comienza con..":
            //                    consulta += "Nombre like @Filtro + '%'";
            //                    break;
            //                case "Termina con..":
            //                    consulta += "Nombre like '%' + @Filtro";
            //                    break;
            //                default:
            //                    consulta += "Nombre like '%' + @Filtro + '%'";
            //                    break;
            //            }
            //            datos.SeterParametros("@Filtro", filtro);
            //        }

            //        datos.SetearConsulta(consulta);
            //        datos.ejecutarLectura();
            //        while (datos.Lector.Read())
            //        {
            //            Insumo aux = new Insumo();

            //            aux.id = (int)datos.Lector["id"];
            //            aux.Codigo = (string)datos.Lector["Codigo"];
            //            aux.Nombre = (string)datos.Lector["Nombre"];
            //            aux.descripcion = (string)datos.Lector["Descripcion"];

            //            // para poder cargar IdMarca

            //            aux.idMarca = new Marca();
            //            aux.idMarca.Id = (int)datos.Lector["IdMarca"];
            //            aux.idMarca.Descripcion = (string)datos.Lector["DescripcionMarca"];

            //            //Creamos un aux categoria para poder cargar las columnas

            //            aux.idCategoria = new Categoria();
            //            if (datos.Lector["DescripcionCate"] is DBNull && datos.Lector["Idcategoria"] is DBNull)
            //            {
            //                aux.idCategoria.Descripcion = "Sin descripcion";
            //                aux.idCategoria.Id = 0;
            //            }
            //            else
            //            {

            //                aux.idCategoria.Id = (int)datos.Lector["Idcategoria"];
            //                aux.idCategoria.Descripcion = (string)datos.Lector["DescripcionCate"];
            //            }


            //            // me aseguro que no sea nulo
            //            aux.IdImagenUrl = new Imagenes();
            //            if (datos.Lector["ImagenURL"] is DBNull && datos.Lector["IdImg"] is DBNull)
            //            {
            //                aux.IdImagenUrl.id = 0;
            //                aux.IdImagenUrl.ImagenURL = "";
            //            }
            //            else
            //            {

            //                aux.IdImagenUrl.id = (int)datos.Lector["IdImg"];
            //                aux.IdImagenUrl.ImagenURL = (string)datos.Lector["ImagenUrl"];
            //            }



            //            aux.Precio = (decimal)datos.Lector["Precio"];
            //            lista.Add(aux);
            //        }
            //        return lista;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            //public void BajaFisica(Insumo bajaFisica)
            //{
            //    AccesoDatos datos = new AccesoDatos();

            //    try
            //    {
            //        datos.setearConsulta("delete from articulos where id = @id");
            //        datos.setearParametros("@id", bajaFisica.id);
            //        datos.ejecutarAccion();

            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }
    }
