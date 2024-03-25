using e_Biblioteka.Data;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulEmailKorisnik.Models;
using e_Biblioteka.ModulEmailKorisnik.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulEmailKorisnik
{
    [Route("[controller]")]
    [ApiController]
    public class EmailKorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor
        public EmailKorisnikController(IMailService _MailService, ApplicationDbContext context)
        {
            _mailService = _MailService;
            _dbContext = context;
        }

        [HttpPost]
        [Route("SendMail")]
        public async void SendMail([FromBody] MailData mailData=null)
        {
            Task<bool> sendMail = _mailService.SendMailAsync(mailData);
            await Task.WhenAll(sendMail);
            
        }

        
    }
}
