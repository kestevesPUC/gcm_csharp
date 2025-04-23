using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("visit", Schema = "user")]
public class Visit
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [Column("user_id"), ForeignKey("user_id")]
    public User user { get; set; }

    [Column("description")]
    public string description { get; set; }

    [Column("date_start")]
    public DateTime date_start { get; set; }

    [Column("date_end")]
    public DateTime date_end { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }
}
