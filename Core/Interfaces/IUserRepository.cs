namespace Core.Interfaces;

public interface IUserRepository
{
    Task<Customer> GetUserByIdAsync(int id);
    Task<Customer> GetUserByDetailsAsync(string passport, string firstName, DateTime birthdate);
    Task AddUserAsync(Customer customer);
    Task SaveChangesAsync();
}