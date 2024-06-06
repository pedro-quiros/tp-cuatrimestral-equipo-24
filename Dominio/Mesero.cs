using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesero : Usuario
    {
        public int id {  get; set; }

        public bool estado { get; set; }

        public List<Mesas> MesasAsignadas { get; set; }

        public Mesero ()
        {
            id = 0;
            estado = true;
            MesasAsignadas = new List<Mesas> ();
        }

        public Mesero (int id, bool estado, List<Mesas> mesasAsignadas)
        {
            this.id = id;
            this.estado = estado;
            MesasAsignadas = mesasAsignadas;
        }
    }
}
