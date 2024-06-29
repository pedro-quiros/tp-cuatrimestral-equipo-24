using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaHoraGenerado { get; set; }
        public bool Estado { get; set; }
        public decimal Total { get; set; } // Actualizamos de float a decimal para mayor precisión en precios
        public Mesas Mesa { get; set; } // Relación con la clase Mesas
        public List<ItemPedido> ItemsPedido { get; set; } // Relación con la clase ItemPedido

        public Pedido()
        {
            IdPedido = 0;
            FechaHoraGenerado = DateTime.Now;
            Estado = true;
            Total = 0;
            Mesa = new Mesas();
            ItemsPedido = new List<ItemPedido>();
        }

        public Pedido(int idPedido, DateTime fechaHoraGenerado, bool estado, decimal total, Mesas mesa)
        {
            IdPedido = idPedido;
            FechaHoraGenerado = fechaHoraGenerado;
            Estado = estado;
            Total = total;
            Mesa = mesa;
            ItemsPedido = new List<ItemPedido>();
        }
    }
}
