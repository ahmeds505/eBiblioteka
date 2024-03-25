using e_Biblioteka.ModulKnjiga.Models;
using e_Biblioteka.ModulKnjige;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulTrgovine.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        
        [ForeignKey(nameof(Knjiga))]
        public int KnjigaID { get; set; }
        public KnjigaTrgovina Knjiga { get; set; }

        public int Kolicina { get; set; }

    }
}
