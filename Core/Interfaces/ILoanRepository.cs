using Core.Entities;

namespace Core.Interfaces;

public interface ILoanRepository
{
    Task AddLoanAsync(Loan loan);
    Task SaveChangesAsync();
    Task<Loan> GetLoanByAccountNumber(string accountNumber);
}