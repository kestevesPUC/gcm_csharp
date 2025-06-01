using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("visitor", Schema = "user")]
public class Visitor
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [Column("description")]
    public string description { get; set; }

    [Column("date_start")]
    public DateTime date_start { get; set; }
    
    [Column("date_end")]
    public DateTime date_end { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }
    
    [Column("user_id")]
    public int userId { get; set; }
    public User user { get; set; }

    [Column("responsible_id")]
    public int responsibleId { get; set; }
}