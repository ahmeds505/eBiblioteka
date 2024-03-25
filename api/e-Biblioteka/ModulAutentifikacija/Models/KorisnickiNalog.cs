using e_Biblioteka.Models;
using e_Biblioteka.ModulKorisnika.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulAutentifikacija.Models
{
    [Table("KorisnickiNalog")]
    public abstract class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string korisnickoIme { get; set; }
        [Required]
        public string lozinka { get; set; }
        public string slika_korisnika { get; set; }
        public string slika_prethodna { get; set; }

        public bool Aktivacija { get; set; } = false;

        [JsonIgnore]
        public Administrator admin => this as Administrator;
        [JsonIgnore]
        public EndUser korisnik => this as EndUser;
        [JsonIgnore]
        public Radnik radnik => this as Radnik;

        public bool isAdministrator => admin != null;
        public bool isKorisnik => korisnik != null;
        public bool isRadnik => radnik != null;
    }
}
