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
        public List<Reseña> ListarParaReseña()
        {
            List<Reseña> lista = new List<Reseña>();
            AccesoDatos datos = new AccesoDatos();
           
            try
            {
                string consulta = "select Email,mensaje,Puntaje,Fecha from Reseña";

                datos.SetearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Reseña aux = new Reseña();
                    aux.Email = datos.Lector["Email"].ToString();
                    aux.mensaje = datos.Lector["mensaje"].ToString();
                    aux.puntaje = (int)datos.Lector["Puntaje"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

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
        public (int Positivo, int Negativo) ContadorReseña()
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearProcedimiento("SP_ContReseñas");
                Datos.ejecutarLectura();

                int Positivo = 0;
                int Negativo = 0;

                if (Datos.Lector.Read())
                {
                    Positivo = Datos.Lector.GetInt32(0);
                }
                if (Datos.Lector.NextResult() && Datos.Lector.Read())
                {
                    Negativo = Datos.Lector.GetInt32(0);
                }

                return (Positivo, Negativo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar las reseñas:" + ex.Message, ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        
    }
}
