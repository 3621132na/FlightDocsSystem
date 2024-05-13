namespace DocumentManagementService.Models;

public class Flight
{
    public int FlightID { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public ICollection<Document> Documents { get; set; }
}