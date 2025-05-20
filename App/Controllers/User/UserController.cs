using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi;
using Newtonsoft.Json.Linq;

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


    [HttpPost("create")]
    public async Task<dynamic> CreateUser([FromBody] dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());

        string name = jsonObj["name"]?.ToString();
        string email = jsonObj["email"]?.ToString();
        string password = jsonObj["password"]?.ToString();
        int bloco = int.Parse(jsonObj["bloco"]?.ToString());
        int number = int.Parse(jsonObj["apto"]?.ToString());


        return await this._userRepo.Create(name, email, password, bloco, number);
    }


    [HttpPost("list-type-users")]
    public async Task<dynamic> RecuperarTiposUsuario()
    {
        var list = await this._userRepo.RecuperarTiposUsuario();

        if (list != null)
        {
            return new
            {
                success = true,
                status = 200,
                data = list
            };
        }

        return new
        {
            success = false,
            status = 204,
            message = "Não foi possível recuperar os tipos de usuários."
        };
    }


}

