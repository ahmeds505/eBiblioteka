using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("RENTlog")]
    public class RENTlog
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        [ForeignKey(nameof(Knjiga))]
        public int KnjigaID { get; set; }
        public KnjigaBiblioteka Knjiga { get; set; }
        [ForeignKey(nameof(ClanBiblioteke))]
        public int EndUserID { get; set; }
        public EndUser ClanBiblioteke { get; set; }
         
    }
}
