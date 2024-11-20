using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly DataBridgeDbContext _context;
    private readonly ILogger<LoanRepository> _logger;

    public LoanRepository(DataBridgeDbContext context, ILogger<LoanRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddLoanAsync(Loan loan)
    {
        await _context.Loan.AddAsync(loan);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Loan> GetLoanByAccountNumber(string accountNumber)
    {
        var account = int.Parse(accountNumber);
        return await _context.Loan.FirstOrDefaultAsync(loan => loan.OrderNumber == account);
    }
}