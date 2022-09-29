using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.EmailService
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, StringBuilder builder, string Subject, string bcc, string CC);
    }
}
