using Microsoft.EntityFrameworkCore;
namespace DocumentManagementService.Models;

public class DocumentDbContext: DbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options) : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>()
            .HasOne(d => d.Flight)
            .WithMany(f => f.Documents)
            .HasForeignKey(d => d.FlightID);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.CreatedByUser)
            .WithMany()
            .HasForeignKey(d => d.CreatedBy);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.UpdatedByUser)
            .WithMany()
            .HasForeignKey(d => d.UpdatedBy);
    }
}