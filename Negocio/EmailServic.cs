using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailServic
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailServic()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("bitesybocados24@gmail.com", "b f u s i f c y a i v c j f y u");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("bitesybocados24@gmail.com"); // Dirección de origen
            email.To.Add(emailDestino); // Dirección de destino
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }
        public void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
