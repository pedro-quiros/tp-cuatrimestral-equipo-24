namespace Dominio
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public Insumo Insumo { get; set; }  // Relación con la clase Insumo
        public int Cantidad { get; set; }
        public decimal Precio { get; set; } // Precio del insumo en el momento del pedido

        public ItemPedido()
        {
            IdItemPedido = 0;
            Insumo = new Insumo();
            Cantidad = 0;
            Precio = 0;
        }

        public ItemPedido(int idItemPedido, Insumo insumo, int cantidad, decimal precio)
        {
            IdItemPedido = idItemPedido;
            Insumo = insumo;
            Cantidad = cantidad;
            Precio = precio;
        }

        // Método para obtener el total del ítem
        public decimal ObtenerTotal()
        {
            return Cantidad * Precio;
        }
    }
}
