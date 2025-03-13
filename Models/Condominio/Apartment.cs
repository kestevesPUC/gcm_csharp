using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

public class Apartment
{
    [Key]
    public int id { get; set; }
    public int bloco_id { get; set; }
    public int number { get; set; }
}
