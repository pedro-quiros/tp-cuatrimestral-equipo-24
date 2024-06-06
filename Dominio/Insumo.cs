using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public Insumo() 
        {
            IdInsumo = 0;
            Nombre = "";
            Tipo = "";
            Precio = 0; 
            Stock = 0;
        }

        public Insumo (int idInsumo, string nombre, string tipo, float precio, int stock)
        {
            IdInsumo = idInsumo;
            Nombre = nombre;
            Tipo = tipo;
            Precio = precio;
            Stock = stock;
        }
    }
}
