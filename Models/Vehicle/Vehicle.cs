using System.ComponentModel.DataAnnotations;

public class Vehicle {
    [Key]
    public int id { get; set; }
    public int type_id { get; set; }
    public string model { get; set; }
    public string mark { get; set; }
    public string color { get; set; }
    public string plate { get; set; }
}
/*




*/