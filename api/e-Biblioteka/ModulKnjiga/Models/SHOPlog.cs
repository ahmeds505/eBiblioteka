using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjiga.Models
{
    [Table("SHOPlog")]
    public class SHOPlog
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumKupovine { get; set; }
        public float Popust { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey(nameof(Kupac))]
        public int EndUserID { get; set; }
        public EndUser Kupac { get; set; }
    }
}
