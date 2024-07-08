using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
                if (string.IsNullOrEmpty(txtNombre.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del Insumo.');</script>");
                }
                if (string.IsNullOrEmpty(txtPrecio.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del Precio.');</script>");
                }
                if (string.IsNullOrEmpty(txtStock.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre del Stock.');</script>");
                }
                if (string.IsNullOrEmpty(txtDescripcion.Value))
                {
                    Response.Write("<script>alert('Por favor, complete el nombre de la Descripcion.');</script>");
                }
                if (Regex.IsMatch(txtPrecio.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el Precio');</script>");
                }
                if (Regex.IsMatch(txtStock.Value, @"\D"))
                {
                    Response.Write("<script>alert('Ingresar solo numeros en el Stock');</script>");
                }


                nuevoInsumo.Nombre = txtNombre.Value;
                nuevoInsumo.Tipo = ddlTipo.Text;
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
                    MessageBox.Show("Agregado exitosamente :)");
                }
                else
                {

                    MessageBox.Show("Complete todos los campos mi estimado/a");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error..");
            }
            finally
            {
                Response.Redirect("Menu.aspx");
            }

        }
    }
}