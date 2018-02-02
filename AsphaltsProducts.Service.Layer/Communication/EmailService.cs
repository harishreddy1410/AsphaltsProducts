using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsphaltsProducts.Service.Layer
{
    public class EmailService : IEmailService
    {
        IConfigurationRoot _configuration;
        public EmailService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string subject,string to,string name,string htmlContent)
        {
            if(name == null || name.Trim() == "" || name.Length <= 2)
            {
                name = "Visitor!";
            }
            
            var apiKey = _configuration.GetSection("MailSettings")["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration.GetSection("MailSettings")["From"],
                _configuration.GetSection("MailSettings")["FiendlyName"]);
            
            var toAddress = new EmailAddress(to);
            var plainTextContent = "and easy to do anywhere, even with C#";
            htmlContent = htmlContent.Replace("##NAME##",name);
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            
        }
    }
}
