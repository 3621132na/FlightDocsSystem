using DocumentManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagementService.Services;

public class DocumentService:IDocumentService
{
    private readonly DocumentDbContext _dbContext;
    private readonly IConfiguration _configuration;
    public DocumentService(DocumentDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }
    public Task<Flight> AddFlight(Flight flight)
    {
        var flight=_dbContext.Flights.FirstOrDefaultAsync()
    }
}