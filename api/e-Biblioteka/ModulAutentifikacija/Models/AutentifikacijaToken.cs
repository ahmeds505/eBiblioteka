using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulAutentifikacija.Models
{
    [Table("AutentifikacijaToken")]
    public class AutentifikacijaToken
    {
        [Key]
        public int ID { get; set; }
        public string Vrijednost { get; set; }
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IPadresa { get; set; }
    }
}
