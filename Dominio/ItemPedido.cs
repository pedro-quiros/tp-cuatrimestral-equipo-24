using System;

namespace Dominio
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public Pedido Pedido { get; set; } // Relación con la clase Pedido
        public Insumo Insumo { get; set; } // Relación con la clase Insumo
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } // Actualizamos de float a decimal para mayor precisión en precios

        public ItemPedido()
        {
            IdItemPedido = 0;
            Pedido = new Pedido();
            Insumo = new Insumo();
            Cantidad = 0;
            PrecioUnitario = 0;
        }

        public ItemPedido(int idItemPedido, Pedido pedido, Insumo insumo, int cantidad, decimal precioUnitario)
        {
            IdItemPedido = idItemPedido;
            Pedido = pedido;
            Insumo = insumo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
