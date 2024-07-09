using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class PedidoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select IdPedido, Estado, FechaHoraCreado from Pedido";


                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.FechaHoraGenerado = (DateTime)datos.Lector["FechaHoraCreado"];

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

        

        public int CantidadPedidos(int idMesa)
        {
            int cantPed;
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.SetearConsulta("select COUNT(IdPedido) AS CANTIDAD_PEDIDOS, IdMesa from Pedido WHERE IdMesa = @idMesa" +
                                     " GROUP BY IdMesa" +
                                     " ORDER BY COUNT(IdPedido)");
                datos.SeterParametros("@idMesa", idMesa);
                datos.EjecutarAccion();
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    cantPed = (int)datos.Lector["CANTIDAD_PEDIDOS"];
                    return cantPed;
                }
                return -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public decimal TotalPedidos(int idMesa)
        {
            decimal TotalPed;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select SUM(Total) AS TOTAL_PEDIDOS, IdMesa from Pedido WHERE IdMesa = 1" +
                                     " GROUP BY IdMesa" +
                                     " ORDER BY SUM(Total)");
                datos.SeterParametros("@idMesa", idMesa);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TotalPed = (decimal)datos.Lector["TOTAL_PEDIDOS"];
                    return TotalPed;
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public List<Insumo> ListarInsumos()
        {
            List<Insumo> lista = new List<Insumo>();

            try
            {
                datos.setearProcedimiento("SP_ListarInsumos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Stock = (int)datos.Lector["Stock"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Tipo = (string)datos.Lector["Tipo"],  // Asegúrate de que 'Tipo' sea un campo en tu base de datos
                        Descripcion = datos.Lector["Descripcion"] as string,  // Si puede ser nulo
                        UrlImagen = datos.Lector["UrlImagen"] as string  // Si puede ser nulo
                    };

                    lista.Add(insumo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar insumos", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

        // Método para listar mesas
        public List<Mesas> ListarMesas()
        {
            List<Mesas> lista = new List<Mesas>();

            try
            {
                datos.setearProcedimiento("SP_ListarMesas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesas mesa = new Mesas
                    {
                        IdMesa = (int)datos.Lector["IdMesa"],
                        Numero = (int)datos.Lector["Numero"],
                        Estado = (bool)datos.Lector["Estado"]
                    };

                    lista.Add(mesa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar mesas", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }


        // Método para insertar un pedido
        public void InsertarPedido(DateTime fechaHora, decimal total, int idMesa)
        {
            try
            {
                datos.setearProcedimiento("InsertarPedido");
                datos.SeterParametros("@FechaHora", fechaHora);
                datos.SeterParametros("@Total", total);
                datos.SeterParametros("@IdMesa", idMesa);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar pedido", ex);
            }
        }

        public void AgregarItemPedido(int idPedido, int idInsumo, int cantidad, decimal precioUnitario)
        {
            try
            {
                datos.setearProcedimiento("SP_AgregarItemPedido");
                datos.SeterParametros("@IdPedido", idPedido);
                datos.SeterParametros("@IdInsumo", idInsumo);
                datos.SeterParametros("@Cantidad", cantidad);
                datos.SeterParametros("@PrecioUnitario", precioUnitario);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el ítem al pedido: " + ex.Message);
            }
        }


        // Método para actualizar el stock de un insumo
        public void ActualizarStockInsumo(int idInsumo, int cantidad)
        {
            try
            {
                datos.setearProcedimiento("ActualizarStockInsumo");
                datos.SeterParametros("@IdInsumo", idInsumo);
                datos.SeterParametros("@Cantidad", cantidad);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar stock del insumo", ex);
            }
        }

        public void CerrarPedido(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "UPDATE Pedido SET Estado = 1 WHERE IdPedido = @IdPedido";
                datos.SetearConsulta(consulta);
                datos.SeterParametros("@IdPedido", idPedido);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar el pedido: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public int CrearPedido(DateTime fechaHora, decimal totalPedido, int idMesa)
        {
            try
            {
                // Definir la consulta SQL para insertar un nuevo pedido
                string consulta = @"
            INSERT INTO Pedido (IdMesa, FechaHoraGenerado, Estado, Total)
            VALUES (@IdMesa, @FechaHoraGenerado, @Estado, @Total);
            SELECT SCOPE_IDENTITY() AS IdPedido;";

                // Configurar la consulta y establecer los parámetros
                datos.SetearConsulta(consulta);
                datos.SeterParametros("@FechaHoraGenerado", fechaHora);
                datos.SeterParametros("@Total", totalPedido);
                datos.SeterParametros("@IdMesa", idMesa);
                datos.SeterParametros("@Estado", 1);  // Estado 1 representa "Abierto"

                // Ejecutar la consulta e identificar el nuevo IdPedido generado
                datos.ejecutarLectura();
                datos.Lector.Read();
                int idPedido = Convert.ToInt32(datos.Lector["IdPedido"]);
                datos.CerrarConexion();

                // Retornar el IdPedido generado
                return idPedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pedido: " + ex.Message);
            }
        }

        //public int CrearPedido(DateTime fechaHora, decimal totalPedido, int idMesa)
        //{
        //    try
        //    {
        //        datos.setearProcedimiento("SP_CrearPedido");
        //        datos.SeterParametros("@FechaHoraGenerado", fechaHora);
        //        datos.SeterParametros("@Total", totalPedido);
        //        datos.SeterParametros("@IdMesa", idMesa);
        //        datos.SeterParametros("@Estado", 1);  // Estado 1 representa "Abierto"
        //        datos.EjecutarAccion();

        //        // Obtener el IdPedido generado
        //        datos.SetearConsulta("SELECT SCOPE_IDENTITY()");

        //        datos.Lector.Read();
        //        int idPedido = Convert.ToInt32(datos.Lector["IdPedido"]);
        //        datos.CerrarConexion();

        //        return idPedido;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al crear el pedido: " + ex.Message);
        //    }
        //}


        // Método para obtener los ítems de un pedido
        public List<ItemPedido> ObtenerItemsDePedido(int idMesa)
        {
            List<ItemPedido> lista = new List<ItemPedido>();

            try
            {
                datos.setearProcedimiento("ObtenerItemsDePedido");
                datos.SeterParametros("@IdMesa", idMesa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Nombre = (string)datos.Lector["Nombre"],  // Asegúrate de que tu procedimiento almacene el nombre del insumo
                        Precio = (decimal)datos.Lector["Precio"],
                        Stock = (int)datos.Lector["Stock"]
                    };

                    ItemPedido item = new ItemPedido
                    {
                        Insumo = insumo,
                        Cantidad = (int)datos.Lector["Cantidad"],
                     //   Precio = (decimal)datos.Lector["Precio"]
                    };

                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener ítems de pedido", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

    }
}