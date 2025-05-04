using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("address", Schema = "condominium")]
public class Address
{
    [Key]
    public int id { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public string postal_cod { get; set; }
    public int number { get; set; }
    public string? complement { get; set; }

    // public Condominium? condominium { get; set; }
}