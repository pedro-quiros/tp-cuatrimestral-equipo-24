using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PagosNegocio
    {
        public Pago ListarPorId(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            Pago pago = new Pago();
            string apellido = "";
            string nombre = "";

            try
            {
                datos.LimpiarParametros();
                datos.SetearConsulta(" SELECT M.Numero, U.Nombre, U.Apellido, P.Total FROM Pedido P " +
                                     " INNER JOIN Mesa M ON M.IdMesa = P.IdMesa" +
                                     " INNER JOIN Usuario2 U ON U.IdUsuario = P.IdUsuario" +
                                     " WHERE P.IdPedido = @idPedido");

                datos.SeterParametros("@idPedido", idPedido);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    pago.nroMesa = Convert.ToInt32(datos.Lector["Numero"]);
                    apellido = datos.Lector["Apellido"].ToString();
                    nombre = datos.Lector["Nombre"].ToString();
                    pago.Mesero = string.Concat(apellido, nombre);
                    pago.Fecha = DateTime.Now.Date;
                    pago.PrecioTotal = (decimal)datos.Lector["Total"];
                    pago.Consumicion = "";
                }

                return pago;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
