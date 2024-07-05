namespace Dominio
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; } // Relación con la clase Pedido
        public Insumo Insumo { get; set; }  // Relación con la clase Insumo
        public int IdInsumo { get; set; } // Id del insumo
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } // Precio del insumo en el momento del pedido

        public ItemPedido()
        {
            IdItemPedido = 0;
            IdPedido = 0;
            Insumo = new Insumo();
            IdInsumo = 0;
            Cantidad = 0;
            PrecioUnitario = 0;
        }

        public ItemPedido(int idItemPedido, int idPedido, Insumo insumo, int idInsumo, int cantidad, decimal precioUnitario)
        {
            IdItemPedido = idItemPedido;
            IdPedido = idPedido;
            Insumo = insumo;
            IdInsumo = idInsumo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        // Método para obtener el total del ítem
        public decimal ObtenerTotal()
        {
            return Cantidad * PrecioUnitario;
        }
    }
}
