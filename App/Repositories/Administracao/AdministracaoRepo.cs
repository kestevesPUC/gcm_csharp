using Microsoft.EntityFrameworkCore;

public class AdministracaoRepo
{
    private readonly ApplicationDbContext _context;
    public AdministracaoRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<List<Profile>> RecuperaPerfis()
    {
        return await this._context.profile.ToListAsync();
    }


    public async Task<Profile> CreateProfile(string name, string description)
    {

        Profile profile = new Profile();
        profile.name = name;
        profile.description = description;

        this._context.profile.Add(profile);
        this._context.SaveChanges();

        return profile;
    }


    public async Task<List<Area>> GetAreas()
    {
        return await this._context.areas.ToListAsync();
    }
    public async Task<Reserve> GetReserve(DateTime start, DateTime end, int area)
    {
        try
        {
            Reserve reserveArea = await this._context.reserves
                .Where(r => r.date_start >= start && r.date_start <= end)
                .Where(r => r.areaId == area)
                .FirstOrDefaultAsync();

            return reserveArea;
        }
        catch (System.Exception e)
        {

            throw;
        }
    }


    public async Task<dynamic> ReservaArea(string dataInit, string dataFim, int area, int responsavel)
    {
        DateTime start = Util.ConverterParaDate(dataInit);
        DateTime end = Util.ConverterParaDate(dataFim);

        var reserveArea = await GetReserve(start, end, area);

        if (reserveArea != null)
        {
            return new
            {
                success = false,
                message = "Esta área já está reservada neste período."
            };
        }

        Reserve reserve = new Reserve();
        reserve.areaId = area;
        reserve.userId = responsavel;
        reserve.date_end = end;
        reserve.date_start = start;
        reserve.created_at = Util.DateTimeNow();

        this._context.reserves.Add(reserve);

        if (this._context.SaveChanges() > 0)
        {
            return new
            {
                success = true,
                message = "Área reservada com sucesso!"

            };
        }

        return new
        {
            success = false,
            message = "Não foi possível reservar esta área."
        };
    }


    public async Task<dynamic> RecuperaReservas()
    {
        return await this._context.reserves
            .Include(r => r.user)
            .Include(r => r.area)
            .ToListAsync();
    }





}