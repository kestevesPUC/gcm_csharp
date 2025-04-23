using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("brand", Schema = "vehicle")]
public class Brand
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
}
