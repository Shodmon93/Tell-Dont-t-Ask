using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class LoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly ICustomerRepository _customerRepository;

    public LoanService(ICustomerRepository customerRepository, ILoanRepository loanRepository)
    {
        _customerRepository = customerRepository;
        _loanRepository = loanRepository;
    }

    public async Task<LoanBalanceResponse> GetLoanBalance(LoanBalanceRequest request)
    {
        var loan = await _loanRepository.GetLoanByAccountNumber(request.AccountNumber);
        if (loan == null)
        {
            return new LoanBalanceResponse();
        }

        var balance = loan.GetLoanBalance();
        var response = new LoanBalanceResponse
        {
            LoanBalance = balance
        };
        return response;
    }
    
    public async Task<int> CreateLoan(CreateLoanRequest request)
    {
        foreach (var loanData in request.CreateLoan)
        {
            var existingCustomer = await _customerRepository.GetCustomerByDetailsAsync(loanData.Passport);
            if (existingCustomer == null)
            {
                return -1;
            }

            var loan = new Loan
            {
                OrderNumber = int.Parse(loanData.OrderNumber),
                BranchId = int.Parse(loanData.BranchId),
                ServiceId = int.Parse(loanData.ServiceId),
                Passport = loanData.Passport,
                CreditAmount = decimal.Parse(loanData.CreditAmount),
                LoanTerm = int.Parse(loanData.LoanTerm)
            };
            
            existingCustomer.AddLoan(loan);
            await _loanRepository.AddLoanAsync(loan);
            await _loanRepository.SaveChangesAsync();
            return loan.Id;
        }

        return -1;
    }
    
}