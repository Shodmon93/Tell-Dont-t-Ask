using Core;
using Core.Interfaces;

namespace Infrastructure.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> CreateOrGateUserId(CreateCustomerRequest request)
    {
        foreach (var data in request.CreateCustomer)
        {
            var birthDate = DateTime.SpecifyKind(DateTime
                .ParseExact(data.DateOfBirth, "dd.MM.yyyy", null).ToUniversalTime(),DateTimeKind.Utc).Date;
            var existingUser = await _userRepository
                .GetUserByDetailsAsync(data.Passport, data.Name, birthDate);
            if (existingUser != null)
            {
                return existingUser.ID;
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
            await _userRepository.AddUserAsync(newCustomer);
            await _userRepository.SaveChangesAsync();
            return newCustomer.ID;
        }

        return -1;
    }
    
}