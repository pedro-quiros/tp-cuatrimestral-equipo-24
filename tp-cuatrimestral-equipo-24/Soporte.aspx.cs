using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo_24
{
    public partial class Soporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtEmail.Text) || string.IsNullOrWhiteSpace(txtmensaje.Text))
            {
                Response.Write("<script>alert('Por favor, complete todos los campos obligatorios.');</script>");
                return;
            }

            EmailServic emailService = new EmailServic();
            string emailDestino = "bitesybocados24@gmail.com"; 
            string asunto = "Nueva Reseña de Cliente";
            string cuerpo = $"<h1>Reseña de Cliente</h1><br>" +
                            $"<b>Nombre:</b> {TxtNombre.Text}<br>" +
                            $"<b>Email:</b> {TxtEmail.Text}<br>" +
                            $"<b>Mensaje:</b> {txtmensaje.Text}";
                            //$"<b>Fecha:</b> {fecha.Text}";

            emailService.armarCorreo(emailDestino, asunto, cuerpo);

            try
            {
                emailService.EnviarMail();
                Response.Write("<script>alert('Reseña enviada correctamente.');</script>");
                // Limpia los campos después de enviar el correo
                TxtNombre.Text = "";
                TxtEmail.Text = "";
                txtmensaje.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Write("<script>alert('Error al enviar la reseña.');</script>");
            }
        }
    }
}