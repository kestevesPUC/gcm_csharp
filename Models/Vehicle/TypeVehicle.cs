using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("type", Schema = "vehicle")]
public class TypeVehicle
{
    [Key]
    public int id { get; set; }
    public string description { get; set; }
}