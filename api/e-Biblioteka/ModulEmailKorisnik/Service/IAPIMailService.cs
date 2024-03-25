using e_Biblioteka.ModulEmailKorisnik.Models;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulEmailKorisnik.Service
{
    public interface IAPIMailService
    {
        Task<bool> SendMailAsync(MailData mailData);
        
    }
}
