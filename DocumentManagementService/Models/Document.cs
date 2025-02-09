using UserManagementService.Models;

namespace DocumentManagementService.Models;

public class Document
{
    public int DocumentID { get; set; }
    public int FlightID { get; set; }
    public string DocumentType { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsConfirmed { get; set; }
    public Flight Flight { get; set; }
    public User CreatedByUser { get; set; }
    public User UpdatedByUser { get; set; }
}