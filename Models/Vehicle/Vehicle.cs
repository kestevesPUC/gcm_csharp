using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using MinhaApi;


[Table("vehicle", Schema = "vehicle")]
public class Vehicle
{
    [Key]
    public int id { get; set; }
    // public int type { get; set; }
    // public int model { get; set; }
    // public int brand { get; set; }
    // public int color { get; set; }
    [ForeignKey("user_id")]
    public User user { get; set; }
    [ForeignKey("type_id")]
    public TypeVehicle type { get; set; }
    [ForeignKey("model_id")]
    public Model model { get; set; }
    [ForeignKey("brand_id")]
    public Brand brand { get; set; }
    [ForeignKey("color_id")]
    public MinhaApi.Color color { get; set; }
    public string plate { get; set; }

    public DateTime created_at { get; set; } = DateTime.UtcNow;
}
