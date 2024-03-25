namespace e_Biblioteka.ModulAutentifikacija.ViewModels
{
    public class AutentifikacijaVM
    {
        public bool isAdministrator { get; set; }
        public bool isRadnik { get; set; }
        public bool isKorisnik { get; set; }
        public bool isLogiran { get; set; }
        public string vrijednost { get; set; }
        public string korisnickoIme { get; set; }
        public int korisnikId { get; set; }
    }
}
