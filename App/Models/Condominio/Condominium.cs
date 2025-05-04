using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("condominium", Schema = "condominium")]
public class Condominium
{
    [Key]
    public int id { get; set; }
    public string cnpj { get; set; }
    public string name { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public List<Apartment> apartments { get; set; }
}
