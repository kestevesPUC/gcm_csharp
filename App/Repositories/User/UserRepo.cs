using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class UserRepo
{
    private readonly ApplicationDbContext _context;
    public UserRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<dynamic> Create(string name, string email, string password, int bloco, int number, int perfil = 1)
    {
        try
        {

            ApartmentRepo apartment = new ApartmentRepo(this._context);

            var apto = await apartment.RecuperaApto(bloco, number);

            Apartment apartment1;
            if (apto == null)
            {
                apartment1 = new Apartment();
                apartment1.number = number;
                apartment1.bloco = bloco;
                apartment1.bloco = bloco;
                apartment1.CondominiumId = 1;

                this._context.Add(apartment1);
                this._context.SaveChanges();
            }
            else
            {
                apartment1 = apto;
            }

            User user = new User();
            user.name = name;
            user.email = email;
            user.ProfileId = perfil;
            user.password = Util.GerarHashSenha(password);
            user.created_at = Util.DateTimeNow();

            user.ApartmentId = apartment1.id;

            this._context.user.Add(user);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    status = 200,
                    data = user,
                    message = "Usuário criado com sucesso!"
                };
            }

            return new
            {
                success = false,
                status = 204,
                message = "Houve um problema ao tentar criar o usuário."
            };
        }
        catch (System.Exception e)
        {
            return new
            {
                success = false,
                status = 500,
                message = "Houve erro interno ao tentar criar usuário."
            };
        }
    }


    public async Task<dynamic> RecuperarUsuarios()
    {
        return await this._context.user
            .Include(u => u.Apartment)
            .ToListAsync();
    }

    public async Task<List<Profile>> RecuperarTiposUsuario()
    {
        return await this._context.profile.ToListAsync();
    }

    public async Task<dynamic> ValidaSenha(string email, string password)
    {
        var user = await this._context.user
            .Where(u => u.email == email)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return new
            {
                success = false,
                status = 204,
                message = "Usuário não identificado."
            };
        }

        string hash = Util.GerarHashSenha(password);

        if (user.password.Equals(hash))
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
            status = 403,
            message = "Usuário ou senha incorretos."
        };
    }
}