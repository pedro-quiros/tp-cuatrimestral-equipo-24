﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class PedidoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();

            try
            {
                string consulta = "SELECT IdPedido, Estado, FechaHoraGenerado FROM Pedido";
                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido
                    {
                        IdPedido = (int)datos.Lector["IdPedido"],
                        Estado = (bool)datos.Lector["Estado"],
                        FechaHoraGenerado = (DateTime)datos.Lector["FechaHoraGenerado"]
                    };

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los pedidos", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

        public int CantidadPedidos(int idMesa)
        {
            try
            {
                datos.LimpiarParametros();
                datos.SetearConsulta(@"
                    SELECT COUNT(IdPedido) AS CANTIDAD_PEDIDOS
                    FROM Pedido
                    WHERE IdMesa = @idMesa
                    GROUP BY IdMesa");
                datos.SeterParametros("@idMesa", idMesa);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["CANTIDAD_PEDIDOS"];
                }

                return -1;  // Indica que no se encontraron pedidos para la mesa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los pedidos", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public decimal TotalPedidos(int idMesa)
        {
            try
            {
                datos.LimpiarParametros();
                datos.SetearConsulta(@"
                    SELECT SUM(Total) AS TOTAL_PEDIDOS
                    FROM Pedido
                    WHERE IdMesa = @idMesa
                    GROUP BY IdMesa");
                datos.SeterParametros("@idMesa", idMesa);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (decimal)datos.Lector["TOTAL_PEDIDOS"];
                }

                return 0;  // Si no hay pedidos, el total es 0
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular el total de los pedidos", ex);
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
                datos.LimpiarParametros();
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

        public List<Mesas> ListarMesas()
        {
            List<Mesas> lista = new List<Mesas>();

            try
            {
                datos.LimpiarParametros();
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

        public void InsertarPedido(DateTime fechaHora, decimal total, int idMesa)
        {
            try
            {
                datos.LimpiarParametros();
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
                datos.LimpiarParametros();
                string consulta = @"
                    INSERT INTO ItemPedido (IdPedido, IdInsumo, Cantidad, PrecioUnitario)
                    VALUES (@IdPedido, @IdInsumo, @Cantidad, @PrecioUnitario)";

                datos.SetearConsulta(consulta);
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

        public void ActualizarStockInsumo(int idInsumo, int cantidad)
        {
            try
            {
                datos.LimpiarParametros();
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
            try
            {
                datos.LimpiarParametros();
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
                datos.LimpiarParametros();
                string consulta = @"
                    INSERT INTO Pedido (IdMesa, FechaHoraGenerado, Estado, Total)
                    VALUES (@IdMesa, @FechaHoraGenerado, @Estado, @Total);
                    SELECT SCOPE_IDENTITY() AS IdPedido";

                datos.SetearConsulta(consulta);
                datos.SeterParametros("@FechaHoraGenerado", fechaHora);
                datos.SeterParametros("@Total", totalPedido);
                datos.SeterParametros("@IdMesa", idMesa);
                datos.SeterParametros("@Estado", 1);  // Estado 1 representa "Abierto"
                datos.ejecutarLectura();
                datos.Lector.Read();
                int idPedido = Convert.ToInt32(datos.Lector["IdPedido"]);
                datos.CerrarConexion();
                return idPedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pedido: " + ex.Message);
            }
        }

        public List<ItemPedido> ListarItemsPedido(int idPedido)
        {
            List<ItemPedido> lista = new List<ItemPedido>();

            try
            {
                datos.LimpiarParametros();
                string consulta = @"
                    SELECT i.IdInsumo, i.Nombre, ip.Cantidad, ip.PrecioUnitario
                    FROM ItemPedido ip
                    INNER JOIN Insumo i ON ip.IdInsumo = i.IdInsumo
                    WHERE ip.IdPedido = @IdPedido";

                datos.SetearConsulta(consulta);
                datos.SeterParametros("@IdPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Precio = (decimal)datos.Lector["PrecioUnitario"]
                    };

                    ItemPedido item = new ItemPedido
                    {
                        Insumo = insumo,
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"]
                    };

                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los ítems del pedido", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

        public List<ItemPedido> ObtenerItemsDePedido(int idMesa)
        {
            List<ItemPedido> lista = new List<ItemPedido>();

            try
            {
                datos.LimpiarParametros();
                datos.setearProcedimiento("ObtenerItemsDePedido");
                datos.SeterParametros("@IdMesa", idMesa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Insumo insumo = new Insumo
                    {
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Stock = (int)datos.Lector["Stock"]
                    };

                    ItemPedido item = new ItemPedido
                    {
                        Insumo = insumo,
                        Cantidad = (int)datos.Lector["Cantidad"]
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
