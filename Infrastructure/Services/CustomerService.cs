using Core;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> CreateOrGateUserId(CreateCustomerRequest request)
    {
        foreach (var data in request.CreateCustomer)
        {
            var birthDate = DateTime.SpecifyKind(DateTime
                .ParseExact(data.DateOfBirth, "dd.MM.yyyy", null), DateTimeKind.Utc).Date;
            var existingCustomer = await _customerRepository
                .GetCustomerByDetailsAsync(data.Passport);
            if (existingCustomer != null)
            {
                return existingCustomer.ID;
            }

            var newCustomer = new Customer
            {
                OrderNumber = int.Parse(data.OrderNumber),
                BranchID = int.Parse(data.BranchId),
                Passport = data.Passport,
                FirstName = data.Name,
                LastName = data.Surname,
                MiddleName = data.Patronymics,
                Address = data.Address,
                PhoneNumber = data.PhoneNumber,
                Gender = data.Gender,

            };
            newCustomer.SetBirthDate(data.DateOfBirth);
            await _customerRepository.AddCustomerAsync(newCustomer);
            await _customerRepository.SaveChangesAsync();
            return newCustomer.ID;
        }

        return -1;
    }
    
}