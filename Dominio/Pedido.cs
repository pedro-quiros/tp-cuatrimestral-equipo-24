using Dominio;
using System.Collections.Generic;
using System;

public class Pedido
{
    public int IdPedido { get; set; }
    public int IdMesa { get; set; }
    public DateTime FechaHoraCreado { get; set; }
    public bool Estado { get; set; }
    public decimal Total { get; set; }
    public Mesas Mesa { get; set; }
    public List<ItemPedido> ItemsPedido { get; set; }

    public Pedido()
    {
        IdPedido = 0;
        IdMesa = 0;
        FechaHoraCreado = DateTime.Now;
        Estado = true;
        Total = 0;
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

    public void AgregarItem(ItemPedido item)
    {
        ItemsPedido.Add(item);
        Total += item.ObtenerTotal();
    }

    public void RecalcularTotal()
    {
        Total = ItemsPedido.Sum(item => item.ObtenerTotal());
    }

    public void CerrarPedido()
    {
        Estado = false;
        if (Mesa != null)
        {
            Mesa.Estado = false;
        }
    }
}
