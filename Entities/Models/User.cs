namespace AuthorizationAndAuthentication.Entities.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public IList<UserRole> Roles { get; set; }

    public User()
    {
        this.Roles = new List<UserRole>();

    }
}
