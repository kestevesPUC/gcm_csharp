

using Microsoft.EntityFrameworkCore;

public class CalledRepo
{
    private readonly ApplicationDbContext _context;
    public CalledRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }

    public async Task<List<Called>> GetCalleds() {
        return  await _context.called
            .Include(c => c.Status)
            .Include(c => c.Responsible)
            .Include(c => c.Applicant)
            .OrderByDescending(c => c.id)
            .ToListAsync();
    }
}