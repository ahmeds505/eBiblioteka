using e_Biblioteka.Data;
using iText.IO.Source;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulAutentifikacija.Models
{
    public static class AuthTokenExtension
    {


        public static KorisnickiNalog GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();
            KorisnickiNalog korisnickiNalog = db.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.korisnickiNalog).SingleOrDefault();
            return korisnickiNalog;
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();

            if (token == null)
                return null;

            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken.Include(k => k.korisnickiNalog)
                .SingleOrDefault(x => token != null && x.Vrijednost == token);

            return korisnickiNalog;
        }

        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();
           

            return new LoginInformacije(token);
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }

    }
}
