using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using MinhaApi;


[Table("vehicle", Schema = "vehicle")]
public class Vehicle {
    [Key]
    public int id { get; set; }
    public Type type { get; set; }
    public Model model { get; set; }
    public Mark mark { get; set; }
    public MinhaApi.Color color { get; set; }
    public string plate { get; set; }
    
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}
