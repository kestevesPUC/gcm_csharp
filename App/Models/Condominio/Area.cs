using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("area", Schema = "condominium")]
public class Area
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}