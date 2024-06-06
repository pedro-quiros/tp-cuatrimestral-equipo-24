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
        public int Dni { get; set; }
        public DateTime Nacimiento { get; set; }
        public char Genero { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Domicilio { get; set; }

        public DatosPersonales()
        {
            IdDatosPersonales = 0;
            Legajo = 0;
            Nombre = "";
            Apellido = "";
            Dni = 0;
 //           FechaNacimiento = DateTime.Now;
            Genero = ' ';
            Telefono = 0;
            Email = "";
            Domicilio = "";

        }
        public DatosPersonales(int idDatosPersonales, int legajo, string nombre, string apellido, int dni, DateTime fechaNacimiento, char genero, int telefono, string email, string domicilio)
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
