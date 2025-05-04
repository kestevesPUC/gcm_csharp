using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private UserRepo _userRepo;

    public UserController(ApplicationDbContext dbContext)
    {
        this._userRepo = new UserRepo(dbContext);
    }

    [HttpPost("list-all")]
    public async Task<dynamic> GetAllUsers()
    {
        try
        {
            var users = await this._userRepo.RecuperarUsuarios();

            if (users == null)
            {
                return new
                {
                    success = false,
                    message = "Não foi identificado usuários.",
                    status = 204
                };
            }

            return new
            {
                success = true,
                data = users,
                status = 200
            };
        }
        catch (System.Exception e)
        {
            return new
            {
                success = false,
                message = "Houve um erro interno ao tentar recuperar os usuários.",
                status = 500
            };
        }
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

