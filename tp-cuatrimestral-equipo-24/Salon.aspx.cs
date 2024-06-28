using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Salon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesas();
            }
        }

        private void CargarMesas()
        {
            // Aquí deberías implementar la lógica para cargar las mesas desde la base de datos
            // Por ejemplo, utilizando Entity Framework o ADO.NET

            List<Mesas> mesas = ObtenerMesasDesdeBaseDeDatos(); // Implementa esta función según tu método de acceso a datos

            // Actualizar visualmente los botones de las mesas según su estado
            foreach (var mesa in mesas)
            {
                var btnMesa = FindControl("btnMesa" + mesa.Id) as Button;
                if (btnMesa != null)
                {
                    if (mesa.Estado)
                    {
                        btnMesa.CssClass = "mesa-btn mesa-activa"; // Clase CSS para mesa activa (rojo, por ejemplo)
                    }
                    else
                    {
                        btnMesa.CssClass = "mesa-btn"; // Clase CSS para mesa inactiva (opcional)
                    }
                }
            }
        }

        // Método de ejemplo para obtener mesas desde la base de datos
        private List<Mesas> ObtenerMesasDesdeBaseDeDatos()
        {
            // Aquí implementa tu lógica para consultar las mesas desde la base de datos
            // Puedes utilizar Entity Framework, ADO.NET u otro método según tu configuración

            // Ejemplo básico
            List<Mesas> mesas = new List<Mesas>
            {
                new Mesas { Id = 1, Estado = true },
                new Mesas { Id = 2, Estado = false },
                // Agrega más mesas según tu estructura en la base de datos
            };

            return mesas;
        }

        protected void btnMesa_Click(object sender, EventArgs e)
        {
            // Lógica adicional si es necesario al hacer clic en una mesa
        }
    }
}
