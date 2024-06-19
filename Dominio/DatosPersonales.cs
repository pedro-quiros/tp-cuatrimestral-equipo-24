using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class DatosPersonales

    {        
        public int IdDatosPersonales { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Nacimiento { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }

        public DatosPersonales()
        {
            IdDatosPersonales = 0;
            Legajo = 0;
            Nombre = "";
            Apellido = "";
            Dni = "";
 //           FechaNacimiento = DateTime.Now;
            Genero = "";
            Telefono = "";
            Email = "";
            Domicilio = "";

        }
        public DatosPersonales(int idDatosPersonales, int legajo, string nombre, string apellido, string dni, string fechaNacimiento, string genero, string telefono, string email, string domicilio)
        {
            IdDatosPersonales = idDatosPersonales;
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

    }
}
