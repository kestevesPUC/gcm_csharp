using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }


    public DbSet<Address> address { get; set; }
    public DbSet<Apartment> apartment { get; set; }
    public DbSet<Brand> brand { get; set; }
    public DbSet<Called> called { get; set; }
    public DbSet<Color> color { get; set; }
    public DbSet<Condominium> condominium { get; set; }
    public DbSet<Model> model { get; set; }
    public DbSet<Occurrence> occurrence { get; set; }
    public DbSet<Profile> profile { get; set; }
    public DbSet<Status> status { get; set; }
    public DbSet<Visitor> visitor { get; set; }
    public DbSet<TypeVehicle> typevehicle { get; set; }
    public DbSet<User> user { get; set; }
    public DbSet<Vehicle> vehicle { get; set; }
    public DbSet<Area> areas { get; set; }
    public DbSet<Reserve> reserves { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<Statement> statements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        base.OnModelCreating(modelBuilder);
    }
}