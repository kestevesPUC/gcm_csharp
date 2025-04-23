using MinhaApi;

public class UserRepo
{
    private readonly ApplicationDbContext _context;
    public UserRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<dynamic> Create()
    {
        User user = new User();
        user.name = "";
        user.email = "";
        user.created_at = Util.DateTimeNow();

        this._context.user.Add(user);

        if (this._context.SaveChanges() > 0)
        {
            return new
            {
                success = true,
                status = 200,
                data = user
            };
        }

        return new
        {
            success = false,
            status = 204,
            message = "Houve um problema ao tentar criar o usuário."
        };
    }
}