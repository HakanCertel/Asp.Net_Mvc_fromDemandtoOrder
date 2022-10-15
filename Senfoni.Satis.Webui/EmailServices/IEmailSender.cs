using System.Threading.Tasks;

namespace Senfoni.Satis.Webui.EmailServices
{
    public interface IEmailSender
    {
        //smtp=>gmail,hotmail
        //api=> sengrid
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
