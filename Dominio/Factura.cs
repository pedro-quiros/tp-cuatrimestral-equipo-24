using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public char TipoFactura { get; set; }
        public int Cantidad { get; set; }
        public float PrecioTotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Pedido Pedido { get; set; }
        public FormaDePago FormaDePago { get; set; }


        public Factura()
        {
            IdFactura = 0;
            TipoFactura = ' ';
            Cantidad = 0;
            PrecioTotal = 0;
            FechaCreacion = DateTime.Now;
            Pedido = new Pedido();
            FormaDePago = new FormaDePago();
        }

    }
}

