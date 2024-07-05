using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClientesGestion
    {
        public void InsertarReseña(Reseña reseña)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearProcedimiento("Insertarreseña");
                Datos.SeterParametros("@nombre", reseña.Nombre);
                Datos.SeterParametros("@email", reseña.Email);
                Datos.SeterParametros("@fecha", reseña.Fecha);
                Datos.SeterParametros("@puntaje", reseña.puntaje);
                Datos.SeterParametros("@msj", reseña.mensaje);
                

                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar la Reseña: " + ex.Message, ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
