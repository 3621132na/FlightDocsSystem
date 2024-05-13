using Microsoft.EntityFrameworkCore;

namespace FlightDocsSystem.Models;

public class FlightDocsSystemDbContext: DbContext
{
    public FlightDocsSystemDbContext(DbContextOptions<FlightDocsSystemDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentPermission> DocumentPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));
        modelBuilder.Entity<Document>()
            .HasOne(d => d.CreatedByUser)
            .WithMany(u => u.CreatedDocuments)
            .HasForeignKey(d => d.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Document>()
            .HasOne(d => d.UpdatedByUser)
            .WithMany(u => u.UpdatedDocuments)
            .HasForeignKey(d => d.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Document>()
            .HasOne(d => d.Flight)
            .WithMany(f => f.Documents)
            .HasForeignKey(d => d.FlightId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<DocumentPermission>()
            .HasKey(dp => new { dp.UserId, dp.DocumentId });
        modelBuilder.Entity<DocumentPermission>()
            .HasOne(dp => dp.User)
            .WithMany(u => u.DocumentPermissions)
            .HasForeignKey(dp => dp.UserId);
        modelBuilder.Entity<DocumentPermission>()
            .HasOne(dp => dp.Document)
            .WithMany(d => d.Permissions)
            .HasForeignKey(dp => dp.DocumentId);
    }
}