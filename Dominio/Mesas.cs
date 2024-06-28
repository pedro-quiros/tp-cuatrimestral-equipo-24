using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Mesas : Mesero
    {
        public int Id { get; set; }

        public bool Estado {  get; set; }

        public int idFactura {  get; set; }

        public Mesas ()
        {
            Id = 0;
            Estado = false;
           idFactura = 0;
        }

        public Mesas (int id, bool estado)
        {
            Id = id;
            Estado = estado;
         this.idFactura = idFactura;
        }
    }
}
