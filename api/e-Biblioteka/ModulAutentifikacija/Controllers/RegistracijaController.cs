using e_Biblioteka.Data;
using Microsoft.AspNetCore.Mvc;

namespace e_Biblioteka.ModulAutentifikacija.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RegistracijaController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RegistracijaController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

    }
}
