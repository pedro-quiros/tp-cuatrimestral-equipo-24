using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaHoraGenerado { get; set; }
        public bool Estado { get; set; }

        public Pedido()
        {
            IdPedido = 0;
            FechaHoraGenerado = DateTime.Now;
            Estado = true;
        }

        public Pedido(int idPedido,bool estado)
        {
            IdPedido = idPedido;
            Estado = estado;
        }
    }
}
