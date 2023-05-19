using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCOMMON.Tools
{
    public static class MailService
    {
        public static void send(string receiver, string password = "boran",string body ="Test mesajıdır",string subject="Emai testi", string sender ="borankaya210@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Bizim  Email İşlemlerimiz SMTP'ye göre yapılır...
            //Kullandığınız gmail hesabının baska uygulamalar tarafından mesaj gönderme özelliğini acmalsınız...

            SmtpClient smtp = new SmtpClient
            {
              Host = "smtp.gmail.com",
              Port = 587,
              EnableSsl = true,
              DeliveryMethod = SmtpDeliveryMethod.Network,
              UseDefaultCredentials = false,
              Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            }) 
            {
                smtp.Send(message);
            }
        }
    }
}
