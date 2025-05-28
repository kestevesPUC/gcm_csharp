using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/called")]
[ApiController]
public class CalledController : ControllerBase
{
    private CalledRepo _calledRepo;

    public CalledController(ApplicationDbContext dbContext)
    {
        this._calledRepo = new CalledRepo(dbContext);
    }

    [HttpPost("list-all")]
    public async Task<dynamic> Read()
    {
        var calleds = await this._calledRepo.GetCalleds();

        if (calleds == null)
        {
            return new
            {
                success = false,
                status = 204,
                message = "Nenhum chamado encontrado."
            };
        }

        return new
        {
            success = true,
            status = 200,
            data = calleds
        };
    }
    [HttpPost("create")]
    public async Task<dynamic> Create(dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());

        string title = jsonObj["title"].ToString();
        string description = jsonObj["description"].ToString();
        int applicantId = int.Parse(jsonObj["applicantId"].ToString());

        return await this._calledRepo.Create(title, description, applicantId);
    }

    [HttpPost("list-all-ocurrence")]
    public async Task<dynamic> ReadOcurrence(dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());
        int id = int.Parse(jsonObj["id"].ToString());

        return await this._calledRepo.GetOccurrences(id);
    }

    [HttpPost("start")]
    public async Task<dynamic> StartOcurrence(dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());
        int id = int.Parse(jsonObj["id"].ToString());
        int responsible = int.Parse(jsonObj["responsible"].ToString());

        return await this._calledRepo.StartOcurrence(id, responsible);
    }

    [HttpPost("status")]
    public async Task<dynamic> Status()
    {
        return await this._calledRepo.Status();
    }

    [HttpPost("atualizar")]
    public async Task<dynamic> Atualizar(dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());
        int id = int.Parse(jsonObj["id"].ToString());
        int responsible = int.Parse(jsonObj["user"].ToString());
        int status = int.Parse(jsonObj["status"].ToString());
        string message = jsonObj["message"].ToString();
        
        return await this._calledRepo.Atualizar(id, responsible, status, message);
    }
}