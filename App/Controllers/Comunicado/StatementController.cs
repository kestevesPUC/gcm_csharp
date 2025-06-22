
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/statement")]
[ApiController]
public class StatementController
{
    private StatementRepo _statementRepo;

    public StatementController(ApplicationDbContext dbContext)
    {
        this._statementRepo = new StatementRepo(dbContext);
    }

    [HttpPost("list-all")]
    public async Task<dynamic> Read()
    {
        return await this._statementRepo.Read();
    }

    [HttpPost("create")]
    public async Task<dynamic> Create([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        string title = jsonObj["title"]?.ToString() ?? "";
        string mensagem = jsonObj["mensagem"]?.ToString() ?? "";
        string photo = jsonObj["photo"]?.ToString() ?? "";

        return await this._statementRepo.Create(title, mensagem, photo);
    }

    [HttpPost("update")]
    public async Task<dynamic> Update([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        return await this._statementRepo.Update(jsonObj["id"]?.ToString());
    }
}