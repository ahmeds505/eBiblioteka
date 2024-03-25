using e_Biblioteka.Data;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKnjiga.Models;
using e_Biblioteka.ModulKnjiga.ViewModel;
using e_Biblioteka.ModulKnjige;
using e_Biblioteka.ModulKnjiga.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

namespace e_Biblioteka.ModulKnjiga.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public KnjigaController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            return Ok(db.Knjiga.FirstOrDefault(x => x.ID == id));
        }

        //Knjige za iznajmljivanje
        [HttpPost]
        public Knjiga AddKnjigaBiblioteka([FromBody] KnjigaVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
            //    return null;

            var newKnjiga = new KnjigaBiblioteka
            {
                Naslov = x.Naslov,
                ImePisca = x.ImePisca,
                PrezimePisca = x.PrezimePisca,
                Izdavac = x.Izdavac,
                GodinaIzdavanja = x.GodinaIzdavanja.ToString(),
                Stampa = x.Stampa,
                Kolicina = x.Kolicina,
                OdjeljenjeID = x.OdjeljenjeID,
                Sekcija = "Biblioteka"
            };

            db.KnjigaBiblioteka.Add(newKnjiga);
            db.SaveChanges();

            CRUDlogController(newKnjiga.ID, "Dodana nova knjiga za biblioteku");

            return newKnjiga;
        }

        [HttpPost]
        public void CRUDlogController(int id, string opis)
        {
            var uposlenik = HttpContext.GetKorisnikOfAuthToken();

            var newLog = new CRUDlog
            {
                RadnikID = uposlenik.ID,
                KnjigaID = id,  
                DatumIzmjene = DateTime.Now,
                Opis = opis,
                Radnik = (Korisnik)uposlenik,
                Knjiga = db.Knjiga.FirstOrDefault(x => x.ID == id)
            };

            db.CRUDlog.Add(newLog);
            db.SaveChanges();
        }

        //Knjige za prodaju
        [HttpPost]
        public ActionResult<Knjiga> AddKnjigaTrgovina([FromBody] KnjigaVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return null;

            var newKnjiga = new KnjigaTrgovina
            {
                Naslov = x.Naslov,
                ImePisca = x.ImePisca,
                PrezimePisca = x.PrezimePisca,
                Izdavac = x.Izdavac,
                GodinaIzdavanja = x.GodinaIzdavanja.ToString(),
                Stampa = x.Stampa,
                Kolicina = x.Kolicina,
                Cijena = x.Cijena,
                OdjeljenjeID = x.OdjeljenjeID,
                Sekcija = "Trgovina"
            };

            db.KnjigaTrgovina.Add(newKnjiga);
            db.SaveChanges();

            CRUDlogController(newKnjiga.ID, "Dodana nova knjiga za trgovinu");

            return Ok(true);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] KnjigaVM x)
        {
            //if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
            //    return BadRequest("Login podaci nisu uredu");

            Knjiga knjiga = db.Knjiga.Include(x => x.Odjeljenje).FirstOrDefault(x => x.ID == id);

            knjiga.Naslov = x.Naslov;
            knjiga.ImePisca = x.ImePisca;
            knjiga.PrezimePisca = x.PrezimePisca;
            knjiga.Naslov = x.Naslov;
            knjiga.Izdavac = x.Izdavac;
            knjiga.Kolicina = x.Kolicina;
            knjiga.Stampa = x.Stampa;
            knjiga.OdjeljenjeID = x.OdjeljenjeID;
            knjiga.Sekcija = x.Sekcija;


            db.SaveChanges();

            CRUDlogController(knjiga.ID, "Izmjena podataka");

            return GetById(knjiga.ID);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            Knjiga knjiga = db.Knjiga.Find(id);

            CRUDlogController(knjiga.ID, "Brisanje knjige");

            db.Remove(knjiga);
            db.SaveChanges();


            return Ok(knjiga);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKnjigeCRUD || loginInfo.isPermisijaKorisnik)
            {
                return Ok(db.Knjiga.Include(x => x.Odjeljenje).ToList());
            }

            return BadRequest("Permisija odbijena.");

        }

        [HttpGet("{sekcija}")]
        public ActionResult GetAllBySekcija(string sekcija)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKnjigeCRUD || loginInfo.isPermisijaKorisnik)
            {
                return Ok(db.Knjiga.Include(x => x.Odjeljenje).Where(x => x.Sekcija == sekcija).ToList());
            }

            return BadRequest("Permisija odbijena.");

        }

        [HttpGet]
        public ActionResult<PagedList<Knjiga>> GetAllPaged(int brojStranica, int brojItema)
        {
           var knjige = db.Knjiga.Include(x => x.Odjeljenje).ToList().AsQueryable();

           return new PagedList<Knjiga>(knjige, brojStranica, brojItema);
        }

        [HttpPost("{idKnjiga},{idKorisnik}")]
        public ActionResult IznajmiKnjigu(int idKnjiga, int idKorisnik)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKorisnik)
            {
                List<IznajmljenaKnjiga> iznajmljene = db.IznajmljeneKnjige.Where(x => x.ClanID == idKorisnik).ToList();
                var zaIznajmljivanje = db.Knjiga.Find(idKnjiga);

                if (iznajmljene.Count() == 2)
                {
                    return BadRequest("2");
                }

                if (zaIznajmljivanje.Kolicina == 0)
                {
                    return BadRequest("1");
                }

                foreach (var x in iznajmljene)
                {
                    if (x.KnjigaID == idKnjiga)
                    {
                        return BadRequest("Knjiga je već iznajmljena.");
                    }
                }

                RENTlog log = new RENTlog
                {
                    DatumIznajmljivanja = DateTime.Now,
                    EndUserID = idKorisnik,
                    ClanBiblioteke = db.EndUser.Find(idKorisnik),
                    Knjiga = db.KnjigaBiblioteka.Find(idKnjiga),
                    KnjigaID = idKnjiga
                };

                Knjiga knjiga = db.Knjiga.Find(idKnjiga);
                knjiga.Kolicina--;


                db.RENTlog.Add(log);
                db.SaveChanges();

                DodajIznajmljenuKnjigu(idKorisnik, idKnjiga);

                return Ok("Knjiga je uspješno iznajmljena.");
            }
            else
            {
                return BadRequest("Permisija odbijena.");
            }
                
        }
        private void DodajIznajmljenuKnjigu(int korisnikId, int knjigaId)
        {
            EndUser clan = db.EndUser.Find(korisnikId);
            Knjiga knjiga = db.Knjiga.Find(knjigaId);

            IznajmljenaKnjiga iznajmljenaKnjiga = new IznajmljenaKnjiga
            {
                ClanID = korisnikId,
                Clan = clan,
                KnjigaID = knjigaId,
                Knjiga = knjiga,
                DatumIznajmljivanja = DateTime.Now
            };

            db.IznajmljeneKnjige.Add(iznajmljenaKnjiga);
            db.SaveChanges();
        }


        [HttpPost("{idKnjiga},{idKorisnik}")]
        public ActionResult VratiKnjigu(int idKnjiga, int idKorisnik)
        {
            List<RENTlog> log = db.RENTlog.Where(x => x.EndUserID == idKorisnik && x.KnjigaID == idKnjiga).ToList();
            int n = log.Count();
            log[n - 1].DatumVracanja = DateTime.Now;
            Knjiga knjiga = db.Knjiga.Find(idKnjiga);
            knjiga.Kolicina++;
            List<IznajmljenaKnjiga> iznajmljenaKnjiga = db.IznajmljeneKnjige.Where(x => x.ClanID == idKorisnik && x.KnjigaID == idKnjiga).ToList();
            db.IznajmljeneKnjige.Remove(iznajmljenaKnjiga[0]);

            DodajProcitanuKnjigu(idKorisnik, idKnjiga);

            db.SaveChanges();

            return Ok("OK");

        }
        private void DodajProcitanuKnjigu(int korisnikid, int knjigaid)
        {
            Korisnik korisnik = db.Korisnik.Find(korisnikid);
            Knjiga knjiga = db.Knjiga.Find(knjigaid);
            ProcitanaKnjiga nova = new ProcitanaKnjiga
            {
                knjiga = knjiga,
                clan = korisnik
            };
            db.ProcitaneKnjige.Add(nova);
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult GetIznajmljene()
        {
            var loginInfo = HttpContext.GetLoginInfo();

            //if (loginInfo.isPermisijaRadnici)
            //{
                List<IznajmljenaKnjiga> list = db.IznajmljeneKnjige.Include(x => x.Knjiga).Include(x => x.Clan).ToList();

                return Ok(list);
            //}

            return BadRequest("Permisija odbijena.");
        }

        [HttpGet("{clanId}")]
        public ActionResult GetIznajmljeneById(int clanId)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if (loginInfo.isPermisijaKorisnik)
            {
                List<IznajmljenaKnjiga> list = db.IznajmljeneKnjige.Include(x => x.Knjiga).Where(x => x.ClanID == clanId).ToList();

                return Ok(list);
            }

            return BadRequest("Permisija odbijena.");
        }

        [HttpGet("{clanId}")]
        public ActionResult GetProcitane(int clanId)
        {
            var loginInfo = HttpContext.GetLoginInfo();

            if(loginInfo.isPermisijaKorisnik)
                return Ok(db.ProcitaneKnjige.Include(x=> x.knjiga).Where(x => x.clanID == clanId).ToList());

            return BadRequest("Permisija odbijena.");
        }
    }
}
