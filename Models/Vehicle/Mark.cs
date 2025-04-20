using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("mark", Schema = "vehicle")]
public class Mark
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
}
