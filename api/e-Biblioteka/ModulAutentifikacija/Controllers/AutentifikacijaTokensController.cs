using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_Biblioteka.Data;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulAutentifikacija.ViewModels;
using e_Biblioteka.Helpers;
using e_Biblioteka.ModulEmailKorisnik.Service;
using e_Biblioteka.Models;
using e_Biblioteka.ModulEmailKorisnik.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace e_Biblioteka.ModulAutentifikacija.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaTokensController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMailService _mailService;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "FCnMUUSzVZ6IGgtRn09ChYMiithoKmAagAP4xvpW",
            BasePath = "https://emailnotifications-cae6b-default-rtdb.europe-west1.firebasedatabase.app"
        };
        IFirebaseClient client;

        public AutentifikacijaTokensController(ApplicationDbContext context, IMailService mailService)
        {
            _dbContext = context;
            _mailService = mailService;
        }

        [HttpPost]
        public ActionResult AktivirajRacun(string email)
        {
            var user = _dbContext.EndUser.FirstOrDefault(x => x.Email == email);

            if(user == null)
            {
                return BadRequest("Nije pronadjen korisnik.");
            }

            user.Aktivacija = true;

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public  AutentifikacijaVM Login ([FromBody] LoginVM x)
        {
            //provjera login-a
            KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog
                .SingleOrDefault(k => k.korisnickoIme == x.korisnickoIme && k.lozinka == x.lozinka);

            if (logiraniKorisnik == null || !logiraniKorisnik.Aktivacija)
            {
                //pogresan username ili pw
                return null;
            }

            //generisati random string
            string randomString = TokenGenerator.Generate(10);


            var newLogin = new AutentifikacijaToken
            {
                IPadresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                VrijemeEvidentiranja = DateTime.Now
            };

            var vratiAuth = new AutentifikacijaVM
            {
                isAdministrator = logiraniKorisnik.isAdministrator,
                isRadnik = logiraniKorisnik.isRadnik,
                isKorisnik = logiraniKorisnik.isKorisnik,
                isLogiran = true,
                vrijednost = newLogin.Vrijednost,
                korisnickoIme = logiraniKorisnik.korisnickoIme,
                korisnikId = logiraniKorisnik.ID
            };

            _dbContext.Add(newLogin);
            _dbContext.SaveChanges();

            if(logiraniKorisnik.isKorisnik)
            {
                ProvjeriClanarinu(logiraniKorisnik.ID);
            }

            return vratiAuth;
        }

        private void ProvjeriClanarinu(int korisnikId)
        {
            string body = "Poštovani,\n\n" +
                            "Obaviještavamo vas da vam je ostalo 10 dana do isteka članarine.\n\n" +
                            "Srdačno,\nAdministracija biblioteke.";
            string body2 = "Poštovani,\n\n" +
                            "Obaviještavamo vas da vam je istekla članarina.\n\n" +
                            "Srdačno,\nAdministracija biblioteke.";
            EndUser endUser = _dbContext.EndUser.Find(korisnikId);
            if (DateTime.Now.Year == endUser.DatumIstekaClanarine.Year)
            {
                if(endUser.DatumIstekaClanarine.Month - DateTime.Now.Month == 1)
                {
                    if(DateTime.Now.Day > endUser.DatumIstekaClanarine.Day)
                    {
                        int ovajMjesec = 30 - DateTime.Now.Day;
                        int preostaliDani = ovajMjesec + endUser.DatumIstekaClanarine.Day;
                        if(preostaliDani == 10)
                        {
                            SendMail(endUser, body); 
                        }
                    }

                }
                else if(DateTime.Now.Month == endUser.DatumIstekaClanarine.Month)
                {
                    int preostaliDani = endUser.DatumIstekaClanarine.Day - DateTime.Now.Day;
                    if(preostaliDani == 10)
                    {
                        SendMail(endUser, body);
                    }
                    else if(DateTime.Now.Day == endUser.DatumIstekaClanarine.Day)
                    {
                        SendMail(endUser, body2);
                    }
                }
            }
        }
        private async void SendMail(EndUser endUser, string body)
        {
            MailData mail = new MailData()
            {
                EmailToId = endUser.Email,
                EmailToName = endUser.Ime,
                EmailSubject = "Obavijest",
                EmailBody = body
            };

            client = new FireSharp.FirebaseClient(config);
            MailData data = mail;
            PushResponse response = client.Push("Emails/", data);
            string dataId = response.Result.name;
            SetResponse setResponse = client.Set("Emails/" + dataId, data);

            Task<bool> sendMail = _mailService.SendMailAsync(mail);
            await Task.WhenAll(sendMail);


        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();

            return Ok("Uredu");
        }

        [HttpGet]
        public string GetProvjereniToken()
        {
            string mojToken = HttpContext.Request.Headers["autentifikacija-token"];
            KorisnickiNalog korisnik = ControllerContext.HttpContext.GetKorisnikOfAuthToken();

            if (korisnik == null)
                return null;

            return mojToken;
        }

    }
}
