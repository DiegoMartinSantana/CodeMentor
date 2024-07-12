using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ServicioEmail
{
    public class EnvioGmail
    {

        private SmtpClient server;
        private MailMessage email;
        public EnvioGmail()
        {
            server = new SmtpClient();

            server.Credentials = new NetworkCredential("codementor.net@gmail.com", "qadihekvzmyjlzkh");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void EmailUsuarioRespuesta(string destino, string asunto,string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@Codementor.com");
            email.To.Add(destino);
            email.Subject = asunto;
            email.IsBodyHtml = true;

            email.Body = mensaje;

        }

        public void EmailUsuarioBienvenida(string destino, string asunto)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@Codementor.com");
            email.To.Add(destino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //template email de Boostrapp :https://app.bootstrapemail.com/templates/free-order-receipt
            //usar ese template y cargar con datos de inscripcion Recibida
            // O GENERAR HTML Y DARLE DISEÑO PROPIO
            string message = "Gracias por registrarte en nuestro sitio, esperamos que disfrutes de nuestros servicios.";
            email.Body = message;

        }
        public void EmailRecuperarPass(string destino, string codigo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceasp.com");
            email.To.Add(destino);
            email.Subject = "Recover Pass";
            email.IsBodyHtml = true;
            //GENERAR CODIGO ALEATORIO Y ENVIARLO POR EMAIL POSIBLE IMPLEMENTACION DE ALGO
            string mensaje = "CODIGO DE RECUPERACION : " + codigo + "  Ingrese el código sin las comillas(\"\").";
            email.Body = mensaje;


        }
        public void EmailHaciaAdmin(string destino, string asunto, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceasp.com");
            email.To.Add(destino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = mensaje;

        }
        public void EmailUsuariodeBaja(string mailUsuario, string mensaje)
        {
            email = new MailMessage();
            email.To.Add("codementor.net@gmail.com");
            email.Subject= mailUsuario;
            email.IsBodyHtml = true;
            email.Body= mensaje;


        }

        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
