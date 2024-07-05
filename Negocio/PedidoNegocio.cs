﻿using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        // Método para listar insumos
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
                return lista;
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

        // Método para abrir o cerrar una mesa
        public void AbrirCerrarMesa(int idMesa)
        {
            try
            {
                datos.setearProcedimiento("SP_AbrirCerrarMesa");
                datos.SeterParametros("@IdMesa", idMesa);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir o cerrar mesa", ex);
            }
        }

        // Método para insertar un pedido
        public int CrearPedido(DateTime fechaHora, decimal total, int idMesa)
        {
            int idPedido = 0;

            try
            {
                datos.setearProcedimiento("CrearPedido");
                datos.SeterParametros("@FechaHora", fechaHora);
                datos.SeterParametros("@Total", total);
                datos.SeterParametros("@IdMesa", idMesa);

                // Asume que el procedimiento almacenado devuelve el ID del nuevo pedido
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    idPedido = Convert.ToInt32(datos.Lector["IdPedido"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pedido", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return idPedido;
        }

        // Método para agregar un ítem a un pedido
        public void AgregarItemPedido(int idPedido, int idInsumo, int cantidad, decimal precioUnitario)
        {
            try
            {
                datos.setearProcedimiento("AgregarItemPedido");
                datos.SeterParametros("@IdPedido", idPedido);
                datos.SeterParametros("@IdInsumo", idInsumo);
                datos.SeterParametros("@Cantidad", cantidad);
                datos.SeterParametros("@PrecioUnitario", precioUnitario);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
        {
                throw new Exception("Error al agregar item al pedido", ex);
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

        // Método para cerrar un pedido
        public void CerrarPedido(int idPedido, int idMesa)
        {
            try
            {
                // Cerrar el pedido en la base de datos
                datos.setearProcedimiento("CerrarPedido");
                datos.SeterParametros("@IdPedido", idPedido);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar el pedido", ex);
            }
        }
       
        // Método para obtener los ítems de un pedido
        public List<ItemPedido> ObtenerItemsDePedido(int idPedido)
        {
            List<ItemPedido> lista = new List<ItemPedido>();

            try
            {
                datos.setearProcedimiento("ObtenerItemsDePedido");
                datos.SeterParametros("@IdPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ItemPedido item = new ItemPedido
                    {
                        IdItemPedido = (int)datos.Lector["IdItemPedido"],
                        IdPedido = (int)datos.Lector["IdPedido"],
                        IdInsumo = (int)datos.Lector["IdInsumo"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"]
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
