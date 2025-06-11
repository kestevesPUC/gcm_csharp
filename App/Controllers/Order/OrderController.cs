
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/order")]
public class OrderController
{
    private ApplicationDbContext _dbContext;
    private OrderRepo _orderRepo;
    public OrderController(ApplicationDbContext dbContext)
    {
        this._orderRepo = new OrderRepo(dbContext);
        this._dbContext = dbContext;
    }

    [HttpPost("list-all")]
    public async Task<dynamic> Recuperar()
    {
        return await _orderRepo.Recuperar();
    }

    [HttpPost("save")]
    public async Task<dynamic> Save([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        
        return await _orderRepo.Save(jsonObj["photo"]?.ToString());
    }
    [HttpPost("update")]
    public async Task<dynamic> Update([FromBody] dynamic data)
    {
        JObject jsonObj = JObject.Parse(data.ToString());
        
        return await _orderRepo.Update(jsonObj["id"]?.ToString());
    }
}