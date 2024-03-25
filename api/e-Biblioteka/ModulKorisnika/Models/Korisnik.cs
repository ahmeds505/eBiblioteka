using e_Biblioteka.ModulAutentifikacija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.Models
{
    public abstract class Korisnik:KorisnickiNalog
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public int PostanskiBroj { get; set; }
        public DateTime DatumRegistracije { get; set; }


    }
}
