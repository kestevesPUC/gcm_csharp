using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("occurrence", Schema = "called")]
public class Occurrence
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [Column("called_id")]
    
    [ForeignKey("called_id")]
    public Called called { get; set; }

    [Column("user_id")]
    
    [ForeignKey("user_id")]
    public User user { get; set; }

    [Column("status_id")]
    
    [ForeignKey("status_id")]
    public Status status { get; set; }

    [Column("message")]
    public string message { get; set; }
}