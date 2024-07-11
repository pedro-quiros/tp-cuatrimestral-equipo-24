using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
     public enum TipoUsuario
    {
        EMPLEADO = 1,
        GERENTE = 2,
    }
    public class Usuario 
    {
      
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public int Puesto { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public bool Activo { get; set; }
        
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Genero { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }


        public Usuario() 
        {
            Id = 0;
            NombreUsuario = "";
            Clave = "fip12345";
            Activo= true;
            Puesto = 1;
             Legajo = 0;
            Nombre = "";
            Apellido = "";
            Dni = 111111;
            Nacimiento = DateTime.Now;
            Genero = "";
            Telefono = 1111111;
            Email = "";
            Domicilio = "";
        }

        public Usuario (int id, string nombreUsuario, string clave,int puesto , bool Activado, string nombre, string apellido, int dni, int legajo, DateTime fechaNacimiento, string genero, int telefono, string email, string domicilio)

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

          Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Nacimiento = fechaNacimiento;
            Genero = genero;
            Telefono = telefono;
            Email = email;
            Domicilio = domicilio;
        }
        public Usuario (string clave,string nombreUsuario,bool gerente)
        {
            Clave = clave;
            NombreUsuario = nombreUsuario;
            tipoUsuario = gerente ? TipoUsuario.GERENTE : TipoUsuario.EMPLEADO;
        }
    }
}
