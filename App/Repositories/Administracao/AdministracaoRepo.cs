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


    public async Task<Profile> CreateProfile(string name, string description) {

        Profile profile= new Profile();
        profile.name = name;
        profile.description = description;

        this._context.profile.Add(profile);
        this._context.SaveChanges();

        return profile;
    }
}