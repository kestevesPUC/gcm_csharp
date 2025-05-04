
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/vehicle")]
[ApiController]
public class VehicleController : ControllerBase
{
    private VehicleRepo _vehicleRepo;

    public VehicleController(ApplicationDbContext dbContext)
    {
        this._vehicleRepo = new VehicleRepo(dbContext);
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
}