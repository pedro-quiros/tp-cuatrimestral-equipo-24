using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public Pedido Pedido { get; set; }
        public Insumo Insumo { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }

        public ItemPedido() 
        {
            IdItemPedido = 0;
            Pedido = new Pedido();
            Insumo = new Insumo();
            Cantidad = 0;
            PrecioUnitario = 0;
        }

        public ItemPedido (int idItemPedido, Pedido pedido, Insumo insumo, int cantidad, float precioUnitario)
        {
            IdItemPedido = idItemPedido;
            Pedido = pedido;
            Insumo = insumo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
