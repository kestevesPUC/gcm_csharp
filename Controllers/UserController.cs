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

        [HttpGet("list-all")]    
        public IActionResult GetAllUsers() 
        {
            var users = dbContext.Users.ToList();

            return Ok(users);
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
