using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("color", Schema = "vehicle")]
public class Color
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
}
