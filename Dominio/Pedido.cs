using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; } // Relación con la clase Mesas
        public DateTime FechaHoraCreado { get; set; }
        public bool Estado { get; set; } // Estado del pedido (abierto o cerrado)
        public decimal Total { get; set; } // El total del costo del pedido
        public Mesas Mesa { get; set; } // Relación con la clase Mesas
        public List<ItemPedido> ItemsPedido { get; set; } // Relación con la clase ItemPedido

        public Pedido()
        {
            IdPedido = 0;
            IdMesa = 0;
            FechaHoraCreado = DateTime.Now;
            Estado = true;
            Total = 0;
            Mesa = new Mesas();
            ItemsPedido = new List<ItemPedido>();
        }

        public Pedido(int idPedido, int idMesa, DateTime fechaHoraCreado, bool estado, decimal total, Mesas mesa)
        {
            IdPedido = idPedido;
            IdMesa = idMesa;
            FechaHoraCreado = fechaHoraCreado;
            Estado = estado;
            Total = total;
            Mesa = mesa;
            ItemsPedido = new List<ItemPedido>();
        }

        // Método para agregar un ítem al pedido
        public void AgregarItem(ItemPedido item)
        {
            ItemsPedido.Add(item);
            Total += item.ObtenerTotal(); // Actualiza el total del pedido
        }

        // Método para recalcular el total del pedido
        public void RecalcularTotal()
        {
            Total = 0;
            foreach (var item in ItemsPedido)
            {
                Total += item.ObtenerTotal();
            }
        }

        // Método para cerrar el pedido
        public void CerrarPedido()
        {
            Estado = false; // Marca el pedido como cerrado
            if (Mesa != null)
            {
                Mesa.Estado = false; // Marca la mesa como cerrada
            }
        }
    }
}
