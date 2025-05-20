using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

    private UserRepo _userRepo;

    public AuthController(ApplicationDbContext dbContext)
    {
        this._userRepo = new UserRepo(dbContext);
    }
    [HttpPost]
    public async Task<dynamic> Login([FromBody] dynamic json)
    {
        JObject jsonObj = JObject.Parse(json.ToString());

        string email = jsonObj["email"].ToString();
        string password = jsonObj["password"].ToString();

        return await _userRepo.ValidaSenha(email, password);
    }
}