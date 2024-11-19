using Core;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}