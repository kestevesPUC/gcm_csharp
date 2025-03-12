namespace MinhaApi;

public class User
{
    public int id { get; set; }
    public string name { get; set;}
    public string email { get; set;}
    public int apartment_id { get; set;}
    public int type_id { get; set;}
    public bool active { get; set;}
    public DateTime created_at { get; set; }
}
