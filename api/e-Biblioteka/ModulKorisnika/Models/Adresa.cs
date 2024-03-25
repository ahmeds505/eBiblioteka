using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKorisnika.Models
{
    public class Adresa
    {
        public int ID { get; set; }
        public string Grad { get; set; }
        public string Ulica { get; set; }
        public string Drzava { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
