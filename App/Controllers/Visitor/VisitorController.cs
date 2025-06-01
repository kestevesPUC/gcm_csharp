
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/visitor")]
[ApiController]
public class VisitorController : ControllerBase
{
    private UserRepo _userRepo;
    private VisitorRepo _visitorRepo;
    private ApplicationDbContext _dbContext;

    public VisitorController(ApplicationDbContext dbContext)
    {
        this._visitorRepo = new VisitorRepo(dbContext);
        this._userRepo = new UserRepo(dbContext);
        this._dbContext = dbContext;
    }


    [HttpPost("registra-visita")]
    public async Task<dynamic> RegistraVisitante([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        string cpf = jsonObj["cpf"]?.ToString();
        int responsavel = int.Parse(jsonObj["responsavel"]?.ToString());
        string name = jsonObj["name"]?.ToString();
        string email = jsonObj["email"]?.ToString();
        string dataInit = jsonObj["dataInit"]?.ToString();
        string dataFim = jsonObj["dataFim"]?.ToString();
        string motivo = jsonObj["motivo"]?.ToString();
        dynamic result = new { };

        dynamic user = await this._userRepo.RecuperarUsuarioPeloCpf(cpf);

        if (user == null)
        {
            result = await this._userRepo.Create(name, email, "123456", 0, 0, 5, cpf);
            user = result.data;
        }
        System.Console.WriteLine(user);
        int user_id = user.id;

        var resul2 = await this._visitorRepo.Create(user_id, responsavel, motivo, dataInit, dataFim);


        return resul2;
    }


    [HttpPost("recupera-visitante")]
    public async Task<dynamic> RecuperaVisitante([FromBody] dynamic data)
    {
        
        JObject jsonObj = JObject.Parse(data.ToString());
        return await this._userRepo.RecuperarUsuarioPeloCpf(jsonObj["cpf"]?.ToString());
    }

    [HttpPost("recupera-visitantes")]
    public async Task<dynamic> RecuperaVisitantes()
    {
        return await this._visitorRepo.RecuperarVisitantes();
    }


}