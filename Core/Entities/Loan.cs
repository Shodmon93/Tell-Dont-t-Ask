namespace Core.Entities;

public class Loan
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public int BranchId { get; set; }
    public int ServiceId { get; set; }
    public string Passport { get; set; }
    public decimal CreditAmount { get; set; }
    public int LoanTerm { get; set; }
    public int CustomerId { get; set; }
    // Navigation property
    public Customer Customer { get; set; }

    public LoanBalance GetLoanBalance()
    {
        var principle = CreditAmount;
        var interest = principle * 0.05m;
        var penalty = 200m;
        var total = principle + interest + penalty;
        return new LoanBalance
        {
            Principal = principle.ToString(),
            Interest = interest.ToString(),
            Penalty = penalty.ToString(),
            Total = total.ToString()
        };
    }
}

public class CreateLoanRequest
{
    public List<LoanData> CreateLoan { get; set; }
}

public class LoanData
{
    public string OrderNumber { get; set; }
    public string BranchId { get; set; }
    public string ServiceId { get; set; }
    public string Passport { get; set; }
    public string CreditAmount { get; set; }
    public string LoanTerm { get; set; }
}

