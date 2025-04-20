using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_user", Schema = "user")]
public class TypeUser
{
    [Key]
    public int id { get; set; }
    public string description { get; set; }
}