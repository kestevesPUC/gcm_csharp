using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("user", Schema = "user")]
public class User
{
    [Key]
    public int id { get; set; }
    [Column("name")]
    public string name { get; set;}
    public string email { get; set;}
    public Apartment apartment { get; set;}
    public TypeUser type { get; set;}
    
    public List<Vehicle> vehicles { get; set; } = new();
    
    [DefaultValue(true)]
    public bool active { get; set;} = true;
    
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}
