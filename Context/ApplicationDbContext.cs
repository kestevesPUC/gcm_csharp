using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
    

    public DbSet<User> user { get; set; }
    public DbSet<Apartment> apartment { get; set; }
    public DbSet<Bloco> bloco { get; set; }
    public DbSet<TypeUser> type_user { get; set; }
    public DbSet<TypeVehicle> type_vehicle { get; set; }
    public DbSet<Vehicle> vehicle { get; set; }
    public DbSet<VehicleUser> user_vehicle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}