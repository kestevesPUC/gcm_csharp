using Microsoft.EntityFrameworkCore;

public class VehicleRepo
{
    private readonly ApplicationDbContext _context;
    public VehicleRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<Vehicle> GetVehicle(int id)
    {
        try
        {
            return await _context.vehicle
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public async Task<List<Vehicle>> GetVehicles(int user_id = 0)
    {
        try
        {
            if (user_id == 0)
            {
                return await _context.vehicle
                    .Include(v => v.Brand)
                    .Include(v => v.Color)
                    .Include(v => v.Model)
                    .Include(v => v.Type)
                    .ToListAsync();
            }

            return await _context.vehicle
                .Where(v => v.UserId == user_id)
                .Include(v => v.Brand)
                .Include(v => v.Color)
                .Include(v => v.Model)
                .Include(v => v.Type)
                .ToListAsync();
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public async Task<dynamic> Create(Vehicle vehicle)
    {
        try
        {
            this._context.vehicle.Add(vehicle);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    message = "Veículo criado com sucesso!",
                    status = 200
                };
            }

            return new
            {
                success = false,
                message = "Não foi possível cadastrar o veículo",
                status = 204
            };

        }
        catch (System.Exception)
        {

            return new
            {
                success = false,
                message = "Houve um erro interno ao tentar criar o veículo",
                status = 500
            };
        }
    }


}