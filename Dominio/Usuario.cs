﻿using System;
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

        public string Puesto { get; set; }

        public DatosPersonales datos { get; set; }

        public Usuario() 
        {
            Id = 0;
            NombreUsuario = "";
            Clave = "fip12345";
            Puesto = "";
            datos = new DatosPersonales();
        }

        public Usuario (int id, string nombreUsuario, string clave, string puesto, DatosPersonales datos)
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
            this.datos = datos;
        }
    }
}