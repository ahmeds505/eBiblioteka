using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using e_Biblioteka.Models;

namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("KnjigaListaZelja")]
    public class KnjigaListaZelja
    {
        [Key]
        public int Id { get; set; }
        public string NazivKnjige { get; set; }
        public string ImePisca { get; set; }
        public string PrezimePisca { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
