using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace humiditymonitor2
{
    public class Emailer
    {
        private readonly SmtpClient _mailClient;

        public Emailer(String smtpHost, String username, String password)
        {
            _mailClient = new SmtpClient(smtpHost)
            {
                Port = 587,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }
        public void Send(String fromAddress, String recipient, String subject, String body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(fromAddress);

            message.To.Add(new MailAddress(recipient));

            message.Subject = subject;
            message.Body = body;
            _mailClient.Send(message);
        }

    }
}
