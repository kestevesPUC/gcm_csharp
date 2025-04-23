using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("called", Schema = "called")]
public class Called
{
    [Key]
    public int id { get; set; }
    
    [ForeignKey("applicant_id")]
    public User applicant { get; set; }
    
    [ForeignKey("responsible_id")]
    public User responsible { get; set; }
    [ForeignKey("status_id")]
    public Status status { get; set; }
    public DateTime? created_at { get; set; }

}