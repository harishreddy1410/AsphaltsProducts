using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsphaltsProducts.Service.Layer
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string subject,string to,string name,EmailTemplateType emailTemplateType, [Optional]string additinalData)
        {
            if(name == null || name.Trim() == "" || name.Length <= 2)
            {
                name = "Visitor!";
            }
            
            var apiKey = _configuration.GetSection("MailSettings")["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration.GetSection("MailSettings")["From"],
                _configuration.GetSection("MailSettings")["FiendlyName"]);
            var htmlContent = string.Empty;
            var toAddress = new EmailAddress(to);
            var plainTextContent = "and easy to do anywhere, even with C#";
            switch(emailTemplateType)
            {
                case EmailTemplateType.THANKS_GIVING:
                    htmlContent= _configuration.GetSection("MailTemplates")["ThanksGivingMail"].Replace("##FIRSTNAME##", name);
                    break;
                case EmailTemplateType.CONTACT_FORM_RECEIVED:
                    htmlContent = _configuration.GetSection("MailTemplates")["NotifyMailToAdmin"] + "<br /><br />" + additinalData;
                    break;

            }            
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);            
        }

        public enum EmailTemplateType
        {
            THANKS_GIVING,
            CONTACT_FORM_RECEIVED
        }
    }
}
