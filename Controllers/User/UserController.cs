using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi;

namespace MyApp.Namespace
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpPost("list-all")]    
        public async Task<dynamic> GetAllUsers() 
        {
            var users = dbContext.user.ToList();

            return new {
                success = true,
                data = users,
                status = 200
            };
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User inválido.");
            }

            // Aqui você processaria o User, como salvar no banco de dados

            return Ok(new { message = "User criado com sucesso!", user });
        }
    }
}
