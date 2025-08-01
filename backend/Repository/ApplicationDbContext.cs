using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
            => Database.EnsureCreated();

    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<Balance> Balances { get; set; } = null!;

    public DbSet<IncomingDocument> IncomingDocuments { get; set; } = null!;

    public DbSet<IncomingResouce> IncomingResouces { get; set; } = null!;

    public DbSet<Measure> Measures { get; set; } = null!;

    public DbSet<OutgoingDocument> OutgoingDocuments { get; set; } = null!;

    public DbSet<OutgoingResource> OutgoingResources { get; set; } = null!;

    public DbSet<Resource> Resources { get; set; } = null!;
}