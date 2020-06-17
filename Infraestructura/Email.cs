using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Entity;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Infraestructura
{
    public class Email
    {   

        private MailMessage email;
        private SmtpClient smtp;

        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        public void enviarCorreoClientes(string emisor, string password, string mensaje, string asunto,string destinatario, string ruta)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (ruta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                MessageBox.Show("el mensaje fue enviado");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "mensaje 1.0 vb.net" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Email()
        {
            smtp = new SmtpClient();
        }
        private void ConfigurarSmt() {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("quickbillin2019@gmail.com", "programacion3");
        }
        private void ConfigurarEmail(Cliente cliente) {
            email = new MailMessage();
            email.To.Add(cliente.Email);
            email.From = new MailAddress("quickbillin2019@gmail.com");
            email.Subject = " Registro de Usuario QuickBilling "
   + DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");
            email.Body = $"<b>Sr {cliente.PrimerNombre }</b> <br " +

            $" > se ha realizado su registro Sartisfactoriamente";

            email.IsBodyHtml = true;

            email.Priority = MailPriority.Normal;

        }

         public string EnviarEmail(Cliente cliente)
        {
            try
            {
                ConfigurarSmt();
                ConfigurarEmail(cliente);
                smtp.Send(email);
                return ("correo enviado sastifactoriamente");
            }
            catch (Exception e)
            {

                return ("error al enviar correo" + e.Message);
            }finally
            {
                email.Dispose();
            }
        }

        public void enviarCorreoFactura(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (ruta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;
                envios.Send(correos);
                MessageBox.Show("Factura enviada al correo del clientes");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "mensaje 1.0 vb.net", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
