using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("apartament", Schema = "condominium")]
public class Apartment
{
    [Key]
    public int id { get; set; }
    public int number { get; set; }

    public int bloco { get; set; }

    [ForeignKey("condominium_id")]
    public Condominium condominium { get; set; }
}
