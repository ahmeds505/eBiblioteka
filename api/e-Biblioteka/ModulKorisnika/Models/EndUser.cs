using e_Biblioteka.ModulKnjige;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.Models
{

    public class EndUser:Korisnik
    {
        public DateTime DatumPlacanjaClanarine { get; set; }
        public DateTime DatumIstekaClanarine { get; set; }
        public bool isClan { get; set; }

        //public int BodoviZaPopust { get; set; }

    }
}
