using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Pedi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializar la lista de productos vacía al cargar la página por primera vez
                Session["Productos"] = new List<Producto>();
            }
        }

        protected void ddlMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al seleccionar una mesa, se puede realizar alguna acción si es necesario
            // En este ejemplo, no se realiza ninguna acción especial
        }

        protected void btnCargarProducto_Click(object sender, EventArgs e)
        {
            // Abrir el modal para cargar un producto
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalCargarProducto", "$('#modalCargarProducto').modal('show');", true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados del modal
            int platoValue = int.Parse(ddlPlato.SelectedValue);
            int bebidaValue = int.Parse(ddlBebida.SelectedValue);

            // Determinar el nombre y precio del producto seleccionado
            string nombreProducto = "";
            int precioProducto = 0;

            if (platoValue != 0)
            {
                nombreProducto = ddlPlato.SelectedItem.Text;
                precioProducto = platoValue;
            }
            else if (bebidaValue != 0)
            {
                nombreProducto = ddlBebida.SelectedItem.Text;
                precioProducto = bebidaValue;
            }

            // Crear un nuevo objeto Producto y agregarlo a la lista en sesión
            Producto nuevoProducto = new Producto(nombreProducto, precioProducto);
            List<Producto> productos = (List<Producto>)Session["Productos"];
            productos.Add(nuevoProducto);
            Session["Productos"] = productos;

            // Actualizar la lista de productos y el precio total en la interfaz
            actualizarListaProductos();
            calcularTotal();

            // Cerrar el modal después de aceptar
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hideModal", "$('#modalCargarProducto').modal('hide');", true);
        }

        private void actualizarListaProductos()
        {
            List<Producto> productos = (List<Producto>)Session["Productos"];
          //  gvProductos.DataSource = productos;
            //gvProductos.DataBind();
        }

        private void calcularTotal()
        {
            List<Producto> productos = (List<Producto>)Session["Productos"];
            int total = productos.Sum(p => p.Precio);
            lblTotal.Text = total.ToString();
        }
    }

    // Clase Producto para almacenar información de cada producto
    public class Producto
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public Producto(string nombre, int precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}