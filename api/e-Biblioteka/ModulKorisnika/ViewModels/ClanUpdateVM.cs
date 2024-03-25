using Microsoft.AspNetCore.Http;

namespace e_Biblioteka.ModulKorisnika.ViewModels
{
    public class ClanUpdateVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string adresa { get; set; }
        public string grad { get; set; }
        public int postanskiBroj { get; set; }
        
       
    }
}
