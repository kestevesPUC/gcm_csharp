using Microsoft.AspNetCore.Mvc;

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
}