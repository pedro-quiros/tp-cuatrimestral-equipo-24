using System;
using System.Collections.Generic;
using Dominio;

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
                        Id = (int)datos.Lector["IdMesa"],
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

        public void AbrirCerrarMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AbrirCerrarMesa");
                datos.SeterParametros("@Id", idMesa);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
               // datos.impiarParametros();
            }
        }
    }
}
