namespace FlightDocsSystem.Models;

public class DocumentPermission
{
    public int UserId { get; set; }
    public int DocumentId { get; set; }
    public bool CanView { get; set; }
    public bool CanEdit { get; set; }
    public bool CanConfirm { get; set; }

    public virtual User User { get; set; }
    public virtual Document Document { get; set; }
}