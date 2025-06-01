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

    [HttpPost("list-all-employee")]
    public async Task<dynamic> GetAllEmployee()
    {
        try
        {
            var employers = await this._userRepo.RecuperarEmployee();

            if (employers == null)
            {
                return new
                {
                    success = false,
                    message = "Não foi identificado funcionários.",
                    status = 204
                };
            }

            return new
            {
                success = true,
                data = employers,
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
        int profile = int.Parse(jsonObj["profile"]?.ToString());
        int bloco = 0;
        int number = 0;
        if (profile == 2)
        {
            bloco = int.Parse(jsonObj["bloco"]?.ToString());
            number = int.Parse(jsonObj["apto"]?.ToString());
        }


        return await this._userRepo.Create(name, email, password, bloco, number, profile);
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

    [HttpPost("get-user")]
    public async Task<dynamic> GetUser(dynamic data)
    {
        try
        {

            JObject jsonObj = JObject.Parse(data.ToString());
            int proprietario = int.Parse(jsonObj["proprietario"]?.ToString());
            var users = await this._userRepo.RecuperarUsuario(proprietario);

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


}

