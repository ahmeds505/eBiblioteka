using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulAutentifikacija.Models
{
    public class LoginInformacije
    {

        public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
        {
            this.autentifikacijaToken = autentifikacijaToken;
        }

        AutentifikacijaToken autentifikacijaToken { get; set; }
        public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.korisnickiNalog;

        public bool isLogiran => korisnickiNalog != null;
        public bool isPermisijaKnjigeCRUD => isLogiran && (korisnickiNalog.isRadnik || korisnickiNalog.isAdministrator);
        public bool isPermisijaRadnici => isLogiran && korisnickiNalog.isAdministrator;
        public bool isPermisijaKorisnik => isLogiran && korisnickiNalog.isKorisnik;
    }
}
