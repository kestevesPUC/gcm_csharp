using System.Security.Cryptography;
using System.Text;

public class Util
{
    public static DateTime DateTimeNow(){
        return DateTime.UtcNow;
    }   

    public static string GerarHashSenha(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytes = Encoding.UTF8.GetBytes(senha);
        byte[] hash = sha256.ComputeHash(bytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
    }
}