namespace Domain.Models;

public class CustomerAccounts
{
    public CustomerManagment? Customer { get; set; }

    public List<AccountManagment>? Accounts { get; set; }
}
