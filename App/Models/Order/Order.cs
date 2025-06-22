using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("order", Schema = "public")]
public class Order
{
    [Key]
    public int id { get; set; }
    public bool ativo { get; set; }
    public DateTime? data { get; set; }
    public string? photo { get; set; }
}
