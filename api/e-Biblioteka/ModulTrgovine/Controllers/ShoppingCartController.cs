using e_Biblioteka.Data;
using e_Biblioteka.Models;
using e_Biblioteka.ModulAutentifikacija.Models;
using e_Biblioteka.ModulTrgovine.Models;
using e_Biblioteka.ModulTrgovine.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Biblioteka.ModulTrgovine.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShoppingCartController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("{id}")]
        public ActionResult<ShoppingCart> New(int id, [FromBody] CartItemVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Login podaci nisu uredu");

            // Korisnik logiraniKorisnik = (Korisnik)HttpContext.GetKorisnikOfAuthToken();
            var korisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var cart = _dbContext.ShoppingCart.FirstOrDefault(x => x.KorisnikID == korisnik.ID);
            //ako ne postoji shopping cart alocira se novi
            if (cart == null)
            {
                var knjigaNull = _dbContext.KnjigaTrgovina.FirstOrDefault(x => x.ID == id);

                var itemCartNull = new CartItem
                {
                    Kolicina = x.Kolicina,
                    Knjiga = knjigaNull
                };

                var shoppingCart = new ShoppingCart
                {
                    DatumKreiranja = DateTime.Now,
                    Korisnik = (Korisnik)korisnik,
                    CartItem = itemCartNull
                };

                _dbContext.ShoppingCart.Add(shoppingCart);
                _dbContext.SaveChanges();

                return Ok();
            }

            var knjiga = _dbContext.KnjigaTrgovina.FirstOrDefault(x => x.ID == id);

            var itemCart = new CartItem
            {
                Kolicina = x.Kolicina,
                Knjiga = knjiga
            };

            _dbContext.CartItem.Add(itemCart);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult<List<ShoppingCart>> GetShoppingCart()
        {
            if (!HttpContext.GetLoginInfo().isPermisijaKnjigeCRUD)
                return BadRequest("Login podaci nisu uredu");

            var korisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var cart = _dbContext.ShoppingCart.FirstOrDefault(x => x.KorisnikID == korisnik.ID);

            return _dbContext.ShoppingCart.Where(x => x.CartItemID == cart.ID).ToList();
        }


        [HttpGet]
        public List<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCart.Include(x => x.Korisnik).ToList();
        }

    }
}
