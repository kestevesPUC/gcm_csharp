using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TypeUser
{
    [Key]
    public int id { get; set; }
    public string description { get; set; }
}