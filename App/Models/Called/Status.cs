using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("status", Schema = "called")]
public class Status
{
    [Key]
    public int id { get; set; }
    public string description { get; set; }
    public string description2 { get; set; }
}