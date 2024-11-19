using Core;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBridgeDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ILogger<UserRepository> logger, DataBridgeDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<Customer> GetUserByIdAsync(int id)
    {
        return await _context.Customer.FindAsync(id);
    }

    public async Task<Customer> GetUserByDetailsAsync(string passport, string firstName, DateTime birthdate)
    {
        return await _context.Customer.FirstOrDefaultAsync(u =>
            u.Passport == passport && u.FirstName == firstName && u.BirthDate.Date == birthdate.Date);
        
    }

    public async Task AddUserAsync(Customer customer)
    {
        await _context.Customer.AddAsync(customer);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}