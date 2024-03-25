using e_Biblioteka.Data;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKnjiga.Models;
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
    public class CRUDLogController: ControllerBase
    {
        private readonly ApplicationDbContext db;

        public CRUDLogController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

       [HttpGet]
       public ActionResult<List<CRUDlog>> GetLog()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");
            return db.CRUDlog.Include(x => x.Radnik).Include(x => x.Knjiga).Include(x => x.Knjiga.Odjeljenje).ToList();
            
        }
    }
}
