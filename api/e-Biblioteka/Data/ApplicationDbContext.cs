using e_Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulKnjige;
using e_Biblioteka.ModulKnjiga.Models;
using e_Biblioteka.ModulKorisnika.Models;
using e_Biblioteka.ModulTrgovine.Models;
using e_Biblioteka.ModulEmailKorisnik.Models;

namespace e_Biblioteka.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<EndUser> EndUser { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<RadnoMjesto> RadnoMjesto { get; set; }
        //public DbSet<RadnikOdjeljenjePozicija> RadnikOdjeljenjePozicija { get; set; }

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }


        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<KnjigaBiblioteka> KnjigaBiblioteka { get; set; }
        public DbSet<KnjigaTrgovina> KnjigaTrgovina { get; set; }
        public DbSet<CRUDlog> CRUDlog { get; set; }
        public DbSet<SHOPlog> SHOPlog { get; set; }
        public DbSet<RENTlog> RENTlog { get; set; }
        public DbSet<ProcitanaKnjiga> ProcitaneKnjige { get; set; }
        public DbSet<IznajmljenaKnjiga> IznajmljeneKnjige { get; set; }
        public DbSet<KnjigaListaZelja> KnjigaListaZelja { get; set; }

        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }



    }
}
