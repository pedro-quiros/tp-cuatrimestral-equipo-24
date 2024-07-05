using Dominio;
using System;
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

        public List<Pedido> ListarParaReporte()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT P.IdPedido, P.Estado, P.FechaHoraCreado, I.IdItemPedido, I.Cantidad, " +
                    "I.PrecioUnitario, I.IdPedido AS Pedido, INS.IdInsumo, INS.Nombre FROM ItemPedido I " +
                    "INNER JOIN PEDIDO P ON I.IdItemPedido = P.IdItemPedido" +
                    "INNER JOIN Insumo INS ON INS.IdInsumo = I.IdInsumo";

                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ItemPedido item = new ItemPedido();
                    Pedido aux = new Pedido();

                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.FechaHoraGenerado = (DateTime)datos.Lector["FechaHoraCreado"];
                    item.IdItemPedido = (int)datos.Lector["IdItemPedido"];
                    item.Cantidad = (int)datos.Lector["Cantidad"];
                    item.PrecioUnitario = (float)datos.Lector["PrecioUnitario"];
                    item.Pedido.IdPedido = (int)datos.Lector["Pedido"];
                    item.Insumo.IdInsumo = (int)datos.Lector["IdInsumo"];
                    item.Insumo.Nombre = (string)datos.Lector["Nombre"];
                    aux.ItemPedido.Add(item);

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



    }
}