using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.Models
{

    public class Radnik:Korisnik
    {
        [ForeignKey(nameof(Odjeljenje))]
        public int? OdjeljenjeID { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
        [ForeignKey(nameof(Pozicija))]
        public int? PozicijaID { get; set; }
        public RadnoMjesto Pozicija { get; set; }
        public string Obrazovanje { get; set; }
    }
}
