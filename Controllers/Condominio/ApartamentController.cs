using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NomeDoProjeto.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartamentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ApartamentController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

         
    }
}
