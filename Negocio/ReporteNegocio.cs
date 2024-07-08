using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ReporteNegocio
    {
        public List<Reporte> ListarParaReporte()
        {
            List<Reporte> lista = new List<Reporte>();
            AccesoDatos datos = new AccesoDatos();
            string NombreMesero;
            string ApellidoMesero;
            try
            {
                string consulta = "SELECT M.IdMesa, M.Numero, MS.IdMesero, MS.Apellido, MS.Nombre,COUNT(P.IdPedido) AS CantPedidos, " +
                                  "SUM(P.Total) AS PrecioTotal, MAX(P.FechaHoraCreado) AS FechaHoraGenerado " +
                                  "FROM Mesa M " +
                                  "INNER JOIN Pedido P ON P.IdMesa = M.IdMesa " +
                                  "INNER JOIN Mesero MS ON MS.IdMesa = M.IdMesa " +
                                  "GROUP BY M.IdMesa, M.Numero, MS.IdMesero, MS.Apellido, MS.Nombre " +
                                  "ORDER BY CantPedidos, PrecioTotal;";

                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Reporte aux = new Reporte();

                    aux.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.NumeroMesa = (int)datos.Lector["Numero"];
                    aux.IdMesero = (int)datos.Lector["IdMesero"];
                    NombreMesero = datos.Lector["Nombre"].ToString();
                    ApellidoMesero = datos.Lector["Apellido"].ToString();
                    aux.NombreApellidoMesero = string.Concat(NombreMesero, " ",ApellidoMesero);
                    aux.CantidadPedidos = (int)datos.Lector["CantPedidos"];
                    aux.Precio = (decimal)datos.Lector["PrecioTotal"];
                    aux.FechaHoraGenerado = (DateTime)datos.Lector["FechaHoraGenerado"];

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
