using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKorisnika.Models
{
    [Table("RadnikOdjeljenjePozicija")]
    public class RadnikOdjeljenjePozicija
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Radnik Radnik { get; set; }
        [ForeignKey(nameof(Odjeljenje))]
        public int OdjeljenjeID { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
        [ForeignKey(nameof(Pozicija))]
        public int PozicijaID { get; set; }
        public RadnoMjesto Pozicija { get; set; }
    }
}
