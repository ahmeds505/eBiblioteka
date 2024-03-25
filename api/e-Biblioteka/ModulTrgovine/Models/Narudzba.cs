using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKorisnika.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulTrgovine.Models
{
    public enum Status
    {
        Obrada,
        Slanje,
        Dostavljeno,
        Ponisteno
    }

    public class Narudzba
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime DatumDostave { get; set; }

        [ForeignKey(nameof(Adresa))]
        public int AdresaID { get; set; }
        public Adresa Adresa { get; set; }

        public Status StatusNarudzbe { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public  int KorisnikID{ get; set; }
        public KorisnickiNalog Korisnik { get; set; }

        [ForeignKey(nameof(ShoppingCart))]
        public int? ShoppingCartID { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
