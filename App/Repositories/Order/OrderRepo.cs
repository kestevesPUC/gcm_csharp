using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class OrderRepo
{
    private readonly ApplicationDbContext _context;
    public OrderRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }


    public async Task<dynamic> Recuperar()
    {
        return await this._context.orders
            .Where(o => o.ativo == true)
            .ToListAsync();
    }

    public async Task<dynamic> Save(string photo = "")
    {
        try
        {
            Order order = new Order();
            order.photo = photo;
            order.data = Util.DateTimeNow();
            order.ativo = true;
            this._context.orders.Add(order);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    message = "Encomenda cadastrada com sucesso!"
                };
            }

            return new
            {
                success = false,
                message = "Houve um erro ao tentar salvar a encomenda."
            };
        }
        catch (System.Exception e)
        {

            return new
            {
                success = false,
                message = "Houve um erro interno ao tentar salvar a encomenda."
            };
    
        }
    }
    public async Task<dynamic> Update(string id)
    {
        try
        {
            Order order = await this._context.orders
                .Where(o => o.id.ToString().Equals(id))
                .FirstOrDefaultAsync();

            order.ativo = false;

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    message = "Encomenda entregue ao destinatário!"
                };
            }

            return new
            {
                success = false,
                message = "Houve um erro ao tentar atualizar a encomenda."
            };
        }
        catch (System.Exception e)
        {

            return new
            {
                success = false,
                message = "Houve um erro interno ao tentar atualizar a encomenda."
            };
    
        }
    }
}