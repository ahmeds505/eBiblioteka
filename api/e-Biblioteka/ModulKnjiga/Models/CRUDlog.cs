using e_Biblioteka.Models;
using e_Biblioteka.ModulKnjige;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("CRUDlog")]
    public class CRUDlog
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Radnik))]
        public int RadnikID { get; set; }
        public Korisnik Radnik { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public string Opis { get; set; }
        [ForeignKey(nameof(Knjiga))]
        public int KnjigaID { get; set; }
        public Knjiga Knjiga { get; set; }
    }
}
