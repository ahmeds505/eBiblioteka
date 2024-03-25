using e_Biblioteka.ModulEmailKorisnik.Models;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulEmailKorisnik.Service
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
        Task<bool> SendMailAsync(MailData mailData);
    }
}
