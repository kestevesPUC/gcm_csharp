using Microsoft.EntityFrameworkCore;
using MinhaApi;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }


    public DbSet<User>      user { get; set; }
    public DbSet<Apartment> apartment { get; set; }
    public DbSet<Bloco>     bloco { get; set; }
    public DbSet<TypeUser>  type_user { get; set; }
    public DbSet<Type>      type_vehicle { get; set; }
    public DbSet<Vehicle>   vehicle { get; set; }
    public DbSet<Model>     model { get; set; }
    public DbSet<Type>      type { get; set; }
    public DbSet<Mark>      mark { get; set; }
    public DbSet<Color>     color { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Converte todas as colunas normais para minúsculas
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToLower());
            }

            // Converte todas as chaves estrangeiras para "tabela_id"
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreach (var property in foreignKey.Properties)
                {
                    // Obtém o nome da propriedade e transforma para "nome_id"
                    string newColumnName = $"{property.Name.Replace("id", "").ToLower()}_id";
                    property.SetColumnName(newColumnName);
                }
            }
        }
    }
}