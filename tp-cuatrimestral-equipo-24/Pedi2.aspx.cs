using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el número de mesa desde la URL
                if (Request.QueryString["mesa"] != null)
                {
                    string numeroMesa = Request.QueryString["mesa"];
                    numeroMesaLabel.Text = numeroMesa; // Asignar el número de mesa al control correspondiente
                }

                // Simular productos para mostrar en GridView (esto es un ejemplo, puedes cambiar según tus necesidades)
                List<Producto> productos = new List<Producto>
                {
                    new Producto { Productox = "Hamburguesa", Cantidad = 2, Precio = 150 },
                    new Producto { Productox = "Gaseosa", Cantidad = 3, Precio = 70 },
                    new Producto { Productox = "Milanesa", Cantidad = 1, Precio = 200 },
                    new Producto { Productox = "Pizza", Cantidad = 1, Precio = 250 },
                     new Producto { Productox = "Gaseosa", Cantidad = 3, Precio = 70 },


                };

                // Enlazar datos al GridView
                GridView1.DataSource = productos;
                GridView1.DataBind();
            }
        }

        // Clase de ejemplo para productos
        public class Producto
        {
            public string Productox { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
        }
    }
}
