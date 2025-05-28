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
    public int calledId { get; set; }
    public Called called { get; set; }

    [Column("user_id")]
    public int userId { get; set; }
    public User user { get; set; }

    [Column("status_id")]
    public int statusId { get; set; }

    public Status status { get; set; }

    [Column("message")]
    public string message { get; set; }
    
    
    public DateTime? created_at { get; set; }
}