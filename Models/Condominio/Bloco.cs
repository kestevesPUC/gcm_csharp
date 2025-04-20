using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("bloco")]
public class Bloco
{
    [Key]
    public int id { get; set; }
}
