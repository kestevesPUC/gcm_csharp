using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi;

public class User
{
    [Key]
    public int id { get; set; }
    [Column("name")]
    public string name { get; set;}
    public string email { get; set;}
    public int apartment_id { get; set;}
    public int type_id { get; set;}
    public bool active { get; set;}
    public DateTime created_at { get; set; }
}
