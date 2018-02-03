using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static AsphaltsProducts.Service.Layer.EmailService;

namespace AsphaltsProducts.Service.Layer
{
    public interface IEmailService
    {
        Task SendEmail(string subject,string to, string name,EmailTemplateType emailTemplateType,[Optional]string additinalData);
    }
}
