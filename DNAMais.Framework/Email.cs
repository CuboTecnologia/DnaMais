using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace DNAMais.Framework
{
    public class Email
    {
        public static string smtpServer = ConfigurationManager.AppSettings["smtpServer"];
        public static int smtpPort = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
        public static string smtpUser = ConfigurationManager.AppSettings["smtpUser"];
        public static string smtpPassword = ConfigurationManager.AppSettings["smtpPassword"];

        public static void SendEmailSubscriptionNewsletter(string emailReceiver, string emailBody)
        {
            string senderEmail = smtpUser;
            string senderName = "DNA+";
            string title = "Confirme sua Participação";

            SmtpClient client = new SmtpClient();
            client.Host = smtpServer;
            client.Port = smtpPort;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            //Cria o endereço de email do remetente e do destinatário
            MailAddress de = new MailAddress(senderEmail, senderName);
            MailAddress emailDestiny = new MailAddress(emailReceiver);

            //Monta Mensagem
            MailMessage message = new MailMessage(de, emailDestiny);
            message.IsBodyHtml = true;
            message.Subject = title;
            message.Body = emailBody;

            //Envia o email 
            client.Send(message);
        }

        public static void SendEmailMessageContact(string emailReceiver, string emailBody)
        {
            string smtpServer = "smtp";
            int smtpServerDoor = 587;
            string smtpUser = "email";
            string smtpPassword = "password";
            string senderEmail = "email";
            string senderName = "name";
            string title = "Registramos a sua Solicitação";

            SmtpClient client = new SmtpClient();
            client.Host = smtpServer;
            client.Port = smtpServerDoor;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            //Cria o endereço de email do remetente e do destinatário
            MailAddress de = new MailAddress(senderEmail, senderName);
            MailAddress emailDestiny = new MailAddress(emailReceiver);

            //Monta Mensagem
            MailMessage message = new MailMessage(de, emailDestiny);
            message.IsBodyHtml = true;
            message.Subject = title;
            message.Body = emailBody;

            //Envia o email 
            client.Send(message);
        }

        public static void SendEmailForgotPassword(string emailReceiver, string emailBody)
        {
            string senderEmail = smtpUser;
            string senderName = "DNA+";
            string title = "DNA+ - Sua nova senha";

            SmtpClient client = new SmtpClient();
            client.Host = smtpServer;
            client.Port = smtpPort;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            //Cria o endereço de email do remetente e do destinatário
            MailAddress de = new MailAddress(senderEmail, senderName);
            MailAddress emailDestiny = new MailAddress(emailReceiver);

            //Monta Mensagem
            MailMessage message = new MailMessage(de, emailDestiny);
            message.IsBodyHtml = false;
            message.Subject = title;
            message.Body = emailBody;

            //Envia o email 
            client.Send(message);
        }

    }
}
