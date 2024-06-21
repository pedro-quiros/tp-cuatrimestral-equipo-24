using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Usuario 
    {
      

        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public int Puesto { get; set; }

        public bool Activo { get; set; }

        //   public DatosPersonales datos { get; set; }
   //     public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Nacimiento { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }




        public Usuario() 
        {
            Id = 0;
            NombreUsuario = "";
            Clave = "fip12345";
            Puesto = 2;
            //datos = new DatosPersonales();
            Activo= true;
              //  Legajo = 0;
            Nombre = "";
            Apellido = "";
            Dni = "";
            Nacimiento = "";
            Genero = "";
            Telefono = "";
            Email = "";
            Domicilio = "";
        }

        public Usuario (int id, string nombreUsuario, string clave, int puesto, bool Activado, string nombre, string apellido, string dni, string fechaNacimiento, string genero, string telefono, string email, string domicilio)

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
         //   this.datos = datos;

          //  Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Nacimiento = fechaNacimiento;
            Genero = genero;
            Telefono = telefono;
            Email = email;
            Domicilio = domicilio;
        }
    }
}
