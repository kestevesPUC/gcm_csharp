
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/vehicle")]
[ApiController]
public class VehicleController : ControllerBase
{
    private VehicleRepo _vehicleRepo;
    private ApplicationDbContext _dbContext;

    public VehicleController(ApplicationDbContext dbContext)
    {
        this._vehicleRepo = new VehicleRepo(dbContext);
        this._dbContext = dbContext;
    }

    [HttpPost("create")]
    public async Task<dynamic> Create([FromBody] Vehicle vehicle)
    {
        return await this._vehicleRepo.Create(vehicle);
    }

    [HttpPost("list-all")]
    public async Task<dynamic> Read()
    {
        var vehicle = await this._vehicleRepo.GetVehicles();

        if (vehicle != null)
        {

            return new
            {
                success = true,
                status = 200,
                data = vehicle
            };
        }


        return new
        {
            success = false,
            status = 204,
            message = "Nenhum veículo localizado."
        };
    }

    [HttpPost("infos")]
    public async Task<dynamic> ListInfos()
    {
        UserRepo userRepo = new UserRepo(this._dbContext);
        var users = await userRepo.RecuperarUsuarios();
        var types = await this._vehicleRepo.GetTypes();
        var brands = await this._vehicleRepo.GetBrands();
        var models = await this._vehicleRepo.GetModels();
        var colors = await this._vehicleRepo.GetColors();

        return new
        {
            success = true,
            data = new
            {
                users = users,
                types = types,
                brands = brands,
                models = models,
                colors = colors
            }
        };
    }

    [HttpPost("create2")]
    public async Task<dynamic> Create([FromBody] dynamic data)
    {

        JObject jsonObj = JObject.Parse(data.ToString());


        Vehicle vehicle = new Vehicle();

        vehicle.UserId = int.Parse(jsonObj["user"]?.ToString());
        vehicle.Year = int.Parse(jsonObj["ano"]?.ToString());
        vehicle.TypeId = int.Parse(jsonObj["type"]?.ToString());
        vehicle.BrandId = int.Parse(jsonObj["brand"]?.ToString());
        vehicle.ColorId = int.Parse(jsonObj["color"]?.ToString());
        vehicle.ModelId = int.Parse(jsonObj["model"]?.ToString());
        vehicle.Plate = jsonObj["placa"]?.ToString();

        return await this._vehicleRepo.Create(vehicle);
    }
}