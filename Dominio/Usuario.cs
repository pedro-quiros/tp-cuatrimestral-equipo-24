using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Usuario : DatosPersonales
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public int Puesto { get; set; }

        public bool Activo { get; set; }

        public DatosPersonales datos { get; set; }

        public Usuario() 
        {
            Id = 0;
            NombreUsuario = "";
            Clave = "fip12345";
            Puesto = 2;
            datos = new DatosPersonales();
            Activo= true;
        }

        public Usuario (int id, string nombreUsuario, string clave, int puesto, DatosPersonales datos,bool Activado)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            if (clave.Count() >= 8)
            {
                Clave = clave;
            }
            else
            {
                Clave = "fip12345";
            }
            Puesto = puesto;
            Activo = Activado;
            this.datos = datos;
        }
    }
}
