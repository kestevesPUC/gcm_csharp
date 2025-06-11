using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class StatementRepo
{
    private readonly ApplicationDbContext _context;
    public StatementRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<dynamic> Read()
    {
        return await this._context.statements
            .Where(s => s.ativo == true)
            .ToListAsync();
    }

    public async Task<dynamic> Create(string title, string description, string photo = "")
    {
        Statement statement = new Statement();

        statement.ativo = true;
        statement.title = title;
        statement.description = description;
        statement.description = photo;
        statement.data = Util.DateTimeNow();

        this._context.Add(statement);

        if (this._context.SaveChanges() > 0)
        {
            return new
            {
                success = true,
                message = "Comunicado cadastrado com sucesso!"
            };
        }
        return new
        {
            success = false,
            message = "Houve um erro ao tentar criar o comunicado."
        };
    }

    public async Task<dynamic> Update(string id)
    {
        Statement statement = await this._context.statements
            .Where(s => s.id.ToString().Equals(id))
            .FirstOrDefaultAsync();

        statement.ativo = false;

        if (this._context.SaveChanges() > 0)
        {
            return new
            {
                success = true,
                message = "Comunicado desabilitado!"
            };
        }

        return new
        {
            success = false,
            message = "Não foi possível desabilitar o comunicado."
        };
    }
}