using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;


[Table("model", Schema = "vehicle")]
public class Model
{
    
    [Key]
    public int id { get; set; }
    public string name { get; set; }
}
