using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjige
{
    [Table("Knjiga")]
    public abstract class Knjiga
    {
        [Key]
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string ImePisca { get; set; }
        public string PrezimePisca { get; set; }
        public string Izdavac { get; set; }
        public string GodinaIzdavanja { get; set; }
        public string Stampa { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey(nameof(Odjeljenje))]
        public int? OdjeljenjeID { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
        public string Sekcija { get; set; }
    }
}
