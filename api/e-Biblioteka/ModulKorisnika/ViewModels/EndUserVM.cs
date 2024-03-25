using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKorisnika.ViewModels
{
    public class EndUserVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }
        public string grad { get; set; }
        public string lozinka { get; set; }
        public int postanskiBroj { get; set; }
        public DateTime datumRegistracije { get; set; }
    }
}
