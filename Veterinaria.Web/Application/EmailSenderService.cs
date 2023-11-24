using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System;
using Veterinaria.Website.Application.Contracts;
using Veterinaria.Models.ConfigurationModels;
using Veterinaria.Models.DataModels;

namespace Veterinaria.Website.Application
{
    public class EmailSenderService : IEmailSenderService
    {
        public EmailSenderService(IOptions<SmtpConfiguration> options)
        {
            _configuration = options.Value;
        }

        SmtpConfiguration _configuration;

        public bool SendEmail(Email email)
        {
            var client =
                new SmtpClient
                {
                    Host = _configuration.Server,
                    Port = _configuration.Port,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials =
                    new NetworkCredential
                    {
                        UserName = _configuration.UserName,
                        Password = _configuration.Password
                    }
                };

            var message =
                new MailMessage
                {
                    From = new MailAddress(_configuration.Sender),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = email.IsHtml

                };
            message.To.Add(new MailAddress(email.Receiver));

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

