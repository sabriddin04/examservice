using Domain.Enums;

namespace Domain.Models;

public class CustomerForAdding
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Gender Gender { get; set; }
          
   
}
