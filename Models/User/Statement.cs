using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("statement", Schema = "user")]
public class Statement
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [Column("description")]
    public string description { get; set; }

    [Column("date_end")]
    public DateTime date_end { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }

    [Column("visible")]
    public bool visible { get; set; }

    [ForeignKey("user_id")]
    public User user { get; set; }
}