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
                    Mesas aux = new Mesas();
                    try
                    {
                        aux.Id = (int)datos.Lector["IdMesa"];
                        aux.Estado = Convert.ToBoolean(datos.Lector["Estado"]);
                        // Puedes omitir IdFactura si no lo necesitas en esta lista de mesas

                        lista.Add(aux);
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine("Error de conversión: " + ex.Message);
                        throw new Exception($"Error de conversión: {ex.Message}", ex);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las mesas: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
