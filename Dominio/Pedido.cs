using Dominio;
using System.Collections.Generic;
using System;

public class Pedido
{
    public int IdPedido { get; set; }
    public int IdMesa { get; set; }
    public DateTime FechaHoraGenerado { get; set; }
    public bool Estado { get; set; }
    public decimal Total { get; set; }
    public Mesas Mesa { get; set; }
    public List<ItemPedido> ItemsPedido { get; set; }

    public Pedido()
    {
        IdPedido = 0;
        IdMesa = 0;
        FechaHoraGenerado = DateTime.Now;
        Estado = true;
        Total = 0;
        ItemsPedido = new List<ItemPedido>();
        Mesa = new Mesas();
    }

    public Pedido(int idPedido, int idMesa, DateTime fechaHoraGenerado, bool estado, decimal total, Mesas mesa)
    {
        IdPedido = idPedido;
        IdMesa = idMesa;
        FechaHoraGenerado = fechaHoraGenerado;
        Estado = estado;
        Total = total;
        Mesa = mesa;
        ItemsPedido = new List<ItemPedido>();
    }
}
