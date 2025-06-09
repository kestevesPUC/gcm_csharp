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
    public string? password { get; set; }
    public string? cpf { get; set; }
    public string? photo { get; set; }
    public DateTime created_at { get; set; }
    public DateTime? updated_at { get; set; }    
    
    [Column("apartment_id")]
    public int? ApartmentId { get; set; }
    public Apartment Apartment { get; set; }


    [Column("profile_id")]
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}