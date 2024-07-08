using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reporte
    {
        public int CantidadPedidos { get; set; }
        public decimal Precio { get; set; }
        public int IdMesa { get; set; }
        public int IdMesero { get; set; }
        public string Reseña { get; set; }
        public int PuntajeReseña { get; set; }
        public DateTime FechaHoraGenerado { get; set; }
        public int NumeroMesa { get; set; }
        public string NombreApellidoMesero { get; set; }

        public Reporte()
        {
            CantidadPedidos = 0;
            Precio = 0;
            IdMesa = 0;
            IdMesero = 0;
            Reseña = "";
            PuntajeReseña = 1;
            FechaHoraGenerado = DateTime.Now;
            NumeroMesa = 0;
            NombreApellidoMesero = "";
        }


        public Reporte (int cantidadPedidos, decimal precio, int idMesa, int idMesero, string reseña, int puntajeReseña, 
                        DateTime fechaHoraGenerado, int numeroMesa, string nombreApellidoMesero)
        {
            CantidadPedidos = cantidadPedidos;
            Precio = precio;
            IdMesa = idMesa;
            IdMesero = idMesero;
            Reseña = reseña;
            PuntajeReseña = puntajeReseña;
            FechaHoraGenerado = fechaHoraGenerado;
            NumeroMesa = numeroMesa;
            NombreApellidoMesero = nombreApellidoMesero;
        }
    }
}
