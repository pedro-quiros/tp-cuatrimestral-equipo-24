﻿using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaHoraGenerado { get; set; }
        public bool Estado { get; set; } // Si el pedido está cerrado o abierto
        public decimal Total { get; set; } // El total del costo del pedido
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

        // Método para agregar un ítem al pedido
        public void AgregarItem(ItemPedido item)
        {
            ItemsPedido.Add(item);
            Total += item.Cantidad * item.Precio; // Actualiza el total del pedido
        }

        // Método para cerrar el pedido
        public void CerrarPedido()
        {
            Estado = false;
        }

        // Método para recalcular el total del pedido
        public void RecalcularTotal()
        {
            Total = 0;
            foreach (var item in ItemsPedido)
            {
                Total += item.Cantidad * item.Precio;
            }
        }
    }
}
