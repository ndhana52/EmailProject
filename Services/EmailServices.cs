using EmailProject.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailProject.Services
{
    public class EmailServices : IEmailServices
    {
        private const string templatepath = @"EmailTemplate/{0}.html";
        private readonly SmtpConfigModel _smtpConfig;

        public EmailServices(IOptions<SmtpConfigModel> smtpconfig)
        {
            _smtpConfig = smtpconfig.Value;

        }

        public  async Task SendTestEmail(UserEmailOptions useremailoptions)
        {
            useremailoptions.Subject = "Dhana Email Task ";
            useremailoptions.Body = GetEmailBody("htmlpage");
            await SendEmail(useremailoptions);
        }
        public async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHtml

            };
            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UserDefaultCredential,
                Credentials = networkCredential
            };
            mail.BodyEncoding = System.Text.Encoding.Default;

            await smtpClient.SendMailAsync(mail);

        }

        public string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatepath, templateName));
            return body;
        }
        
    }


}
