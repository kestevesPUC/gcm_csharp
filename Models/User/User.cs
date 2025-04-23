using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("user", Schema = "user")]
public class User
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public string? email { get; set; }
    public string password { get; set; }
    public DateTime created_at { get; set; }
    public DateTime? updated_at { get; set; }
    
    
    
    [ForeignKey("apartment_id")]
    public Apartment? apartment { get; set; }
    public List<Profile> profile { get; set; }
    public List<Vehicle> vehicles { get; set; }
}