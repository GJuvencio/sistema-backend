using System.Net;
using System.Net.Mail;

namespace ProgramacaoZero.Common
{
    public class EmailSender
    {
        public void Enviar(string assunto, string corpo,string emailDestino)
        {
            //disparar email
            var fromEmail = "gustavo.desouza19@gmail.com";
            var fromPassword = "@na&Guh110720";
            var fromHost = "smtp.gmail.com";
            var fromPort = 465;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail);

            mail.To.Add(new MailAddress(emailDestino));

            mail.Subject = assunto;

            mail.Body = corpo;

            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
            }

        }
    }
}
