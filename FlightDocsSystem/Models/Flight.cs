namespace FlightDocsSystem.Models;

public class Flight
{
    public int FlightId { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}