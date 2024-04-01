using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IAccountManagmentService
{

    Task<List<AccountManagment>> GetAccountManagments();
    Task<string> AddAccountManagment(AccountManagment accountManagment);
    Task<string> UpdateAccountManagments(AccountManagment accountManagment);
    Task<string> DeleteAccountManagments(int id);
}

