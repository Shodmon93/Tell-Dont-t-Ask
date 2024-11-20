namespace Core.Entities;

public class LoanBalance
{
    public string Principal { get; set; }
    public string Interest { get; set; }
    public string Penalty { get; set; }
    public string Total { get; set; }
}

public class LoanBalanceRequest
{
    public string AccountNumber { get; set; }
}

public class LoanBalanceResponse
{
    public LoanBalance LoanBalance { get; set; }
}