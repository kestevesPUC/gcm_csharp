using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using MinhaApi;


[Table("vehicle", Schema = "vehicle")]
public class Vehicle
{
    [Key, Column("id")]
    public int Id { get; set; }
    // public int type { get; set; }
    // public int model { get; set; }
    // public int brand { get; set; }
    // public int color { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    public User User { get; set; }

    
    [Column("photo")]
    public string? Photo { get; set; } 

    [Column("type_id")]
    public int TypeId { get; set; }
    public TypeVehicle Type { get; set; }


    [Column("model_id")]
    public int ModelId { get; set; }
    public Model Model { get; set; }


    [Column("brand_id")]
    public int BrandId { get; set; }
    public Brand Brand { get; set; }


    [Column("color_id")]
    public int ColorId { get; set; }
    public MinhaApi.Color Color { get; set; }

    [Column("plate")]
    public string Plate { get; set; }
    [Column("year")]
    public int? Year { get; set; }
    [Column("vaga")]
    public int? Vaga { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}
