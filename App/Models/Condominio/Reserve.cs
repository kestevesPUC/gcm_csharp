using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinhaApi;

[Table("reserve", Schema = "condominium")]
public class Reserve
{
    [Key]
    public int id { get; set; }
    public DateTime? date_start { get; set; }
    public DateTime? date_end { get; set; }
    public DateTime? created_at { get; set; }
    public Area area { get; set; }
    [Column("area_id")]
    public int areaId { get; set; }
    public User user { get; set; }
    [Column("user_id")]
    public int userId { get; set; }

}