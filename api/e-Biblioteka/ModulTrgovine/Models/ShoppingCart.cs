using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulTrgovine.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public DateTime DatumKreiranja { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int? KorisnikID { get; set; }
        public Korisnik? Korisnik { get; set; }

        [ForeignKey(nameof(CartItem))]
        public int CartItemID { get; set; }
        public CartItem CartItem { get; set; }
    }
}
