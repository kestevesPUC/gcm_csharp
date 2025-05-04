using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("profile", Schema = "administration")]
public class Profile
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    
}