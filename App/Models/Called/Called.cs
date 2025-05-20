using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("called", Schema = "called")]
public class Called
{
    [Key]
    public int id { get; set; }
    
    public string title { get; set; }
    public string description { get; set; }
    
    [ForeignKey("applicant_id")]
    public User Applicant { get; set; }
    
    [ForeignKey("responsible_id")]
    public User Responsible { get; set; }
    [ForeignKey("status_id")]
    public Status Status { get; set; }
    public DateTime? created_at { get; set; }

}