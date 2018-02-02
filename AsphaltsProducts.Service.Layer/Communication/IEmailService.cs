using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsphaltsProducts.Service.Layer
{
    public interface IEmailService
    {
        Task SendEmail(string subject,string to, string name,string htmlContent);
    }
}
