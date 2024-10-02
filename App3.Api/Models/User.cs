namespace App3.Api.Models;

public class User {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Type Type { get; set; }
}

public enum Type {
    Admin,
    Elev,
    Underviser
}
