public class ComunicadoRepo
{
    private readonly ApplicationDbContext _context;
    public ComunicadoRepo(ApplicationDbContext contex)
    {
        this._context = contex;
    }
    
}