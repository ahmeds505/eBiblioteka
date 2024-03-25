using System;
using e_Biblioteka.ModulAutentifikacija.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_Biblioteka.ModulReport.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using Microsoft.AspNetCore.Http;
using e_Biblioteka.Data;
using AspNetCore.Reporting;
using GenerateReport;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using e_Biblioteka.ModulTrgovine.Models;
//using QuestPDF.Previewer;


namespace e_Biblioteka.ModulReport.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportTrgovinaController: Controller
    {
        private ApplicationDbContext _db;
        private KorisnickiNalog korisnik;

        public ReportTrgovinaController(ApplicationDbContext db)
        {
            _db = db;
        }



        [HttpGet("{DatumOD}, {DatumDO}, {txtOdjeljenje}")]
        public ActionResult TrgovinaReport(DateTime DatumOD, DateTime DatumDO, int txtOdjeljenje)
        {
            /*if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");*/

            LocalReport _localReport = new LocalReport("ModulReport/TrgovinaReport.rdlc");
            List<TrgovinaReportVM> podaci = GetPodaci(DatumOD, DatumDO, _db, txtOdjeljenje);
            _localReport.AddDataSource("Trgovina", podaci);


            Dictionary<string, string> parameters = new Dictionary<string, string>();

            ReportResult result = _localReport.Execute(RenderType.Pdf, 1);
               
            return File(result.MainStream, "application/pdf");
        }

        public static List<TrgovinaReportVM> GetPodaci(DateTime datumOD, DateTime datumDO, ApplicationDbContext db, int txtOdjeljenje)
        {

           List<TrgovinaReportVM> result = db.Narudzba
                .Include(x => x.ShoppingCart)
                .Include(x => x.ShoppingCart.CartItem)
                .Include(x => x.ShoppingCart.CartItem.Knjiga)
                .Include(x => x.ShoppingCart.CartItem.Knjiga.Odjeljenje)
                .Where(x => x.DatumNarudzbe > datumOD && x.DatumNarudzbe < datumDO 
                && x.ShoppingCart.CartItem.Knjiga.OdjeljenjeID == txtOdjeljenje)
                .Select(x => new TrgovinaReportVM()
                {
                    DatumOD = datumOD.Day.ToString() 
                    + "." + 
                    datumOD.Month.ToString() 
                    + "." + 
                    datumOD.Year.ToString(),

                    DatumDO = datumDO.Day.ToString() 
                    + "." + 
                    datumDO.Month.ToString() 
                    + "." + 
                    datumDO.Year.ToString(),

                    DatumKreiranjaIzvjestaja = DateTime.Now.Date.Day.ToString() 
                    + "." + 
                    DateTime.Now.Date.Month.ToString() 
                    + "." +
                    DateTime.Now.Date.Year.ToString(),

                    NaslovKnjige = x.ShoppingCart.CartItem.Knjiga.Naslov,
                    Cijena = x.ShoppingCart.CartItem.Knjiga.Cijena,
                    Kolicina = x.ShoppingCart.CartItem.Kolicina,
                    Ukupno = x.ShoppingCart.CartItem.Knjiga.Cijena * x.ShoppingCart.CartItem.Kolicina,
                    Odjeljenje = x.ShoppingCart.CartItem.Knjiga.Odjeljenje.Naziv
                })
                .ToList();

            return result;
        }
    }
    }

