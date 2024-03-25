using e_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulReport.ViewModels
{
    public class MainVM
    {
        public DateTime DatumOD { get; set; }
        public DateTime DatumDO{ get; set; }
        public string Odjeljenje { get; set; }
        public string ImeUposlenika { get; set; }
        public string PrezimeUposlenika { get; set; }
    }
}
