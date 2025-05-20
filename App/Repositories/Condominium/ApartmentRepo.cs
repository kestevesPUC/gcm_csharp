using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class ApartmentRepo
{
    private readonly ApplicationDbContext _context;
    public ApartmentRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<List<Apartment>> RecuperaApartamentos() {
        return await _context.apartment.ToListAsync();
    }

    public async Task<Apartment> InserirApto(int number, int bloco) {
        Apartment apartment = new Apartment();
        apartment.number = number;
        apartment.bloco = bloco;
        apartment.CondominiumId = 1;

        this._context.Add(apartment);

        return apartment;
    }

    public async Task<Apartment> RecuperaApto(int bloco, int number) {
        return await this._context.apartment
            .Where(a => a.bloco == bloco && a.number == number)
            .FirstOrDefaultAsync();
    }

}