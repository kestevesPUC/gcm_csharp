using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi;
using Newtonsoft.Json.Linq;

[Route("api/administracao")]
[ApiController]
public class AdministracaoController : ControllerBase
{
    private AdministracaoRepo _administracaoRepo;

    public AdministracaoController(ApplicationDbContext dbContext)
    {
        this._administracaoRepo = new AdministracaoRepo(dbContext);
    }

    [HttpPost("list-all")]
    public async Task<dynamic> RecuperaPerfis()
    {
        var perfis = await _administracaoRepo.RecuperaPerfis();

        if (perfis == null)
        {
            return new
            {
                success = false,
                status = 204,
                message = "Nenhum perfil encontrado."
            };
        }


        return new
        {
            success = true,
            status = 200,
            data = perfis
        };
    }
    [HttpPost("add-perfil")]
    public async Task<dynamic> CreateProfile([FromBody] dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());

        string name = jsonObj["name"]?.ToString();
        string description = jsonObj["description"]?.ToString();

        var perfil = await _administracaoRepo.CreateProfile(name, description);

        if (perfil == null)
        {
            return new
            {
                success = false,
                status = 400,
                message = "Houve um problema ao tentar criar o perfil."
            };
        }


        return new
        {
            success = true,
            status = 200,
            data = perfil,
            message = "Perfil Criado com sucesso!"
        };
    }
}