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

    [Column("status_id")]
    public int statusId { get; set; }
    [Column("applicant_id")]
    public int applicantId { get; set; }

    [Column("responsible_id")]
    public int? responsibleId { get; set; }
    public User Applicant { get; set; }

    public User Responsible { get; set; }

    public Status Status { get; set; }
    public DateTime? created_at { get; set; }

}