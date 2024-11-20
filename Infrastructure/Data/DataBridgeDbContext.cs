using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class DataBridgeDbContext : DbContext
{
    private readonly ILogger<DataBridgeDbContext> _logger;

    public DataBridgeDbContext(DbContextOptions<DataBridgeDbContext> options, ILogger<DataBridgeDbContext> logger) 
        : base(options)
    {
        _logger = logger;
        _logger.LogInformation("Database Initialized");
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Loan> Loan { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property(c => c.BirthDate).HasColumnType("DATE");
        base.OnModelCreating(modelBuilder);
        
    }
}