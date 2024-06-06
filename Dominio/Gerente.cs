using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Gerente : Usuario
    {
        public int id {  get; set; }

        public bool estado { get; set; }

        public Gerente() 
        {
            id = 0;
            estado = false;
        }

        public Gerente (int id, bool estado)
        {
            this.id = id;
            this.estado = estado;
        }
    }
}
