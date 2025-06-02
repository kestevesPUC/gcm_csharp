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

    [HttpPost("areas")]
    public async Task<dynamic> GetAreas()
    {
        return await _administracaoRepo.GetAreas();
    }
    [HttpPost("reserva-areas")]
    public async Task<dynamic> ReservaArea([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        string dataInit = jsonObj["dataInit"]?.ToString();
        string dataFim = jsonObj["dataFim"]?.ToString();
        int area = int.Parse(jsonObj["area"]?.ToString());
        int responsavel = int.Parse(jsonObj["responsavel"]?.ToString());

        return await _administracaoRepo.ReservaArea(dataInit, dataFim, area, responsavel);
    }

    [HttpPost("recupera-reservas")]
    public async Task<dynamic> RecuperaReservas()
    {
        return await _administracaoRepo.RecuperaReservas();
    }

    [HttpPost("upload")]
    public async Task<dynamic> UploadImagem(IFormFile imagem)
    {
        if (imagem == null || imagem.Length == 0)
            return BadRequest("Nenhuma imagem enviada.");

        // Caminho da pasta 'storage' dentro do projeto
        var pastaStorage = Path.Combine(Directory.GetCurrentDirectory(), "storage");

        // Garante que a pasta exista
        if (!Directory.Exists(pastaStorage))
            Directory.CreateDirectory(pastaStorage);

        // Caminho completo para salvar o arquivo
        var caminhoCompleto = Path.Combine(pastaStorage, imagem.FileName);

        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
        {
            await imagem.CopyToAsync(stream);
        }

        return new
        {
            success = true,
            message = "Upload realizado com sucesso",
        };
    }
}