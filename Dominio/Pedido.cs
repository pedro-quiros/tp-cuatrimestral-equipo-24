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
        public List<ItemPedido> ItemPedido { get; set; }

        public Pedido()
        {
            IdPedido = 0;
            FechaHoraGenerado = DateTime.Now;
            Estado = true;
            ItemPedido = new List<ItemPedido>();
        }

        public Pedido(int idPedido,bool estado, List<ItemPedido> itemPedido)
        {
            IdPedido = idPedido;
            Estado = estado;
            ItemPedido = itemPedido;
        }
    }
}
