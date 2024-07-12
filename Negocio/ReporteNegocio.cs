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
        public List<Reporte> ListarPorMesa()
        {
            List<Reporte> lista = new List<Reporte>();
            AccesoDatos datos = new AccesoDatos();
            string NombreMesero;
            string ApellidoMesero;
            try
            {
                string consulta = "SELECT M.IdMesa, M.Numero, MS.IdMesero, MS.Apellido, MS.Nombre,COUNT(P.IdPedido) AS CantPedidos," +
                    " SUM(P.Total) AS PrecioTotal, MAX(P.FechaHoraCreado) AS FechaHoraGenerado FROM Mesa M" +
                    " INNER JOIN Pedido P ON P.IdMesa = M.IdMesa" +
                    " INNER JOIN Mesero MS ON MS.IdMesero = M.IdMesero " +
                    " GROUP BY M.IdMesa, M.Numero, MS.IdMesero, MS.Apellido, MS.Nombre " +
                    " ORDER BY CantPedidos, PrecioTotal";

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
                    aux.NombreApellidoMesero = string.Concat(NombreMesero, " ", ApellidoMesero);
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

        public List<Reporte> ListarPorMesero()
        {
            List<Reporte> lista = new List<Reporte>();
            AccesoDatos accesoDatos = new AccesoDatos();
            string NombreMesero;
            string ApellidoMesero;
            try
            {
                accesoDatos.SetearConsulta("SELECT MS.Apellido, MS.Nombre, MS.IdMesero,(SELECT STRING_AGG(M.Numero, ', ')  " +
                    " FROM Mesa M  WHERE M.IdMesero = MS.IdMesero) AS NumeroMesas," +
                    " MAX(P.FechaHoraCreado) AS FechaHoraGenerado, SUM(P.Total) AS PrecioTotal,COUNT(P.IdPedido) AS CantPedidos" +
                    " FROM Mesero MS " +
                    " INNER JOIN Pedido P ON P.IdMesero = MS.IdMesero" +
                    " GROUP BY MS.Apellido, MS.Nombre, MS.IdMesero" +
                    " ORDER BY PrecioTotal, CantPedidos, NumeroMesas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Reporte aux = new Reporte();

                    NombreMesero = accesoDatos.Lector["Apellido"].ToString();
                    ApellidoMesero = accesoDatos.Lector["Nombre"].ToString();
                    aux.NombreApellidoMesero = string.Concat(NombreMesero, " ", ApellidoMesero);
                    aux.IdMesero = (int)accesoDatos.Lector["IdMesero"];
                    aux.NumeroMesaParaMesero = accesoDatos.Lector["NumeroMesas"].ToString();
                    aux.FechaHoraGenerado = (DateTime)accesoDatos.Lector["FechaHoraGenerado"];
                    aux.Precio = (decimal)accesoDatos.Lector["PrecioTotal"];
                    aux.CantidadPedidos = (int)accesoDatos.Lector["CantPedidos"];

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
                accesoDatos.CerrarConexion();
            }
        }
    }
}
