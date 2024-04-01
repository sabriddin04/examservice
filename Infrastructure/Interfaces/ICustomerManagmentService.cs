using Domain.Enums;
using Domain.Models;

namespace Infrastructure.Services;

public interface ICustomerManagmentService
{
    public Task<List<CustomerManagment>> GetCustomerManagment();
    public Task<string> AddCustomerManagment(CustomerForAdding customerManagment);
    public Task<string> UpdateCustomerManagment(CustomerManagment customer);
    public Task<string> DeleteCustomerManagment(int id);

    public Task<List<CustomerManagment>> GetCustomersByGender(Gender gender);

    public Task<List<CustomerManagment>> GetCustomerManagmentsByAddress(string address);

    public Task<CustomerAccounts>GetCustomerAccounts(int id);


}
