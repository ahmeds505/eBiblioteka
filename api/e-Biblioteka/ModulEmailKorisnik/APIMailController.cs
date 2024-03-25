using e_Biblioteka.ModulEmailKorisnik.Models;
using e_Biblioteka.ModulEmailKorisnik.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulEmailKorisnik
{
    [Route("[controller]")]
    [ApiController]
    public class MailAPIController : ControllerBase
    {
        private readonly IAPIMailService _apiMailService;

        //injecting the IMailService into the constructor
        public MailAPIController(IAPIMailService apiMailService)
        {
            _apiMailService = apiMailService;
        }

        [HttpPost]
        [Route("SendMailAsync")]
        public async Task<bool> SendMailAsync(MailData mailData)
        {
            return await _apiMailService.SendMailAsync(mailData);
        }

    }
}
