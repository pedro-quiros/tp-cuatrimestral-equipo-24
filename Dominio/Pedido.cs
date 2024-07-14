using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public int IdUsuario { get; set; }  // Agregado
        public DateTime FechaHoraGenerado { get; set; }
        public bool Estado { get; set; }
        public decimal Total { get; set; }
        public Mesas Mesa { get; set; }
        public List<ItemPedido> ItemsPedido { get; set; }

        public Pedido()
        {
            IdPedido = 0;
            IdMesa = 0;
            IdUsuario = 0;  // Inicialización del nuevo campo
            FechaHoraGenerado = DateTime.Now;
            Estado = true;
            Total = 0;
            ItemsPedido = new List<ItemPedido>();
            Mesa = new Mesas();
        }

        public Pedido(int idPedido, int idMesa, int idUsuario, DateTime fechaHoraGenerado, bool estado, decimal total, Mesas mesa)
        {
            IdPedido = idPedido;
            IdMesa = idMesa;
            IdUsuario = idUsuario;  // Inicialización del nuevo campo
            FechaHoraGenerado = fechaHoraGenerado;
            Estado = estado;
            Total = total;
            Mesa = mesa;
            ItemsPedido = new List<ItemPedido>();
        }

        public Pedido(int idPedido, int idMesa, int idUsuario, DateTime fechaHoraGenerado, bool estado, decimal total, Mesas mesa, List<ItemPedido> itemsPedido)
        {
            IdPedido = idPedido;
            IdMesa = idMesa;
            IdUsuario = idUsuario;  // Inicialización del nuevo campo
            FechaHoraGenerado = fechaHoraGenerado;
            Estado = estado;
            Total = total;
            Mesa = mesa;
            ItemsPedido = itemsPedido;  // Acepta una lista de ítems en el constructor
        }
    }
}
