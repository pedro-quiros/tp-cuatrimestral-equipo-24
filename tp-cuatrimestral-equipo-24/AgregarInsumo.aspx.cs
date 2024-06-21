using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace tp_cuatrimestral_equipo_24
{
    public partial class AgregarInsumo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            Insumo nuevoInsumo = new Insumo();
            InsumosNegocio nuevoNegocio = new InsumosNegocio();
            MemoryStream ms = new MemoryStream();

            try
            {

                nuevoInsumo.Nombre = txtNombre.Value;
                nuevoInsumo.Tipo = txtTipo.Value;
                nuevoInsumo.Stock = int.Parse(txtStock.Value);
                nuevoInsumo.Precio = decimal.Parse(txtPrecio.Value);
                nuevoInsumo.UrlImagen = txtImagen.Value;
                nuevoInsumo.Descripcion = txtDescripcion.Value;
                decimal verificadorNumero;

                if (decimal.TryParse((txtPrecio.Value), out verificadorNumero))
                {
                    nuevoInsumo.Precio = decimal.Parse(txtPrecio.Value);
                }
                else
                {
                    MessageBox.Show("Ingresar sólo números en el precio por favor");
                    return;
                }

                if (nuevoInsumo.Tipo != "" && nuevoInsumo.Nombre != "" && nuevoInsumo.Descripcion != "" && txtPrecio.Value != "" && txtStock.Value != "")
                {

                    nuevoNegocio.AgregarArticulo(nuevoInsumo);
                    MessageBox.Show("Modificado exitosamente :)");
                }
                else
                {

                    MessageBox.Show("Complete todos los campos mi estimado/a");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}