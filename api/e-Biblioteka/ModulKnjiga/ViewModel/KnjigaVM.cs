using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulKnjiga.ViewModel
{
    public class KnjigaVM
    {
        public string Naslov { get; set; }
        public string ImePisca { get; set; }
        public string PrezimePisca { get; set; }
        public string Izdavac { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string Stampa { get; set; }
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public int OdjeljenjeID { get; set; }
        public string Sekcija { get; set; }
    }
}
