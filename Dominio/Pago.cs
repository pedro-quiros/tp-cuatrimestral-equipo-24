using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pago
    {
        public int nroMesa { get; set; }
        public string Mesero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal TipoPago { get; set; }
        public string Consumicion { get; set; }

        public Pago()
        {
            nroMesa = 0;
            Mesero = "";
            Fecha = new DateTime();
            PrecioTotal = 0;
            TipoPago = 0;
            Consumicion = "";
        }

        public Pago(int nroMesa, string Mesero, DateTime fecha, decimal precioTotal, decimal tipoPago, string consumicion)
        {
            this.nroMesa = nroMesa;
            this.Mesero = Mesero;
            Fecha = fecha;
            PrecioTotal = precioTotal;
            TipoPago = tipoPago;
            Consumicion = consumicion;
        }
    }
}
