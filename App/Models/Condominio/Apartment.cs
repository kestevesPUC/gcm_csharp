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

    [Column("condominium_id")]
    public int CondominiumId { get; set; }
    public Condominium Condominium { get; set; }
}
