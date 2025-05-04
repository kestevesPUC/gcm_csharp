using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NomeDoProjeto.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class NomeDoController : ControllerBase
    {

         [HttpPost]
        public IActionResult CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            // Aqui você processaria o produto, como salvar no banco de dados

            return Ok(new { message = "Produto criado com sucesso!", produto });
        }
    }
}
  public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }