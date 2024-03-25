using e_Biblioteka.Data;
using e_Biblioteka.Helpers;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKorisnika.Models;
using e_Biblioteka.ModulKorisnika.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realms.Sync.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace e_Biblioteka.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RadnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RadnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        // GET: KorisniciController/Details/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            return Ok(_dbContext.Radnik.FirstOrDefault(x => x.ID == id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            return Ok(_dbContext.Radnik.Include(x=>x.Odjeljenje).Include(x=>x.Pozicija).ToList());
        }

        [HttpGet]
        public ActionResult GetRadnoMjesto()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            return Ok(_dbContext.RadnoMjesto.ToList());
        }

        // POST: KorisniciController/Create
        [HttpPost]
        public ActionResult Add([FromBody] RadnikVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            var newKorisnik = new Radnik
            {
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                Adresa = x.adresa,
                Grad = x.grad, 
                PostanskiBroj = x.postanskiBroj,
                DatumRegistracije = DateTime.Now,
                lozinka = x.lozinka,
                korisnickoIme = x.ime.ToLower() + "." + x.prezime.ToLower(),
                OdjeljenjeID = x.odjeljenjeID,
                PozicijaID = x.pozicijaID
            };
                _dbContext.Add(newKorisnik);
                _dbContext.SaveChanges();


            return Get(newKorisnik.ID);
        }

        [HttpPost]
        public ActionResult AddAdministrator([FromBody] RadnikVM x)
        {
            var newKorisnik = new Administrator
            {
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                Adresa = x.adresa,
                Grad = x.grad,
                PostanskiBroj = x.postanskiBroj,
                DatumRegistracije = DateTime.Now,
                lozinka = x.lozinka,
                korisnickoIme = x.ime.ToLower() + "." + x.prezime.ToLower()
            };

            _dbContext.Add(newKorisnik);
            _dbContext.SaveChanges();
            return Get(newKorisnik.ID);
        }


        // POST: KorisniciController/Edit/5
        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] RadnikVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            Radnik radnik = _dbContext.Radnik.Include(x => x.Odjeljenje).Include(x => x.Pozicija).FirstOrDefault(x => x.ID == id);

            radnik.Ime = x.ime;
            radnik.Prezime = x.prezime;
            radnik.Email = x.email;
            radnik.Adresa = x.adresa;
            radnik.Grad = x.grad;
            radnik.PostanskiBroj = x.postanskiBroj;
            radnik.lozinka = x.lozinka;
            radnik.OdjeljenjeID = x.odjeljenjeID;

            _dbContext.SaveChanges();

            return Get(id);
        }



        // POST: KorisniciController/Delete/5
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            Radnik radnik = _dbContext.Radnik.Find(id);
            _dbContext.Remove(radnik);
            _dbContext.SaveChanges();

            return Ok(radnik);
        }

        [HttpGet]
        public ActionResult GetAllUclanjeniKorisnici()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            return Ok(_dbContext.EndUser.Where(x => x.isClan).ToList());
        }

        [HttpPost]
        public ActionResult AddKorisnikUclanjen([FromBody] EndUserVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            var newMember = new EndUser
            {
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                Adresa = x.adresa,
                Grad = x.grad,
                PostanskiBroj = x.postanskiBroj,
                DatumRegistracije = DateTime.Now,
                korisnickoIme = x.ime.ToLower() + "." + x.prezime.ToLower(),
                lozinka = TokenGenerator.Generate(5),
                DatumPlacanjaClanarine = DateTime.Now,
                DatumIstekaClanarine = DateTime.Now.AddYears(1),
                isClan = true
            };

            _dbContext.EndUser.Add(newMember);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult UpdateUclanjenKorisnik(int id, [FromBody] ClanUpdateVM k)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            EndUser korisnik = _dbContext.EndUser.FirstOrDefault(x => x.ID == id);

            korisnik.Ime = k.ime;
            korisnik.Prezime = k.prezime;
            korisnik.Email = k.email;
            korisnik.Adresa = k.adresa;
            korisnik.Grad = k.grad;
            korisnik.PostanskiBroj = k.postanskiBroj;
            korisnik.DatumPlacanjaClanarine = DateTime.Now;
            korisnik.DatumIstekaClanarine = DateTime.Now.AddYears(1);

            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
