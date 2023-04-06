namespace AuthorizationAndAuthentication.Entities.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<UserRole> Users { get; set; }
}