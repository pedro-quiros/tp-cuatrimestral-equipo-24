using Dominio;
using System.Collections.Generic;
using System;

namespace Negocio
{
    public class MesaNegocio
    {
        public List<Mesas> ListarConSpMesa()
        {
            List<Mesas> lista = new List<Mesas>();
            AccesoDatos datos = new AccesoDatos();

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
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return lista;
        }

        public void AbrirMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "UPDATE Mesa SET Estado = 1 WHERE IdMesa = @IdMesa";
                datos.SetearConsulta(consulta);
                datos.SeterParametros("@IdMesa", idMesa);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la mesa: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void CerrarMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "UPDATE Mesa SET Estado = 0 WHERE IdMesa = @IdMesa";
                datos.SetearConsulta(consulta);
                datos.SeterParametros("@IdMesa", idMesa);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la mesa: " + ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
