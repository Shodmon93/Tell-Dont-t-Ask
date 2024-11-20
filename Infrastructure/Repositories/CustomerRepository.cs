using Core;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataBridgeDbContext _context;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(ILogger<CustomerRepository> logger, DataBridgeDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customer.FindAsync(id);
    }

    public async Task<Customer> GetCustomerByDetailsAsync(string passport)
    {
        return await _context.Customer.FirstOrDefaultAsync(u =>
            u.Passport == passport);
        
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _context.Customer.AddAsync(customer);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}