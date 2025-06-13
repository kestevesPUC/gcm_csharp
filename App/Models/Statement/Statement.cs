using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

[Table("statement", Schema = "user")]

public class Statement
{
    [Key]
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public bool ativo { get; set; }
    public string? photo { get; set; }
    public DateTime? data { get; set; }
}