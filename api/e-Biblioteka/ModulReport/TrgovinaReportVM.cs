using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateReport
{
    public class TrgovinaReportVM
    {
        public int RedniBroj { get; set; }
        public string DatumOD { get; set; }
        public string DatumDO { get; set; }
        public string DatumKreiranjaIzvjestaja { get; set; }
        public string NaslovKnjige { get; set; }
        public float Cijena { get; set; }
        public int Kolicina { get; set; }
        public string Odjeljenje { get; set; }
        public float Ukupno { get; set; }

        

        public static List<TrgovinaReportVM> Get()
        {
            return new List<TrgovinaReportVM>();
        }
    }
}