namespace FlightDocsSystem.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    public virtual ICollection<Document> CreatedDocuments { get; set; } = new List<Document>();
    public virtual ICollection<Document> UpdatedDocuments { get; set; } = new List<Document>();
    public virtual ICollection<DocumentPermission> DocumentPermissions { get; set; } = new List<DocumentPermission>();
}