using Domain.Enums;

namespace Domain.Models;

public class AccountManagment
{

   public int AccountManagmentId { get; set; }
  
   public Int64 AccountNumber { get; set; }

   public AccountTypes AccountType { get; set; }

  public decimal Balance { get; set; }

  public int CustomerManagmentId { get; set; }

}
