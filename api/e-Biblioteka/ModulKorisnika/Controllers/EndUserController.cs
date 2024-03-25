using e_Biblioteka.Data;
using e_Biblioteka.Helpers;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Controllers;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulEmail.Models;
using e_Biblioteka.ModulEmail.Service;
using e_Biblioteka.ModulKnjiga.Models;
using e_Biblioteka.ModulKnjiga.ViewModel;
using e_Biblioteka.ModulKorisnika.Models;
using e_Biblioteka.ModulKorisnika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_Biblioteka.ModulKorisnika.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EndUserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        string slikaBrisi;
        string folderUploads = "wwwroot/uploads/";
        private readonly IEmailService EmailService;


        public EndUserController(ApplicationDbContext dbContext, IEmailService email)
        {
            this._dbContext = dbContext;
            EmailService = email;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult GetAll()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            return Ok(_dbContext.EndUser.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isLogiran)
            {
                var user = _dbContext.Korisnik.Find(id);

                return Ok(user);

            }


            return BadRequest("Login podaci nisu uredu");

        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Add([FromBody] EndUserVM x)
        {
            var korisnik = _dbContext.EndUser.FirstOrDefault(y => y.Email == x.email);

            if (korisnik != null)
                return BadRequest("Email adresa je u upotrebi.");


            var newMember = new EndUser
            {
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                Adresa = x.adresa,
                Grad = x.grad,
                PostanskiBroj = x.postanskiBroj,
                DatumRegistracije = DateTime.Now,
                DatumPlacanjaClanarine = DateTime.MinValue,
                DatumIstekaClanarine = DateTime.MaxValue,
                korisnickoIme = x.ime.ToLower() + "." + x.prezime.ToLower(),
                lozinka = x.lozinka,
                isClan = true
            };

            _dbContext.EndUser.Add(newMember);
            _dbContext.SaveChanges();

            EmailModel model = new EmailModel();

            string link = "<a href = " + "http://localhost:4200/confirm-registration/" + x.email + ">Potvrdi registraciju</a>";

            model.Subject = "Potvrda registracije";
            model.Body = link;
            model.To = x.email;

            PotvrdaRegistracije potvrda = new PotvrdaRegistracije();
            potvrda.isRegistrovan = true;

            if (EmailService.SendEmail(model).Value)
                potvrda.isPoslanEmail = true;
            

            return Ok(potvrda);
        }



        [HttpPost("{id}")]
        public ActionResult UpdatePodaci(int id, [FromBody] EndUserUpdateVM k)
        {
           

            var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.ID == id);

            korisnik.Ime = k.ime;
            korisnik.Prezime = k.prezime;
            korisnik.Email = k.email;
            korisnik.Adresa = k.adresa;
            korisnik.Grad = k.grad;
            korisnik.PostanskiBroj = k.postanskiBroj;
            korisnik.korisnickoIme = k.korisnickoIme;
            korisnik.lozinka = k.lozinka;

            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost("{id}"), DisableRequestSizeLimit]
        public ActionResult UpdateSlika(int id, [FromBody] EndUser korisnik)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isLogiran)
            {
                var _korisnik = _dbContext.Korisnik.Find(id);
                _korisnik.slika_korisnika = korisnik.slika_korisnika;
                _dbContext.SaveChanges();

                return Ok("OK");

                //try
                //{
                //    var file = Request.Form.Files[0];

                //    string ekstenzija = Path.GetExtension(file.FileName);
                //    string contentType = file.ContentType;

                //    var filename = $"{Guid.NewGuid()}{ekstenzija}";
                //    bool exists = System.IO.Directory.Exists(folderUploads);
                //    if (!exists)
                //        System.IO.Directory.CreateDirectory(folderUploads);

                //    var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.ID == id);
                //    if (korisnik.slika_korisnika != null)
                //    {
                //        System.IO.File.Delete(Path.Combine(folderUploads, korisnik.slika_korisnika));
                //    }

                //    korisnik.slika_korisnika = filename;
                //    file.CopyTo(new FileStream(folderUploads + filename, FileMode.Create));

                //    _dbContext.SaveChanges();

                //    return Ok("Slika uspješno promijenjena.");
                //}
                //catch (Exception e)
                //{
                //    return StatusCode(500, $"Internal server error:{e}");
                //}
            }
            else
            {
                return BadRequest("Niste logirani.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetListaZelja (int id)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKorisnik)
                return Ok(_dbContext.KnjigaListaZelja.Include(x => x.Korisnik).Where(x => x.KorisnikID == id));

            return BadRequest("Permisija odbijena.");
        }
        [HttpPost("{id}")]
        public ActionResult AddKnjigaListaZelja(int id, [FromBody] KnjigaListaZeljaVM knjiga)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKorisnik)
            {
                KnjigaListaZelja nova = new KnjigaListaZelja
                {
                    KorisnikID = id,
                    NazivKnjige = knjiga.nazivKnjige,
                    ImePisca = knjiga.imePisca,
                    PrezimePisca = knjiga.prezimePisca
                };
                _dbContext.KnjigaListaZelja.Add(nova);
                _dbContext.SaveChanges();

                return Ok("OK");
            }

            return BadRequest("Permisija odbijena.");
        }
        [HttpPost("{id}")]
        public ActionResult RemoveKnjigaListaZelja(int id)
        {
            KnjigaListaZelja knjiga = _dbContext.KnjigaListaZelja.Find(id);
            _dbContext.KnjigaListaZelja.Remove(knjiga);
            _dbContext.SaveChanges();

            return Ok("OK");
        }
    }
}
