using System;
using System.Text.RegularExpressions;
using AsphaltsProducts.Presentation.Layer.Models;
using AsphaltsProducts.Service.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    [Route("about")]
    [AllowAnonymous]
    public class AboutController : Controller
    {
        IServiceProvider _serviceProvider;
        public AboutController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [Route("me")]
        [Route("\\")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("contactrequest")]
        public JsonResult ContactRequest(ContactFormViewModel contactForm)
        {
            if (ModelState.IsValid)
            {
                _serviceProvider.GetRequiredService<IEmailService>().SendEmail(subject: "New Visitor!", to:
                    _serviceProvider.GetRequiredService<IConfiguration>().GetSection("MailSettings")["AdminEmail"],
                    name:"",
                    emailTemplateType: EmailService.EmailTemplateType.CONTACT_FORM_RECEIVED,
                    additinalData: Newtonsoft.Json.JsonConvert.SerializeObject(contactForm));
                if (contactForm.LikeToHearback && Regex.IsMatch(contactForm.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    _serviceProvider.GetRequiredService<IEmailService>().SendEmail(subject: "Greetings!", to: contactForm.Email, name: contactForm.FirstName, emailTemplateType:EmailService.EmailTemplateType.THANKS_GIVING);
                
            }
            return Json("success");
        }
        
    }
}