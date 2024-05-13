using DocumentManagementService.Models;

namespace DocumentManagementService.Services;

public interface IDocumentService
{
    public Task<Flight> AddFlight(Flight flight);
    //public Task<Flight> DetailFlight(int id);
    //public Task<Flight> UpdateFlight(int int);
}