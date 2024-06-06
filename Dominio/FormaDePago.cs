using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FormaDePago
    {
        public int IdFormaDePago { get; set; }
        public string Nombre { get; set; }
    

    public FormaDePago()
    {
        IdFormaDePago = 0;
        Nombre = "";
    }
    public FormaDePago(int idFormaDePago, string nombre)
    {
        IdFormaDePago = idFormaDePago;
        Nombre = nombre;
        }
    }
}
