using e_Biblioteka.Data;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKnjiga.Models;
using e_Biblioteka.ModulKnjiga.ViewModel;
using e_Biblioteka.ModulKnjige;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjiga.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OdjeljenjeController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public OdjeljenjeController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public class OdjeljenjeVM
        {
            public string naziv { get; set; }
            public string adresa { get; set; }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            return Ok(db.Odjeljenje.FirstOrDefault(x => x.ID == id));
        }

        [HttpGet]
        public ActionResult<List<Odjeljenje>> GetAll()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            List<Odjeljenje> lista = db.Odjeljenje.ToList();

            return lista;
        }

        [HttpPost]
        public ActionResult Add([FromBody] OdjeljenjeVM x)
        {
            if (!HttpContext.GetLoginInfo().isPermisijaRadnici)
                return BadRequest("Login podaci nisu uredu");

            var odjeljenje = new Odjeljenje
            {
                Naziv = x.naziv,
                Adresa = x.adresa
            };

            db.Add(odjeljenje);
            db.SaveChanges();

            return Ok();
        }

    }
}
