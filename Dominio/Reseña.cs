using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reseña
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public string mensaje { get; set; }
        public int puntaje { get; set; }

        public Reseña()
        {
            Id = 0;
            Nombre = "";
            Email = "";
            Fecha = DateTime.Now;
            mensaje = "";
            puntaje = 5;
        }
        public Reseña(int ID,string nom, string email,DateTime fecha,string msj,int punt)
        {
            Id = ID;
            Nombre = nom;
            Email = email;
            Fecha = fecha;
            mensaje =msj ;
            puntaje = punt;
        }


    }

}
