using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesas
    {
        public int IdMesa { get; set; }
        public bool Estado { get; set; }
        public int Numero { get; set; }

        public Mesas()
        {
            IdMesa = 0;
            Estado = false;
            Numero = -1;
        }

        public Mesas(int idMesa, bool estado, int numero)
        {
            IdMesa = idMesa;
            Estado = estado;
            Numero = numero;
        }
    }
}

