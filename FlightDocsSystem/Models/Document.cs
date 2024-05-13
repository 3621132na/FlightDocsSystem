namespace FlightDocsSystem.Models;

public class Document
{
    public int DocumentId { get; set; }
    public int FlightId { get; set; }
    public string DocumentType { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsConfirmed { get; set; }

    public virtual User CreatedByUser { get; set; }
    public virtual User UpdatedByUser { get; set; }
    public virtual Flight Flight { get; set; }
    public virtual ICollection<DocumentPermission> Permissions { get; set; } = new List<DocumentPermission>();
}