namespace Core.Entities;

public class Customer
{
    public int ID { get; set; }
    public int OrderNumber { get; set; }
    public int BranchID { get; set; }
    public string Passport { get; set; }
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string  Gender { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public string GetFormattedBirthDate()
    {
        return BirthDate.ToString("dd.MM.yyyy");
    }

    public void SetBirthDate(string birthDateString)
    {
        BirthDate = DateTime.SpecifyKind(DateTime.ParseExact(birthDateString, "dd.MM.yyyy", null),
            DateTimeKind.Utc);
    }

    public void AddLoan(Loan loan)
    {
        loan.CustomerId = ID;
        Loans.Add(loan);
    }
    
}

public class CreateCustomerRequest
{
    public List<CustomerData> CreateCustomer { get; set; }
}

public class CustomerData
{
    public string OrderNumber { get; set; }
    public string BranchId { get; set; }
    public string Passport { get; set; }
    public string DateOfBirth { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymics { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
}