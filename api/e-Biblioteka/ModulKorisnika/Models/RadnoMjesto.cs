using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.Models
{
    [Table("RadnoMjesto")]
    public class RadnoMjesto
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
