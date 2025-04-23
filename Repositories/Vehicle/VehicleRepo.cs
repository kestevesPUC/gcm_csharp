public class VehicleRepo
{
    private readonly ApplicationDbContext _context;
    public VehicleRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    
}