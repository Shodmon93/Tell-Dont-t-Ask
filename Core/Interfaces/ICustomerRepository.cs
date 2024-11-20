using Core.Entities;

namespace Core.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> GetCustomerByDetailsAsync(string passport);
    Task AddCustomerAsync(Customer customer);
    Task SaveChangesAsync();
}