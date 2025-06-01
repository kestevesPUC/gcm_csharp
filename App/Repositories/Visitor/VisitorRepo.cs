using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class VisitorRepo
{
    private readonly ApplicationDbContext _context;
    public VisitorRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<dynamic> Create(int user_id, int responsavel_id, string description, string dateStart, string dateEnd)
    {
        try
        {
            DateTime start = Util.ConverterParaDate(dateStart);
            DateTime end = Util.ConverterParaDate(dateEnd);

            Visitor visitor = new Visitor();
            visitor.description = description;
            visitor.created_at = Util.DateTimeNow();
            visitor.date_end = end;
            visitor.date_start = start;
            visitor.userId = user_id;
            visitor.responsibleId = responsavel_id;

            this._context.Add(visitor);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    message = "Visitante cadastrado com sucesso."
                };
            }

            return new
            {
                success = false,
                message = "Não foi possível cadastrar o visitante."
            };
        }
        catch (System.Exception e)
        {
            return new
            {
                success = false,
                message = "Não foi possível cadastrar o visitante."
            };
        }
    }


    public async Task<dynamic> RecuperarVisitantes()
    {
        try
        {
            DateTime agoraLocal = DateTime.Now;
            DateTime hoje = agoraLocal.Date;

            // Semana iniciando na segunda-feira
            var inicioSemanaLocal = hoje.AddDays(-(int)(hoje.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)hoje.DayOfWeek - 1));
            var fimSemanaLocal = inicioSemanaLocal.AddDays(7).AddSeconds(-1);

            // Converte para UTC apenas no momento da comparação com o banco
            var inicioSemanaUtc = inicioSemanaLocal.ToUniversalTime();
            var fimSemanaUtc = fimSemanaLocal.ToUniversalTime();

            return await this._context.visitor
               .Where(v =>
               v.date_start <= fimSemanaUtc &&
                v.date_end >= inicioSemanaUtc
                )
                .Include(v => v.user)
               .Join(this._context.user,
                    v => v.responsibleId,
                    r => r.id,
                    (v, r) => new { v, r }
               )
               .ToListAsync();
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }


}