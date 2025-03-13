using System.ComponentModel.DataAnnotations;

public class TypeVehicle
{
    [Key]
    public int id { get; set; }
    public string description { get; set; }
}