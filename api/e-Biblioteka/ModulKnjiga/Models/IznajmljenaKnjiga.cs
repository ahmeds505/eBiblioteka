using e_Biblioteka.Models;
using e_Biblioteka.ModulKnjige;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("IznajmljeneKnjige")]
    public class IznajmljenaKnjiga 
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Clan))]
        public int ClanID { get; set; }
        public EndUser Clan { get; set; }
        [ForeignKey(nameof(Knjiga))]
        public int KnjigaID { get; set; }
        public Knjiga Knjiga { get; set; }
        public DateTime DatumIznajmljivanja { get; set; }
    }
}
