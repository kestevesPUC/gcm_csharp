
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/comunicado")]
[ApiController]
public class ComunicadoController
{
    private ComunicadoRepo _comunicadoRepo;

    public ComunicadoController(ApplicationDbContext dbContext)
    {
        this._comunicadoRepo = new ComunicadoRepo(dbContext);
    }

    // [HttpPost("create")]
    // public async Task<dynamic> Create([FromBody] Comuni)
    // {
    //     return await this._comunicadoRepo.Create(vehicle);
    // }
}