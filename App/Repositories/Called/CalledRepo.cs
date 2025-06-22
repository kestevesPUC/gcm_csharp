

using Microsoft.EntityFrameworkCore;

public class CalledRepo
{
    private readonly ApplicationDbContext _context;
    public CalledRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<List<Called>> GetCalleds()
    {
        return await _context.called
            .Include(c => c.Status)
            .Include(c => c.Responsible)
            .Include(c => c.Applicant)
            .Include(c => c.Status)
            .OrderByDescending(c => c.statusId)
            .OrderByDescending(c => c.id)
            .ToListAsync();
    }

    public async Task<Called> GetCalled(int id)
    {
        return await _context.called
            .Where(c => c.id == id)
            .FirstOrDefaultAsync();

    }


    public async Task<List<Occurrence>> GetOccurrences(int id)
    {
        return await _context.occurrence
            .Include(o => o.status)
            .Where(o => o.calledId == id)
            .OrderBy(c => c.id)
            .ToListAsync();
    }
    public async Task<dynamic> Create(string title, string description, int applicantId)
    {
        try
        {
            Called called = new Called();

            called.statusId = 1;
            called.title = title;
            called.description = description;
            called.applicantId = applicantId;
            called.created_at = Util.DateTimeNow();

            this._context.Add(called);

            if (this._context.SaveChanges() > 0)
            {



                Occurrence occurrence = new Occurrence();
                occurrence.calledId = called.id;
                occurrence.userId = applicantId;
                occurrence.message = "Chamado aberto";
                occurrence.statusId = 1;
                occurrence.created_at = Util.DateTimeNow();

                this._context.Add(occurrence);
                this._context.SaveChanges();

                return new
                {
                    success = true,
                    status = 200,
                    message = $"Chamado {called.id} aberto com sucesso!"
                };
            }

            return new
            {
                success = false,
                status = 204,
                message = $"Não foi possível abrir o chamado. Tente novamente mais tarde."
            };
        }
        catch (System.Exception e)
        {
            return new
            {
                success = false,
                status = 500,
                message = $"Houve um erro interno ao tentar abrir o chamado."
            };
        }
    }

    public async Task<dynamic> StartOcurrence(int id, int responsibleId)
    {
        try
        {
            var called = this._context.called
            .Where(o => o.id == id)
            .FirstOrDefault();

            called.statusId = 2;
            called.responsibleId = responsibleId;

            Occurrence occurrence = new Occurrence();
            occurrence.statusId = 2;
            occurrence.calledId = id;
            occurrence.userId = responsibleId;
            occurrence.message = "Atendimento Iniciado.";
            occurrence.created_at = Util.DateTimeNow();

            this._context.Add(occurrence);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    status = 200,
                    message = $"Chamado iniciado com sucesso!"
                };
            }

            return new
            {
                success = false,
                status = 204,
                message = $"Não foi possível iniciar o atendimento. Tente novamente mais tarde."
            };
        }
        catch (System.Exception e)
        {
            return new
            {
                success = false,
                status = 500,
                message = $"Não foi possível iniciar o atendimento. Tente novamente mais tarde."
            };
        }
    }


    public async Task<List<Status>> Status()
    {
        return await this._context.status.ToListAsync();
    }

    public async Task<dynamic> Atualizar(int id, int responsible_id, int status, string message)
    {
        Called called = await this.GetCalled(id);

        if (called == null)
        {
            return new
            {
                success = false,
                message = "Chamado não encontrado."
            };
        }

        called.statusId = status;
        called.responsibleId = responsible_id;


        Occurrence occurrence = new Occurrence();
        occurrence.calledId = id;
        occurrence.statusId = status;
        occurrence.userId = responsible_id;
        occurrence.created_at = Util.DateTimeNow();
        occurrence.message = message;

        this._context.Add(occurrence);

        if (this._context.SaveChanges() > 0)
        {
            return new
            {
                success = true,
                message = "Chamado atualizado com sucesso!"
            };
        }

        return new
        {
            success = false,
            message = "Houve um problema ao tentar atualizar o chamado."
        };
    }
}