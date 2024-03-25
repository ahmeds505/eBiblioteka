using e_Biblioteka.Models;
using e_Biblioteka.ModulKnjige;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("ProcitaneKnjige")]
    public class ProcitanaKnjiga
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey (nameof(knjiga))]
        public int knjigaID { get; set; }
        public Knjiga knjiga { get; set; }
        [ForeignKey (nameof(clan))]
        public int clanID { get; set; }
        public Korisnik clan { get; set; }
    }
}
